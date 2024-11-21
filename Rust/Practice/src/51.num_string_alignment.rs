fn main() {
    // Number are by default aligned right
    // Strings are by default aligned left

    // |                       10|
    // |Hello World!             |
    println!("|{:25}|", 10);
    println!("|{:25}|", "Hello World!");
}
