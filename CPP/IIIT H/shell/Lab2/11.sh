#!/bin/bash



mkdir $1/executables 2>/dev/null
find $1  -type f  -executable -exec cp -f {} $1/executables \; 2>/dev/null




