#![allow(unused)]

fn main() {
    let mut arr = [1, 2, 3, 4, 5, 6];
    let mid = arr.len() / 2;

    // Below 2nd mutable borrow fails. As per
    // https://doc.rust-lang.org/nomicon/borrow-splitting.html, Borrow checker
    // does understand structs sufficiently to know that it's possible to borrow
    // disjoint fields of a struct simultaneously. However borrow checker
    // doesn't understand arrays or slices in anyway, so this doesn't work:
    //
    // let mut left_slice = &mut arr[..mid];
    // let mut right_slice = &mut arr[mid..];

    // This is the reason why we have split_at_mut() method which will by pass
    // the limitations of borrow check by using simple unsafe to split the
    // slice with multiple mutable borrows

    // pub fn split_at_mut(&mut self, mid: usize) -> (&mut [T], &mut [T]) {
    // ..
    //     unsafe {
    //         (from_raw_parts_mut(ptr, mid),
    //         from_raw_parts_mut(ptr.add(mid), len - mid))
    //     }
    // }
    let (left_slice, right_slice) = arr.split_at_mut(mid);
    println!("left_slice: {:?}", left_slice);
    println!("right_slice: {:?}", right_slice);
}
