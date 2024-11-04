fn main() {
    let x  = 123;

    println!("number of set bits: {:?}", i32::count_ones(x));
    println!("number of cleared bits: {:?}", i32::count_zeros(x));
    println!("number of leading ones: {:?}", i32::leading_ones(x));
    println!("number of leading zeros: {:?}", i32::leading_zeros(x));
    println!("number of trailing ones: {:?}", i32::trailing_ones(x));
    println!("number of trailing zeros: {:?}", i32::trailing_zeros(x));
}
