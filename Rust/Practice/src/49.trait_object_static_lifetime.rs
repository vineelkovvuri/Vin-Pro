pub trait PageAllocator {
    fn allocate_page(&mut self);
}

// Every trait object(dyn Trait) have lifetime of 'static - Meaning creation of
// that object requires any of its parts to have 'static lifetime. In the
// following example since we want to Box an object which implements
// PageAllocator, Before Boxing that object, we need to make sure that object
// will have 'static lifetime. So because of that, below code will fail to
// compile with below error
//
// --> src/main.rs:6:5
// |
// 6 |     Box::new(page_allocator)
// |     ^^^^^^^^^^^^^^^^^^^^^^^^
// |     |
// |     the parameter type `A` must be valid for the static lifetime...
// |     ...so that the type `A` will meet its required lifetime bounds
// |
// help: consider adding an explicit lifetime bound
// |
// 5 | pub fn new_paging<A: PageAllocator + 'static>(page_allocator: A) -> Box<dyn PageAllocator> {
// |                                    +++++++++
// The fix here is to mark T: PageAllocator + 'static
pub fn new_paging<T: PageAllocator>(page_allocator: T) -> Box<dyn PageAllocator> {
    Box::new(page_allocator)
}
