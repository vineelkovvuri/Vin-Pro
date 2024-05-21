#[derive(Debug)]
struct Book {
    k: i32,
    l: i32,
}

fn main() {
    let x = 123;
    let ptr: *const u64 = &x;
    let b = Book { k: 10, l: 20 };
    let bptr: *const Book = &b;

    println!("ptr: {:?}", ptr);
    println!("bptr: {:?}", bptr);
    unsafe {
        println!("*ptr: {:?}", *ptr);
        println!("*bptr: {:?}", *bptr);
    }

    println!("&b.l: {:p}", &b.l); // print the address of the field
    println!("core::ptr::addr_of!(b.l): {:p}", core::ptr::addr_of!(b.l));

    unsafe {
        // accessing fields in a struct and dumping their values
        println!("*&b.l: {:?}", *&b.l);
        println!("*core::ptr::addr_of!(b.l): {:?}", *core::ptr::addr_of!(b.l));
    }

    println!("is_null: {:?}", ptr.is_null());

    unsafe {
        println!("offset: {:?}", ptr.offset(3)); // same as saying ptr + 3 in C
        println!("byte_offset: {:?}", ptr.byte_offset(1)); // same as saying (byte*)ptr + 1 in C
    }

    unsafe {
        let ptr2 = ptr.offset(3); // same as saying ptr + 3 in C
        println!("offset_from: {:?}", ptr2.offset_from(ptr)); // same as saying ptr2 - ptr in C
        println!("byte_offset_from: {:?}", ptr2.byte_offset_from(ptr)); // same as saying (byte*)ptr2 - (byte*)ptr in C
    }

    // Perform low level array copy
    let arr1 = [1, 2, 3, 4, 5];
    let mut arr2 = [0; 5];
    let mut arr3 = [0; 5];

    let ptr_arr1: *const i32 = &arr1[0];
    let ptr_arr2: *mut i32 = &mut arr2[0];
    let ptr_arr3: *mut i32 = &mut arr3[0];

    unsafe {
        ptr_arr2.copy_from(ptr_arr1, arr1.len());
        println!("{:?}", arr2);
        ptr_arr2.copy_to(ptr_arr3, arr2.len());
        println!("{:?}", arr3);
    }

    // Update value of x via pointer directly or via write()
    let mut x = 10;
    let ptr_x: *mut i32 = &mut x;

    unsafe {
        *ptr_x = 20;
        println!("x = {}", x);

        ptr_x.write(30);
        println!("x = {}", x);
    }

}
