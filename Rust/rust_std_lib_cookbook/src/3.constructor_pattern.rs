// This problem demonstrates the constructor design pattern

struct Book {
    name: String,
    price: u32,
    pages: u32,
}

impl Book {
    fn new(name: String, price: u32, pages: u32) -> Self {
        Self { name, price, pages }
    }

    fn print(&self) {
        println!(
            "name: {}\nprice: {}\npages: {}",
            self.name, self.price, self.pages
        );
    }
}

fn main() {
    // No default initialization nor constructor pattern
    let book = Book {
        name: "The Rust Programming Language".to_string(),
        price: 100,
        pages: 1000,
    };

    // This is using constructor pattern
    let book = Book::new("The Rust Programming Language".to_string(), 100, 1000);

    book.print();
}
