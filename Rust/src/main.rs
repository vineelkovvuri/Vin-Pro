fn main() {
    let s = "asdfasdf";

    let ptr_str: *const &str = &s;
    // let ptr_str: *mut &str = &mut s;

     unsafe {
        // println!("{}", *ptr_str);
        println!("{:?}", *ptr_str.offset(0 as isize));
     }
}
