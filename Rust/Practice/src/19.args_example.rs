
// cargo run -- -h
// anything after -- is passed to the program as arguments
// Args {
//     inner: [
//         "target\\debug\\rust.exe",
//         "-h",
//     ],
// }
fn main() {
    let args = std::env::args();
    println!("args count: {}", args.len());
    // println!("args {:#?}", args);

    let current_exe = std::env::current_exe().unwrap();
    println!("current_exe: {:?}", current_exe.to_str());
    for arg in args {
        println!("arg {:?}", arg);
    }
}
