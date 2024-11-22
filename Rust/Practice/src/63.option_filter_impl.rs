// filter - Converts an Option<T> in to an Option<T> by running through the
// functions
// filter ((&T) -> bool) -> Option<T>
//  match T
//    Some(value) => {
//          if f(&value) {
//              return Some(value);
//          } else {
//              return None;
//          }
//    },
//    None    => None
fn main() {
    let x = Some(20);
    dbg!(x.filter(|x| x % 2 == 0)); // Some(20)

    // We should prefix Option::<u32>:: without which the compiler cannot infer
    // the type from map(), unlike other unwrap functions
    let x = Option::<u32>::None;
    dbg!(x.filter(|x| x % 2 == 0)); // None

    let x = Some(20);
    dbg!(my_filter(x, |x| x % 2 == 0)); // Some(20)

    let x = Option::<u32>::None;
    dbg!(my_filter(x, |x| x % 2 == 0)); // None
}

// filter ((&T) -> bool) -> Option<T>
//  match T
//    Some(value) => {
//          if f(&value) {
//              return Some(value);
//          } else {
//              return None;
//          }
//    },
//    None    => None
fn my_filter<T, F>(opt: Option<T>, f: F) -> Option<T>
where
    F: FnOnce(&T) -> bool,
{
    match opt {
        Some(value) => {
            if f(&value) {
                return Some(value);
            } else {
                return None;
            }
        }
        None => None,
    }
}
