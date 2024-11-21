// map_or_else
// map_or_else (() -> U, (T) -> U) -> U
//    Some(T) => (T) -> U
//    None    => () -> U
fn main() {
    let x = Some(20);
    dbg!(x.map_or_else(|| 11.2, |x| 10.2)); // 10.2

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.map_or_else(|| 11.2, |x| 10.2)); // 11.2

    let x = Some(20);
    dbg!(my_map_or_else(x, || 11.2, |x| 10.2)); // 10.2

    let x = Option::<u32>::None;
    dbg!(my_map_or_else(x, || 11.2, |x| 10.2)); // 11.2
}

// This function will map T -> U in the follow way
//    Some(T) => (T) -> U
//    None    => () -> U
// This is just lazy version of map_or()
fn my_map_or_else<T, D, F, U>(opt: Option<T>, d: D, f: F) -> U
where
    D: FnOnce() -> U,
    F: FnOnce(T) -> U,
{
    match opt {
        Some(value) => f(value),
        None => d(),
    }
}
