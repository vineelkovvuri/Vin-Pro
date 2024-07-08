pub trait Book {
    fn read(&self);
}

struct PaperBook {
    pages: u16,
}

impl Book for PaperBook {
    fn read(&self) {}
}

struct BindingBook {
    pages: u16,
}

impl Book for BindingBook {
    fn read(&self) {}
}

struct Library<T>
where
    T: Book,
{
    books: Vec<T>,
}

fn main() {

    let books = Vec::<BindingBook>::new();
    let mut books2 = Vec::<&dyn Book>::new();
    books2.push(&PaperBook {pages:10});
}
