use std::cell::RefCell;

struct Book {
    pages: u32,                     // immutable
    cost: core::cell::RefCell<u32>, // can be mutated
}

fn main() {
    // Interior Mutability: RefCell allows you to mutate data from an immutable
    // context.
    // Runtime Borrowing Rules: RefCell provides methods to borrow data either
    // immutably or mutably. The borrowing rules are checked at runtime:
    // You can have multiple immutable borrows (borrow()) at the same time.
    // You can have only one mutable borrow (borrow_mut()) at a time, and this
    // mutable borrow cannot coexist with immutable borrows.
    let x = RefCell::new(10);
    {
        // this mutable borrow should be in a inner scope to limit the borrow
        let mut y = x.borrow_mut();
        *y = 20;
    }

    let z = x.borrow();
    println!("x = {:?}", *z);

    // the below example demonstrates the interior mutability(with RefCell)
    let b = Book {
        pages: 100,
        cost: core::cell::RefCell::new(100), // 100$ now.
    };

    {
        *b.cost.borrow_mut() = 200;
    }

    println!("cost: {}", *b.cost.borrow());

    // the difference b/w cell and refcell is cell only support replacing the
    // content all at once. Where as refcell provides reference(shared and
    // mutable) to the object which can be modified in place. RefCell do incur
    // performance penalty as it should do runtime borrow rules
}
