fn main() {
    let mut num = 12333;
    let mut rev = 0;

    while num != 0 {
        rev = rev * 10 + num % 10;
        num /= 10;
    }

    println!("{rev}");
}
