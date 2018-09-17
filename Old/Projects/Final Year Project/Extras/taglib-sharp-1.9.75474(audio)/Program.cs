using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;

//Title ,artist,album, year, genre, composer, track



namespace TestTagLib
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TagLib.File file = TagLib.File.Create(@"D:\test.ogg");
				TagLib.Tag tags = file.Tag;

				// Read some information.
				var title =tags.Title;
				var artists = tags.Artists; // Remember, each song can have more than one artist.
				var album = tags.Album;
				var genres = tags.Genres;
				var year = tags.Year;
				var track = tags.Track;

				var composer = tags.Composers;

				Console.WriteLine("title : "+title);
				Console.Write("Atrists : ");
				foreach(string s in artists)
					Console.Write(s+", ");
				Console.WriteLine("\nAlbum : " + album);
				Console.Write("Genres : ");
				foreach (string s in genres)
					Console.Write(s + ", ");
				Console.WriteLine("\nYear : " + year);
				Console.WriteLine("Track : " + track);
				Console.Write("Composers : ");
				foreach (string s in composer)
					Console.Write(s + ", ");
			}
			catch(Exception e) { Console.WriteLine(e); }
		}
	}
}


// Do stuff to title, album, artists.

//// Store that information in the tag.
//file.Tag.Title = title;
//file.Tag.Track = track;
//file.Tag.Album = album;
//file.Tag.Artists = artists;

//file.Save();

