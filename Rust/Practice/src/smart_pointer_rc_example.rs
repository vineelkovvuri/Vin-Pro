use std::rc::Rc;

struct Author {
    name: String,
    age: u32,
}

#[derive(Clone)]
struct Book {
    // when Book object is cloned, this Author member is not cloned fully. In
    // other words, we can make part of the struct common(shared) between the
    // cloned objects.
    author: Rc<Author>,
    name: String,
    pages: u32,
    price: u32,
}

impl Book {
    fn print(&self) {
        println!(
            "Book name: {} pages: {} price: {} Author name: {} age: {}",
            self.name, self.pages, self.price, self.author.name, self.author.age
        );
    }
}

fn main() {
    let b1 = Book {
        author: Rc::new(Author {
            name: "Dennis Ritche".to_string(),
            age: 10,
        }),
        name: "The C Programming Language".to_string(),
        pages: 1000,
        price: 300,
    };

    // When we clone b1 other members are cloned but not the author member Which
    // in effect makes that part of the struct sharable between the clones. in
    // other words, Rc help each of the cloned object become owner of the author
    // object. Now since Rc will not let me mutate the object, the author object
    // is still safe from getting modified by multiple owners.

    let mut b2 = b1.clone();
    b2.pages = 2000; // change values of the cloned object
    b2.price = 400; // change values of the cloned object
                    // b2.author.age = 30; // This do not works as object behind Rc is immutable

    b1.print();
    b2.print();

    // Output:
    // Book name: The C Programming Language pages: 1000 price: 300 Author name: Dennis Ritche age: 10
    // Book name: The C Programming Language pages: 2000 price: 400 Author name: Dennis Ritche age: 10
}
