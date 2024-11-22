// and - Returns None if the option is None, otherwise returns Option<U>.
// functions
// and (optu: Option<U>) -> Option<U>
//  match T
//    Some(value) => optu,
//    None    => None
fn main() {
    let x = Some(20);
    dbg!(x.and(Some(10))); // Some(10)

    let x = Option::<u32>::None;
    dbg!(x.and(Some(10))); // None

    let x = Some(20);
    dbg!(my_and(x, Some(10))); // Some(10)

    let x = Option::<u32>::None;
    dbg!(my_and(x, Some(10))); // None
}

fn my_and<T, U>(opt: Option<T>, optu: Option<U>) -> Option<U> {
    match opt {
        Some(_) => optu,
        None => None,
    }
}

// - Option<T> => unwrap_or() => Option<T>
//   - The final type is still T because we are filling in the missing value. So
// this works when Option<T> is None
// - Option<T> => and() => Option<U>
//   - The final type is U because we are replacing success case. So this works
//     when Option<T> is Some
// In a sense, and() will convert one Option to other Option
