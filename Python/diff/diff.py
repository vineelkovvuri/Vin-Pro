
# Program to perform diff on two directories
# Works in echo mode:
#           New and updated files are copied left to right. 
#           Renames and deletes on the left are repeated on the right
# Written by Vineel Kumar Reddy Kovvuri <vineel567@yahoo.co.in>
# Updated on: 10:34 PM Tuesday, September 14, 2010

import sys
from os import *
from os.path import *
import shutil
import optparse

newDirs,delDirs,newFiles,delFiles,modFiles = [],[],[],[],[]
extExclusions = ["thumbs.db"] # files with matching extensions should be ignored

def file_modified(file,src,des):
    srcstat = stat(join(src,file))
    desstat = stat(join(des,file))
    #print [join(src,file),des,srcstat.st_size, desstat.st_size ,srcstat.st_mtime, desstat.st_mtime] 
    return srcstat.st_size != desstat.st_size or \
    srcstat.st_mtime != desstat.st_mtime    
    
def is_exclude_by_name(file):
    return (file.lower() in extExclusions)
    
def echo(src,des):
    ''' Code to  '''
    try:
        # frozenset for directories and files in src and des at current level
        fsrcDirSet  = frozenset([file for file in listdir(src) if isdir(join(src,file))])
        fsrcFileSet = frozenset([file for file in listdir(src) if isfile(join(src,file)) \
                                and not is_exclude_by_name(file)])

        fdesDirSet  = frozenset([file for file in listdir(des) if isdir(join(des,file))])
        fdesFileSet = frozenset([file for file in listdir(des) if isfile(join(des,file)) \
                                and not is_exclude_by_name(file)])

        # prepare conflicts list....
        # dirs that should be copied from src to des        
        for dir in fsrcDirSet - fdesDirSet:
            newDirs.append([join(src,dir),des])
            
        # files that should be copied from src to des
        for file in fsrcFileSet - fdesFileSet:
            newFiles.append([join(src,file),des])
            
        # dirs that should be deleted from src to des
        for dir in fdesDirSet - fsrcDirSet:
            delDirs.append([dir,des])
            
        # files that should be deleted from src to des
        for file in fdesFileSet - fsrcFileSet: 
            delFiles.append([file,des])
        
        # list of outdated files in des 
        for modFile in fsrcFileSet & fdesFileSet:
            if file_modified(modFile,src,des):
                modFiles.append([join(src,modFile),des])
                
        # folders common to both src and des    
        for dir in fsrcDirSet & fdesDirSet:
            echo(join(src,dir),join(des,dir))

    except WindowsError:
        print "Access Denied at ("+src+","+des+")"
                
                

def perform_echo():
    for src,des in newDirs:
        folder = split(src)[-1]
        print "New Dir Conflict: "+src+" should be copied to "+des +" copying....",
        shutil.copytree(src,join(des,folder)) 
        print "done"
        
    for src,des in newFiles:
        print "New File Conflict: "+src+" should be copied to "+des +" copying....",
        shutil.copy2(src,des)
        print "done"

    for src,des in delDirs:
        print "Dir Delete Conflict: "+src+" should be deleted in "+des +" deleting....",
        shutil.rmtree(join(des,src))
        print "done"
        
    for src,des in delFiles:
        print "File Delete Conflict: "+src+" should be deleted in "+des +" deleting....",
        remove(join(des,src))
        print "done"
        
    for src,des in modFiles:
        file = split(src)[-1]
        remove(join(des,file))
        print "File Modified Conflict: "+src+" should be overwritten in "+des +" overwriting....",
        shutil.copy2(src,des)
        print "done"
        


                
if __name__ == "__main__":
    
    usage = "usage: %prog [options] <src dir> <des dir>"
    parser = optparse.OptionParser(usage=usage)
    parser.add_option("-c", action="store_true" , dest='copy',\
    help="Perform the copy operation",default=False)
    

    (options, args) = parser.parse_args()
    
    if len(sys.argv) >= 3 and isdir(sys.argv[-2]) and isdir(sys.argv[-1]): #src des
        stat_float_times(False)
        echo(sys.argv[-2],sys.argv[-1])  
        #print options
        if options.copy :
            perform_echo()
        else:
            for src,des in newDirs:
                print "New Dir Conflict: "+src+" should be copied to "+des
                
            for src,des in newFiles:
                print "New File Conflict: "+src+" should be copied to "+des

            for src,des in delDirs:
                print "Dir Delete Conflict: "+src+" should be deleted in "+des

            for src,des in delFiles:
                print "File Delete Conflict: "+src+" should be deleted in "+des

            for src,des in modFiles:
                print "File Modified Conflict: "+src+" should be overwritten in "+des
    else:
        parser.print_help()
        
'''
    New Dir Conflict: ..\a\LP_2 should be copied to ..\b
    New File Conflict: ..\a\3.Pattern 1`001`0 .C should be copied to ..\b
    Dir Delete Conflict: LP should be deleted in ..\b
    File Delete Conflict: 2.lex.c should be deleted in ..\b\LP Exam
    File Modified Conflict: ..\a\NP\CharStuff.c should be overwritten in ..\b\NP        
'''

