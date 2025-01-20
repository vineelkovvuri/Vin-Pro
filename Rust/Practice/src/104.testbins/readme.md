- This repo contains two packages
    - "testbins" is the root package declared in /Cargo.toml
        - main.rs creates the default crate with the name "testbins.exe"
            - `cargo run` will run the binary
    - "tools" is the 2nd package declared in /tools/Cargo.toml
        - tools/src/bin/bin1.rs creates the bin1 binary crate with the name "bin1.exe"
            - `cargo run --package tools --bin bin1` will run the binary
        - tools/src/bin/bin2.rs creates the bin2 binary crate with the name "bin2.exe"
            - `cargo run --package tools --bin bin2` will run the binary

Directory: C:\repos\testbins\target\debug

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a----         1/19/2025  11:21 PM         141312 bin1.exe
-a----         1/19/2025  11:27 PM         141312 bin2.exe
-a----         1/19/2025  11:21 PM         141312 testbins.exe
