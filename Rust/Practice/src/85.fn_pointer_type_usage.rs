#![allow(unused)]

use std::mem::{self, transmute};

fn main() {
    fn bar(x: i32) {
        println!("{}", x);
    }

    // assigning a function directly to a variable like below do not create a
    // function pointer
    let not_bar_ptr = bar; // `not_bar_ptr` is zero-sized, uniquely identifying `bar`
    assert_eq!(mem::size_of_val(&not_bar_ptr), 0);

    // assigning a function directly to a variable by defining `fn(i32)` makes
    // the assignment create a function pointer
    let bar_ptr: fn(i32) = bar; // force coercion to function pointer
    assert_eq!(mem::size_of_val(&bar_ptr), mem::size_of::<usize>());

    // The only difference b/w `not_bar_ptr` vs `bar_ptr` is its declaration.
    // not_bar_ptr is of type `fn bar(i32)` where as bat_ptr is of type `fn(i32)`

    let footgun = &bar; // this is a shared reference to the zero-sized type identifying `bar`

    let fun_ptr: fn(i32) = bar;

    unsafe fn unsafe_bar(x: i32) {
        println!("{}", x);
    }

    // an unsafe function pointer can point to safe function
    let unsafe_fun_ptr: unsafe fn(i32) = bar;
    let unsafe_fun_ptr: unsafe fn(i32) = unsafe_bar;
    // a safe function pointer cannot point to unsafe function
    // let safe_fun_ptr: fn(i32) = unsafe_bar;

    // any function pointer can be casted to integers
    let fun_ptr: fn(i32) = bar;
    let fun_ptr_addr = fun_ptr as usize;
    println!("{:x}", fun_ptr_addr);

    // but converting an integer back to a function pointer require
    // 1. Converting the integer to *const pointer - This step is mainly to avoid
    // 2. Using transmute to convert the final function pointer
    let fun_ptr_const = fun_ptr_addr as *const ();
    let fun_ptr: fn(i32) = unsafe { std::mem::transmute(fun_ptr_const) };
    // Converting directly from integer to final function pointer also works
    // using transmute() But apparently the above approach explicitly specifies
    // that we are converting from integer to pointer first.
    let fun_ptr: fn(i32) = unsafe { std::mem::transmute(fun_ptr_addr) };

    // function pointers implements Debug trait so we can print the address
    // value
    println!("{:?}", fun_ptr);
}
