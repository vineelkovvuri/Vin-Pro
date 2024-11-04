fn main() {
    let num = "123".parse::<u64>().unwrap_or(10u64);
    println!("num: {}", num);
    let num = "123k".parse::<u64>().unwrap_or(10u64);
    println!("num: {}", num);
}
