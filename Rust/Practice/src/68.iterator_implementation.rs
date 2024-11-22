// Below is an example of how Iterators work, CountUpDown do not produce new
// iterator objects but instead acts itself as a single iterator object whose
// state gets modified as we use it. Hence in the examples we are recreating the
// CountUpDown object multiple times
struct CountUpDown {
    current: u32,
    min: u32,
    max: u32,
}

impl CountUpDown {
    pub fn new(current: u32, min: u32, max: u32) -> Self {
        Self { current, min, max }
    }
}

impl Iterator for CountUpDown {
    type Item = u32;

    fn next(&mut self) -> Option<Self::Item> {
        if self.current == self.max {
            None
        } else {
            let curr = self.current;
            self.current = self.current + 1;
            Some(curr)
        }
    }
}

impl DoubleEndedIterator for CountUpDown {
    fn next_back(&mut self) -> Option<Self::Item> {
        if self.current == self.min {
            None
        } else {
            let curr = self.current;
            self.current = self.current - 1;
            Some(curr)
        }
    }
}

fn main() {
    let count_up_down = CountUpDown::new(10, 0, 20);
    println!("--------normal iteration-------");
    for c in count_up_down {
        println!("{}", c);
    }

    println!("--------rev iteration-------");
    let count_up_down = CountUpDown::new(10, 0, 20);
    // we are able to call rev() on count_up_down because CountUpDown satisfies
    // the DoubleEndedIterator requirement bound on rev() function. --.
    //                                                                |
    //         fn rev(self) -> Rev<Self>                              |
    //         where                                                  |
    //             Self: Sized + DoubleEndedIterator,    <------------'
    //         {
    //             Rev::new(self)
    //         }

    // Now when the for loop calls next() on the final iterator(Rev) implemented
    // on Rev struct, this internally calls next_back() on the iterator
    //
    //       impl<I> Iterator for Rev<I>
    //       where
    //           I: DoubleEndedIterator,
    //       {
    //           type Item = <I as Iterator>::Item;
    //           fn next(&mut self) -> Option<<I as Iterator>::Item> {
    //               self.iter.next_back()
    //           }
    for c in count_up_down.rev() {
        println!("{}", c);
    }

    // Calling rev() on the iterator encapsulate the iterator inside a Rev
    // struct
    //
    //             Rev::new(self)
    //
    // So calling rev() multiple times like below will encapsulate the Rev
    // struct inside a Rev struct
    //
    // ┌────────────────────────┐
    // │  Rev                   │
    // │   ┌────────────────┐   │
    // │   │  Rev           │   │
    // │   │   ┌─────────┐  │   │
    // │   │   │  Iter   │  │   │
    // │   │   └─────────┘  │   │
    // │   │                │   │
    // │   └────────────────┘   │
    // │                        │
    // └────────────────────────┘
    println!("--------rev rev iteration-------");
    let count_up_down = CountUpDown::new(10, 0, 20);
    // On top of this, since DoubleEndedIterator trait extends Iterator, we can
    // call rev() again and again. Now, ultimately when the for loop calls
    // next() on the outer iterator(Rev), this internally calls next_back() on --.
    // the iterator inside it. Since the inside iterator(Rev) implements         |
    // DoubleEndedIterator this next_back() call will in turn calls the next()---+--.
    // method on inner most iterator.                                            |  |
    //                                                                           |  |
    //       impl<I> Iterator for Rev<I>                                         |  |
    //       where                                                               |  |
    //           I: DoubleEndedIterator,                                         |  |
    //       {                                                                   |  |
    //           type Item = <I as Iterator>::Item;                              |  |
    //           fn next(&mut self) -> Option<<I as Iterator>::Item> {           |  |
    //               self.iter.next_back()    <----------------------------------'  |
    //           }                                                                  |
    //                                                                              |
    //       impl<I> DoubleEndedIterator for Rev<I>                                 |
    //       where                                                                  |
    //           I: DoubleEndedIterator,                                            |
    //       {                                                                      |
    //           fn next_back(&mut self) -> Option<<I as Iterator>::Item> {         |
    //               self.iter.next()         <-------------------------------------'
    //           }
    for c in count_up_down.rev().rev() {
        println!("{}", c);
    }
}
