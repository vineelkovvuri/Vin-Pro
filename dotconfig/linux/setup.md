sudo apt-get install linux-source
sudo apt update

sudo add-apt-repository ppa:gnome-terminator
sudo add-apt-repository ppa:freefilesync/ffs

sudo apt install -y gcc nasm make pkg-config git neovim micro tree unrar python-is-python3 curl fzf gparted fish cifs-utils meld vlc htop ripgrep lsscsi graphviz fd-find bat hexyl xchm hwinfo shutter mate-themes gtkterm bless alacritty tmux terminator dconf-editor cutecom minicom gdb-multiarch xscreensaver xscreensaver-data-extra xscreensaver-gl-extra qdirstat btop  sigrok dosfstools mtools nvme-cli  openssh-server gpart  freefilesync

curl https://getmic.ro | bash
sudo mv micro /usr/bin
sudo update-alternatives --install /usr/bin/editor editor /usr/bin/micro 100
sudo update-alternatives --install /usr/bin/x-terminal-emulator x-terminal-emulator /usr/bin/terminator 50

sudo update-alternatives --config x-terminal-emulator
chsh -s $(which fish)

set -U fish_prompt_pwd_dir_length 0

- Disable boot logo
sudo nvim /etc/default/grub
GRUB_CMDLINE_LINUX_DEFAULT=""
sudo update-grub2

curl -LO https://github.com/BurntSushi/ripgrep/releases/download/14.1.0/ripgrep_14.1.0-1_amd64.deb
sudo dpkg -i ripgrep_14.1.0-1_amd64.deb

- Install below software from Botique
https://github.com/ubuntu-mate/ubuntu-mate-welcome-legacy/blob/master/data/js/applications.json
chrome
vscode
sublime


RDP:
sudo apt install xrdp -y 
sudo systemctl status xrdp
sudo usermod -a -G ssl-cert xrdp 
sudo systemctl restart xrdp 
sudo ufw allow from 192.168.1.0/24 to any port 3389 
sudo ufw reload
/etc/X11/Xsession.d/80mate-environment
Add:
unset DBUS_SESSION_BUS_ADDRESS
before the closing "fi"
