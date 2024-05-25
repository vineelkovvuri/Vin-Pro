pub fn fibonacci(n: i32) {
    println!("Printing first {0} fibonacci numbers", n);

    let mut first = 1;
    let mut second = 1;

    for _ in 1..n {
        println!("{0}", first);
        let third = first + second;
        first = second;
        second = third;
    }
}
