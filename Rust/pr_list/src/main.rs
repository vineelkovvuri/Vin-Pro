use core::str;
use std::{fmt::Display, process::Command};

use chrono::{DateTime, Utc};
//gh pr list --repo "lvgl/lvgl" --json "author,title,url,updatedAt,mergeStateStatus,mergeable"
use serde::{Deserialize, Serialize};
use unicode_width::UnicodeWidthStr;

#[derive(Serialize, Deserialize, Debug)]
struct Author {
    id: String,
    is_bot: bool,
    login: String,
    name: String,
}

#[derive(Serialize, Deserialize, Debug)]
struct Pr {
    author: Author,
    #[serde(rename = "mergeStateStatus")]
    merge_state_status: String,
    mergeable: String,
    title: String,
    #[serde(rename = "updatedAt")]
    updated_at: String,
    url: String,
}

impl Display for Pr {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(
            f,
            "|{}|{}|{:60.60}|{:30}|{}|",
            self.updated_at, self.author, self.title, self.url, self.merge_state_status,
        )
    }
}

impl Display for Author {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        let width = self.name.width();
        write!(f, "{}{1:2$} ", self.name, " ", 20 - width)
    }
}

fn main() {
    let mut cmd = Command::new("gh");
    let cmd = cmd.args([
        "pr",
        "list",
        "--repo",
        "lvgl/lvgl",
        "--json",
        "author,title,url,updatedAt,mergeStateStatus,mergeable",
    ]);

    let Ok(output) = cmd.output() else {
        println!("failed to capture gh command output");
        return;
    };

    let Ok(mut pr_list) = serde_json::from_slice::<Vec<Pr>>(&output.stdout) else {
        println!("failed to deserialize gh output");
        return;
    };

    // for pr in &mut pr_list {
    //     pr.merge_state_status = map_merge_status(pr.merge_state_status.as_str())
    // }

    pr_list.iter_mut().for_each(|pr| {
        pr.merge_state_status = map_merge_status(&pr.merge_state_status.as_str());
        pr.merge_state_status.push_str("(");
        pr.merge_state_status.push_str(&pr.mergeable);
        pr.merge_state_status.push_str(")");
    });

    pr_list.sort_by(|pr1, pr2| {
        let date1 = DateTime::parse_from_rfc3339(pr1.updated_at.as_str())
            .unwrap()
            .with_timezone(&Utc);
        let date2 = DateTime::parse_from_rfc3339(pr2.updated_at.as_str())
            .unwrap()
            .with_timezone(&Utc);

        date2.cmp(&date1)
    });

    for pr in pr_list {
        println!("{}", pr);
    }
}

fn map_merge_status(status: &str) -> String {
    match status {
        "BEHIND" => "🦕  Stale out of date".to_string(),
        "BLOCKED" => "🕵️  Pending review".to_string(),
        "CLEAN" => "✅  Mergeable and passing commit status".to_string(),
        "DIRTY" => "⚔️  Merge conflict".to_string(),
        "DRAFT" => "📝  Draft PR".to_string(),
        "HAS_HOOKS" => "Mergeable with passing commit status and pre-receive hooks".to_string(),
        "UNKNOWN" => "The state cannot currently be determined".to_string(),
        "UNSTABLE" => "Mergeable with non-passing commit status".to_string(),
        _ => "❓  Unknown state.".to_string(),
    }
}
