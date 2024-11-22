use bitflags::bitflags;

bitflags! {
    #[derive(Debug, Clone, Copy, PartialEq, Eq, PartialOrd, Ord, Hash)]
    pub struct MemoryAttributes: u64 {
        // Memory Caching Attributes
        const Uncacheable       = 0x00000000_00000001u64;
        const WriteCombining    = 0x00000000_00000002u64;
        const WriteThrough      = 0x00000000_00000004u64;
        const Writeback         = 0x00000000_00000008u64;
        const UncacheableExport = 0x00000000_00000010u64;
        const WriteProtect      = 0x00000000_00001000u64;

        // Memory Access Attributes
        const ReadProtect       = 0x00000000_00002000u64;   // Maps to Present bit on X64
        const ExecuteProtect    = 0x00000000_00004000u64;   // Maps to NX bit on X64
        const ReadOnly          = 0x00000000_00020000u64;   // Maps to Read/Write bit on X64


        const CacheAttributeMask = Self::Uncacheable.bits() |
                                   Self::WriteCombining.bits() |
                                   Self::WriteThrough.bits() |
                                   Self::Writeback.bits() |
                                   Self::UncacheableExport.bits() |
                                   Self::WriteProtect.bits();

        const MemoryAttributeMask = Self::ReadProtect.bits() |
                                    Self::ExecuteProtect.bits() |
                                    Self::ReadOnly.bits();
    }
}

fn main() {
    let attr = MemoryAttributes::Uncacheable
        | MemoryAttributes::WriteThrough;

    dbg!(attr.contains(MemoryAttributes::Uncacheable | MemoryAttributes::WriteThrough));  // true
    dbg!(attr.intersects(MemoryAttributes::Uncacheable | MemoryAttributes::WriteCombining)); // true because this and attr inspect with Uncacheable
}
