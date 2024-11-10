use math::add;


mod math;

fn main() {
    add(1, 2);
    // cannot call because math module is not exporting sub

    // sub(1, 2);
}
