using System;
using System.Runtime.InteropServices;
using QuartzTypeLib;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Text;



/*
  	// assembled by Kenton Brown, kenton@crossroadmission.org but I got the info from various sources.
	// I decided to assemble this example after spending several hours searching
	// for this type of information for C#
	// remember that 'int, uint' in C# is the same length (32 bits, 4 bytes) as a 'long'
	// in visual basic, and DWORD or UINT in C++
	// credit given to C#HELP where I found the mp3 example
	// credit given to all the other places I found the winmm.lib info
	// visual C++ example http://www.cs.binghamton.edu/~reckert/360/11.html
	// http://support.microsoft.com/default.aspx?scid=kb;EN-US;q152180
	// kenton@crossroadmission.org
	// the end of the file has the lame.exe help file and info on converting types between languages
	// put the blade.exe in same directory as your test wave file to convert wav to mp3
	// first confirm your mic is working
	// code your project directory
	// record a wave file
	// in case you don't know @"c:\testdir\proj" is the same as "c:\\testdir\\proj"
	// to use this as is just jput the lame.exe program in the c:\ directory and record a wave
	// don't forget to hit t and enter to stop the recording
			
*/



namespace cSoundProj {
	/// <summary>
	/// Summary description for csSound.
	/// </summary>
	public class csSound {

		ushort WAVE_FORMAT_PCM = 1;
		//  flags for the dwFlags parameter of MCI_SET command message
		uint MCI_WAVE_SET_FORMATTAG = 0x10000;
		uint MCI_WAVE_SET_CHANNELS = 0x20000;
		uint MCI_WAVE_SET_SAMPLESPERSEC = 0x40000;
		uint MCI_WAVE_SET_AVGBYTESPERSEC = 0x80000;
		uint MCI_WAVE_SET_BLOCKALIGN = 0x100000;
		uint MCI_WAVE_SET_BITSPERSAMPLE = 0x200000;
		uint MCI_WAVE_INPUT = 0x400000;
		uint MCI_WAVE_OUTPUT = 0x800000;
		uint MMSYSERR_NOERROR = 0;
		uint MCI_SET = 0x80D;
		uint MCI_SETAUDIO=0x0873;
		uint MCI_WAIT = 0x2;  // this was &H2&

		
		private string pworkingDir;
		private string fichier; 
		private Thread MusicThread;
		/********* IMPORTANT  MUST DO THIS ************/
		/* I found this information and built on it from charphelp.com
			 * http://www.csharphelp.com/board/read.html?num=1&id=9025&loc=1&thread=9020
			 * 
			 * QuartzTypeLib has to be produced and then you have to add the reference to it
			 * under the visual studio Project menu - Add Reference
			 * to produce the library do the following
			 *  tlbimp c:\winnt\system32\quartz.dll 
			 * you will have to locate the tlbimp, it is not in a default path
			 * You should find it in C:\Program Files\Microsoft.NET\FrameworkSDK\Bin
			 * see http://hosting.msugs.ch/dotnetrox/cs/Ch12.html
			 * 
			*/
		private static QuartzTypeLib.IMediaControl mp3control;
		private static QuartzTypeLib.FilgraphManager graphManager;
		// there seems to be no difference between using int or uint
		// I have changed some to unit to try to get MCI_WAVE_SET_PARMS to work.
		// C++ uses DWORD and UINT for these parameters which means that uint should
		// be used for win32 programs.  (ie.  32 bit unsigned)
		// the C# long does not work as it is 64 bit.
		[DllImport ("winmm.dll")]		
		public static extern int PlaySound(String lpszName, int hModule, int dwFlags);
		[DllImport ("winmm.dll")]		
		public static extern int mciSendString(String s1, StringBuilder s2, int l1, int l2);
		[DllImport ("winmm.dll")]		
		public static extern int mciGetErrorString(int l1, StringBuilder s1, int l2);
		[DllImport ("winmm.dll")]		
		public static extern uint mciGetDeviceID (string lpstrName);
		[DllImport ("winmm.dll")]		
		public static extern int mciSendCommand (uint wDeviceID, uint uMessage,uint dwParam1, ref object dwParam2);
		[DllImport ("winmm.dll")]		
		public static extern int waveOutGetVolume (uint uDeviceID,int lpdwVolume );
		[DllImport ("winmm.dll")]	
		public static extern int waveOutSetVolume (uint uDeviceID,uint lpdwVolume );
		[DllImport ("winmm.dll")]	
		public static extern int sndPlaySound (StringBuilder lpszSoundName, uint uFlags);		
		public StringBuilder errorBuffer;
		public StringBuilder recordBuffer;
		private uint pvolLevel;
		
		[StructLayout(LayoutKind.Sequential)] // in docs for compatability with C++ type of struct
			struct MCI_WAVE_SET_PARMS {
			public uint dwCallback; 
			public uint dwTimeFormat; 
			public uint dwAudio; 
			public uint wInput; 
			public uint wOutput; 
			public ushort wFormatTag; //As Integer
			public ushort wReserved2; //As Integer
			public ushort nChannels; 
			public ushort wReserved3; //As Integer
			public uint nSamplesPerSec; 
			public uint nAvgBytesPerSec; 
			public ushort nBlockAlign; 
			public ushort wReserved4; 
			public ushort wBitsPerSample; 
			public ushort wReserved5; 
		}

		public csSound(string wdir) {
			
			pworkingDir=wdir;
			errorBuffer = new StringBuilder(128,128);
			recordBuffer = new StringBuilder(1024,1024);
			pvolLevel = 128;	
		}



		public static void PlayAMp3(string args) { 
			graphManager = new QuartzTypeLib.FilgraphManager(); 
			mp3control = (QuartzTypeLib.IMediaControl)graphManager; 
			mp3control.RenderFile(args); 
			mp3control.Run(); 
		}

		public void PlayMp3() { 
			if(fichier.Length>0) { 
				PlayAMp3(fichier); 
			} 
			//fichier=""; 
		} 

		public void PlayMp3InThread(string fileName) { 
			fichier = pworkingDir+fileName; 			
			MusicThread = new Thread(new ThreadStart(PlayMp3)); 
			MusicThread.Start(); 
			PlayMp3();
		}

		public void StopMp3Thread() {
			 if (mp3control != null) {
				mp3control.Stop();			
			 }
		}

		// ***************  MCI ************************
		// *********************************************
		// mciRecord buffer problem, sometimes you lose about 1 second of the end

		public void mciSetVolume(int VolumeL, int VolumeR) {
			int volOut = (VolumeL << 8)+VolumeR;
			string mciString = "open type waveaudio alias changevol";
			int err=mciSendString(mciString,recordBuffer,1024,0);
			this.pvolLevel=Convert.ToUInt32(volOut);
			uint wDeviceID = mciGetDeviceID("changevol"); //     'get the device ID that was opened above
			err=waveOutSetVolume(wDeviceID,this.pvolLevel);
			mciSendString("close changevol", errorBuffer, 128, 0);
		}

		
		// you need the lame.exe  http://www.mp3dev.org/mp3/ in the same directory as your pworkingDir, I am using lame.exe 3.91
		// but any version of the lame.exe should work.
		// LOOOOOOOOOOK  - you have to have the lame.exe file in your sound directory
		// for this to work as is
		//    BUG  -- Once you play the mp3 file you can not replace it until you quit the program
		// and restart.  The play routine locks the file.  You can go to a dos window, delete it, but it will
		// still show in the directory listing.  When you quit the program the file will no longer
		// show in your directory listing.  This behavior was not present at first but I have tried
		// to isolate the bug, and even went back to code that did not show this behavior but it still will
		// not copy over the mp3 file after you play the file once.  I have tried everything I know to
		// do to fix this.  Any help?  kenton@crossroadmission.org.  Here is the sequence that fails
		// record file, play mci, convert to mp3, plays ok, record another file, play mci, convert to mp3
		// will not overwrite the first file.  You have to quit the program, restart and then convert again.
		// http://www.webattack.com/get/lame.shtml

		public void mciConvertWavMP3(string fileName, bool waitFlag){  //maxLen is in ms (1000 = 1 second)
			string outfile= "-b 32 --resample 22.05 -m m \""+pworkingDir+fileName + "\" \"" + pworkingDir+fileName.Replace(".wav",".mp3")+"\"";
			System.Diagnostics.ProcessStartInfo psi=new System.Diagnostics.ProcessStartInfo();
			psi.FileName="\""+pworkingDir+"lame.exe"+"\"";
			psi.Arguments=outfile;
			//psi.WorkingDirectory=pworkingDir;
			psi.WindowStyle=System.Diagnostics.ProcessWindowStyle.Minimized;
			System.Diagnostics.Process p=System.Diagnostics.Process.Start(psi);
			if (waitFlag) {
				p.WaitForExit();  // wait for exit of called application			
			}
		}

		
		public void mciWaveLoad (string fileName) {
			string mciString = "open \""+pworkingDir+fileName+ "\" type waveaudio alias mciWave";
			int err=mciSendString(mciString,errorBuffer,128,0);
			if (err != 0) {								
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n3-MCI error: {0}",errorBuffer.ToString());
			}
		}

		public void mciRecord(int bitspersample, int channels, int samplespersec){  
			string mciString = "open new type waveaudio alias myvoice";
			int err=mciSendString(mciString,recordBuffer,1024,0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n4-MCI error: {0}",errorBuffer.ToString());
			}
			mciString="set myvoice bitspersample "+ bitspersample.ToString()+" channels "+channels.ToString()+" samplespersec "+samplespersec.ToString();
			err=mciSendString(mciString,errorBuffer,128,0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n5-MCI error: {0}",errorBuffer.ToString());
			}
			// maxLen  limits amount of seconds to record, it is documented in millseconds but
			// the length changes depending on the bitspersample, channels, and samplepersec
			// so I disabled it.  I was using it as a timeout so if left recording it would not
			// fill up the hard disk.
			//mciString="record myvoice  to "+maxLen.ToString();
			mciString="record myvoice";
			err=mciSendString(mciString,recordBuffer,1024,0); // I have not reason to have of set this to 1024
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n6-MCI error: {0}",errorBuffer.ToString());
			}
		}

		public void mciRecordAbort(){  // stop recording no save
			mciSendString("stop myvoice",errorBuffer,128,0);			
			mciSendString("close myvoice",errorBuffer,128,0);
		}
		
		public void mciWaveSave (string fileName) {
			int err=mciSendString("stop myvoice",errorBuffer,128,0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n7-MCI error: {0}",errorBuffer.ToString());
			}
			string mciString = "save myvoice \""+pworkingDir+fileName+"\"";
			err=mciSendString(mciString,errorBuffer,128,0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n8-MCI error: {0}",errorBuffer.ToString());
			}
			err = mciSendString("close myvoice", errorBuffer,128, 0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n9-MCI error: {0}",errorBuffer.ToString());
			}
		}

		public void sndPlayS (string fileName) {
			StringBuilder outfile=new StringBuilder();
			outfile.Append(pworkingDir+fileName);
			int err=sndPlaySound(outfile,1);
		}

		public void mciWavePlay (bool waitFlag) {
			int err;
			if (waitFlag) {
				err = mciSendString("play mciWave wait", errorBuffer, 128, 0);
			} else {
				err = mciSendString("play mciWave", errorBuffer, 128, 0);
			}
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n10-MCI error: {0}",errorBuffer.ToString());
			}
		}

		public void mciWaveClose () {
			int err = mciSendString("stop mciWave", errorBuffer, 128, 0);
			if (err != 0) {				
				int retval;
				retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n11-MCI error: {0}",errorBuffer.ToString());
			}
			err = mciSendString("close mciWave", errorBuffer, 128, 0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n12-MCI error: {0}",errorBuffer.ToString());
			}
		}

		public void mciRecordparm(string fileName) {	// not working
			// ************** this is not working yet ********************
			// *******  ANY SUGGESTIONS?  kenton@crossroadmission.org
			// ************** this is not working yet ********************
			
			MCI_WAVE_SET_PARMS parms = new MCI_WAVE_SET_PARMS();
			//parms.dwCallback=0; 
			//parms.dwTimeFormat=0; 
			//parms.dwAudio=0; 
			//parms.wInput=1; 
			//parms.wOutput=1; 
			parms.wFormatTag = WAVE_FORMAT_PCM;     //'pcm wave type
			//parms.wReserved2=0; 
			parms.nChannels = 2;                    //'two channel (stereo)
			//parms.wReserved3=0; 
			parms.nSamplesPerSec = 44100;           //'sample rate
			parms.nAvgBytesPerSec=0; 
			parms.nBlockAlign=0; 
			//parms.wReserved4=0; 
			parms.wBitsPerSample = 16;              //'16 bit record
			//parms.wReserved5=0; 
			
			//'make calculations
			parms.nAvgBytesPerSec = Convert.ToUInt32((parms.wBitsPerSample / 8) * parms.nChannels * parms.nSamplesPerSec);
			parms.nBlockAlign = Convert.ToUInt16((parms.wBitsPerSample / 8) * parms.nChannels);
			// may need to erase wave file if it exists here
			string mciString = "open new type waveaudio alias myvoice";
			int err=mciSendString(mciString,errorBuffer,128,0);
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n1-MCI error: {0}",errorBuffer.ToString());
			}
			uint wDeviceID; 
			wDeviceID = mciGetDeviceID("myvoice"); //get the device ID that was opened above
			//uint tt = MCI_WAIT | MCI_WAVE_SET_FORMATTAG | MCI_WAVE_SET_BITSPERSAMPLE | MCI_WAVE_SET_CHANNELS | MCI_WAVE_SET_SAMPLESPERSEC | MCI_WAVE_SET_AVGBYTESPERSEC | MCI_WAVE_SET_BLOCKALIGN;
			object pRef = (object) parms;
			//uint ts = MCI_SET;
			//MCI_SET
			err = mciSendCommand(wDeviceID, MCI_SET, MCI_WAIT | MCI_WAVE_SET_FORMATTAG | MCI_WAVE_SET_BITSPERSAMPLE | MCI_WAVE_SET_CHANNELS | MCI_WAVE_SET_SAMPLESPERSEC | MCI_WAVE_SET_AVGBYTESPERSEC | MCI_WAVE_SET_BLOCKALIGN, ref pRef);
			

			//err=mciSendCommand(wDeviceID, ts, 2, ref pRef);
			//err=mciSendCommand(wDeviceID, 0,0, ref pRef);
			
			if (err != 0) {				
				int retval = mciGetErrorString(err, errorBuffer, 128);
				Console.WriteLine("\n2-MCI error: {0}",errorBuffer.ToString());
			}

			// add record command here
	
		}

	}
}


/* 
 ********** C# **********************
sbyte -128 to 127 Signed 8-bit integer 
byte 0 to 255 Unsigned 8-bit integer 
char U+0000 to U+ffff Unicode 16-bit character 
short -32,768 to 32,767 Signed 16-bit integer 
ushort 0 to 65,535 Unsigned 16-bit integer 
int -2,147,483,648 to 2,147,483,647 Signed 32-bit integer 
uint 0 to 4,294,967,295 Unsigned 32-bit integer 
long -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 Signed 64-bit integer 
ulong 0 to 18,446,744,073,709,551,615 Unsigned 64-bit integer 

********** C++ ***************
BOOL   A Boolean value.
BSTR   A 32-bit character pointer.
BYTE   An 8-bit integer that is not signed.
COLORREF   A 32-bit value used as a color value.
DWORD   A 32-bit unsigned integer or the address of a segment and its associated offset.
LONG   A 32-bit signed integer.
LPARAM   A 32-bit value passed as a parameter to a window procedure or callback function.
LPCSTR   A 32-bit pointer to a constant character string.
LPSTR   A 32-bit pointer to a character string.
LPCTSTR   A 32-bit pointer to a constant character string that is portable for Unicode and DBCS.
LPTSTR   A 32-bit pointer to a character string that is portable for Unicode and DBCS.
LPVOID   A 32-bit pointer to an unspecified type.
LRESULT   A 32-bit value returned from a window procedure or callback function.
UINT   A 16-bit unsigned integer on Windows versions 3.0 and 3.1; a 32-bit unsigned integer on Win32.
WNDPROC   A 32-bit pointer to a window procedure.
WORD   A 16-bit unsigned integer.
WPARAM   A value passed as a parameter to a window procedure or callback function: 16 bits on Windows versions 3.0 and 3.1; 32 bits on Win32. 

       C++							C#
VARIANT								n/a
DECIMAL								DECIMAL
BYTE/bool							byte
VARIANT_BOOL						bool
signed short int __int16			short,char
signed char, __int8					
long, (long int, signed long int)	int
__int64								long
float								float
double								double

Converting C Declarations to Visual Basic
The procedures in DLLs are most commonly documented using C language syntax. To call these procedures from Visual Basic, you need to translate them into valid Declare statements and call them with the correct arguments.
As part of this translation, you must convert the C data types into Visual Basic data types and specify whether each argument should be called by value (ByVal) or implicitly, by reference (ByRef). The following table lists common C language data types and their Visual Basic equivalents for 32-bit versions of Windows.

C language		Visual Basic declare as						Call with 
ATOM			ByVal variable As Integer			An expression that evaluates to an Integer 
BOOL			ByVal variable As Long				An expression that evaluates to a Long 
BYTE			ByVal variable As Byte				An expression that evaluates to a Byte 
CHAR			ByVal variable As Byte				An expression that evaluates to a Byte 
COLORREF		ByVal variable As Long				An expression that evaluates to a Long 
DWORD			ByVal variable As Long				An expression that evaluates to a Long 
HWND, HDC, HMENU, etc. (Windows handles)ByVal variable As Long An expression that evaluates to a Long 
INT, UINT		ByVal variable As Long				An expression that evaluates to a Long 
LONG			ByVal variable As Long				An expression that evaluates to a Long 
LPARAM			ByVal variable As Long				An expression that evaluates to a Long 
LPDWORD			variable As Long					An expression that evaluates to a Long 
LPINT, LPUINT	variable As Long					An expression that evaluates to a Long 
LPRECT			variable As type					Any variable of that user-defined type 
LPSTR, LPCSTR	ByVal variable As String			An expression that evaluates to a String 
LPVOID			variable As Any						Any variable (use ByVal when passing a string) 
LPWORD			variable As Integer					An expression that evaluates to an Integer 
LRESULT			ByVal variable As Long				An expression that evaluates to a Long 
NULL			As Any or
ByVal			variable As Long					ByVal Nothing or ByVal 0& or vbNullString 
SHORT			ByVal variable As Integer			An expression that evaluates to an Integer 
VOID			Sub procedure						Not applicable 
WORD			ByVal variable As Integer			An expression that evaluates to an Integer 
WPARAM			ByVal variable As Long				An expression that evaluates to a Long 

 * 
 * 
 * ************************ LAME README ********************************* 


% lame [options] inputfile [outputfile]

For more options, just type:
% lame --help


=======================================================================
Constant Bitrate Examples:
=======================================================================
fixed bit rate jstereo 128 kbps encoding:
% lame sample.wav  sample.mp3      

fixed bit rate jstereo 128 kbps encoding, higher quality:  (recommended)
% lame -h sample.wav  sample.mp3      

Fast encode, low quality  (no noise shaping)
% lame -f sample.wav  sample.mp3     

=======================================================================
Variable Bitrate Examples:
=======================================================================
LAME has two types of variable bitrate: ABR and VBR.

ABR is the type of variable bitrate encoding usually found in other
MP3 encoders, Vorbis and AAC.  The number of bits is determined by
some metric (like perceptual entropy, or just the number of bits
needed for a certain set of encoding tables), and it is not based on
computing the actual encoding/quantization error.  ABR should always
give results equal or better than CBR:

ABR:   (--abr <x> means encode with an average bitrate of around x kbps)
lame -h --abr 128  sample.wav sample.mp3


VBR is a true variable bitrate mode which bases the number of bits for
each frame on the measured quantization error relative to the
estimated allowed masking.  VBR is currently under heavy development.
It can on occasion result in too much compression, so it should be
used with a minimum bitrate of 112 kbps.  This will let LAME increase
the bitrate for difficult-to-encode frames, but prevent LAME from
being too aggressive for simple frames:

Variable Bitrate (VBR): (use -V n to adjust quality/filesize)
% lame -h -v -b 112 sample.wav sample.mp3



=======================================================================
LOW BITRATES
=======================================================================
At lower bitrates, (like 24 kbps per channel), it is recommended that
you use a 16 kHz sampling rate combined with lowpass filtering.  LAME,
as well as commercial encoders (FhG, Xing) will do this automatically.
However, if you feel there is too much (or not enough) lowpass
filtering, you may need to try different values of the lowpass cutoff
and passband width (--resample, --lowpass and --lowpass-width options).


=======================================================================
STREAMING EXAMPLES
=======================================================================

% cat inputfile | lame [options] - - > output




=======================================================================
Scripts are included (in the 'misc' subdirectory)
to run lame on multiple files:

bach script:  mlame     Run "mlame -?" for instructions.
sh script:    auenc     Run auenc for instructions
sh script:    mugeco.sh

Windows scripts:
lame4dos.bat  
Lame.vbs   (and an HTML frontend: LameGUI.html)


=======================================================================
options guide:
=======================================================================
These options are explained in detail below.


Quality related:

-m m/s/j/f/a   mode selection
-k             disable all filtering
-d             allow block types to differ between channels
--athonly      ignore psy-model output, only use masking from the ATH
--voice        experimental voice encoding mode
--noshort      disable short blocks
-q n           Internal algorithm quality setting 0..9. 
0 = slowest algorithms, but potentially highest quality
9 = faster algorithms, very poor quality
-h             same as -q2
-f             same as -q7


Constant Bit Rate (CBR)
-b  n          set bitrate (8, 16, 24, ..., 320)
--freeformat   produce a free format bitstream.  User must also specify
a bitrate with -b, between 8 and 640 kbps.

Variable Bit Rate (VBR)
-v             VBR
--vbr-old      use old variable bitrate (VBR) routine (default)
--vbr-new      use new variable bitrate (VBR) routine
-V n           VBR quality setting  (0=highest quality, 9=lowest)
-b  n          specify a minimum allowed bitrate (8,16,24,...,320)
-B  n          specify a maximum allowed bitrate (8,16,24,...,320)
-F             strictly enforce minimum bitrate
-t             disable VBR informational tag 
--nohist       disable display of VBR bitrate histogram

--abr n        specify average bitrate desired


Experimental (undocumented):  may work better or worse:

-X n           try different quality measures (when comparing quantizations)
-Y             
-Z             


Operational:

-r              assume input file is raw PCM
-s  n           input sampling frequency in kHz (for raw PCM input files)
--resample n    output sampling frequency
--mp3input      input file is an MP3 file.  decode using mpglib/mpg123
--ogginput      input file is an Ogg Vorbis file.  decode using libvorbis
-x              swap bytes of input file
--scale <arg>   multiply PCM input by <arg>
--scale-l <arg> scale channel 0 (left) input (multiply PCM data) by <arg>
--scale-r <arg> scale channel 1 (right) input (multiply PCM data) by <arg>
-a              downmix stereo input file to mono .mp3
-e  n/5/c       de-emphasis
-p              add CRC error protection
-c              mark the encoded file as copyrighted
-o              mark the encoded file as a copy
-S              don't print progress report, VBR histogram
--strictly-enforce-ISO   comply as much as possible to ISO MPEG spec

--decode        assume input file is an mp3 file, and decode to wav.
-t              disable writing of WAV header when using --decode
(decode to raw pcm, native endian format (use -x to swap))

--ogg           Encode using Ogg Vorbis (.ogg) instead of mp3.



ID3 tagging:

--tt <title>    audio/song title (max 30 chars for version 1 tag)
--ta <artist>   audio/song artist (max 30 chars for version 1 tag)
--tl <album>    audio/song album (max 30 chars for version 1 tag)
--ty <year>     audio/song year of issue (1 to 9999)
--tc <comment>  user-defined text (max 30 chars for v1 tag, 28 for v1.1)
--tn <track>    audio/song track number (1 to 255, creates v1.1 tag)
--tg <genre>    audio/song genre (name or number in list)
--add-id3v2     force addition of version 2 tag
--id3v1-only    add only a version 1 tag
--id3v2-only    add only a version 2 tag
--space-id3v1   pad version 1 tag with spaces instead of nulls
--pad-id3v2     pad version 2 tag with extra 128 bytes
--genre-list    print alphabetically sorted ID3 genre list and exit

Note: A version 2 tag will NOT be added unless one of the input fields
won't fit in a version 1 tag (e.g. the title string is longer than 30
characters), or the '--add-id3v2' or '--id3v2-only' options are used,
or output is redirected to stdout.

OS/2-specific options:
--priority <type>     sets the process priority


options not yet described:
--nores            disable bit reservoir
--noath            disable ATH
--athlower <n db>  lower the ATH by n db.  
--athshort         use only the ATH for short blocks
--cwlimit <freq>   specify range of tonality calculation
--disptime
--notemp           disable temporal masking

--lowpass
--lowpass-width
--highpass
--highpass-width





=======================================================================
Detailed description of all options in alphabetical order
=======================================================================


=======================================================================
downmix
=======================================================================
-a  

mix the stereo input file to mono and encode as mono.  

This option is only needed in the case of raw PCM stereo input 
(because LAME cannot determine the number of channels in the input file).
To encode a stereo PCM input file as mono, use "lame -m s -a"

For WAV and AIFF input files, using "-m m" will always produce a
mono .mp3 file from both mono and stereo input.


=======================================================================
average bitrate encoding (aka Safe VBR)
=======================================================================
--abr n

turns on encoding with a targeted average bitrate of n kbps, allowing
to use frames of different sizes.  The allowed range of n is 8...320 
kbps, you can use any integer value within that range.





=======================================================================
ATH only
=======================================================================
--athonly

This option causes LAME to ignore the output of the psy-model and
only use masking from the ATH.  (absolute threshold of hearing)

Using --athonly is NOT RECOMMENDED.  It is designed for testing
different ATH curves.



=======================================================================
bitrate
=======================================================================
-b  n

For MPEG-1 (sampling frequencies of 32, 44.1 and 48 kHz)
n =   32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320

For MPEG-2 and MPEG-2.5 (sampling frequencies of 8, 11.025, 
12, 16, 22.05 and 24 kHz)
n = 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160


The bitrate to be used.  Default is 128 kbps MPEG1, 80 kbps MPEG2.

When used with variable bitrate encodings (VBR), -b specifies the
minimum bitrate to use.  This is useful to prevent LAME VBR from
using some very aggressive compression which can cause some distortion
due to small flaws in the psycho-acoustic model.

=======================================================================
max bitrate
=======================================================================
-B  n

see also option "-b" for allowed bitrates.

Maximum allowed bitrate when using VBR/ABR.

Using -B is NOT RECOMMENDED.  A 128 kbps CBR bitstream, because of the
bit reservoir, can actually have frames which use as many bits as a
320 kbps frame.  ABR/VBR modes minimize the use of the bit reservoir, and
thus need to allow 320 kbps frames to get the same flexability as CBR
streams.  




=======================================================================
copyright
=======================================================================
-c   

mark the encoded file as copyrighted



=======================================================================
block type control
=======================================================================
-d 

Allows the left and right channels to use different block types.
Normally this is not allowed, only because the FhG encoder does
not seem to allow it either.  If anyone finds a sample where -d
produces better results, let me know.  (mt@sulaco.org)


=======================================================================
mpglib decode capability
=======================================================================
--decode 

This just uses LAME's mpg123/mpglib interface to decode an MP3 file to
a wav file.  The input file can be any input type supported by
encoding, including .mp3 (layers 1, 2 and 3) and .ogg.  

If -t is used (disable wav header), LAME will output
raw pcm in native endian format (use -x to swap bytes).


=======================================================================
de-emphasis
=======================================================================
-e  n/5/c   

n = (none, default)
5 = 0/15 microseconds
c = citt j.17

All this does is set a flag in the bitstream.  If you have a PCM
input file where one of the above types of (obsolete) emphasis has
been applied, you can set this flag in LAME.  Then the mp3 decoder
should de-emphasize the output during playback, although most 
decoders ignore this flag.

A better solution would be to apply the de-emphasis with a standalone
utility before encoding, and then encode without -e.  



=======================================================================
fast mode
=======================================================================
-f   

Same as -q 7.  

NOT RECOMMENDED.  Use when encoding speed is critical and encoding
quality does not matter.  Disable noise shaping.  Psycho acoustics are
used only for bit allocation and pre-echo detection.

=======================================================================
strictly enforce VBR minimum bitrate
=======================================================================
-F   

strictly enforce VBR minimum bitrate.  With out this optioni, the minimum
bitrate will be ignored for passages of analog silence.



=======================================================================
free format bitstreams
=======================================================================
--freeformat   

LAME will produce a fixed bitrate, free format bitstream.
User must specify the desired bitrate in kbps, which can
be any integer between 8 and 640.

Not supported by most decoders.  Complient decoders (of which there
are few) are only required to support up to 320 kbps.  

Decoders which can handle free format:

supports up to
MAD                      640 kbps
"lame --decode"          550 kbps  
Freeamp:                 440 kbps
l3dec:                   310 kbps





=======================================================================
high quality
=======================================================================
-h

use some quality improvements.  The same as -q 2.



=======================================================================
keep all frequencies
=======================================================================
-k   

keep all frequencies.  (Disable all filters)

LAME will automatically apply various types of lowpass filters.  This
is because the high frequency coefficients can take up a lot of bits
that would be better used for lower, more important frequencies.

-k will disable all lowpass filtering.  Not recommended.



=======================================================================
Modes:
=======================================================================

-m m           mono
-m s           stereo
-m j           joint stereo
-m f           forced mid/side stereo
-m d           dual (independent) channels
-m i           intensity stereo
-m a           auto

MONO is the default mode for mono input files.  If "-m m" is specified
for a stereo input file, the two channels will be averaged into a mono
signal.  

STEREO

JOINT STEREO is the default mode for stereo files with fixed bitrates of
128 kbps or less.  At higher fixed bitrates, the default is stereo.
For VBR encoding, jstereo is the default for VBR_q >4, and stereo
is the default for VBR_q <=4.  You can override all of these defaults
by specifing the mode on the command line.  

jstereo means the encoder can use (on a frame by frame bases) either
regular stereo (just encode left and right channels independently)
or mid/side stereo.  In mid/side stereo, the mid (L+R) and side (L-R)
channels are encoded, and more bits are allocated to the mid channel
than the side channel.  This will effectively increase the bandwidth
if the signal does not have too much stereo separation.  

Mid/side stereo is basically a trick to increase bandwidth.  At 128 kbps,
it is clearly worth while.  At higher bitrates it is less useful.

For truly mono content, use -m m, which will automatically down
sample your input file to mono.  This will produce 30% better results
over -m j.  

Using mid/side stereo inappropriately can result in audible
compression artifacts.  To much switching between mid/side and regular
stereo can also sound bad.  To determine when to switch to mid/side
stereo, LAME uses a much more sophisticated algorithm than that
described in the ISO documentation.

FORCED MID/SIDE STEREO forces all frames to be encoded mid/side stereo.  It 
should only be used if you are sure every frame of the input file
has very little stereo seperation.  

DUAL CHANNELS   Not supported.

INTENSITY STEREO

AUTO

Auto select should select (if input is stereo)
8 kbps   Mono
16- 96 kbps   Intensity Stereo (if available, otherwise Joint Stereo)
112-128 kbps   Joint Stereo -mj
160-192 kbps   -mj with variable mid/side threshold
224-320 kbps   Independent Stereo -ms



=======================================================================
MP3 input file
=======================================================================
--mp3input

Assume the input file is a MP3 file.  LAME will decode the input file
before re-encoding it.  Since MP3 is a lossy format, this is 
not recommended in general.  But it is useful for creating low bitrate
mp3s from high bitrate mp3s.  If the filename ends in ".mp3" LAME will assume
it is an MP3.  For stdin or MP3 files which dont end in .mp3 you need
to use this switch.


=======================================================================
disable historgram display
=======================================================================
--nohist

By default, LAME will display a bitrate histogram while producing
VBR mp3 files.  This will disable that feature.


=======================================================================
disable short blocks
=======================================================================
--noshort

Encode all frames using long blocks.  NOT RECOMMENDED.  For
testing purposes only.  



=======================================================================
non-original
=======================================================================
-o   

mark the encoded file as a copy



=======================================================================
CRC error protection
=======================================================================
-p  

turn on CRC error protection.  
Yes this really does work correctly in LAME.  However, it takes 
16 bits per frame that would otherwise be used for encoding.


=======================================================================
algorithm quality selection
=======================================================================
-q n  

Bitrate is of course the main influence on quality.  The higher the
bitrate, the higher the quality.  But for a given bitrate,
we have a choice of algorithms to determine the best
scalefactors and huffman encoding (noise shaping).

-q 0:  use slowest & best possible version of all algorithms.

-q 2:  recommended.  Same as -h.  -q 0 and -q 1 are slow and may not produce 
significantly higher quality.  

-q 5:  default value.  Good speed, reasonable quality

-q 7:  same as -f.  Very fast, ok quality.  (psycho acoustics are
used for pre-echo & M/S, but no noise shaping is done.  

-q 9:  disables almost all algorithms including psy-model.  poor quality.



=======================================================================
input file is raw pcm
=======================================================================
-r  

Assume the input file is raw pcm.  Sampling rate and mono/stereo/jstereo
must be specified on the command line.  Without -r, LAME will perform
several fseek()'s on the input file looking for WAV and AIFF headers.

Not supported if LAME is compiled to use LIBSNDFILE.



=======================================================================
output sampling frequency in kHz
=======================================================================
--resample  n

where n = 8, 11.025, 12, 16, 22.05, 24, 32, 44.1, 48

Output sampling frequency.  Resample the input if necessary.  

If not specified, LAME may sometimes resample automatically 
when faced with extreme compression conditions (like encoding
a 44.1 kHz input file at 32 kbps).  To disable this automatic
resampling, you have to use --resamle to set the output samplerate
equal to the inptu samplerate.  In that case, LAME will not
perform any extra computations.



=======================================================================
sampling frequency in kHz
=======================================================================
-s  n

where n = sampling rate in kHz.

Required for raw PCM input files.  Otherwise it will be determined
from the header information in the input file.

LAME will automatically resample the input file to one of the
supported MP3 samplerates if necessary.


=======================================================================
silent operation
=======================================================================
-S

don't print progress report

=======================================================================
scale
=======================================================================
--scale <arg>

Scales input by <arg>.  This just multiplies the PCM data
(after it has been converted to floating point) by <arg>.  

<arg> > 1:  increase volume
<arg> = 1:  no effect
<arg> < 1:  reduce volume

Use with care, since most MP3 decoders will truncate data
which decodes to values greater than 32768.  


=======================================================================
strict ISO complience
=======================================================================
--strictly-enforce-ISO   

With this option, LAME will enforce the 7680 bit limitation on
total frame size.  This results in many wasted bits for
high bitrate encodings.


=======================================================================
disable VBR tag
=======================================================================
-t              

Disable writing of the VBR Tag (only valid if -v flag is
specified) This tag in embedded in frame 0 of the MP3 file.  It lets
VBR aware players correctly seek and compute playing times of VBR
files.

When '--decode' is specified (decode mp3 to wav), this flag will 
disable writing the WAV header.  The output will be raw pcm,
native endian format.  Use -x to swap bytes.



=======================================================================
variable bit rate  (VBR)
=======================================================================
-v

Turn on VBR.  There are several ways you can use VBR.  I personally
like using VBR to get files slightly bigger than 128 kbps files, where
the extra bits are used for the occasional difficult-to-encode frame.
For this, try specifying a minimum bitrate to use with VBR:

lame -v      -b 112  input.wav output.mp3

If the file is too big, use -V n, where n = 0...9

lame -v -V n -b 112  input.wav output.mp3


If you want to use VBR to get the maximum compression possible,
and for this, you can try:  

lame -v  input.wav output.mp3
lame -v -V n input.wav output.mp3         (to vary quality/filesize)






=======================================================================
VBR quality setting
=======================================================================
-V n       

n = 0...9.  Specifies the value of VBR_q.
default = 4,  highest quality = 0, smallest files = 9

Using -V 5 or higher (lower quality) is NOT RECOMMENDED.  
ABR will produce better results.  


How is VBR_q used?

The value of VBR_q influences two basic parameters of LAME's psycho
acoustics:
a) the absolute threshold of hearing
b) the sample to noise ratio
The lower the VBR_q value the lower the injected quantization noise
will be.
 
*NOTE* No psy-model is perfect, so there can often be distortion which
is audible even though the psy-model claims it is not!  Thus using a
small minimum bitrate can result in some aggressive compression and
audible distortion even with -V 0.  Thus using -V 0 does not sound
better than a fixed 256 kbps encoding.  For example: suppose in the 1 kHz
frequency band the psy-model claims 20 dB of distortion will not be
detectable by the human ear, so LAME VBR-0 will compress that
frequency band as much as possible and introduce at most 20 dB of
distortion.  Using a fixed 256 kbps framesize, LAME could end up
introducing only 2 dB of distortion.  If the psy-model was correct,
they will both sound the same.  If the psy-model was wrong, the VBR-0
result can sound worse.


=======================================================================
voice encoding mode
=======================================================================
--voice

An experimental voice encoding mode.  Tuned for 44.1 kHz input files.


=======================================================================
swapbytes   
=======================================================================
-x

swap bytes in the input file (and output file when using --decode).
For sorting out little endian/big endian type problems.  If your
encodings sound like static, try this first.

=======================================================================
OS/2 process priority control   
=======================================================================
--priority <type>

(OS/2 only)

Sets the process priority for LAME while running under IBM OS/2.
This can be very useful to avoid the system becoming slow and/or
unresponsive. By setting LAME to run in a lower priority, you leave
more time for the system to update basic processing (drawing windows,
polling keyboard/mouse, etc). The impact in LAME's performance is 
minimal if you use priority 0 to 2.

The valid parameters are:

0 = Low priority (IDLE, delta = 0)
1 = Medium priority (IDLE, delta = +31)
2 = Regular priority (REGULAR, delta = -31)
3 = High priority (REGULAR, delta = 0)
4 = Maximum priority (REGULAR, delta = +31) 

Note that if you call '--priority' without a parameter, then 
priority 0 will be assumed.

*/










