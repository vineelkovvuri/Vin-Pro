fn main() {
    let array = core::array::from_fn::<_, 4, _>(|i| i);
    // indexes are:    0  1  2  3  4
    assert_eq!(array, [0, 1, 2, 3]);

    let array = core::array::from_fn::<_, 4, _>(|i| i);
    // indexes are:    0  1  2  3  4
    assert_eq!(array, [0, 1, 2, 3]);

}
