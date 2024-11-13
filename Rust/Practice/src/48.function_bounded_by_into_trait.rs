use std::net::Ipv4Addr;

// This function accepts any type T which can be converted to Ipv4Addr
fn ping<T>(address: T)
where
    T: Into<Ipv4Addr>,
{
    let _ipv4_address = address.into();
}

fn main() {
    // We can pass Ipv4Addr as an object for ping function
    // because there is below blanket implementation defined on every T
    // impl<T> Into<T> for T {
    //     fn into(self) -> T {
    //         self
    //     }
    // }
    println!("{:?}", ping(Ipv4Addr::new(23, 21, 68, 141))); // pass an Ipv4Addr

    // Passing array with 4 elements to ping function work because
    // of below implementation on Ipv4Addr
    // impl From<[u8; 4]> for Ipv4Addr {
    //     fn from(octets: [u8; 4]) -> Ipv4Addr {
    //         Ipv4Addr::new(octets[0], octets[1], octets[2], octets[3])
    //     }
    // }
    println!("{:?}", ping([66, 146, 219, 98])); // pass a [u8; 4

    // Passing u32 to ping function work because
    // of below implementation on Ipv4Addr
    // impl From<u32> for Ipv4Addr {
    //     #[inline]
    //     fn from(ip: u32) -> Ipv4Addr {
    //         Ipv4Addr::from_bits(ip)
    //     }
    // }
    println!("{:?}", ping(0xd076eb94_u32)); // pass a u32
}
