using System;
using System.Text;
using cSoundProj;

namespace cSoundProjtest
{
	/// <summary>
	/// Test cSoundProj class
	/// </summary>
	class Class1 {
		static void Main(string[] args) {
			string inkey="z";
			//csSound cs = new csSound("C:\\Documents and Settings\\Kenton\\My Documents\\Programming\\Visual Studio Projects\\SpanishFlash\\");  // add back-slashes to the working directory
			csSound cs = new csSound("C:\\");
			string sfName="testFile123.wav";

			while (inkey != "") {
				Console.WriteLine("m<playMP3 k<killMP3 p<playMCI s<stopMCI f<file-play r<record t<terminateRecord\n z<record2 c<convertWAV-MP3 v<volumn");
				inkey=Console.ReadLine();
				if (inkey == "a") {
					cs.mciRecordAbort();
				}
				if (inkey == "f") {
					cs.sndPlayS(sfName);
				}
				if (inkey == "v") {
					Console.WriteLine("Enter Volumn 0-255");
					inkey=Console.ReadLine();
					int vol=Convert.ToInt32(inkey.ToString());
					cs.mciSetVolume(vol,vol);
									
				}
				if (inkey == "m") {
					Console.WriteLine("Play MP3");				
					cs.StopMp3Thread();				
					cs.PlayMp3InThread(sfName.Replace(".wav",".mp3"));
				}

				//if (inkey == "z") {  // this is not working yet
				//	Console.WriteLine("Record with parameters");
				//	cs.mciRecordparm(sfName);						
				//}
								
				if (inkey == "k") {								
					Console.WriteLine("Terminate MP3 Thread");
					Console.WriteLine(sfName);
					cs.StopMp3Thread();
				}
				if (inkey == "p") {
					bool waitFlag = true;
					Console.WriteLine("Play Wave file using MCI");
					cs.mciWaveLoad(sfName);
					cs.mciWavePlay(waitFlag);  // if you change this to false then comment out the next line- you have to close the file with the s command
					if (waitFlag == true) {
						cs.mciWaveClose();
					} else {
						Console.WriteLine("not waiting: Press 's' and Enter to close the wave file");
					}
				}
				if (inkey == "s") {
					Console.WriteLine("Stop and Close MCI");
					cs.mciWaveClose();
				}
				if (inkey == "r") {
					Console.WriteLine("Recording... (type 't' to stop recording");
					cs.mciRecord(16,2,44100);  // test with frequency 44100 and 22050, 16 and 8 bit 1 and 2 channel
				}
				if (inkey == "t") {
					cs.mciWaveSave(sfName);
				}
				if (inkey == "c") {
					cs.StopMp3Thread();
					cs.mciConvertWavMP3(sfName,false);					
				}
			} // end while
		}
	}
}
