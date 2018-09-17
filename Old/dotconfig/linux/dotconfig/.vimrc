" Prerequisites: ctags, cscope
"
" Install Vundle Plugin Manager
" git clone https://github.com/VundleVim/Vundle.vim.git ~/.vim/bundle/Vundle.vim
set nocompatible              " be iMproved, required
filetype off                  " required

" set the runtime path to include Vundle and initialize
set rtp+=~/.vim/bundle/Vundle.vim
call vundle#begin()
" alternatively, pass a path where Vundle should install plugins
"call vundle#begin('~/some/path/here')

" let Vundle manage Vundle, required
Plugin 'VundleVim/Vundle.vim'

" MY PLUGINS --VINEEL
Plugin 'vim-scripts/mru.vim'
Plugin 'chazy/cscope_maps'
Plugin 'ntpeters/vim-better-whitespace'
Plugin 'vim-scripts/taglist.vim'
Plugin 'altercation/vim-colors-solarized'
Plugin 'ctrlpvim/ctrlp.vim'
" All of your Plugins must be added before the following line
call vundle#end()            " required
filetype plugin indent on    " required
" To ignore plugin indent changes, instead use:
"filetype plugin on
"
" Brief help
" :PluginList       - lists configured plugins
" :PluginInstall    - installs plugins; append `!` to update or just :PluginUpdate
" :PluginSearch foo - searches for foo; append `!` to refresh local cache
" :PluginClean      - confirms removal of unused plugins; append `!` to auto-approve removal
"
" see :h vundle for more details or wiki for FAQ
" Put your non-Plugin stuff after this lineet nocompatible


"-------MY SETUP START HERE--------"
set rnu   "change to relative numbering
set number "this helps in having the current line number still visible when rnu is used
filetype plugin indent on
syntax on
set cindent
set shiftwidth=4
set tabstop=4
set incsearch
set ignorecase
set hlsearch
set ruler

"disable arrow keys in normal mode
noremap <Up> <Nop>
noremap <Down> <Nop>
noremap <Left> <Nop>
noremap <Right> <Nop>

set t_Co=256
let g:solarized_termcolors=256
syntax enable
set background=dark
colorscheme solarized

" TagList options
" let Tlist_Display_Prototype = 1 "display full prototype instead of just function name
let Tlist_Exit_OnlyWindow = 1 "if taglist window is the only window left, exit vim
let Tlist_GainFocus_On_ToggleOpen = 1 "automatically switch to taglist window
let Tlist_Highlight_Tag_On_BufEnter = 1 "highlight current tag in taglist window
let Tlist_Process_File_Always = 1 "even without taglist window, create tags file, required for displaying tag in statusline
let Tlist_Show_Menu = 1 "show Tags menu in gvim
let Tlist_Show_One_File = 1 "show tags of only one file
let Tlist_Sort_Type = "name"

" Make vsplit and split open files to the right and below respectively
set splitright
set splitbelow

set lazyredraw
set ttyfast

" no wrapping of text
set nowrap
set textwidth=0
set wrapmargin=0

"no sounds
set noerrorbells
set novisualbell
set t_vb=
set noeb vb t_vb=

set showmode

set laststatus=2                " tell VIM to always put a status line in, even
                                "    if there is only one window
set wildmenu                    " make tab completion for files/buffers act like bash
set wildmode=list:full          " show a list when pressing tab and complete
                                "    first full match
set showcmd                     " show (partial) command in the last line of the screen
                                "    this also shows visual selection info
set pastetoggle=<F2>
set listchars=tab:\|\ ,eol:$,trail:-
set backspace=indent,eol,start
set wildmode=longest:full,full
set colorcolumn=100

set showmatch
hi MatchParen cterm=underline ctermfg=blue ctermbg=none "Highlight only other matching brace(not both) in red

au BufNewFile,BufRead COMMIT_EDITMSG set spell
hi clear SpellBad
hi SpellBad cterm=underline
hi clear SpellCap
hi SpellCap cterm=underline
hi clear SpellRare
hi SpellRare cterm=underline
hi clear SpellLocal
hi SpellLocal cterm=underline

"Correct common mistakes
:command WQ wq
:command Wq wq
:command W w
:command Q q

nnoremap <silent> <F4> :TlistToggle<CR>

"No swapfiles
set nobackup
set noswapfile
set nowritebackup

