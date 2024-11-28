use std::iter;

fn main() {
    // successors() usage
    let arr: Vec<i32> = iter::successors(Some(1), |&ele| Some(ele * 2))
        .take(10)
        .collect();
    dbg!(arr);

    // generate fibonacci sequence
    let fib: Vec<_> = iter::successors(Some((0, 1)), |&ele| Some((ele.1, ele.0 + ele.1)))
        .map(|ele| ele.0)
        .take(10)
        .collect();
    dbg!(fib);

    // generate factorial sequence
    let fact: Vec<_> = iter::successors(Some((1, 2)), |&ele| Some((ele.0 * ele.1, ele.1 + 1)))
        .take(10)
        .map(|ele| ele.0)
        .collect();
    dbg!(fact);
}
