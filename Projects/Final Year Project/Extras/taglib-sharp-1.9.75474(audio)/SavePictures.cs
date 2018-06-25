using System.IO;
using System;
public class SavePictures
{
	public static void Main (string [] args)
	{
		SavePics (TagLib.File.Create (args[0]));
	}

	private static void SavePics (TagLib.File file)
	{
		foreach (TagLib.IPicture pic in file.Tag.Pictures)
		{
			string ext = pic.MimeType.Substring (pic.MimeType.IndexOf ("/") + 1);  //jpeg , png
			string path = Path.GetDirectoryName(file.Name) + "\\"+Path.GetFileNameWithoutExtension(file.Name)+"."+ext; //image save path
			Stream stream = File.Open (path,FileMode.CreateNew);
			byte [] data = pic.Data.Data;
			stream.Write (data, 0, data.Length);
			stream.Close ();
		}
	}
}
