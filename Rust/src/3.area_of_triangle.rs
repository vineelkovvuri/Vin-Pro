fn main() {
    let a = 10.0;
    let b = 10.0;
    let c = 10.0;
    let s = (a + b + c) / 2.0;

    let mut result = s * (s - a) * (s - b) * (s - c);
    result = f32::sqrt(result);

    println!("Area of a triangle: {result}");
}
