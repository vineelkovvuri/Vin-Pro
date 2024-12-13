// impl From<A> for B {
//     fn from(a: A) -> B {
//         // convert A to B
//     }
// }

// Because we are implementing this new static "from" method on B, if you have an instance of A you can get to B.
// let a: A = ...;
// let b: B = B::from(a); // like this

// But generally we don't do this becuase it is not rustic enough :-D. Instead we do below

// let b: B = a.into();


// Q. Wait, where does this into() come from? Because I didn't implement any into() function on my A?
// A. Now this gets us in to blanket implementations in Rust. Which a fancy way of saying, implementing something on all types. In other words, doing something like below

//     impl<T> Trait1 for T {
//         ....
//     }

//     Now in case of From what the rust standard library does is, below
//     impl<T, U> Into<U> for T  // For all T implement Into<U>
//     where
//         U: From<T>,           // if U already has an implemenation to convert to T
//     {
//         fn into(self) -> U {
//             U::from(self)
//         }
//     }

//     It provides a blanket implementation of Into<U> trait on all T where U has an implementation of From<T>


//     In other words, This is in a way saying the compiler has implemented the other half for us for free.
//     impl Into<B> for A {
//         fn into(self) -> B {
//             B::from(self)
//         }
//     }

//     So for any given instance of A we can call .into() on it to convert in to the other type.

