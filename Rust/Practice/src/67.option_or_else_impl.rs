// or_else - Returns the option if it contains a value, otherwise calls f and returns the result.
//
// functions
// or_else (() -> Option<T>) -> Option<T>
//  match T
// Some(value) => Some(value),
// None => f(),
fn main() {
    let x = Some(20);
    dbg!(x.or_else(|| Some(2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(x.or_else(|| Some(2))); // Some(2)

    let x = Some(20);
    dbg!(my_or_else(x, || Some(2))); // Some(40)

    let x = Option::<u32>::None;
    dbg!(my_or_else(x, || Some(2))); // Some(2)
}

fn my_or_else<T, F>(opt: Option<T>, f: F) -> Option<T>
where
    F: FnOnce() -> Option<T>,
{
    match opt {
        Some(value) => Some(value),
        None => f(),
    }
}

// - Option<T> => and_then() => Option<U>
//   - The final type is U because we are replacing success case. So this works
//     when Option<T> is Some
// - Option<T> => or_else() => Option<T>
//   - The final type is T because we are replacing failure case. So this works
//     when Option<T> is None.
