#![allow(unused)]

use std::array::from_fn;

fn main() {
    // Create arrays out of a generator
    // pub fn from_fn<T, const N: usize, F>(cb: F) -> [T; N]
    // where
    //     F: FnMut(usize) -> T,
    let arr = from_fn::<u32, 5, _>(|i| i as u32 * 2);
    //                               ^------- This is how turbo operator is used
}
