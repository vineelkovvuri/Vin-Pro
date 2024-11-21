// Basic macro usage

// Below macro captures the expression into num variable
macro_rules! my_macro {
    // can have multiple pattern
    ($num:expr) => { // matches only one expression
        let x = $num;
        println!("{}", x);
    };
    ($($num:expr),*) => { // matches multiple expressions
        $(                // iterate over each matched expression
            let x = $num;
            println!("{}", x);
        )*
    }
}
fn main() {
    my_macro!(2);
    my_macro!(2, 3);
}
