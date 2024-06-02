use std::fs::File;

fn main() {
    let file_path = r"D:\Softs\Notepad2\License.txt";
    let file = File::open(file_path).unwrap();
    let metadata = file.metadata().unwrap();
    let length = metadata.len();
    let modified_date = metadata.modified().unwrap();

    println!("Length: {} bytes", length);
    println!("Modified date: {:?}", modified_date);
}
