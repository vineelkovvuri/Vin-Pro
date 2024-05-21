// use std::alloc::Layout;

// fn main() {
//     let x = Layout::from_size_align(11, 2);
//     match x {
//         Ok(layout) => {println!("{:#?}", layout);}
//         Err(e) => {println!("{:#?}", e);}
//     }
// }


fn main() {
    let x: f64 = 10f64;

    println!("to_le_bytes: {:?}", x.to_le_bytes());
    println!("to_be_bytes: {:?}", x.to_be_bytes());
    println!("to_ne_bytes: {:?}", x.to_ne_bytes());
}
