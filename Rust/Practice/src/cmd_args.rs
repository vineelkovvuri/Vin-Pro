
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

    println!("{:#?}", args);
}
