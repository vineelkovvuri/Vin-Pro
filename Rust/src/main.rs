use std::process::Command;

#[allow(dead_code)]
fn reverse(mut num: i32) -> i32 {
    let mut rev = 0;

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
    let res = cmd.output().unwrap() ;

    println!("{}", String::from_utf8(res.stdout).unwrap());
}

fn main() {
    command_exec();
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
