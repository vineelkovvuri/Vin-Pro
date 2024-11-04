// Implementing different traits on T, &T, &mut T

struct Book {
    pages: u32,
}

trait EBook {
    fn get_book_type(&self) -> String;
}
trait EBookRef {
    fn get_book_type_ref(self) -> String;
}

trait EBookMutRef {
    fn get_book_type_mut_ref(self) -> String;
}

impl EBook for Book {
    // Here we take &self as parameter meaning, who ever calls this method
    // should pass self as a reference meaning even if we do b.get_book_type();
    // the complier will do (&b).get_book_type();
    fn get_book_type(&self) -> String {
        "pdf".to_string()
    }
}

impl EBookRef for &Book {
    // Here we take self as parameter But because this trait is implemented on
    // &Book, whoever calls this method like b.get_book_type_ref() will
    // automatically pass b as (&b).get_book_type_ref() and self will become &b
    fn get_book_type_ref(self) -> String {
        "pdf(ref)".to_string()
    }
}

impl EBookMutRef for &mut Book {
    // Here we take self as parameter But because this trait is implemented on
    // &mut Book, whoever calls this method like b.get_book_type_ref() will
    // automatically pass b as (&mut b).get_book_type_ref() and self will become
    // &mut b
    fn get_book_type_mut_ref(self) -> String {
        "pdf(mut ref)".to_string()
    }
}

fn main() {
    let mut b = Book { pages: 10 };
    println!("Format: {}", b.get_book_type());          // b => (&b)
    println!("Format: {}", b.get_book_type_ref());      // b => (&b)
    println!("Format: {}", b.get_book_type_mut_ref());  // b => (&mut b)

    // let mut v = vec![1, 2, 3, 4, 5];

    // for ele in &v {}

    // for ele in &mut v {}

    // for ele in v {}
}
