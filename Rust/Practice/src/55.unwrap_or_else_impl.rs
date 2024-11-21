fn main() {
    let x = Some(20);
    dbg!(x.unwrap_or_else(|| 10)); // return 20

    let x = None;
    dbg!(x.unwrap_or_else(|| 10)); // return 10

    let x = Some(20);
    dbg!(my_unwrap_or_else(x, || 10)); // return 20

    let x = None;
    dbg!(my_unwrap_or_else(x, || 10)); // return 10
}

// This helps in lazy evaluation of the function's code
fn my_unwrap_or_else<T, F>(opt: Option<T>, f: F) -> T
where
    F: FnOnce() -> T,
{
    match opt {
        Some(value) => value,
        None => f(), // This is how the function gets called
    }
}
