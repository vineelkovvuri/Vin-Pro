fn main() {
    // below declares immutable x on heap. we cannot change its content as it is
    // immutable
    let x = Box::new(10);
    // *x = 20; <-- this cannot be done as x is immutable

    // Mutability: To modify the contents of a Box, the Box itself must be
    // mutable (let mut my_box), and the contents of the Box must be mutable as
    // well. This means you need to use Box::new to allocate a mutable value if
    // you intend to modify it.

    // Dereferencing: You use * to dereference the Box and access or modify the
    // value it contains
    let mut y = Box::new(20);
    *y = 30;
}
