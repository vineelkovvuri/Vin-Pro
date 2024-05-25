use std::ops::Deref;

struct Book {
    pages: u32, // immutable
    cost: core::cell::Cell<u32>, // can be mutated
}

fn main() {
    // x itself is immutable which means I cannot get a mutable reference to it
    // like let y = &mut x;

    // RefCell<T> uses Rust’s lifetimes to implement “dynamic borrowing”, a
    // process whereby one can claim temporary, exclusive, mutable access to the
    // inner value.
    let x = core::cell::RefCell::new(10);

    // by making x immutable we get the usual Rust compiler guarantees about
    // safety
    let mut _y = 10;

    let x_Ref = x.borrow();
    let x_ref: &i32 = x_Ref.deref(); // This will convert the Ref<T> to &T

    let x1_ref = x.borrow().deref();

    let x1_mut_ref = x.borrow_mut().deref();
    // cannot borrow two mutable references and this will panic at runtime
    let x2_mut_ref = x.borrow_mut().deref();

}
