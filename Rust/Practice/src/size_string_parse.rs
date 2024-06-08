
fn convert_to_bytes(size_str: &str) -> Result<u64, String> {
    let len = size_str.len();
    if len <= 2 {
        return Ok(size_str.parse::<u64>().unwrap_or(0));
    }

    let suffix = &size_str[len - 2..].to_ascii_uppercase();
    let last = suffix.as_str();
    let remaining = &size_str[..len - 2];

    let multiplier = match last {
        "KB" => 1024,
        "MB" => 1024 * 1024,
        "GB" => 1024 * 1024 * 1024,
        "TB" => 1024 * 1024 * 1024 * 1024,
        _ => 1,
    };

    remaining
        .parse::<u64>()
        .map(|rem| rem * multiplier)
        .map_err(|_| format!("Failed to convert the {}", size_str))
}

fn parse_size_param(size_str: &str) -> Result<(u64, u64), String> {
    let size_str = size_str.trim();
    let mut splits = size_str.split(",");
    let size_min_str = splits.next().or(Some("0"));
    let size_max_str = splits.next().or(Some("0"));

    let size_min_bytes = convert_to_bytes(size_min_str.unwrap().trim())?;
    let size_max_bytes = convert_to_bytes(size_max_str.unwrap().trim())?;

    Ok((size_min_bytes, size_max_bytes))
}

#[test]
fn size_str_test() {
    assert_eq!(parse_size_param("10KB,20KB"), Ok((10 * 1024, 20 * 1024)));
    assert_eq!(parse_size_param("10KB, 20KB"), Ok((10 * 1024, 20 * 1024)));
    assert_eq!(
        parse_size_param("10KB,  20KB  "),
        Ok((10 * 1024, 20 * 1024))
    );
    assert_eq!(parse_size_param(", 20KB"), Ok((0, 20 * 1024)));
    assert_eq!(parse_size_param("10KB,"), Ok((10 * 1024, 0)));
    assert_eq!(parse_size_param("10KB,20KB"), Ok((10 * 1024, 20 * 1024)));
}
