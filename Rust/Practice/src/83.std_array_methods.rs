#![allow(unused)]

#[derive(Default, Clone, Copy)]
struct Book {
    a: u32,
}

fn main() {
    let a = [1, 2, 4];

    let a = [1; 4];

    // Up to 12 parameter tuple can be converted to an array. Tuple should be
    // homogenous(same type)
    let a: [i32; 4] = (1, 2, 3, 4).into();

    let b = Book { a: 10 };
    let a = [b; 4]; // b can be any expression which can be copyable

    // If Book supports default impl then we can create array like below(only up
    // to 32 elements)
    let mut a: [Book; 32] = Default::default();

    // Getting a reference to array
    let b = &a;
    let b = &mut a;

    // Coercing array to slice is implicit
    let mut a: [Book; 32] = Default::default();
    let b = &a[..];
    let b = &mut a[..];

    // Coercing slice to array is NOT implicit
    let a: [Book; 32] = b.try_into().unwrap();

    // Slice pattern for destructuring arrays
    let arr = [1, 2];
    let [first, second] = arr;
    let arr = [1, 2, 3, 4];
    let [first, second, _, _] = arr; // last
    let [first, _, _, last] = arr; // middle
    let [first, second, ..] = arr; // remaining
    let [first, .., last] = arr; // remaining


    let mut arr = [1, 2, 3, 4];
    let arr_refs = arr.each_mut();
    *arr_refs[1] = 10;

    // Array implements AsMut<[T]> trait. Which means, calling as mut will
    // return a mutable slice
    let mut arr = [1, 2, 3, 4];
    let as_mut_arr = arr.as_mut();
}
