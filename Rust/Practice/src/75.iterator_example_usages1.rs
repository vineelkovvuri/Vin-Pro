fn main() {
    // 1. Find All Even Numbers
    // Given a vector of integers, find all even numbers and collect them into a new vector.
    let numbers = vec![1, 2, 3, 4, 5, 6, 7, 8, 9];
    let _evens: Vec<i32> = numbers.into_iter().filter(|ele| ele % 2 == 0).collect();

    // 2. Calculate the Sum of Squares
    // Given a vector of integers, calculate the sum of the squares of all elements.
    let numbers = vec![1, 2, 3, 4];
    let _sum: i32 = numbers.into_iter().map(|ele| ele * ele).sum();

    // 3. Find the First Number Greater Than X
    // Write a function to find the first number in an iterator that is greater
    // than a given value `x`. If no such number exists, return `None`.
    // Input:
    let numbers = vec![3, 7, 1, 9, 5];
    let x = 6;
    // Output:
    let output = numbers.into_iter().find(|&ele| ele == x);
    // Some(7)

    // -------------------------------

    // 4. Flatten Nested Vectors
    // Given a vector of vectors, flatten it into a single vector.

    // Input:
    let nested = vec![vec![1, 2], vec![3, 4, 5], vec![6]];
    let output: Vec<i32> = nested.into_iter().flatten().collect();
    // Output:
    // [1, 2, 3, 4, 5, 6]

    // -------------------------------

    // 5. Group Words by Length
    // Given a vector of words, group the words by their lengths into a `HashMap`.
    // Input:
    // let words = vec!["apple", "banana", "cat", "dog", "elephant"];

    // Output:
    // {3: ["cat", "dog"], 5: ["apple"], 6: ["banana"], 8: ["elephant"]}

    // -------------------------------

    // 6. Count the Frequency of Characters
    // Write a function to count the frequency of each character in a string.

    // Input:
    // let input = "hello world";

    // Output:
    // {'h': 1, 'e': 1, 'l': 3, 'o': 2, ' ': 1, 'w': 1, 'r': 1, 'd': 1}

    // -------------------------------

    // 7. Find the Maximum Value
    // Write a function to find the maximum value in an iterator of integers. If
    // the iterator is empty, return `None`.
    // Input:
    let numbers = vec![10, 20, 30, 5, 15];
    let output = numbers.into_iter().max();
    // Output:
    // Some(30)

    // -------------------------------

    // 8. Generate Fibonacci Sequence
    // Generate the first `n` Fibonacci numbers using an iterator.
    // Input:
    // let n = 6;
    // let output = (1..=n).map()

    // Output:
    // [0, 1, 1, 2, 3, 5]

    // -------------------------------

    // 9. Skip and Take
    // Given a vector of numbers, skip the first 3 elements and take the next 5 elements.

    // Input:
    let numbers = vec![1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    let output: Vec<i32> = numbers.into_iter().skip(3).take(5).collect();
    // Output:
    // [4, 5, 6, 7, 8]

    // -------------------------------

    // 10. Zipping Two Iterators
    // Given two vectors of the same length, zip them into a vector of tuples, where each tuple contains elements from both vectors at the same index.

    // Input:
    let vec1 = vec![1, 2, 3];
    let vec2 = vec!['a', 'b', 'c'];
    let output: Vec<(i32, char)> = vec1.into_iter().zip(vec2).collect();
    // Output:
    // [(1, 'a'), (2, 'b'), (3, 'c')]

    // -------------------------------

    // 11. Filter and Find the Product
    // Given a vector of integers, filter out all odd numbers, multiply the remaining even numbers together, and return the result. If no even numbers exist, return 1.

    // Input:
    let numbers = vec![3, 7, 2, 4, 6, 9];
    let output: i32 = numbers.into_iter().filter(|&ele| ele % 2 == 0).product();

    // Output:
    // 48  // 2 * 4 * 6

    // -------------------------------

    // 12. Chunk Processing
    // Divide a vector into chunks of size `n` and collect the chunks into a vector of vectors.

    // Input:
    let numbers = vec![1, 2, 3, 4, 5, 6, 7];
    let chunk_size = 3;
    let _output: Vec<Vec<i32>> = numbers
        .chunks(chunk_size)
        .map(|chunk| chunk.to_vec())
        .collect();

    // Output:
    // [[1, 2, 3], [4, 5, 6], [7]]
}
