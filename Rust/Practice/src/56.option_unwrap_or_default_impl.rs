fn main() {
    let x = Some(20);
    dbg!(x.unwrap_or_default()); // return 20

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from unwrap_or_default(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.unwrap_or_default()); // return 10

    let x = Some(20);
    dbg!(my_unwrap_or_default(x)); // return 20

    let x = Option::<u32>::None;
    dbg!(my_unwrap_or_default(x)); // return 10
}

// This helps in returning the default value of the type. Hence T is
// constrainned on the T: Default trait
fn my_unwrap_or_default<T>(opt: Option<T>) -> T
where
    T: Default,
{
    match opt {
        Some(value) => value,
        None => T::default(), // This is how the function gets called
    }
}
