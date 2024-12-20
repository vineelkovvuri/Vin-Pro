use std::convert::From;

#[derive(Debug)]
enum MyError {
    IoError(std::io::Error),
    ParseError(std::num::ParseIntError),
}


// By providing this from implementation, ? operator in parse_file is able to
// convert from two different types to a single MyError error type.
impl From<std::io::Error> for MyError {
    fn from(err: std::io::Error) -> MyError {
        MyError::IoError(err)
    }
}

// By providing this from implementation, ? operator in parse_file is able to
// convert from two different types to a single MyError error type.
impl From<std::num::ParseIntError> for MyError {
    fn from(err: std::num::ParseIntError) -> MyError {
        MyError::ParseError(err)
    }
}

fn parse_file(file_path: &str) -> Result<i32, MyError> {
    let content = std::fs::read_to_string(file_path)?; // Converts `std::io::Error` to `MyError`
    let number: i32 = content.trim().parse()?;         // Converts `ParseIntError` to `MyError`
    Ok(number)
}

fn main()
{

}