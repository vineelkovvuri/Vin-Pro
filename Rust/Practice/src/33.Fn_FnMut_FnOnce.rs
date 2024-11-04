fn main() {
    let mut x = 10;
    let mut FnExample = || {
        // Since we are only referring to environment and x is copyable this
        // closure is of type Fn()
        x
    };

    let mut FnMutExample = || {
        // Since we are referring to environment and modifying x this closure is
        // of type FnMut()
        x = 20;
        x
    };

    let mut s = "Vineel".to_owned();
    let mut FnMutExample2 = || {
        // Since we are referring to environment and modifying x
        // this closure is of type FnMut()
        s = "Vineel Kovvuri".to_owned();

        // No matter how many times this closure is called. The value of s can
        // be safely modified and this function do not need to take ownership of
        // the s.
    };

    let mut s = "Vineel".to_owned();
    let mut FnOnceExample = || {
        // Here we are taking ownership of the s. Hence this function cannot be
        // called more than once
        drop(s)
    };
}
