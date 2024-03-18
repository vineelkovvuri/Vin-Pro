
fn reverse(mut num: i32) -> i32 {
    let mut rev = 0;

    while num != 0 {
        rev = rev * 10 + num % 10;
        num /= 10;
    }

    rev
}


fn main() {

}




#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn postive_test_reverse() {
        let rev = reverse(123);

        assert_eq!(rev, 321);
    }
}

