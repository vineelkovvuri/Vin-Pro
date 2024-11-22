// or_else - Returns the option if it contains a value, otherwise calls f and returns the result.
//
// functions
// or_else (() -> Option<T>) -> Option<T>
//  match T
// Some(value) => Some(value),
// None => f(),

pub type PtResult<T> = Result<T, PtError>;

#[derive(Debug, PartialEq)]
pub enum PtError {
    // Invalid parameter
    InvalidParameter,

    // Out of resources
    OutOfResources,

    // No Mapping
    NoMapping,

    // Incompatible Memory Attributes
    IncompatibleMemoryAttributes,

    // Unaligned Page Base
    UnalignedPageBase,

    // Unaligned Address
    UnalignedAddress,

    // Unaligned Memory Range
    UnalignedMemoryRange,

    // Invalid Memory Range
    InvalidMemoryRange,
}

fn main() {

    let x = Some(60);
    let y = x.and(Some(())).ok_or(PtError::InvalidMemoryRange);
    assert_eq!(y, Ok(()));

    let x = Option::<i32>::None;
    let y = x.and(Some(())).ok_or(PtError::InvalidMemoryRange);
    assert_eq!(y, Err(PtError::InvalidMemoryRange));


    let x = Some(60);
    let y = x.map(|_| ()).ok_or(PtError::InvalidMemoryRange);
    assert_eq!(y, Ok(()));

    let x = Option::<i32>::None;
    let y = x.map(|_| ()).ok_or(PtError::InvalidMemoryRange);
    assert_eq!(y, Err(PtError::InvalidMemoryRange));
    

    let v = vec![1,2,2,3,4];
    let i1 = v.into_iter();
    let v = vec![1,2,2,3,4];
    let i2 = v.iter();
}
