
BRIEF LOOK AT PE FILE

            .----------------------.
            |                      |
            |    Other stuff not   |
            |    touched in this   |
            |    program           |
            |                      |
            |----------------------|
            |                      |
            | Various Section like |
            |        .....         |
            |        .....         |
    .------>|       .reloc         |
    | .---->|       .idata         |
    | | .-->|       .data          |
    | | | .>|       .text          |
    | | | | |----------------------|
    '-|-|-|-|                      | <--- Each entry in section table have pointer
      '-|-|-|         Section      |      offsets to actual sections
        '-|-|     Header or Table  |
          '-|                      |      ---.----------------.
            |----------------------|-----/   |   PE Optional  |  1) ImageBase
            |                      |         |    Header      |
            |                      |         |                |
            |        NT Headers    |         |----------------|
            |                      |         |     COFF/PE    |  1) NumberOfSections
            |                      |         |   Header Info  |  2) SizeOfOptionalHeader
            |----------------------|-----    |----------------|
            |         UNUSED       |     \   |   PE Signature |
            |----------------------|      ---'----------------'
            |      MS-DOS stub     |
            |----------------------|
            |         UNUSED       |
            |----------------------|
            |     MS-DOS Header    | <-- Here at 0x3c location we have the offset of NT Header
            '----------------------'


ASCII ART by
Vineel :)
