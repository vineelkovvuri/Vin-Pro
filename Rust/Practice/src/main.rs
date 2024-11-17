fn main() {
    let strs = [
        "feat(font): allow using A1,2,4 bitmaps + handle byte aligned fonts",
        "feat(observer): add subject snprintf",
        "feat(observer)",
    ];

    for s in strs {
        println!("|{:25.25}|", s);
    }
}
