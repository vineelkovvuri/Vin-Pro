// and_then - Returns None if the option is None, otherwise calls f with the
// wrapped value and returns the result.
//
// functions
// and_then ((T) -> Option<U>) -> Option<U>
//  match T
//    Some(value) => f(value),
//    None    => None
fn main() {
    let x = Some(20);
    dbg!(x.and_then(|v| Some(v * 2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(x.and_then(|v| Some(v * 2))); // None

    let x = Some(20);
    dbg!(my_and_then(x, |v| Some(v * 2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(my_and_then(x, |v| Some(v * 2))); // None
}

fn my_and_then<T, F, U>(opt: Option<T>, f: F) -> Option<U>
where
    F: FnOnce(T) -> Option<U>,
{
    match opt {
        Some(value) => f(value),
        None => None,
    }
}

// - Option<T> => unwrap_or() => Option<T>
//   - The final type is still T because we are filling in the missing value. So
// this works when Option<T> is None
// - Option<T> => and_then() => Option<U>
//   - The final type is U because we are replacing success case. So this works
//     when Option<T> is Some In a sense, and_then() will convert one Option to
// other Option and also uses the previous T to produce U
