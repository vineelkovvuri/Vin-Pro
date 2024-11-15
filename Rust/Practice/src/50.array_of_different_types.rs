use std::fmt::Display;

fn main() {
    // With the help of trait bounds(for example Display trait here), we can old
    // different type of object in to an vector and print them
    let array: Vec<Box<dyn Display>> = vec![Box::new(10), Box::new("asfasdf")];
    for arr in array {
        println!("{}", arr);
    }

    // More static way
    let array: [Box<dyn Display>; 2] = [Box::new(10), Box::new("asfasdf")];
    for arr in array {
        println!("{}", arr);
    }
}
