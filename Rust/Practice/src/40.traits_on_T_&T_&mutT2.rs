// Implementing different traits on T, &T, &mut T

struct Book {
    name: String,
    pages: u32,
}

trait EBook {
    // This method signature looks deceiving as it appears that the method
    // consume the type on which this trait is implemented (Book). Yes that is
    // true when implemented directly on Book, but Rust does provide the ability
    // to implement this trait on &Book and &mut Book and also other type of
    // Book listed below. The beauty here is, You define one trait and that
    // trait can be implemented with different kinds of same Type(kind of
    // confusing)
    //  - impl EBook for Book
    //  - impl EBook for &Book
    //  - impl EBook for &mut Book
    //  - impl EBook for [Book]
    //  - impl EBook for [Book; N]
    fn some_method(self);
}

impl EBook for Book {
    // calling this method on Book will consume the object.
    fn some_method(self) {
        // Here we can completely own the object
        println!("some_method on Book is called");
    }
}

impl<'a> EBook for &'a Book {
    // calling this method on Book will not consume the object because self here
    // mean &book not Book itself
    fn some_method(self) {
        // because we have been passed &book we can all methods of book type
        // which take &self. In other words we can have some custom
        // implementation that applies only to &book that is different from
        // other implementations like &mut book etc. But because of references
        // we will have to deal with lifetimes
        println!("some_method on &Book is called");
    }
}

impl<'a> EBook for &'a mut Book {
    // calling this method on Book will not consume the object because self here
    // mean &mut book not Book itself
    fn some_method(self) {
        // because we have been passed &mut book we can all methods of book type
        // which take &mut self. In other words we can have some custom
        // implementation that applies only to &mut book that is different from
        // other implementations like &book etc. But because of references we
        // will have to deal with lifetimes
        println!("some_method on &mut Book is called");
    }
}

fn main() {
    let mut b = Book { name:"The Rust Programming".to_string(), pages: 10 };
    (&b).some_method(); // some_method on &Book is called
    (&mut b).some_method(); // some_method on &mut Book is called
    b.some_method(); // some_method on Book is called
}
