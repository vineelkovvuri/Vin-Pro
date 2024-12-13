
#[derive(Debug)]
pub struct Duration {
    seconds: u64,
}

impl From<u64> for Duration {
    fn from(s: u64) -> Self {
        Self { seconds: s }
    }
}

pub trait Planet {
    fn years_during(d: &Duration) -> f64 {
        todo!("convert a duration ({d:?}) to the number of years on this planet for that duration");
    }
}

macro_rules! planet_init {
    // Here $planet have to declared as identifier because the actual planet
    // type do not exist yet! Had each planet struct was already declared
    // outside of this macro rule then makeing $planet:ty will work.
    ($planet:ident, $period:expr) => {
        pub struct $planet {}
        impl Planet for $planet {
            fn years_during(d: &Duration) -> f64 {
                d.seconds as f64 / ($period * 31557600f64)
            }
        }
    };
}

planet_init!(Mercury, 0.2408467);
planet_init!(Venus, 0.61519726);
planet_init!(Earth, 1.0);
planet_init!(Mars, 1.8808158);
planet_init!(Jupiter, 11.862615);
planet_init!(Saturn, 29.447498);
planet_init!(Uranus, 84.016846);
planet_init!(Neptune, 164.79132);
