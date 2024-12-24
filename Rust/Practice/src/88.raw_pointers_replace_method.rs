#![allow(unused)]

use std::ptr;

struct Book(String);

fn main() {
    let mut book1 = Book("Book1".to_string());
    let book1_ptr = &mut book1 as *mut Book;
    let mut book2 = Book("Book2".to_string());

    // replace method replace the pointer without dropping the object it points
    // to and instead returns the old object
    let book1 = unsafe { book1_ptr.replace(book2) };

    println!("{}", book1.0);
}
