fn main() {
    let x = Some(19);
    let _y = x.map(|v| v * 2);

    let x = Some(19);
    let _y = x.map_or(10.0, |v| v as f32 * 2.0);

    let x = Some(19);
    let _y = x.map_or(10.0, |v| v as f32 * 2.0);

    // Problem 1: Basic Option Manipulation. Write a function get_first_element
    // that takes a vector of integers and returns the first element as an
    // Option<i32>. Use the Option::unwrap_or method to return -1 if the vector
    // is empty.
    let x = vec![10, 20, 30];
    let _y = x.get(0).unwrap_or(&-1);

    // Problem 2: Mapping Over Options. Write a function double_if_some that
    // takes an Option<i32> and doubles its value if it is Some. Use the
    // Option::map method.
    let x = Some(20);
    let _y = x.map(|x| 2 * x);

    // Problem 3: Combining Options. Write a function sum_options that takes two
    // Option<i32> and returns their sum as an Option<i32>. If either value is
    // None, return None. Use the Option::zip method.
    let x1 = Some(20);
    let x2 = Option::<i32>::None;
    let _y = x1.zip(x2).map(|(a, b)| a + b);

    // Problem 4: Unwrapping Options. Write a function get_username that takes an
    // Option<&str> and returns the username. If the input is None, return
    // "Guest" using the Option::unwrap_or_else method.
    let x = Some("Vineel");
    let _y = x.unwrap_or("Guest");

    // Problem 5: Chaining Options. Write a function find_user that takes a
    // Vec<Option<&str>> representing usernames and a username to find. Return
    // the first Some(username) that matches, or None if not found. Use the
    // Iterator::find and Option::and_then methods.
    let x = vec![Some("Riya"), Some("Vihaan")];
    let _y = x
        .into_iter()
        .find_map(|ele| ele.and_then(|ele| (ele == "Riya").then(|| ele)));

    // Problem 6: Using Option with Results. Write a function safe_divide that
    // takes two integers, a and b, and returns an Option<i32>. Return
    // Some(result) if b != 0, otherwise None. Use the Option::ok_or method to
    // convert this to a Result<i32, &'static str>.
    let x1 = 10;
    let x2 = 20;
    let _y = (if x2 != 0 { Some(x1 / x2) } else { None }).ok_or("Division by zero");
    let _y = (x2 != 0).then(|| x1 / x2).ok_or("Division by zero");

    // Problem 7: Flattening Options. Write a function merge_options that takes
    // an Option<Option<i32>> and returns a flattened Option<i32> using
    // Option::flatten
    let x = Some(Some("Riya"));
    let _y = x.flatten();

    // Problem 8: Filtering Options. Write a function filter_even that takes an
    // Option<i32> and returns the number only if it is even. Use
    // Option::filter.
    let x = Some(10);
    let _y = x.filter(|ele| ele % 2 == 0);

    // Problem 9: Handling Nested Options. Write a function extract_value that
    // takes a nested Option<Option<i32>> and returns the value multiplied by 10
    // if present. Use Option::and_then.
    let x = Some(Some(5));
    let _y = x.and_then(|x2| x2.and_then(|x3| Some(10 * x3)));

    // Problem 10: Iterating Over Option. Write a function option_to_vec that
    // converts an Option<i32> into a Vec<i32>. If the Option is Some, return a
    // vector with that value; otherwise, return an empty vector. Use the
    // Option::iter method.
    // My Version:
    let x = Some(5);
    let _y = x.map(|ele| vec![ele]).unwrap_or(vec![]);
    // ChatGPT Version:
    let x = Some(5);
    let _y: Vec<i32> = x.into_iter().collect();

    // Problem 11: Converting Option to a Boolean. Write a function is_positive
    // that takes an Option<i32> and returns true if the value is Some and
    // positive, otherwise false. Use Option::map and unwrap_or.
    let x = Some(5);
    let _y = x.map(|ele| ele > 0).unwrap_or(false);

    // Problem 12: Nested Option Transformation. Write a function
    // increment_inner that takes an Option<Option<i32>> and increments the
    // inner value if it exists. Use Option::and_then
    let increment_inner =
        |x: Option<Option<i32>>| x.and_then(|ele| Some(ele.and_then(|x1| Some(x1 + 1))));
    assert_eq!(increment_inner(Some(Some(3))), Some(Some(4)));
    assert_eq!(increment_inner(Some(None)), Some(None));
    assert_eq!(increment_inner(None), None);

    // Problem 13: Default Value with unwrap_or_default. Write a function
    // get_default_value that takes an Option<String> and returns the contained
    // value or "Default" if None. Use Option::unwrap_or_default.
    let get_default_value = |x: Option<String>| x.unwrap_or("Default".to_string());
    assert_eq!(get_default_value(Some("Hello".to_string())), "Hello");
    assert_eq!(get_default_value(None), "Default");

    // Problem 14: Filter and Transform. Write a function get_even_number that
    // takes an Option<i32> and returns the doubled value of the number if it is
    // even. Return None otherwise. Use Option::filter and Option::map
    let get_even_number = |x: Option<i32>| x.filter(|ele| ele % 2 == 0).map(|ele| ele * 2);
    assert_eq!(get_even_number(Some(4)), Some(8));
    assert_eq!(get_even_number(Some(5)), None);
    assert_eq!(get_even_number(None), None);

    // Problem 15: Option with Custom Types. Define a struct User with a field
    // age: Option<u32>. Write a function can_vote that takes a User and returns
    // true if the user's age is Some and at least 18, otherwise false.
    struct User {
        age: Option<u32>,
    }

    let user1 = User { age: Some(20) };
    let user2 = User { age: Some(15) };
    let user3 = User { age: None };
    let can_vote = |x: &User| x.age.unwrap_or(0) > 18;

    assert_eq!(can_vote(&user1), true);
    assert_eq!(can_vote(&user2), false);
    assert_eq!(can_vote(&user3), false);

    // Problem 16: Option-Based Iterator. Write a function sum_some_numbers that
    // takes a vector of Option<i32> and returns the sum of all numbers inside
    // Some. Use Iterator::filter_map
    let sum_some_numbers = |x: Vec<Option<i32>>| {
        // My Version:
        // x.into_iter().fold(0, |acc, ele| acc + ele.unwrap_or_default())
        // ChatGPT Version:
        x.into_iter().flatten().sum::<i32>()
    };
    assert_eq!(sum_some_numbers(vec![Some(1), None, Some(3), Some(5)]), 9);
    assert_eq!(sum_some_numbers(vec![None, None, None]), 0);

    // Problem 17: Finding Maximum with Options. Write a function find_max that
    // takes a vector of Option<i32> and returns the maximum value as an
    // Option<i32>. Use iterators and Option::copied.

    let find_max = |x: Vec<Option<i32>>| x.into_iter().flatten().max();
    assert_eq!(find_max(vec![Some(1), Some(3), None, Some(2)]), Some(3));
    assert_eq!(find_max(vec![None, None]), None);

    // Problem 18: Chain Default Values. Write a function get_final_value that
    // takes two Option<i32> values a and b. If a is Some, return its value.
    // Otherwise, return b. Use Option::or.
    let get_final_value = |a: Option<i32>, b: Option<i32>| a.or(b);

    assert_eq!(get_final_value(Some(10), Some(20)), Some(10));
    assert_eq!(get_final_value(None, Some(20)), Some(20));
    assert_eq!(get_final_value(None, None), None);

    // Problem 19: Composing Results and Options. Write a function process_input
    // that takes an Option<i32>. If the value is None, return an error as
    // Result::Err. If the value is Some, double it and return it as Result::Ok.
    // Use Option::ok_or
    let process_input = |a: Option<i32>| a.ok_or("No input provided").map(|ele| ele * 2);

    assert_eq!(process_input(Some(5)), Ok(10));
    assert_eq!(process_input(None), Err("No input provided"));

    // Problem 20: Advanced Combination. Write a function merge_and_transform
    // that takes two Option<&str> values, first and second. If both are Some,
    // concatenate them and return the result as Option<String>. If either is
    // None, return None. Use Option::zip
    let merge_and_transform =
        |a: Option<&str>, b: Option<&str>| a.zip(b).map(|(a, b)| a.to_string() + b);

    assert_eq!(
        merge_and_transform(Some("Hello"), Some("World")),
        Some("HelloWorld".to_string())
    );
    assert_eq!(merge_and_transform(Some("Hello"), None), None);
    assert_eq!(merge_and_transform(None, None), None);
}
