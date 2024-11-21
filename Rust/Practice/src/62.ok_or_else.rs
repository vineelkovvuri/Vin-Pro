// ok_or_else - Converts an Option in to a Result. Same as ok_or() but lazy
// ok_or_else (f() -> E) -> Result<T, E>
//    Some(T) => Ok(T)
//    None    => Err(f(E))
fn main() {
    let x = Some(20);
    dbg!(x.ok_or_else(|| 19)); // Ok(20)

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.ok_or_else(|| 19)); // Err(19)

    let x = Some(20);
    dbg!(my_ok_or_else(x, || 19)); // Ok(20)

    let x = Option::<u32>::None;
    dbg!(my_ok_or_else(x, || 19)); // Err(19)
}

// This function will convert Option<T> => Result<T, E> in the follow way
//    Some(T) => Ok(T)
//    None    => Err(f(E))
// This is just lazy version of ok_or()
fn my_ok_or_else<T, E, F>(opt: Option<T>, f: F) -> Result<T, E>
where
    F: FnOnce() -> E,
{
    match opt {
        Some(value) => Ok(value),
        None => Err(f()),
    }
}
