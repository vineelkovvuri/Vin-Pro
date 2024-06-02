use std::fs;
use std::path::Path;

use clap::{Arg, Command};

// struct ExactFileNameMatcher<'a> {
//     file_name: &'a str,
// }

// trait Matcher {
//     fn match_path(&self, file_path: &str) -> bool;
// }

// impl<'a> Matcher for ExactFileNameMatcher<'a> {
//     fn match_path(&self, file_path: &str) -> bool {
//         file_path.ends_with(self.file_name)
//     }
// }

struct SearchOptions {
    name: String,
    path: String,
}

fn parse_command_line() -> SearchOptions {
    let args = Command::new("search")
        .version("1.0")
        .about("File search program")
        .arg(
            Arg::new("name")
                .short('n')
                .long("name")
                .help("File name to search"),
        )
        .arg(
            Arg::new("path")
                .short('p')
                .long("path")
                .help("Path to search")
                .default_value("C:\\"),
        )
        .get_matches();
    let name = args.get_one::<String>("name").expect("name is expected");
    let path = args.get_one::<String>("path").expect("path is expected");

    SearchOptions {
        name: name.to_string(),
        path: path.to_string(),
    }
}

fn main() {
    let options = parse_command_line();

    let mut results: Vec<String> = Vec::new();
    let path = Path::new(&options.path);
    search2(&path, &options.name, &mut results);
    for result in results {
        println!("{:?}", result);
    }
}

fn search(path: &Path, file_name: &str, results: &mut Vec<String>) {
    let result = fs::read_dir(&path);
    if let Ok(entries) = result {
        for entry in entries {
            if let Ok(entry) = entry {
                let sub_path = entry.path();
                if sub_path.is_dir() {
                    let sub_path = Path::new(&sub_path);
                    search(sub_path, file_name, results);
                } else if sub_path.ends_with(file_name) {
                    results.push(String::from(sub_path.as_os_str().to_str().unwrap()));
                }
            }
        }
    }
}

fn search2(path: &Path, file_name: &str, results: &mut Vec<String>) {
    let result = fs::read_dir(&path);
    if result.is_err() {
        return;
    }

    let entries = result.unwrap();
    for entry in entries {
        if entry.is_err() {
            continue;
        }

        let entry = entry.unwrap();
        let sub_path = entry.path();
        if sub_path.is_dir() {
            let sub_path = Path::new(&sub_path);
            search(sub_path, file_name, results);
        } else if sub_path.ends_with(file_name) {
            results.push(String::from(sub_path.as_os_str().to_str().unwrap()));
        }
    }
}
