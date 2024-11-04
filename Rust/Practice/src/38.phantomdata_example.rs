use std::marker::PhantomData;

struct Dog<Bread> {
    name: String,
    bread: PhantomData<Bread>, // This will be optimized away by the complier
}

struct GoldenRetriever;
fn main() {
    let golden_retriever = Dog::<GoldenRetriever> {
        name: "Snoopy".to_string(),
        bread: PhantomData, // This is a special way to specify PhantomData
    };
}
