
fn find_directory_depth(string: &str) -> u32 {
    let components = string.split('\\');
    components.count() as u32
}

fn main() {
    let count = find_directory_depth(r"C:\Windows\System32\drivers\http.sys");
    println!("{}", count);
}
