use std::fs;

fn main() {}

// Problem 1: Chaining Results
// Implement a function parse_and_divide(input: &str, divisor: i32) -> Result<f64, String>.
// input is a string that represents a number (e.g., "42").
// Parse input into an i32. If parsing fails, return an error with the message
// "Invalid number".
// Divide the parsed number by divisor. If divisor is zero, return an error with
// the message "Division by zero".
// Return the result as a f64.
// Constraints: Use the and_then or map helper methods to chain operations.
fn parse_and_divide(input: &str, divisor: i32) -> Result<f64, String> {
    input
        .parse::<i32>()
        .map_err(|_| "Invalid number".to_string())
        .and_then(|ele| {
            if divisor != 0 {
                Ok(ele as f64 / divisor as f64)
            } else {
                Err("Division by Zero".to_string())
            }
        })
}

// Problem 2: Collecting Results
// Write a function parse_numbers(inputs: Vec<&str>) -> Result<Vec<i32>, String> that:
// Takes a vector of strings (e.g., vec!["10", "20", "abc", "40"]).
// Attempts to parse each string into an i32.
// If all parsing succeeds, return a vector of the parsed numbers.
// If any string fails to parse, return the error "Parsing failed".
// Hint: Use Iterator::collect() to handle the Result.
fn parse_numbers(inputs: Vec<&str>) -> Result<Vec<i32>, String> {
    inputs
        .into_iter()
        .map(|ele| ele.parse::<i32>().map_err(|_| "Parsing failed".to_string()))
        .collect()
}

// Problem 3: Matching Results
// Implement a function fetch_user_age(user_id: u32) -> Result<u8, String> with the following logic:
// If user_id is 0, return an error "User not found".
// If user_id is odd, return an error "Invalid user ID".
// Otherwise, return the age 25.
// Write a test function that:
// Calls fetch_user_age with different user_id values.
// Prints "Age: X" if the result is Ok(X).
// Prints "Error: Y" if the result is Err(Y).
// Constraint: Use match or if let syntax to handle the Result.

fn fetch_user_age(user_id: u32) -> Result<u8, String> {
    (user_id != 0)
        .then(|| ()) // convert to option
        .ok_or("User not found".to_string())?;

    (user_id % 2 == 0)
        .then(|| ())
        .ok_or("Invalid user ID".to_string())?;

    Ok(25)
}

// Problem 4: Combining Results
// Implement a function safe_math_operations(a: i32, b: i32) -> Result<i32, String> that:
// Adds, subtracts, and multiplies a and b.
// Returns the first encountered error:
// "Addition overflow" if addition overflows.
// "Subtraction overflow" if subtraction overflows.
// "Multiplication overflow" if multiplication overflows.
// Hint: Use methods like checked_add, checked_sub, and checked_mul.
fn safe_math_operations(a: i32, b: i32) -> Result<i32, String> {
    a.checked_add(b).ok_or("Addition overflow".to_string())?;
    a.checked_sub(b).ok_or("Subtraction overflow".to_string())?;
    a.checked_mul(b)
        .ok_or("Multiplication overflow".to_string())
}

// Problem 5: Transforming Errors
// Write a function read_file(file_path: &str) -> Result<String, String> that:
// Reads a file's contents and returns it as a String.
// If the file doesn't exist, transform the std::io::Error into a custom error message "File not found: {file_path}".
// Hint: Use the map_err helper method.
fn read_file(file_path: &str) -> Result<String, String> {
    fs::read_to_string(file_path).map_err(|_| format!("File not found: {}", file_path))
}

// Problem 6: Nested Results
// Implement a function validate_and_calculate(input: Option<Result<i32, String>>) -> Result<i32, String> that:
// Takes an Option<Result<i32, String>>.
// If the Option is None, return an error "No input provided".
// If the inner Result is Err, propagate the error.
// If the inner Result is Ok, return double the value.
// Hint: Use and_then and unwrap_or.
fn validate_and_calculate(input: Option<Result<i32, String>>) -> Result<i32, String> {
    input.unwrap_or("No input provided").and_then(|ele| ele * 2)
}

// Problem 7: Short-Circuiting
// Create a function check_credentials(username: &str, password: &str) -> Result<(), String> that:
// Ensures username is not empty. Return an error "Username cannot be empty" if it is.
// Ensures password is at least 8 characters long. Return an error "Password too short" if it isn't.
// If both checks pass, return Ok(()).
// Constraint: Use the ? operator to short-circuit on errors.
fn check_credentials(username: &str, password: &str) -> Result<(), String> {
    (!username.is_empty())
        .then(|| ())
        .ok_or("Username cannot be empty".to_string())?;
    (password.len() < 8)
        .then(|| ())
        .ok_or("Password too short".to_string())?;

    Ok(())
}

// Problem 8: Custom Result with Chaining
// Given the custom types:
pub type MyResult<T> = Result<T, MyError>;
#[derive(Debug, PartialEq)]
pub enum MyError {
    InvalidData,
    PermissionDenied,
}
// Implement a function process_request(data: Option<&str>, authorized: bool) -> MyResult<i32>:
// If data is None, return MyError::InvalidData.
// If authorized is false, return MyError::PermissionDenied.
// Otherwise, parse data as an i32 and return the value multiplied by 2.

fn process_request(data: Option<&str>, authorized: bool) -> MyResult<i32> {
    data.ok_or(MyError::InvalidData).and_then(|ele| {
        if !authorized {
            Err(MyError::PermissionDenied)
        } else {
            ele.parse::<i32>()
                .map_err(|_| MyError::InvalidData)
                .map(|x1| x1 * 2)
        }
    })
}
