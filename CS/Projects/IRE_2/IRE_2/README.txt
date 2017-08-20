

PLEASE OPEN THIS README IN NOTEPAD( FONT Lucida Console )

IRE Mini Project - Implementation of simple indexing and searching on wikipedia's data
--------------------------------------------------------------------------------------
It is completely coded in C. At few places Windows system calls are used(File Merge Routine)
                                                                   

Source code organisation / IRE Architecture
-------------------------------------------                                                                                    
                                                                                                                               
                                            IRECommon.h                                                                        
                                                |\                                                                             
                                                | `--IRECommon.c                                                               
                                                |                                               ---.                           
           .--------------------+---------------------+-------------------+-------------.          |                           
        Filter.h             Parser.h             Tokeniser.h        FileMerger.h       |          |                           
           |                    |                /     \            /     \             |          |                           
    StopwordsFilter.h        WikiParser.h       /   Tokenizer.c    /   FileMerger.c     |          |                           
        /           \       /    \             /                  /                     |          |                           
StopwordsFilter.c    \     /   WikiParser.c   /                  /                      |          |--> Indexing Implementation
                      \   /                  /                  /                       |          |                           
                       `-'------------------+------------------'                        |          |                           
                                            |                                           |          |                           
                                        Indexer.h                                       |          |                           
                                           /    \                                       |          |                           
                                     Indexer.c   \                                      |       ---'                           
                                                  \                                     |       ---.                           
                                                   \                                    |          |                           
                                                    \                                 Query.h      |--> Querying Implementation
                                                     \                                /   \        |                           
                                                      \                              /   Query.c   |                           
                                                       `----------------------------'           ---'                           
                                                                      |                         ---.                           
                                                                    Main.c                         |--> Driver Module          
                                                                                                ---'                           
                                                                                                                               
                                                                                                                               
                                                                                                                               
                                                                                                                               
HOW TO COMPILE AND RUN
----------------------
	Step 1: Visual Studio 2010 is required to build the application
	Step 2: Double click project solution file(.sln)
	Step 3: Once the project is loaded in VS2010 please open IRECommon.h file and set the BASE_DIR for the project
	Step 4: Press CTRL+F5 ( Project will compile and execute )
	Step 5: The final executable will be placed in to "Debug" folder of the project

Please explore the code and comments - Thanks

