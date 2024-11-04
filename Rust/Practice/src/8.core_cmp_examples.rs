use std::cmp::Ordering;

struct Book {
    pages: u32,
    author: String,
}

fn main() {
    println!("{}", core::cmp::max(19, 2));
    println!(
        "{}",
        core::cmp::max_by(19, 2, |x, y| {
            if x < y {
                Ordering::Less
            } else if x > y {
                Ordering::Greater
            } else {
                Ordering::Equal
            }
        })
    );

    let b1 = Book {
        pages: 10,
        author: "The C Programming Language".to_string(),
    };

    let b2 = Book {
        pages: 100,
        author: "The Java Programming Language".to_string(),
    };

    let b3 = core::cmp::max_by_key(b1, b2, |x: &Book| x.pages);

}
