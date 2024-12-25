#![allow(unused)]

use std::alloc::{GlobalAlloc, System};

struct MyAllocator;

#[global_allocator]
static GLOBAL: MyAllocator = MyAllocator;

unsafe impl GlobalAlloc for MyAllocator {
    unsafe fn alloc(&self, layout: std::alloc::Layout) -> *mut u8 {
        // using println will cause infinite recursion
        // println!("allocated: {:?}", layout);
        System.alloc(layout)
        // System.alloc_zeroed(layout) // For zero allocation
    }

    unsafe fn dealloc(&self, ptr: *mut u8, layout: std::alloc::Layout) {
        // using println will cause infinite recursion
        // println!("deallocated: {:?}", layout);
        System.dealloc(ptr, layout);
    }
}

fn main() {
    let x = Box::new(5);
}
