struct Pair<T> {
    a: T,
    b: T,
}

fn print_type_name<T: ?Sized>(_val: &T) {
    println!("{}", std::any::type_name::<T>());
}

fn main() {
    let p1 = Pair { a: 3, b: 9 };
    let p2 = Pair { a: true, b: false };
    print_type_name(&p1); // prints "Pair<i32>"
    print_type_name(&p2); // prints "Pair<bool>"
    print_type_name( " asdasdad"); // prints "str"
}
