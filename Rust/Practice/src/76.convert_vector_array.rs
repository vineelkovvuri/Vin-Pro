fn main() {
    // Vector implements TryFrom as shown below
    // impl<T, A: Allocator, const N: usize> TryFrom<Vec<T, A>> for [T; N] {
    //      fn try_from(mut vec: Vec<T, A>) -> Result<[T; N], Vec<T, A>> {
    //          if vec.len() != N {
    //              return Err(vec);
    //          }
    let arr: [i32; 5] = vec![1, 2, 3, 4, 5].try_into().unwrap();
    dbg!(arr);
}
