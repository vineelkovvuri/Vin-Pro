use std::{ops::Deref, process::Command};

#[allow(dead_code)]
fn reverse(mut num: i32) -> i32 {
    let mut rev: i32 = 0;

    while num != 0 {
        rev = rev * 10 + num % 10;
        num /= 10;
    }

    rev
}

#[allow(dead_code)]
fn command_exec() {
    let mut cmd = Command::new("git");
    cmd.args(["log", "-10"]);
    let res = cmd.output().unwrap();

    println!("{}", String::from_utf8(res.stdout).unwrap());
}

struct Author {
    name: String,
}

struct Book {
    // author: Author,
    author: String,
}

fn main() {
    // let mut b = Book {
    //     author: "Rust".to_string(),
    // };

    // b = Book {
    //     author: "Rust++".to_string(),
    // };

    // let mut f = || println!("Rust");
    // f = || println!("Rust++");  // <-- This do not work
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn positive_test_reverse() {
        let rev = reverse(123);

        assert_eq!(rev, 321);
    }
}
