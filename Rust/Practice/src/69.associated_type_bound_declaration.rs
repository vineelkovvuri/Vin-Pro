
trait FormatTrait{}

// Bounds on associated types can be declared after the trait name using Self::
// or can be declared inside the trait after the associated type.
trait Book1
where
    Self::Format: FormatTrait,
{
    type Format;
    fn read(&self);
}

trait Book2 {
    type Format
    where
        Self::Format: FormatTrait;
    fn read(&self);
}
