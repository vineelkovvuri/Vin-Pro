// Structs holding mutable references to other structs

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

    // Even if the container is not mutable, Since it is the owner we can still
    // update the value of the data_ref because the data_ref is mutable.
    container.data_ref.update_value(20);

    // // Below code do not work because the container_ref itself is not mutable
    // // reference to a container object. But the data_ref inside the container is
    // // mutable.
    // let container_ref = &container;
    // container_ref.data_ref.update_value(30);

    // Below code works because the container_ref itself is mutable reference to
    // a container object. One side effect is, we have to declare container as
    // let mut
    let container_ref = &mut container;
    container_ref.data_ref.update_value(30);


    // Take aways:
    // 1. Even if a struct field hold a mutable reference to an other struct, we
    //    can modify that other struct only if the container struct is held by a
    //    owner or by a mutable reference.
    // 2. If the container struct is held by a immutable reference, we can't
    //    modify the other struct even if we the field holds a mutable
    //    reference.
}
