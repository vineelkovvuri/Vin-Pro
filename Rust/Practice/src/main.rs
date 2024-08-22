
struct Book {
    pages: u32, // immutable
    cost: u32,  // can be mutated
}

impl From<u32> for Book {
    fn from(value: u32) -> Self {
        Book {
            pages: value,
            cost: value,
        }
    }
}
fn main() {
    let arr = [0u8; 10];
    let s = arr.split_at(5);
    let s1 = s.0.split_at(5);

    let v = vec![1, 2, 3, 4];
}
