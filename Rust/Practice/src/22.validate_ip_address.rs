
fn validate_ipv4(string: &str) -> bool {
    let octets = string.split('.');
    for octet in octets {
        // by trying to parse it in to u8 we guarantee the value is b/w 0 and
        // 255
        let num = octet.parse::<u8>();
        if num.is_err() {
            return false;
        }
    }

    true
}

fn main() {
    let str = validate_ipv4("192.168.0.1");
    println!("{}", str);
    let str = validate_ipv4("192.168.a.1");
    println!("{}", str);
    let str = validate_ipv4("192.168.zzz.1");
    println!("{}", str);
    let str = validate_ipv4("255.255.255.255");
    println!("{}", str);
    let str = validate_ipv4("0.0.0.0");
    println!("{}", str);
}
