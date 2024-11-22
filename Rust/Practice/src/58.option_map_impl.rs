// map
// map ((T) -> U) -> Option<U>

fn main() {
    let x = Some(20);
    dbg!(x.map(|x| 10.2)); // return Some(20)

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.map(|x| 10.2)); // None

    let x = Some(20);
    dbg!(my_map(x, |x| 10.2)); // return Some(20)

    let x = Option::<u32>::None;
    dbg!(my_map(x, |x| 10.2)); // None
}

// This function takes an option and return an option of different type. If the
// option is none it is expected to None
fn my_map<T, F, U>(opt: Option<T>, f: F) -> Option<U>
where
    F: FnOnce(T) -> U,
{
    match opt {
        Some(value) => Some(f(value)),
        None => None,
    }
}
