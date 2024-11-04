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

// In the above implementation, the actual error is suppressed within
// accumulate() method. One way to propagate this to main() is make accumulate()
// return Option<u32> instead of u32
fn to_int(s: &String) -> Option<u32> {
    s.parse().ok()
}

fn accumulate(string_vec: &Vec<String>) -> Option<u32> {
    let mut res = 0;
    for s in string_vec {
        res += to_int(s)
    }
    res
}


fn main() {
    let string_vec = vec!["12".to_string(), "a14".to_string()];
    let val = accumulate(&string_vec);
    dbg!(val);
}
