Rust’s `Iterator` trait has a wide variety of methods that enable powerful and expressive operations on iterators. Here’s a categorized list of common iterator methods with brief descriptions:

---

### **Creation**
1. **`successors`**  
   Create an iterator by repeatedly applying a function to the previous value until `None` is returned.  
   Example: `Iterator::successors(Some(0), |x| Some(x + 1))` produces `0, 1, 2, ...`.

2. **`from_fn`**  
   Create an iterator by repeatedly calling a closure.  
   Example: `Iterator::from_fn(|| Some(1))` creates an infinite iterator of `1`.

---

### **Adaptors (Transformers)**
1. **`map`**  
   Apply a function to each item, transforming it into a new value.  
   Example: `iter.map(|x| x * 2)`.

2. **`filter`**  
   Filter items, keeping only those that satisfy a predicate.  
   Example: `iter.filter(|x| *x > 5)`.

3. **`filter_map`**  
   Combine `filter` and `map`: apply a function that returns `Option` and keep only `Some` values.  
   Example: `iter.filter_map(|x| if x > 0 { Some(x) } else { None })`.

4. **`flat_map`**  
   Map each item to an iterator, and flatten the results into a single iterator.  
   Example: `iter.flat_map(|x| 0..x)`.

5. **`chain`**  
   Combine two iterators into one.  
   Example: `iter1.chain(iter2)`.

6. **`zip`**  
   Combine two iterators into one, yielding tuples of paired elements.  
   Example: `iter1.zip(iter2)` produces `(x1, y1), (x2, y2), ...`.

7. **`enumerate`**  
   Add indices to items in the iterator.  
   Example: `iter.enumerate()` produces `(0, x1), (1, x2), ...`.

8. **`rev`**  
   Reverse the direction of a `DoubleEndedIterator`.  
   Example: `iter.rev()`.

9. **`inspect`**  
   Run a closure on each item for debugging or side effects without modifying the iterator.  
   Example: `iter.inspect(|x| println!("{x}"))`.

10. **`cycle`**  
    Repeat an iterator endlessly.  
    Example: `iter.cycle()`.

---

### **Consumers**
1. **`collect`**  
   Consume the iterator and collect its items into a collection like `Vec`, `HashMap`, or `String`.  
   Example: `iter.collect::<Vec<_>>()`.

2. **`fold`**  
   Reduce all items into a single value using an accumulator.  
   Example: `iter.fold(0, |acc, x| acc + x)`.

3. **`reduce`**  
   Similar to `fold`, but uses the first element as the initial value.  
   Example: `iter.reduce(|a, b| a + b)`.

4. **`for_each`**  
   Apply a closure to each item, primarily for side effects.  
   Example: `iter.for_each(|x| println!("{x}"))`.

5. **`sum`**  
   Calculate the sum of all items.  
   Example: `iter.sum::<i32>()`.

6. **`product`**  
   Calculate the product of all items.  
   Example: `iter.product::<i32>()`.

7. **`find`**  
   Return the first item that satisfies a predicate.  
   Example: `iter.find(|&x| x > 5)`.

8. **`any`**  
   Check if any item satisfies a predicate.  
   Example: `iter.any(|x| x > 5)`.

9. **`all`**  
   Check if all items satisfy a predicate.  
   Example: `iter.all(|x| x > 0)`.

10. **`count`**  
    Count the number of items.  
    Example: `iter.count()`.

11. **`max` / `min`**  
    Find the maximum or minimum value in the iterator.  
    Example: `iter.max()`.

12. **`nth`**  
    Return the `n`-th element (0-based).  
    Example: `iter.nth(3)`.

---

### **Slicing**
1. **`take`**  
   Take the first `n` items.  
   Example: `iter.take(5)`.

2. **`skip`**  
   Skip the first `n` items.  
   Example: `iter.skip(3)`.

3. **`take_while`**  
   Take items while a predicate is true.  
   Example: `iter.take_while(|x| *x < 5)`.

4. **`skip_while`**  
   Skip items while a predicate is true, then take the rest.  
   Example: `iter.skip_while(|x| *x < 5)`.

---

### **Set-Like Operations**
1. **`distinct`**  
   Return items with duplicates removed (requires `std::collections`).  
   Example: `iter.collect::<std::collections::HashSet<_>>()`.

2. **`partition`**  
   Split items into two collections based on a predicate.  
   Example: `iter.partition(|x| *x > 5)`.

---

### **Combinators**
1. **`peekable`**  
   Allow peeking at the next item without consuming it.  
   Example: `iter.peekable()`.

2. **`fuse`**  
   Make the iterator return `None` forever after it’s exhausted.  
   Example: `iter.fuse()`.

3. **`by_ref`**  
   Borrow the iterator so it can still be used after partial consumption.  
   Example: `iter.by_ref().take(3)`.

4. **`copied`**  
   Create an iterator that copies items from a source that yields references.  
   Example: `iter.copied()`.

5. **`cloned`**  
   Create an iterator that clones items from a source that yields references.  
   Example: `iter.cloned()`.

---

Would you like examples of any specific methods?