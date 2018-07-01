# LUbuntu Post Install Setup

### Virtual Box Setup
1. open “sudo vim /etc/apt/sources.list”
2. add “deb http://download.virtualbox.org/virtualbox/debian 'REPLACE WITH UBUNTU NAME' contrib”
3. wget -q https://www.virtualbox.org/download/oracle_vbox.asc -O- | sudo apt-key add -
4. sudo apt-get update

### Install essential software
sudo apt-get install  vim-gtk meld git gparted pavucontrol tree virtualbox-5.0 qbittorrent imagemagick gimp unrar xchm pdftk curl tmux

### Install all Java software
sudo apt-get install openjdk-8-jdk openjdk-8-source openjdk-8-doc openjfx openjfx-source

### Install freefilesync
sudo add-apt-repository ppa:freefilesync/ffs
sudo apt-get update
sudo apt-get install freefilesync

### Install telugu fonts and core ms fonts
sudo apt-get install ttf-telugu-fonts language-pack-te ttf-mscorefonts-installer

### Install vlc
sudo apt-get install vlc

### Remove unwanted software
sudo apt-get remove transmission transmission-gtk transmission-common
sudo apt-get remove gnome-mplayer

### Replace keyboard shortcuts
1. replace the modified lubuntu-rc.xml to ~/.config/openbox/lubuntu-rc.xml
2. run "openbox --reconfigure" or "openbox --restart"

### Install albert
sudo add-apt-repository ppa:nilarimogard/webupd8
sudo apt-get update
sudo apt-get install albert
# Set Alt+F1 as the hot key in albert settings.

### Makes numlock on by default after boot
sudo apt-get install numlockx
sudo echo greeter-setup-script=/usr/bin/numlockx on >> /etc/lightdm/lightdm.conf 

### Setup open as root for a directory in pcmanfm 
## copy below line to ~/.local/share/file-manager/actions/root.desktop
## (root.desktop file will be automatically renamed to "Open Folder As Root")
[Desktop Entry]
Type=Action
Tooltip=Open Folder As Root
Name=Open Folder As Root
Profiles=profile-zero;
Icon=gtk-dialog-authentication

[X-Action-Profile profile-zero]
MimeTypes=inode/directory;
Exec=/usr/bin/gksu /usr/bin/pcmanfm %u
Name=Default profile
## restart pcmanfm via pkill pcmanfm

### Copy .files from linux/dotconfig to home directory

### Enable hibernation (Make sure swap partition is as large as RAM)
add below lines to “sudo vim /etc/polkit-1/localauthority/50-local.d/com.ubuntu.enable-hibernate.pkla”

	[Re-enable hibernate by default for login1]
	  Identity=unix-user:*
	  Action=org.freedesktop.login1.hibernate
	  ResultActive=yes

	[Re-enable hibernate for multiple users by default in logind]
	  Identity=unix-user:*
	  Action=org.freedesktop.login1.hibernate-multiple-sessions
	  ResultActive=yes

sudo apt-get remove light-locker #uninstall default screen locker
sudo apt-get install xscreensaver xscreensaver-gl-extra xscreensaver-data-extra #add xscreen locker

# Reduce bootloader timeout after enabling Hibernation 
# https://thelastmaimou.wordpress.com/2013/11/11/this-grub-does-not-start-in-ubuntu/
open sudo vim /etc/default/grub
change GRUB_RECORDFAIL_TIMEOUT=5  
sudo update-grub

