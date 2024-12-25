#![allow(unused)]

use std::ptr;

#[repr(packed)]
struct PackedStruct {
    a: u16,
    b: u32,
}

fn main() {
    let data = PackedStruct {
        a: 42,
        b: 0x12345678,
    };

    let data_ptr = &data as *const PackedStruct;
    println!("data ptr: {:?}", data_ptr);

    // We cannot get raw pointers or references to fields of a packed structure
    // because the fields themselves could be unaligned. Rust require every type
    // should be aligned properly. So below `&data.b` do not compile. let b_ptr
    // = &data.b as *const u32; Instead we have to use addr_of! macro to get the
    // address of that field.
    let b_ptr = ptr::addr_of!(data.b); // old way
    println!("data.b ptr: {:?}", b_ptr);

    let b_ptr = &raw const data.b; // new way - using &raw const
    println!("data.b ptr: {:?}", b_ptr);

    //  This would be undefined behavior if b_ptr is not properly aligned
    // let b_value = unsafe { *b_ptr };
    // println!("{:x}", b_value);

    // Instead, use read_unaligned:
    let b_value = unsafe { ptr::read_unaligned(b_ptr) };
    println!("Value: 0x{:X}", b_value);

    // The core idea here is, using & and * on unaligned access can generate
    // undefined behavior(rightfully by the language). Instead to relax that
    // restriction and to allow access, we are required to use ptr::addr_of! and
    // read_unaligned() respectively.
}
// Output:
// data ptr: 0x6f6d8ff452
// data.b ptr: 0x6f6d8ff454
// data.b ptr: 0x6f6d8ff454
// Value: 0x12345678
