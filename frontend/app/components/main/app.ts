import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


import { GithubService } from '../../services/github';
import { GithubIssue } from '../../models/github/issue';

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
  public issues: GithubIssue[];

  constructor(private _router: Router, private githubService: GithubService) { }

  ngOnInit() {
    this.githubService.getIssues(this.user, this.repo, 7).then(issues => this.issues = issues);
    alert(this.issues);
  }

}
