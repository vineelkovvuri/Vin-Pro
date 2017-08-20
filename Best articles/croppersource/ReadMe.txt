
Cropper Version 1.5.2
-----------------------------------------------------------------
By Brian Scott
http://blogs.geekdojo.net/brian

UI Inspired by Ruler by Jeff Key
http://www.sliver.com
http://weblogs.asp.net/jkey



REQUIREMENTS
-----------------------------------------------------------------
Requires version 1.1 of the Microsoft .Net Framework
Available in Windows Update site.



CONTROLS
-----------------------------------------------------------------
Right Click for context menu.

Arrow Keys: Nudge one pixel. 
Alt + Arrow Keys: Resize one pixel. 
+Ctrl changes Resize and Nudge amount to five pixels. 

[ or ]: Resize entire form while keeping the crosshairs centered. 
[ or ] + Alt: Resize the thumbnail indicator one pixel;
[ or ] + Alt + Ctrl Resize the thumbnail indicator ten pixels;

DoubleClick or Enter: Take a screen shot.
Tab: Toggle color inversion.
Esc: Exit the program



OUTPUT OPTIONS
-----------------------------------------------------------------
BMP - Large files but no compression artifacts.

PNG - Smaller files with lossless compression, good for most 
image formats except full color photographic.  Think of it as a 
replacement for the simpler GIF format.

JPEG - Good for full color photographic images.  Cropper can 
save JPEG's in varying quality settings from 10 to 100.  
10 being the lowest quality and smallest file size.  100 being the
highest quality and largest file size.  In my work, I've discovered 
that a quality setting of 60-70 is usually good for the web.  It's 
a good trade off between file size and image quality.

Clipboard - The image is placed on the clipboard and can be pasted 
into any application that acceptes images.

Printer - Presents a print dialog that allows you to send the image 
straight to the printer. 



KNOWN ISSUES
----------------------------------------------------------------
1) Unable to cature images of movies in WMP or Winamp. This 
usually applies to all screen capture programs. It's hardware 
acceleration / hardware video overlay that causes it. 

In Windows Media Player, under the performance tab, slide the 
video acceleration to something less than full. In Winamp, under 
Video Options, uncheck 'Allow hardware video overlay'. This 
should allow you to take screenshots with any program. 



LATEST UPDATES
-----------------------------------------------------------------

[Version 1.5.1.0 09/26/2004 12:40 AM]

1) Added license information to source files.  A couple small 
to better clean up resources.



[Version 1.5.1.0 09/26/2004 12:40 AM]

1) Small change in configuration class.  Moved management methods 
into the class itself where they should be.  Renamed IO class to 
CaptureOutput since it now contains only Image saving and 
printing methods.



[Version 1.5.0.0 09/17/2004 3:00 PM: New Features]

1) The Image menu name has been changed to Output to better 
reflect the new output options.

2) Cropper can now output directly to a printer. Accessed in 
Output menu.

3) The configuration file is now saved to the Application Data 
folder of the current user.



[Version 1.4.0.0 09/12/2004 10:30 AM: New Features]

1) Cropper now remembers its size and location between 
sessions.

2) Size indicators have been moved to a tab on the top 
left for better viewing at smaller crop sizes.

3) Added a color invert feature to make it easier to
see the crop line against a dark background. Press the 
Tab key or select Invert from the context menu to toggle 
it.
  
4) The Jpeg image option has been expanded into a
submenu.  You can now save Jpegs from 10 to 100 quality.

5) Added a thumbnail feature. Clicking the 
Thumbnail option in the context menu will overlay 
another box on the form indicating the thumbnail size.
You can adjust the size by pressing [ or ] while holding
the Alt or Alt + Ctrl keys.  When the thumbnail is
enable, the normal screen shot will be taken and saved.
There will also be a resized file with '_Thumbnail' 
appended to the name.  

The thumbnail works off of a maximum size. If the
mazimum size is set to 80px, then the ratio of the 
thumbnail will be updated to keep both the width and
height within the maximum size.  The thumbnail 
indicator will reflect the ratio in real time.

If you resize the form to within 30 px of the thumbnails 
max size, the thumbnail indicator will dissapear and 
thumbnails will not be saved. Thumbnails will resume 
once the form is enlarged past the max thumnail size.

6) The last used thumbnail size will be saved between 
sessions.



[Version 1.3.0.0 09/09/2004 2:30 PM: New Feature]

1) Cropper now remembers its opactiy level and image 
format between sessions.



[Version 1.2.0.0 09/08/2004 5:00 PM: New Feature]

1) Added Png file format support. Selectable in the 
Image menu.



[Version 1.1.0.0 09/08/2004 1:00 PM: New Feature]

1) Added the ability to save the image to the clipboard. 
Selectable in the Image menu.



[Version 1.0.1.0 09/08/2004 11:00AM: Bugfixes] 

1) Cropper should now work on multiple monitor systems 
in any configuration.

2) Fixed an issue where the images folder would not be 
placed on the desktop if the desktop folder was mapped 
to a different location.



[Version 1.0.0.0 09/07/2004 2:35 AM: Initial Release]

Cropper in C#. Grab parts of your screen. 



IN THE WORKS
-----------------------------------------------------------------
1) User list of frequently used capture sizes

2) Multiple form instances that can be snap docked to each other
and take seperate screen shots all at once.  Like the slices 
tool in many drawing apps.  Can be simulated now by starting 
multiple versions of the app and manually lining each one up and
manually taking a screenshot with each.



-----------------------------------------------------------------
Thanks to everyones feedback.  I didn't expect this app 
to be so popular.  It hit 200 downloads in 2 days.  Now 
I feel obligated to make it better :)

If you like it, find it useful, or want it to do more...
let me know on my blog (blogs.geekdojo.net/brian).

Brian

