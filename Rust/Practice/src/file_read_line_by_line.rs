use std::{
    fs::File,
    io::{BufRead, BufReader},
};

fn main() {
    let file_path = r"D:\Softs\Notepad2\License.txt";
    let file = File::open(file_path).unwrap();

    let reader = BufReader::new(file);

    for line in reader.lines() {
        println!("{}", line.unwrap());
    }
}
