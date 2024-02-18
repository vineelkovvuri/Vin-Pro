export CLICOLOR=1
export LSCOLORS=ExFxCxDxBxegedabagacad
export GREP_OPTIONS='--color=always'
export GREP_COLOR='1;35;40'

#export PS1="\[\033[1;94m\]\w \[\033[1;97m\]\$\[\033[0m\]"
. ~/.git-completion.bash

alias cd..='cd ..'
alias c.='cd ..'
alias c..='cd ../..'
alias c...='cd ../../..'
alias c....='cd ../../../..'
alias c.....='cd ../../../../..'
alias gti='git'
alias du='du -hs'
alias tree='tree -ahC'

shopt -s nocaseglob #make ls *ttl* expand to TTL Cook. To unset use shopt -u nocaseglob
export PATH="/usr/local/bin:$PATH"
export PATH="/usr/local/sbin:$PATH"
