fn main() {
    let mut seconds = 100000;
    let hours = seconds / 3600;
    seconds = seconds % 3600;
    let minutes = seconds / 60;
    seconds = seconds % 60;

    println!("HH:MM:SS {hours}:{minutes}:{seconds}");
}
