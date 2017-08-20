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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Fusion8Design.Cropper
{
	/// <summary>
	/// Class for saving the captures.
	/// </summary>
	internal class CaptureOutput : IDisposable
	{
		private Image _outputImage;
		private bool _isDisposed = false;
		private string _className = "CaptureOutput";

 
		#region ctor

		internal CaptureOutput(Image image)
		{
			_outputImage = image;
		}

		#endregion

        #region Image Saving

        internal void SaveToClipboard()
        {
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

            Clipboard.SetDataObject(_outputImage, true);
        }

        internal void SaveToFile(string format, double maxThumbSize, bool thumbnail)
        {
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

			Image thumbnailImage = null;
			string[] fileNames = GetFileNames("_Thumbnail", format);
			try
			{
				SaveToFile(_outputImage, format, fileNames[0]);
				if(thumbnail)
				{
					thumbnailImage = GetThumbnail(_outputImage, maxThumbSize);
					SaveToFile(thumbnailImage, format, fileNames[1]);
				}
			}
			finally
			{
				if(null != thumbnailImage)
					thumbnailImage.Dispose();
			}
        }

        internal void SaveJpegImage(Image image, Stream stream, long quality)
        {
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

            const string ENCODER_TYPE = "image/jpeg";

            ImageCodecInfo myImageCodecInfo = null;
            Encoder myEncoder = null;
            EncoderParameter myEncoderParameter = null;
            EncoderParameters myEncoderParameters = null;

            myImageCodecInfo = GetEncoderInfo(ENCODER_TYPE);
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            try
            {
                image.Save (stream, myImageCodecInfo, myEncoderParameters);
            }
            finally
            {
                image = null;
				myEncoderParameters.Dispose();
				myEncoderParameter.Dispose();
            }
        }

        internal ImageCodecInfo GetEncoderInfo(String mimeType)
        {
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

		private void SaveToFile(Image image, string format, string fileName)
		{
			//TODO: Something different
			long imageQuality = 100;
			try
			{
				imageQuality = long.Parse(format);
				format = "Jpeg";
			}
			catch (FormatException){}			

			FileStream stream = null;
			using (stream = 
				new FileStream(fileName, 
				FileMode.Create, 
				FileAccess.Write, 
				FileShare.Write))
			{

				switch (format)
				{
					case "Bmp":
						image.Save(stream, ImageFormat.Bmp);
						break;
					case "Png":
						image.Save(stream, ImageFormat.Png);  
						break;  
					default:
						SaveJpegImage(image, stream, imageQuality);  
						break;   
				}  
			}
		}

		private string[] GetFileNames(string fileNamePrefix, string format)
		{
			string folder =  ResolveOutputDirectory();           
			string fileNameWithoutExtension = folder + @"\Cropper Capture";	
			
			//TODO: Use a regular expression for this.
			try
			{
				long imageQuality = long.Parse(format);
				format = "Jpeg";
			}
			catch(FormatException){}

			//TODO:  There has to be an easier way of saving incrementing numbered file names.
			string fileName = fileNameWithoutExtension + "[1]." + format.ToLower();
			string fileNamePrefixed = fileNameWithoutExtension + "[1]" + fileNamePrefix + "." + format.ToLower();
			if(File.Exists(fileName))
			{
				int i = 2;
				while(true)
				{
					fileName = fileNameWithoutExtension + "[" + i + "]." + format.ToLower();
					fileNamePrefixed = fileNameWithoutExtension + "[" + i + "]" + fileNamePrefix + "." + format.ToLower();
					if(!File.Exists(fileName))
						break;   
					i++;
				}
			}	
			string[] fileNames = {fileName, fileNamePrefixed};
			return fileNames;
		}

		private string ResolveOutputDirectory()
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Cropper";
			new DirectoryInfo(directory).Create();
			return directory;
		}

		private Image GetThumbnail(Image image, double maxSize)
		{
			if(image != null)
			{
				double ratio;
				if(image.Height > image.Width)
					ratio = image.Height / maxSize;
				else
					ratio = image.Width / maxSize;
				int newWidth = Convert.ToInt32(image.Width/ratio);
				int newHeight = Convert.ToInt32(image.Height/ratio);

				IntPtr ip = new IntPtr();
				Image.GetThumbnailImageAbort imageAbort = new
					Image.GetThumbnailImageAbort(AbortThumb);

				return image.GetThumbnailImage(newWidth, newHeight, imageAbort, ip);
			}		
			else
			{
				return null;
			}
		}

		//Never called in this version of GDI+, but needed.
		//
		private bool AbortThumb()
		{
			return false;
		}

        #endregion

		#region Image Printing
		
		internal void Print()
		{
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

			PrintDialog printDialog = new PrintDialog();
			PrintDocument printImage = new PrintDocument();

			printImage.DocumentName = "Cropper Captured Image";
			printImage.PrintPage += new PrintPageEventHandler(OnPrintPage);

			printDialog.Document = printImage;

			DialogResult result = printDialog.ShowDialog();

			// Send print message
			try
			{
				if (result==DialogResult.OK)
					printImage.Print();
			}
			catch(InvalidPrinterException)
			{				
				ShowPrintError();
			}
			finally
			{
				printImage.Dispose();
				printDialog.Dispose();
			}
		}

		// Print Event Handler
		//
		internal void OnPrintPage(object sender, PrintPageEventArgs ppea)
		{
			if (_isDisposed)
				throw new ObjectDisposedException(_className);

			try
			{
				PrintDocument document = (PrintDocument)sender;
				SizeF imageInches = CalculateSizeInInches(_outputImage);
				PointF originInches = CalculateOriginInInches(imageInches, document);
				ppea.Graphics.DrawImage(_outputImage, originInches.X, originInches.Y);
			}
			catch (InvalidPrinterException)
			{
				ShowPrintError();
			}
		}

		private void ShowPrintError()
		{
			MessageBox.Show(
				"There was a problem printing the image.  Please verify you are able to connect to the printer if it is on a network share.", 
				"Printing Problem", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information);
		}

		private SizeF CalculateSizeInInches(Image image)
		{
			return new SizeF(
				image.Width / image.VerticalResolution,
				image.Height / image.HorizontalResolution);
		}

		private PointF CalculateOriginInInches(SizeF sizesInInches, PrintDocument document)
		{
			PointF point = new PointF();
			point.X = (((document.DefaultPageSettings.Bounds.Width / 100) - sizesInInches.Width) / 2) * _outputImage.HorizontalResolution;
			point.Y = (((document.DefaultPageSettings.Bounds.Height / 100) - sizesInInches.Height) / 2) * _outputImage.VerticalResolution;
			return point;
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if(!this._isDisposed)
			{
				if (disposing)
				{
					// Dispose managed resources.
					//
				}

				// Release unmanaged resources. If disposing is false, 
				// only the following code is executed.
				//
				if(null != _outputImage)
					_outputImage.Dispose();	
				 
			}
			this._isDisposed = true;
		}

		#endregion

		~CaptureOutput()
		{
			Dispose(false);
		}
	}
}




















