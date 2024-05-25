pub fn string_concat() {
    let mut s1 = String::new();
    s1.push_str(" Vineel ");

    let x = s1.trim();

    println!("{s1}  |{x}|");
}