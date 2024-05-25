use std::path::Path;
use std::ffi::OsStr;

fn main() {
    let s = "C:\\Windows";

    // str implements trait AsRef<Path> hence if we request str to
    // AsRef.as_ref() it will return the Path object. Here rust is knows which
    // as_ref() to call based the left hand side variable type.
    let p: &Path = s.as_ref(); // This goes to AsRef<Path> impl. Can be checked in godbolt.org
    println!("{:#?}", p);

    // str implements trait AsRef<OsStr> hence if we request str to
    // AsRef.as_ref() it will return the OsStr object. Here rust is knows which
    // as_ref() to call based the left hand side variable type.
    let pb: &OsStr = s.as_ref(); // This goes to AsRef<OsStr> impl. Can be checked in godbolt.org
    println!("{:#?}", pb);
}
