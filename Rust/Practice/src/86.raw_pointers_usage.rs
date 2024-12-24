#![allow(unused)]

use std::{
    mem::{self, transmute},
    ptr,
};

struct Book(String);

impl Drop for Book {
    fn drop(&mut self) {
        println!("{} dropped", self.0);
    }
}

fn main() {
    // Converting objects to raw pointers
    let book1 = Book("Book1".to_string());
    let book1_ptr = &book1 as *const Book;
    let mut book1 = Book("Book1".to_string());
    let book1_mut_ptr = &mut book1 as *mut Book;

    // Getting a raw pointer to the inside value of a Box. Here we are only
    // getting a pointer to the inside value but the value is still owned by Box
    let book1 = Box::new(Book("Book1".to_string()));
    let book1_ptr = &*book1 as *const Book;
    let mut book1 = Box::new(Book("Book1".to_string()));
    let book1_mut_ptr = &mut *book1 as *mut Book;

    // The other option is actual taking the ownership of the underlying the
    // value
    let book1 = Box::new(Book("Book1".to_string()));
    // book1 will be moved out of the Box and returned as *mut Book
    let book1_ptr = Box::into_raw(book1);
    let book1 = unsafe { Box::from_raw(book1_ptr) };

    let book1 = Book("Book1".to_string());
    // creating references/pointers to fields is allowed because Book not a
    // packed struct. For packed structs, read
    // 87.raw_pointers_unaligned_access.rs
    let x = &(book1.0) as *const String;
}

fn overwrite_via_pointer_drops() {
    let mut book1 = Book("Book1".to_string());
    let book_ptr = &mut book1 as *mut Book;
    let mut book2 = Book("Book2".to_string());
    unsafe {
        // Storing through a raw pointer using *ptr = data calls drop on the old
        // value, so write() must be used if the type has drop glue and memory
        // is not already initialized - otherwise drop would be called on the
        // uninitialized memory.
        *book_ptr = book2;

        // Just putting a loop to identify the output from the drop.
        loop {}
    }
}
