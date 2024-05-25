use std::fs;
use std::path::Path;

struct ExactFileNameMatcher<'a> {
    file_name: &'a str,
}

trait Matcher {
    fn match_path(&self, file_path: &str) -> bool;
}

impl<'a> Matcher for ExactFileNameMatcher<'a> {
    fn match_path(&self, file_path: &str) -> bool {
        file_path.ends_with(self.file_name)
    }
}

fn main() {
    let mut results: Vec<String> = Vec::new();
    let path = Path::new("C:\\");
    search(&path, "kernel32.dll", &mut results);
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
