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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Fusion8Design.Cropper
{
    [Serializable]
    internal sealed class Configuration
    {
        #region Member Variables

        private string _imageFormat = "Bmp";
        private double _userOpacity = 0.40d;
		private double _maxThumbnailSize = 80d;
        private Size[] _userSizes = {new Size(300, 300)};
		private Point  _location;
		private string _configPath;

        #endregion

        #region ctor

        internal Configuration()
		{
			_configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Cropper";
			if (!Directory.Exists(_configPath)) 
			{
				Directory.CreateDirectory(_configPath);
			}
			_configPath += @"\cropper.cpr"; 
		}

		internal Configuration(
			string imageFormat, 
			double userOpacity, 
			double maxThumbnailSize, 
			Point location, 
			params Size[] userSizes
			) : this()
		{
			_imageFormat = imageFormat;
			_userOpacity = userOpacity;
			_maxThumbnailSize = maxThumbnailSize;
			_userSizes = userSizes;
			_location = location;
		}

        #endregion

        #region Property Accessors


        /// <summary>
        /// The users last used image format.
        /// </summary>
        public string ImageFormat
        {
            get{return _imageFormat;}
        }

        /// <summary>
        /// The users last used opacity level.
        /// </summary>
        public double UserOpacity
        {
            get{return _userOpacity;}
        }

		/// <summary>
		/// The users last used thumbnail size.
		/// </summary>
		public double MaxThumbnailSize
		{
			get{return _maxThumbnailSize;}
		}

        /// <summary>
        /// The users last chosen window size.
        /// </summary>
        /// <remarks>This property is being expanded to allow the user to save a list of common
        /// used sizes. </remarks>
        public Size[] UserSizes
        {
            get{return _userSizes;}
        }

		/// <summary>
		/// The last location of the form.
		/// </summary>
		public Point Location
		{
			get{return _location;}
		}

        #endregion

		#region Methods
	
		/// <summary>
		/// Client exposed Load Method
		/// </summary>
		/// <returns>A <see cref="Configuration"/> object.</returns>
		internal Configuration Load()
		{
			return LoadConfiguration(_configPath);
		}
		/// <summary>
		/// Loads the configuration file.
		/// </summary>
		/// <remarks>The <see cref="Configuration"/> class is binary deserialized from disk.</remarks>
		/// <param name="path"></param>
		/// <returns></returns>
		private Configuration LoadConfiguration(string path) 
		{ 
			FileStream stream = null;
			object returnObject;
			try 
			{
				stream = new FileStream(_configPath, FileMode.Open); ;
				IFormatter formatter = new BinaryFormatter(); 
				returnObject = formatter.Deserialize(stream) as object; 				
			} 									
			catch (FileNotFoundException) 
			{
				//If there is no Configuration file, just return a new one.
				//
				return new Configuration(); 
			}
			catch (SerializationException)
			{
				//If the file can't be deserialized, just return a new one.
				return new Configuration();
			}
			catch (InvalidCastException)
			{
				//If the file can't be deserialized, just return a new one.
				return new Configuration();
			}
			finally
			{
				//Close stream in finally block to prevent memory leaks on errors.
				//
				if(null != stream)
					stream.Close(); 
			}

			return (Configuration)returnObject; 
		} 


		/// <summary>
		/// Client exposed save method.
		/// </summary>
		internal void Save()
		{
			SaveConfiguration(this, _configPath);
		}

		/// <summary>
		/// Save the configuration settings to a file.
		/// </summary>
		/// <remarks>The <see cref="Configuration"/> class is binary serialized to disk.</remarks>
		/// <param name="configuration">The configuration object to save.</param>
		/// <param name="path">The path where the file should be saved.</param>
		/// <returns>true if successful, false if not.</returns>
		private bool SaveConfiguration(Configuration configuration, string path) 
		{ 
			if(null == path)
				throw new ArgumentNullException("path", "The path to the configuration file can not be null.");

			bool result = false;

			FileStream stream = null;
			try 
			{                 
				stream = new FileStream(path, FileMode.Create);
				IFormatter formatter = new BinaryFormatter(); 
				formatter.Serialize(stream, configuration); 
				result = true; 
			} 																																																																																					 
			catch (IOException) 
			{ 
				//An error occured, let the client know.
				result = false; 
			} 
			finally
			{
				//Close stream in finally block to prevent memory leaks on errors.
				//
				if(null != stream)
					stream.Close(); 
			}

			return result;
		} 
		#endregion
    }
}
