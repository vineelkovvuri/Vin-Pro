#![allow(unused)]

use std::array::from_fn;

fn main() {
    let mut box1 = Box::new(10);
    *box1 = 30;

    let mut box2 = Box::<u32>::new_uninit();
    let box2 = unsafe {
        // Can write to the value in both ways
        // box2.as_mut_ptr().write(100);
        // Can write to the value in both ways
        box2.write(200);
        box2.assume_init()
    };

    println!("{:?} ", *box2);
}
