// ok_or - Converts an Option in to a Result
// ok_or (E) -> Result<T, E>
//    Some(T) => Ok(T)
//    None    => Err(E)
fn main() {
    let x = Some(20);
    dbg!(x.ok_or(19)); // Ok(20)

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.ok_or(19)); // Err(19)

    let x = Some(20);
    dbg!(my_ok_or(x, 19)); // Ok(20)

    let x = Option::<u32>::None;
    dbg!(my_ok_or(x, 19)); // Err(19)
}

// This function will convert Option<T> => Result<T, E> in the follow way
//    Some(T) => Ok(T)
//    None    => Err(E)
fn my_ok_or<T, E>(opt: Option<T>, err: E) -> Result<T, E> {
    match opt {
        Some(value) => Ok(value),
        None => Err(err),
    }
}
