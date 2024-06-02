fn main() {
    let file_path = r"D:\Softs\Notepad2\License.txt";
    let content = std::fs::read_to_string(file_path).unwrap();
    println!("{}", content);
}
