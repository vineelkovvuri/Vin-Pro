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

    // Update value of an array via write_bytes()
    let mut arr1 = [1, 2, 3, 4, 5];
    let ptr_arr1: *mut i32 = &mut arr1[0];
    unsafe {
        ptr_arr1.write_bytes(0xff, arr1.len());
        println!("{:?}", arr1);
    }

    // alignment offset for the pointer
    let x = 10;
    let ptr_x: *const i32 = &x;

    println!("ptr_x={:p} {}", ptr_x, ptr_x.align_offset(16));
    // for ptr_x=0x88d83ff544 3 <-- this is the alignment because. 0x88d83ff544
    // means 9233232516516. When  9233232516516 is divided by 16 we get
    // 9233232516516 = 577077032282 × 16 + 4. Since the remainder is 4 we need
    // another 12 bytes to make it align to next 16 byte boundary. 12 bytes is
    // nothing but 3 i32s. Hence align_offset return 3
    // The offset is expressed in number of T elements, and not bytes

    // C type casting from int to bool conversion
    let x = 4; // <-- rust don't normal treat integers as booleans like C
    let ptr_x: *const i32 = &x;
    unsafe {
        let ptr_y: *const bool = ptr_x.cast();
        let y = *ptr_y;
        println!("{}", y); // this will print true
    }

    // creating a null pointer
    let x: *const i32 = core::ptr::null();
    println!("{:?}", x); // prints 0x0
}
