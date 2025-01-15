#![allow(unused)]

// Source: Item 2 from "Effective Rust" book

fn add(a: u32, b: u32) -> u32 {
    a + b
}

fn main() {
    let x: fn(u32, u32) -> u32 = add; // x is a function pointer
    let y: fn(u32, u32) -> u32 = add; // y is a function pointer
    assert_eq!(x, y); // function pointer aka fn type do implement Debug trait so assert! macro can be used

    let a = add; // a is a function item not function pointers
    let b = add; // b is a function item not function pointers
                 // assert_eq!(a, b); // function item do not implement Debug trait so cannot use assert! macro on them

    // Below is like getting a pointer to a function pointer
    unsafe {
        let a = &x as *const fn(u32, u32) -> u32;
        println!("{}", (*a)(10, 20));
    }
}
