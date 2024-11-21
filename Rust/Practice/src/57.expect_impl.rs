fn main() {
    let x = Some(20);
    dbg!(x.expect("missing number")); // return 20

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from expect(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.expect("missing number")); // return 10

    let x = Some(20);
    dbg!(my_expect(x, "missing number")); // return 20

    let x = Option::<u32>::None;
    dbg!(my_expect(x, "missing number")); // return 10
}

// This function is similar to unwrap jus that it has custom error message
// on panic
fn my_expect<T>(opt: Option<T>, string: &str) -> T
where
    T: Default,
{
    match opt {
        Some(value) => value,
        None => panic!("{}", string), // This is how the function gets called
    }
}
