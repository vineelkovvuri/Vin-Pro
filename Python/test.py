import fnmatch
import os

for file in os.listdir('.'):
    if fnmatch.fnmatch(file, '[abcdef]*.py'):
        print file
