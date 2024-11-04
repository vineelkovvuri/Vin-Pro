fn split_example(string: &str, split_char: &str) -> u32 {
    let split_iter = string.split(split_char);

    // If we only need the count of splits. We can get the info from count()
    // method.
    split_iter.count() as u32

    // we could have exhaustively traverse over the iterator like below
    // if we need the individual slice.
    // let mut count = 0u32;
    // for split in split_iter {
    //     println!("{}", split);
    //     count += 1;
    // }

    // count
}

fn main() {
    let count = split_example(r"the quick brown fox jumps over the lazy dog", " ");
    println!("{}", count);
}
