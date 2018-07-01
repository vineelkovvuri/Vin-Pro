source /etc/bash_completion

export TERM="screen-256color"
alias tmux="tmux -2"

alias cd..='cd ..'
alias c.='cd ..'
alias c..='cd ../..'
alias c...='cd ../../..'
alias c....='cd ../../../..'
alias c.....='cd ../../../../..'

alias gti='git'
alias du='du -hs'
alias ls='ls --color -h'
alias ks='ls --color -h'
alias tree='tree -ahC'
alias bc='bc -l'
alias gitsrc='cd  ~/vin-pro/git/'

shopt -s nocaseglob #make ls *ttl* expand to TTL Cook. To unset use shopt -u nocaseglob

export CATALINA_HOME=/usr/share/tomcat8/
export OPENGROK_TOMCAT_BASE=$CATALINA_HOME

