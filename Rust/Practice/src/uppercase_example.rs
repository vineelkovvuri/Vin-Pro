
fn upper_case(string: &str) -> String {
    let mut result = String::new();

    for ch in string.chars() {
        result.push(ch.to_ascii_uppercase());
    }

    result
}

fn main() {
    let str = upper_case("sun microsystems");
    println!("{}", str);
}
