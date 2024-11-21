// map
// map ((T) -> U) -> Option<U>

fn main() {
    let x = Some(20);
    dbg!(x.map(|x| 10.2)); // return Some(20)

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.map(|x| 10.2)); // panic

    let x = Some(20);
    dbg!(my_map(x, |x| 10.2)); // return Some(20)

    let x = Option::<u32>::None;
    dbg!(my_map(x, |x| 10.2)); // panic
}

// This function is similar to unwrap jus that it has custom error message
// on panic
fn my_map<T, F, U>(opt: Option<T>, f: F) -> Option<U>
where
    F: FnOnce(T) -> U,
{
    match opt {
        Some(value) => Some(f(value)),
        None => panic!(),
    }
}
