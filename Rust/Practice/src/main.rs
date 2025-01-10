#![allow(unused)]

use std::ops::Deref;

struct OuterType<T>(T);

impl<T> Deref for OuterType<T> {
    type Target = T;

    fn deref(&self) -> &Self::Target {
        &self.0
    }
}

impl<T> OuterType<T> {
    fn print1() {
        println!("Function on OuterType");
    }

    fn print2(&self) {
        println!("Method on OuterType");
    }

    fn print3() {
        println!("Function on OuterType");
    }

    fn print4(&self) {
        println!("Method on OuterType");
    }
}

struct InnerType;

impl InnerType {
    fn print1() {
        println!("Function on underlying Type");
    }

    fn print2(&self) {
        println!("Method on underlying Type");
    }

    fn print3(&self) {
        println!("Method on underlying Type");
    }

    fn print4() {
        println!("Function on underlying Type");
    }
}

fn main() {
    let smart_box = OuterType(InnerType);
    smart_box.print1();
    smart_box.print2();
    smart_box.print3();
    smart_box.print4();
    OuterType::<InnerType>::print1();
    // OuterType::<InnerType>::print2();
    OuterType::<InnerType>::print3();
    // OuterType::<InnerType>::print4();
}


// | OuterType | InnerType | smart_box.func()          |
// |-----------|-----------|---------------------------|
// | function  | function  | Do not compile            |
// | method    | method    | Method on OuterType       |
// | function  | method    | Method on underlying Type |
// | method    | function  | Method on OuterType       |

// When Deref trait is implement on OuterType to return InnerType, Rust prefers
// method calls over function calls when using obj_ref.func() syntax. If both
// outer and inner type has method with the same name then outer struct is
// preferred.
