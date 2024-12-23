#![allow(unused)]

#[derive(Default, Clone)]
struct Book {
    a: u32,
    b: String,
}

impl AsRef<u32> for Book {
    fn as_ref(&self) -> &u32 {
        &self.a
    }
}

impl AsRef<String> for Book {
    fn as_ref(&self) -> &String {
        &self.b
    }
}

fn main() {
    let b = Book {
        a: 10,
        b: "asdfasdf".to_string(),
    };

    let price: &u32 = b.as_ref();
    let name: &String = b.as_ref();
}
