// or - Returns None if the option is None, otherwise calls f with the
// wrapped value and returns the result.
//
// functions
// or (optt: Option<T>) -> Option<T>
//  match T
//    Some(value) => Some(value),
//    None    => optt
fn main() {
    let x = Some(20);
    dbg!(x.or(Some(2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(x.or(Some(2))); // Some(2)

    let x = Some(20);
    dbg!(my_or(x, Some(2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(my_or(x, Some(2))); // Some(2)
}

fn my_or<T>(opt: Option<T>, optt: Option<T>) -> Option<T>
{
    match opt {
        Some(value) => Some(value),
        None => optt,
    }
}

// - Option<T> => and() => Option<U>
//   - The final type is U because we are replacing success case. So this works
//     when Option<T> is Some
// - Option<T> => or() => Option<T>
//   - The final type is T because we are replacing failure case. So this works
//     when Option<T> is None.
