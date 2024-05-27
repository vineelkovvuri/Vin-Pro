
fn skip_char(string: &str, c: char) -> String {
    let mut result = String::new();

    for ch in string.chars() {
        if ch != c {
            result.push(ch);
        }
    }

    result
}

fn main() {
    let str = skip_char("sun microsystems", 's');
    println!("{}", str);
}
