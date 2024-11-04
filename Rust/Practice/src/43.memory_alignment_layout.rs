use std::alloc::Layout;

// https://garden.christophertee.dev/blogs/Memory-Alignment-and-Layout/Part-1
// https://garden.christophertee.dev/blogs/Memory-Alignment-and-Layout/Memory-Alignment-and-Layout-in-Rust


// Rules
// -----
// 1. Bits must be byte-aligned
// 2. Built-in datatypes are “natively”-aligned to their size (a u16 is 2-byte
//    aligned; an f64 is 8-byte aligned as discussed previously)
// 3. Complex types that are made up of other types have alignments equal to the
//    largest alignment of its component types

// This is out the fields of Foo are laid out, in C:
//
// tiny is a boolean, so intuitively it should only occupy one bit, right?
// Actually, no 😮 It occupies 1 byte (8 bits) of memory, because of the first
// rule. If it were to be just one bit long, subsequent appended data would not
// be byte-aligned.5 normal takes up 4 bytes and is 4-byte aligned due to the
// second rule. So, we cannot immediately append it to tiny’s data. Instead, we
// first need to append three bytes of padding. This brings the memory usage so
// far to 1 + 3 + 4 = 8 bytes. small takes up one byte and is byte-aligned so it
// can be appended directly. long occupies 8 bytes, and is 8-byte aligned. Since
// the memory usage up to this point is 1 + 3 + 4 + 1 = 9 bytes, 7 bytes of
// padding needs to be added to ensure that long’s data is 8-byte aligned (i.e.
// starts at the 16th byte) short takes up 2 bytes and can be directly appended
// to the sequence of bits. Up until this point, the memory usage is (1 + 3) + 4
// + (1 + 7) + 8 + 2 = 26 bytes.
//
// Finally, the Foo struct itself also has to be aligned. This is needed so that
// the data that comes after a Foo instance still falls within alignment
// boundaries. From the third rule, Foo takes on the alignment of its largest
// field long, so it itself is 8-byte aligned. As such, 6 bytes of padding is
// added at the end to “round up” the memory layout from 26 to 32 bytes.
#[repr(C)]
#[derive(Default)]
struct Foo {
    tiny: bool, //0 - 1 byte
    normal: u32,//4 - 4 bytes
    small: u8,  //8 - 1 byte
    long: u64,  //16 - 8 byte
    short: u16, //24 - 2 bytes

}

fn main() {
    let layout = Layout::new::<Foo>();
    println!("size = {}", layout.size());
}
