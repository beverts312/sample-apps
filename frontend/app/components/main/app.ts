import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


import { GithubService } from '../../services/github';
import { GithubIssue } from '../../models/github/issue';
import { DisplayIssue } from '../../models/display-issue';

import { Config } from '../../config';
let config = new Config();


@Component({
  selector: 'my-app',
  templateUrl: 'app/components/main/app.html',
  styleUrls: ['app/components/main/app.css']
})
export class AppComponent {
  public title = "Angular Issues from the last 7 days";
  public user = config.github.user;
  public repo = config.github.repo
  public displayIssues: DisplayIssue[];

  constructor(private _router: Router, private githubService: GithubService) { }

  ngOnInit() {
    this.displayIssues = [];
    this.githubService.getIssues(this.user, this.repo, 7).then((issues: GithubIssue[]) => {
      for (let githubIssue of issues) {
        let issue: DisplayIssue = {
          body: '',
          title: githubIssue.title,
          user: githubIssue.user.login,
          url: githubIssue.url
        };
        this.displayIssues.push(issue);
      }
    });
  }
}
