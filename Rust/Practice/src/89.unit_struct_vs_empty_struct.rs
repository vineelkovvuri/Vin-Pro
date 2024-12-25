#![allow(unused)]

// https://discord.com/channels/442252698964721669/448238009733742612/1321260894658756628
// In terms of usage, `struct Book {}`  is “just” a struct with no fields at the
// moment, and when you switch to `struct Book;` you're saying this will _never_
// have any fields; it is a thing that really has no state.
// it's kind of like how Rust doesn't implicitly `#[derive(Copy)]` for you — it
// waits for you to ask first. Though not nearly as significant since it's only
// a different syntax for construction.
// https://rust-lang.github.io/rfcs/0218-empty-struct-with-braces.html

// This is a unit struct. No need to create an object to use it. Instead you can
// directly call BookUnit.print() as if the name of the unit struct itself
// serves as an object. Thats why we actually use . dot operator b/w BookUnit
// and print(). Usually we use :: operator to access associated functions on a
// type, But here since print() is not an associated function we are supposed to
// create an object of the type and then use . dot operator on it, But
// interestingly we don't need that for unit structs!
#[derive(Debug)]
struct BookUnit;
impl BookUnit {
    fn print(&self) {
        println!("Unit struct print called {:?}", self);
    }
}

// This is a empty struct. Much like normal struct which has fields. So we need
// to create an object for it to call its methods
#[derive(Debug)]
struct BookEmpty {}
impl BookEmpty {
    fn print(&self) {
        println!("Empty struct print called {:?}", self);
    }
}

fn main() {
    BookUnit.print();

    let book_empty = BookEmpty {};
    book_empty.print();
    // BookEmpty.print(); // This do not work
}
