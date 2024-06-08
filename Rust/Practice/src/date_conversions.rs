use chrono::{Date, DateTime, Datelike, Local, Timelike, Utc};
use chrono::{NaiveDate, NaiveDateTime};
use time::OffsetDateTime;
use std::time::UNIX_EPOCH;
use std::{fs::File, time::SystemTime};

fn main() {
    // let _size_str = "10MB,20MB";

    let path1 = r"D:\Softs\Notepad2\License.txt";
    let file1 = File::open(path1).unwrap();
    let meta1 = file1.metadata().unwrap();
    let date1 = meta1.created().unwrap();


    // let path2 = r"D:\Softs\Notepad2\Notepad2.ini";
    // let file2 = File::open(path2).unwrap();
    // let meta2 = file2.metadata().unwrap();
    // let date2 = meta2.created().unwrap();

    // let x = parse_date_param("2024-01-29,2024-01-31");
    // println!("{:?}", x);
    let datetime: DateTime<Local> = DateTime::from(date1);

    let year = datetime.year();
    let month = datetime.month() as u8; // month() returns a Month enum, convert it to u8
    let day = datetime.day();

    // Print the resulting year, month, and day
    println!("Year: {}", year);
    println!("Month: {}", month);
    println!("Day: {}", day);

    let date_from_str = "2024-01-29 +1000";
    let x = DateTime::parse_from_str(date_from_str, "%Y-%m-%d").unwrap();
    println!("Year: {}", x.year());
    println!("Month: {}", x.month());
    println!("Day: {}", x.day());


}

fn parse_date_param(date_str: &str) -> Result<(NaiveDate, NaiveDate), String> {
    let date_str = date_str.trim();
    let mut splits = date_str.split(",");
    let date_from_str = splits.next().or(Some("0000-00-00")).unwrap();
    let date_to_str = splits.next().or(Some("0000-00-00")).unwrap();

    let date_from = NaiveDate::parse_from_str(date_from_str, "%Y-%m-%d")
    .map_err(|_| format!("Invalid date 1 format {}", date_from_str))?;

    let date_to = NaiveDate::parse_from_str(date_to_str, "%Y-%m-%d")
    .map_err(|_| format!("Invalid date 2 format {}", date_to_str))?;

    Ok((date_from, date_to))
}

fn compare_dates(date_str1: &str, date_str2: &str) -> Result<bool, String> {
    let date1 = NaiveDate::parse_from_str(date_str1, "%Y-%m-%d")
        .map_err(|_| format!("Invalid date 1 format {}", date_str1))?;
    let date2 = NaiveDate::parse_from_str(date_str2, "%Y-%m-%d")
        .map_err(|_| format!("Invalid date 2 format {}", date_str2))?;

    let date1 = [date1.year() as u32, date1.month(), date1.day()];
    let date2 = [date2.year() as u32, date2.month(), date2.day()];
    match date1.partial_cmp(&date2).unwrap() {
        std::cmp::Ordering::Less => Ok(true),
        std::cmp::Ordering::Equal => Ok(true),
        std::cmp::Ordering::Greater => Ok(false),
    }
}
