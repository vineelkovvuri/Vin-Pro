fn main() {
    //--------------------------------------------------------------------------
    // Problem 1: **Chaining Operations with `and_then`**
    // Given an `Option<i32>`, chain two `and_then` operations:
    // 1. Multiply the contained value by 4.
    // 2. Add 10 to the result.
    // If any step returns `None`, return `None`.

    let x: Option<i32> = Some(3);
    let y = x
        .and_then(|ele| Some(ele * 4))
        .and_then(|ele| Some(ele + 10));
    // Expected output: Some(22)

    //--------------------------------------------------------------------------
    // Problem 2: **Default Value with `unwrap_or`** Given an `Option<i32>`, use
    // `unwrap_or` to provide a default value of `42` if the `Option` is `None`.

    let x: Option<i32> = Some(5);
    let y = x.unwrap_or(42);
    // Expected output: 5

    let y: Option<i32> = None;
    // Expected output: 42

    //--------------------------------------------------------------------------
    // Problem 3: **Mapping to a String** Given an `Option<i32>`, map it to a
    // string that describes whether the number is positive or negative. If
    // `None`, return "No value".

    let x: Option<i32> = Some(-3);
    // My Solution:
    let y = x
        .map(|ele| if ele >= 0 { "Positive" } else { "Negative" })
        .or(Some("No value"));
    // ChatGPT Solution:
    let y = x.map_or(
        "No value",
        |ele| if ele >= 0 { "Positive" } else { "Negative" },
    );
    // Expected output: "Negative"

    let y: Option<i32> = Some(5);
    // Expected output: "Positive"

    let z: Option<i32> = None;
    // Expected output: "No value"

    //--------------------------------------------------------------------------
    // Problem 4: **Combine `Option` Values with `zip`** Given two `Option<i32>`
    // values, use `zip` to combine them into a tuple. If either of them is
    // `None`, return `None`.

    let x: Option<i32> = Some(3);
    let y: Option<i32> = Some(5);
    let z = x.zip(y);
    // Expected output: Some((3, 5))

    let a: Option<i32> = Some(3);
    let b: Option<i32> = None;
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 5: **Return the First Non-None Option** Given a sequence of
    // `Option<i32>` values, return the first `Some` value or `None` if all are
    // `None`.

    let x: Vec<Option<i32>> = vec![None, None, Some(3), Some(5)];
    let y = x.into_iter().find_map(|ele| ele.and_then(|ele| Some(ele)));
    // Expected output: Some(3)

    let y: Vec<Option<i32>> = vec![None, None, None];
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 6: **`map` with Strings** Given an `Option<String>`, convert the
    // string to uppercase. If the `Option` is `None`, return `None`.

    let x: Option<String> = Some("hello".to_string());
    let y = x.map(|ele|ele.to_uppercase());
    // Expected output: Some("HELLO")

    let y: Option<String> = None;
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 7: **Chaining `map` and `filter`** Given an `Option<i32>`, first
    // apply `map` to double the value, and then use `filter` to keep only even
    // numbers. If the final result is odd or `None`, return `None`.

    let x: Option<i32> = Some(3);
    let y = x.map(|ele| ele * 2).filter(|&ele| ele % 2 == 0);
    // Expected output: None

    let y: Option<i32> = Some(5);
    // Expected output: Some(10)

    let z: Option<i32> = Some(4);
    // Expected output: Some(8)

    //--------------------------------------------------------------------------
    // Problem 8: **Handle Missing Value with `unwrap_or_else`** Given an
    // `Option<i32>`, use `unwrap_or_else` to provide a default value calculated
    // as the square of `10` when the `Option` is `None`.

    let x: Option<i32> = Some(5);
    let y = x.unwrap_or_else(|| 10 * 10);
    // Expected output: 5

    let y: Option<i32> = None;
    // Expected output: 100

    //--------------------------------------------------------------------------
    // Problem 9: **Filter Out Negative Numbers** Given an `Option<i32>`, filter
    // out negative numbers. If the number is negative or the `Option` is
    // `None`, return `None`.

    let x: Option<i32> = Some(5);
    let y = x.filter(|&ele| ele >= 0);
    // Expected output: Some(5)

    let y: Option<i32> = Some(-3);
    // Expected output: None

    let z: Option<i32> = None;
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 10: **`flatten` a Nested `Option`** Given a nested
    // `Option<Option<i32>>`, use `flatten` to unwrap the inner `Option`, then
    // multiply the contained value by 5. If either `Option` is `None`, return
    // `None`.

    let x: Option<Option<i32>> = Some(Some(3));
    let y = x.flatten().map(|ele| ele * 5);
    // Expected output: Some(15)

    let y: Option<Option<i32>> = Some(None);
    // Expected output: None

    let z: Option<Option<i32>> = None;
    // Expected output: None
}
