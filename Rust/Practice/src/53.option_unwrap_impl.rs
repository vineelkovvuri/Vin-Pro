fn main() {
    let x = Some(10);
    // Used to unwrap the value inside the Option. If there is no value then it
    // panics. This is achived by using a simple `match` clause as shown below.
    x.unwrap();

    let x = Some(10);
    my_unwrap(x);
}

fn my_unwrap(opt: Option<i32>) -> i32 {
    match opt {
        Some(value) => value,
        None => panic!(),
    }
}
