fn main() {
    let mut arr1 = [1u8, 2, 3, 4, 5];
    println!("{:?}", arr1);

    let ref_arr1 = &mut arr1[1..3];
    ref_arr1.reverse();
    println!("{:?}", ref_arr1);
    println!("{:?}", arr1);

    println!("-----------------");

    let arr1 = [1, 2,3,4,5,6,7];
    let ref_arr1 = &arr1;
    let chunks = ref_arr1.chunks(2);
    println!("{:?}", arr1);

    for chunk in chunks {
        println!("{:?}", chunk);
    }
}
