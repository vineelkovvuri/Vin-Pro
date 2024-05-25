fn main() {
    println!("align_of char {}", core::mem::align_of::<char>());
    println!("align_of i32 {}", core::mem::align_of::<i32>());
    println!("align_of i64 {}", core::mem::align_of::<i64>());

    println!("align_of_val {}", core::mem::align_of_val(&10));

}
