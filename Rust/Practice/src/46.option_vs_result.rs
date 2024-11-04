// https://www.youtube.com/watch?v=f82wn-1DPas
// Rust's Most Important Containers 📦 10 Useful Patterns

// IMPLEMENTATION 1:
// When failure happen during parse() we are assuming zero as the default value
// fn to_int(s: &String) -> u32 {
//     s.parse().unwrap_or(0)
// }
//
// fn accumulate(string_vec: &Vec<String>) -> u32 {
//     let mut res = 0;
//     for s in string_vec {
//         res += to_int(s);
//     }
//     res
// }

// IMPLEMENTATION 2:
// Instead of assuming default value during failure. Let's pass on Option to the
// caller and the caller will decide what to do. Also we don't want to expose
// the Error to the caller hence option is a perfect it. We achieve this using
// the ok() function on Result<T,E> -> Option<T>
// fn to_int(s: &String) -> Option<u32> {
//     s.parse().ok()
// }
// fn accumulate(string_vec: &Vec<String>) -> u32 {
//     let mut res = 0;
//     for s in string_vec {
//         // Because to_int() is now returning Option<u32> instead of u32, we have to
//         // destructor it appropriately. We can do it below ways
//         // 1. using match statement
//         res += match to_int(s) {
//             Some(val) => val,
//             None => 0,
//         };
//         // 2. using if let
//         if let Some(val) = to_int(s) {
//             res += val;
//         }
//         // 3. using unwrap_or on Option
//         res += to_int(s).unwrap_or(0);
//     }
//     res
// }

// IMPLEMENTATION 3:
// In the above implementation, the actual error is suppressed within
// accumulate() method. One way to propagate this to main() is make accumulate()
// return Option<u32> instead of u32
// fn to_int(s: &String) -> Option<u32> {
//     s.parse().ok()
// }
// fn accumulate(string_vec: &Vec<String>) -> Option<u32> {
//     let mut res = 0;
//     for s in string_vec {
//         // we can actually use ? operator to unwrap an Option. In case of errors
//         // ? operator will propagate the None to caller.
//         res += to_int(s)?;
//     }
//     // Since we return Option<u32> we should also wrap the result
//     Some(res)
// }

// IMPLEMENTATION 4: One of the problem with above implementation is, it returns
// None up on a failure but the caller will have no idea why it returned the
// None. In other words, wouldn't it be nice to communicate an error
#[derive(Debug)]
struct SummationError {
    value: String,
}
fn to_int(s: &String) -> Option<u32> {
    s.parse().ok()
}
fn accumulate(string_vec: &Vec<String>) -> Result<u32, SummationError> {
    let mut res = 0;
    for s in string_vec {
        // ok_or() is useful to map from Option to Result. We are using eager
        // version of ok_or() which takes an error type object. If we need we
        // can use a lazy version(ok_or_else()) which takes a function
        res += to_int(s).ok_or(SummationError { value: s.clone() })?;
    }
    // Since we return Result<u32, SummationError> we should wrap the result in
    // Ok
    Ok(res)
}

fn main() {
    let string_vec = vec!["12".to_string(), "a14".to_string()];
    let val = accumulate(&string_vec);
    dbg!(val);
}
