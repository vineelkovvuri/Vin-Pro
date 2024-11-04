
// Struct fields holding mutable references to other structs and trying to
// assign/copy those fields

struct Data {
    pub value: i32,
}

impl Data {
    // This takes a mutable reference to self to update the value.
    fn update_value(&mut self, new_value: i32) {
        self.value = new_value;
    }
}

struct Container<'a> {
    // This is a mutable reference to the Data struct. What this means is,
    // data_ref is a reference to Data struct and using that reference we can
    // mutate the Data struct. Read more notes in the main function on passing
    // around this reference.
    pub data_ref: &'a mut Data,
}

fn main() {
    let mut data = Data { value: 10 };
    let mut container = Container {
        data_ref: &mut data,
    };

    // One thing to note is, when we assign the data_ref to x, we are actually
    // moving the field in to x. So, we can't use data_ref anymore. This happens
    // because this field is a mutable reference. Had this been a normal
    // reference the value would have been copied.

    // let x = container.data_ref;
    // x.update_value(20);
    // // move occurs because `container.data_ref` has type `&mut Data`, which does
    // // not implement the `Copy` trait
    // let y = container.data_ref;
    // x.update_value(20);

    // // To fix the above issue, we can use the below code where we are using a
    // // reference. Which makes x and y &&mut Data type!
    // let x = &container.data_ref;
    // let y = &container.data_ref;

    // But since update_value() method takes a mutable reference, we need to now
    // take a mutable reference to data_ref.
    let x = &mut container.data_ref;
    x.update_value(20);

    let y = container.data_ref;
    y.update_value(40);

    println!("Updated value: {}", data.value);

    // let mut x = 10;
    // let y = &mut x; // move occurs because `y` has type `&mut i32`, which does not implement the `Copy` trait
    // let z = y; // value moved here
    // *y = 20; // use of moved value: `y`

    // let mut x = Data {value: 10};
    // let y = &mut x; // move occurs because `y` has type `&mut Data`, which does not implement the `Copy` trait
    // let z = y; // value moved here
    // y.value = 20; // value used here after move

    // below works fine because x is not a mutable reference assigning y to z do
    // not move the contents of y, instead they get copied.
    let x = 10;
    let y = &x;
    let z = y;
    println!("{} {}", x, *y);


    // Take aways:
    // 1. When copying a mutable reference the value is always moved.
    // 2. This becomes more important when the field in struct hold a mutable
    //    reference to some other struct. Because, we can't copy the field like
    //    we wish. As it makes the field to be moved.
    // 3. To fix the above issue, we can use a reference to the field. Either a
    //    mutable reference or a immutable reference based on the need.
}
