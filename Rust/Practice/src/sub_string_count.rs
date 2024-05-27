fn sub_string_occurrence(string: &str, sub_string: &str) -> u32 {
    string.matches(sub_string).count() as u32
}

fn main() {
    let count = sub_string_occurrence(r"the quick brown fox jumps over the lazy dog", "the");
    println!("{}", count);
}
