fn main() {
    //--------------------------------------------------------------------------
    // Problem 1: **Map and Multiply** Given an `Option<i32>`, use `map` to
    // multiply the contained value by 10. If the `Option` is `None`, return a
    // `None`.

    let x: Option<i32> = Some(5);
    let _y = x.map(|ele| ele * 10);
    // Expected output: Some(50)

    //--------------------------------------------------------------------------
    // Problem 2: **Chaining with `and_then`** Chain two operations using
    // `and_then` where:
    // 1. Multiply the contained value of `Option<i32>` by 3.
    // 2. Subtract 5 from the result. If any step results in `None`, the final
    // result should be `None`.

    let x: Option<i32> = Some(5);
    // Expected output: Some(10)
    let _y = x
        .and_then(|ele| Some(ele * 3))
        .and_then(|ele| Some(ele - 5));

    //--------------------------------------------------------------------------
    // Problem 3: **Filter Even Numbers** Given an `Option<i32>`, filter out odd
    // numbers using `filter` and return the `Option<i32>` containing the even
    // number. If the number is odd or the `Option` is `None`, return `None`.

    let x: Option<i32> = Some(4);
    let _y = x.filter(|ele| ele % 2 == 0);
    // Expected output: Some(4)

    let _y: Option<i32> = Some(5);
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 4: **Fallback Value Using `or_else`** Given an `Option<i32>`, use
    // `or_else` to provide a fallback value of `Some(10)` if the `Option` is
    // `None`. After that, multiply the result by 5.

    let x: Option<i32> = None;
    let _y = x.or(Some(10)).and_then(|ele| Some(ele * 5));
    // Expected output: Some(50)
    let _y: Option<i32> = Some(2);
    // Expected output: Some(10)

    //--------------------------------------------------------------------------
    // Problem 5: **Chaining with `map` and `filter`** First, map the value of
    // `Option<i32>` to multiply it by 2. Then, filter the result to keep only
    // values greater than 10. If the value doesn’t meet the condition, return
    // `None`.

    let x: Option<i32> = Some(6);
    let _y = x.map(|ele| ele * 2).filter(|ele| ele > &10);
    // Expected output: Some(12)

    let _y: Option<i32> = Some(3);
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 6: **Combining Two `Option`s with `zip`** Given two `Option<i32>`
    // values, use `zip` to combine them into a tuple. After combining, multiply
    // both values and return the result wrapped in `Some`. If either `Option`
    // is `None`, return `None`.

    let x: Option<i32> = Some(4);
    let _y: Option<i32> = Some(3);
    let z = x.zip(y).map(|(a, b)| a * b);
    // Expected output: Some(12)

    //--------------------------------------------------------------------------
    // Problem 7: **Handle `None` Using `unwrap_or`** Given an `Option<i32>`,
    // return the contained value if it’s `Some`. Otherwise, return a default
    // value of 100.

    let x: Option<i32> = Some(5);
    let _y = x.unwrap_or(100);
    // Expected output: 5

    let _y: Option<i32> = None;
    // Expected output: 100

    //--------------------------------------------------------------------------
    // Problem 8: **Chaining with `and_then` and `map`** Given an `Option<i32>`,
    // first check if the value is positive using `and_then` (return `None` if
    // negative). Then, use `map` to square the value.

    let x: Option<i32> = Some(4);
    // My Solution:
    let _y = x
        .and_then(|ele| if ele > 0 { Some(ele) } else { None })
        .map(|ele| ele * ele);
    // ChatGPT Solution:
    let _y = x.filter(|&ele| ele > 0).map(|ele| ele * ele);
    // Expected output: Some(16)

    let _y: Option<i32> = Some(-4);
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 9: **Apply `map` and Filter** Given an `Option<i32>`, first apply
    // `map` to subtract 2 from the value. Then, use `filter` to ensure the
    // result is greater than 0. Return `None` if the result is less than or
    // equal to 0.

    let x: Option<i32> = Some(3);
    let _y = x.map(|ele| ele - 2).filter(|&ele| ele > 0);
    // Expected output: Some(1)

    let _y: Option<i32> = Some(1);
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 10: **Using `flatten` to Combine Nested `Option`s** Given a
    // nested `Option<Option<i32>>`, use `flatten` to "flatten" the structure
    // and then multiply the contained value by 5. If the outer or inner
    // `Option` is `None`, return `None`.

    let x: Option<Option<i32>> = Some(Some(4));
    let _y = x.flatten().map(|ele| ele * 5);
    // Expected output: Some(20)

    let _y: Option<Option<i32>> = Some(None);
    // Expected output: None

    //--------------------------------------------------------------------------
    // Problem 11: **Handle `None` with `unwrap_or_else`** Given an
    // `Option<i32>`, return the contained value if it’s `Some`. If it’s `None`,
    // return a computed value that is the square of 10.

    let x: Option<i32> = Some(5);
    let _y = x.unwrap_or_else(|| 10 * 10);
    // Expected output: 5

    let _y: Option<i32> = None;
    // Expected output: 100

    //--------------------------------------------------------------------------
    // Problem 12: **Combining Multiple Operations with `and_then`** Given an
    // `Option<i32>`, chain multiple `and_then` operations:
    // 1. Multiply the value by 2.
    // 2. Add 10 to the result.
    // 3. Subtract 5.
    // Return the final result wrapped in `Option`.

    let x: Option<i32> = Some(5);
    let _y = x.map(|ele| ele * 2 + 10 - 5);
    let _y = x.and_then(|ele| Some(ele * 2 + 10 - 5));
    // Expected output: Some(15)

    //--------------------------------------------------------------------------
    // Problem 13: **Chaining with `map` and `unwrap_or`** First, use `map` to
    // increment the contained value by 1. Then, use `unwrap_or` to return a
    // default value of 100 if the `Option` is `None`.

    let x: Option<i32> = Some(5);
    let _y = x.map(|ele| ele + 1).unwrap_or(100);
    // Expected output: 6

    let _y: Option<i32> = None;
    // Expected output: 100
}
