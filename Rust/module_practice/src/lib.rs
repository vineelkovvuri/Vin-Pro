
//! This module
mod abc;
mod def;
use abc::abc_func;
use def::def_mod_func;

fn main() {

    abc_func();
    def_mod_func();
    println!("Hello, world!");
}
