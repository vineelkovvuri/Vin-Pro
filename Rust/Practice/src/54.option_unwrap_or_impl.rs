fn main() {
    let x = Some(20);
    dbg!(x.unwrap_or(10)); // return 20

    let x = None;
    dbg!(x.unwrap_or(10)); // return 10

    let x = Some(20);
    dbg!(my_unwrap_or(x, 10)); // return 20

    let x = None;
    dbg!(my_unwrap_or(x, 10)); // return 10
}

fn my_unwrap_or<T>(opt: Option<T>, default: T) -> T {
    match opt {
        Some(value) => value,
        None => default, // This is how the default value gets used
    }
}
