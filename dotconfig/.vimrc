set nocompatible
execute pathogen#infect()
set ttyfast
set nu
syntax on
filetype plugin indent on
set cindent
set shiftwidth=4
set tabstop=4
"set noexpandtab
set incsearch
set ignorecase
set hlsearch
set ruler

"No swapfiles
set nobackup
set noswapfile
set nowritebackup
"set textwidth=78
"set wrapmargin=80
set lazyredraw

"no sounds
set noerrorbells
set novisualbell

"set lines=999 columns=999

syn keyword cType uint ubyte ulong uint64_t uint32_t uint16_t uint8_t boolean_t int64_t int32_t int16_t int8_t u_int64_t u_int32_t u_int16_t u_int8_t u8 wait_queue_head_t atomic_t
set showmode
"set gdefault  					"search/replace "globally" (on a line) by default
set laststatus=2                " tell VIM to always put a status line in, even
                                "    if there is only one window
set wildmenu                    " make tab completion for files/buffers act like bash
set wildmode=list:full          " show a list when pressing tab and complete
                                "    first full match
set showcmd                     " show (partial) command in the last line of the screen
                                "    this also shows visual selection info
colorscheme default 
set pastetoggle=<F2>
set listchars=tab:\|\ ,eol:$,trail:-
set backspace=indent,eol,start
set nowrap
set wildmode=longest:full,full
set colorcolumn=100

"change current directory
autocmd BufEnter * silent! lcd %:p:h

"set cursorline
"hi CursorLine   cterm=NONE ctermbg=59
"hi CursorLine   cterm=NONE ctermbg=darkred "ctermfg=white guibg=darkred guifg=white
":autocmd InsertEnter * set cul "Cursor line will be set only in insertmode
":autocmd InsertLeave * set nocul "No cursor line in other modes

set showmatch
hi MatchParen cterm=underline ctermfg=blue ctermbg=none "Highlight only other matching brace(not both) in red

"set clipboard=unnamedplus
"Enabling spell check for all
"set spell

au BufNewFile,BufRead COMMIT_EDITMSG set spell
hi clear SpellBad
hi SpellBad cterm=underline
hi clear SpellCap
hi SpellCap cterm=underline
hi clear SpellRare
hi SpellRare cterm=underline
hi clear SpellLocal
hi SpellLocal cterm=underline

if has("autocmd")
  au BufReadPost * if line("'\"") > 1 && line("'\"") <= line("$") | exe "normal! g'\"" | endif
endif

"Correct common mistakes
:command WQ wq
:command Wq wq
:command W w
:command Q q

"Calculator
:command! -nargs=+ Calc :py print <args>
:py from math import *

"Date time
:nnoremap <F5> "=strftime("%c")<CR>P
:inoremap <F5> <C-R>=strftime("%c")<CR>

"C, C++ compilers
au FileType c setlocal makeprg=gcc\ -Wall\ \"%\"
au FileType cpp setlocal makeprg=g++\ -Wall\ \"%\"
