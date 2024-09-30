// Implementing different traits on T, &T, &mut T

struct Book {
    name: String,
    pages: u32,
}

trait EBook {
    // This associated type can be used to capture the Type(Book or &Book or
    // &mut Book) being operated on or some internal type(generic type like T in
    // Book<T>) of the type(Book) being operated on. After capturing that type,
    // we can use it in function returns etc using Self::Type.
    type Type;

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
    fn some_method(self) -> Self::Type;
}

impl EBook for Book {
    // Here we are capturing the current type being operated(which is Book).
    // After capturing that type, we can use it in function returns etc using
    // Self::Type.
    type Type = Self;
    // calling this method on Book will consume the object.
    fn some_method(self) -> Self::Type {
        // Here we can completely own the object
        println!("some_method on Book is called");
        self
    }
}

impl<'a> EBook for &'a Book {
    // Here we are capturing the current type being operated(which is &Book).
    // After capturing that type, we can use it in function returns etc using
    // Self::Type.
    type Type = Self;
    // calling this method on Book will not consume the object because self here
    // mean &book not Book itself
    fn some_method(self) -> Self::Type {
        // because we have been passed &book we can all methods of book type
        // which take &self. In other words we can have some custom
        // implementation that applies only to &book that is different from
        // other implementations like &mut book etc. But because of references
        // we will have to deal with lifetimes
        println!("some_method on &Book is called");
        self
    }
}

impl<'a> EBook for &'a mut Book {
    // Here we are capturing the current type being operated(which is &mut Book).
    // After capturing that type, we can use it in function returns etc using
    // Self::Type.
    type Type = Self;
    // calling this method on Book will not consume the object because self here
    // mean &mut book not Book itself
    fn some_method(self) -> Self::Type {
        // because we have been passed &mut book we can all methods of book type
        // which take &mut self. In other words we can have some custom
        // implementation that applies only to &mut book that is different from
        // other implementations like &book etc. But because of references we
        // will have to deal with lifetimes
        println!("some_method on &mut Book is called");
        self
    }
}

fn main() {
    let mut b = Book {
        name: "The Rust Programming".to_string(),
        pages: 10,
    };
    (&b).some_method();
    (&mut b).some_method();
    b.some_method();
}
