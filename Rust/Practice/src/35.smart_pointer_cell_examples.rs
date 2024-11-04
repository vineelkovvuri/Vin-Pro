struct Book {
    pages: u32, // immutable
    cost: core::cell::Cell<u32>, // can be mutated
}

fn main() {
    let _x = 10;

    // below will not work because x is immutable
    // _x = 20;

    let x = core::cell::Cell::new(10); // this allocates 10 on the heap
    // even though x is immutable we can mutate it internal state by using set
    // with a simple example like this do not make much difference between this
    // and the normal let mut x declaration.
    x.set(20);
    println!("{:?}", x.get());

    // the below example demonstrates the interior mutability
    let b = Book {
        pages: 100,
        cost: core::cell::Cell::new(100), // 100$ now.
    };

    // b.pages = 200; // do not work because b is immutable
    b.cost.set(200); // this can be mutated
    println!("{:?}", b.pages);
    println!("{:?}", b.cost.get());
}
