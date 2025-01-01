// This problem demonstrates the constructor design pattern

struct Book {
    name: String,
    price: u32,
    pages: u32,
}

impl Book {
    fn print(&self) {
        println!(
            "name: {}\nprice: {}\npages: {}",
            self.name, self.price, self.pages
        );
    }
}

struct BookBuilder {
    name: String,
    price: u32,
    pages: u32,
}

impl BookBuilder {
    fn new() -> Self {
        Self {
            name: " ".to_string(),
            price: 100,
            pages: 1000,
        }
    }

    // All the below methods take mut self. Only then it can return Self

    fn name(mut self, name: String) -> Self {
        self.name = name;
        self
    }

    fn price(mut self, price: u32) -> Self {
        self.price = price;
        self
    }

    fn pages(mut self, pages: u32) -> Self {
        self.pages = pages;
        self
    }

    // we take the self. No need for mut self as we are not modifying self. Only
    // then it can move self.name to name
    fn build(self) -> Book {
        Book {
            name: self.name,
            price: self.price,
            pages: self.pages,
        }
    }
}

fn main() {
    let book = BookBuilder::new()
        .name("The Rust Programming Language".to_string())
        .pages(1000)
        .price(100)
        .build();

    book.print();
}
