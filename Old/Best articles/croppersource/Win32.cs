/**********************************************************************************
Shared Source License for Cropper in C#
Copyright 2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#region Using Directives

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Fusion8Design.Win32
{
	/// <summary>
	/// Class for getting images of the desktop.
	/// </summary>
    /// <threadsafety static="false" instance="false"/>
	/// <note type="caution">This class is not thread safe.</note> 
	/// <remarks>This class has been scaled back to the essentials for capturing a segment of 
	/// the desktop in order to keep Cropper as small as possible.</remarks>
	internal class Desktop
	{
        private const int SRCCOPY = 0x00CC0020;

        #region Dll Imports

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=false)]
		static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=false)]
		private static extern IntPtr GetWindowDC(IntPtr hwnd);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=false)]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
	
		[DllImport("gdi32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=false)]
		private static extern UInt64 BitBlt
			   (IntPtr hDestDC, int x, int y, int nWidth, int nHeight,
	            IntPtr hSrcDC, int xSrc, int ySrc, System.Int32 dwRop);

        #endregion

		private Desktop(){}

        /// <summary>
        /// Gets a segment of the desktop as an image.
        /// </summary>
        /// <param name="x">Starting point X coordinate.</param>
        /// <param name="y">Starting point Y coordinate.</param>
        /// <param name="width">The width of the area to capture.</param>
        /// <param name="height">The height of the area to capture.</param>
        /// <returns>A <see cref="System.Drawing.Image"/> containg an image of the desktop 
        /// at the specified coordinates</returns>
        internal static Image GetBitmap(int x, int y, int width, int height)
        {
			Graphics desktopGraphics;
			Image desktopImage;
			Graphics drawGraphics;
			Image drawImage;
            Rectangle virtualScreen = SystemInformation.VirtualScreen;

            //Create the image and graphics to capture the desktop.
			//
			using(desktopImage = new Bitmap(virtualScreen.Width, virtualScreen.Height))
			{
				using(desktopGraphics = Graphics.FromImage(desktopImage))
				{
					//Pointers for window handles
					//
					IntPtr ptrDesktop = desktopGraphics.GetHdc();
					IntPtr ptrDesktopWindow = GetDesktopWindow();
					IntPtr ptrWindowDC = GetWindowDC(ptrDesktopWindow);

					//Grap the entire virtual desktop
					//
					BitBlt(ptrDesktop, 
						0, 
						0, 
						virtualScreen.Width, 
						virtualScreen.Height, 
						ptrWindowDC, 
						virtualScreen.X, 
						virtualScreen.Y, 
						SRCCOPY);

					//Release and dispose the graphics object so we have an image to work with.
					//
					ReleaseDC(ptrDesktopWindow, ptrWindowDC);
					desktopGraphics.ReleaseHdc(ptrDesktop);
					
					//Set pointers to zero.
					//
					ptrDesktop = IntPtr.Zero;
					ptrDesktopWindow = IntPtr.Zero;
					ptrWindowDC = IntPtr.Zero;
				}

				//Create a new image and graphics object the size we want so we can 'crop' it out of the desktop.
				//
				drawImage = new Bitmap(width, height);
				using(drawGraphics = Graphics.FromImage(drawImage))
				{
					//Draw the area of the desktop we want into the new image.
					//
					drawGraphics.DrawImage(
						desktopImage,
						new Rectangle(new Point(0,0), new Size(width, height)), 
						new Rectangle((virtualScreen.X - x) *-1, (virtualScreen.Y - y) *-1, width, height),
						GraphicsUnit.Pixel);

				}
			}

            //Return a referance to our image.  
			//Don't forget to dispose it in the client code when finished.
			//You will have memory leaks if not.
			//
            return drawImage;
		}
	}
}

