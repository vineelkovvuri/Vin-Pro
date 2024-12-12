fn main() {
    let source_list: &[i32] = &[1, 2, 3, 5, 10, 20];
    let sub_list: &[i32] = &[3, 5];

    let found_sub_list = source_list
        .windows(sub_list.len())
        .any(|window| window == sub_list);
    println!("found_sub_list = {}", found_sub_list);
}
