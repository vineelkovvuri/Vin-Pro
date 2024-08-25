use std::{
    cell::RefCell,
    ops::{Deref, DerefMut},
};

trait Shape {
    fn area(&self);
}

struct Circle {
    r: u32,
}

impl Shape for Circle {
    fn area(&self) {}
}

struct Rectangle {
    l: u32,
    b: u32,
}

impl Shape for Rectangle {
    fn area(&self) {}
}

struct Shaper<T> {
    shape: T,
}

impl<T> Deref for Shaper<T> {
    type Target = T;

    fn deref(&self) -> &Self::Target {
        &self.shape
    }
}

impl<T> DerefMut for Shaper<T> {
    fn deref_mut(&mut self) -> &mut Self::Target {
        &mut self.shape
    }
}

fn main() {
    let shaper = Shaper {
        shape: Circle { r: 20 },
    };
    shaper.area();

    let shaper = Shaper {
        shape: Rectangle { l: 20, b: 30 },
    };
    shaper.area();
}
