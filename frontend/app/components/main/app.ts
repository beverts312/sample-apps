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
  public currentPageIssues: DisplayIssue[];
  public currentPage: number;
  public pageSize: number = 10;
  public maxPages: number;
  public pages: boolean[];

  constructor(private _router: Router, private githubService: GithubService) { }

  ngOnInit() {
    this.displayIssues = [];
    this.currentPageIssues = [];
    this.pages = [];
    this.githubService.getIssues(this.user, this.repo, 7).then((issues: GithubIssue[]) => {
      for (let githubIssue of issues) {
        let issue: DisplayIssue = {
          body: githubIssue.body,
          title: githubIssue.title,
          user: githubIssue.user.login,
          url: githubIssue.url,
          visible: false
        };
        if (githubIssue.assignee) {
          issue.assignee = githubIssue.assignee.login;
        }
        this.displayIssues.push(issue);
      }
      this.initPages();
    });
  }

  initPages() {
    this.maxPages = this.displayIssues.length / this.pageSize;
    for (let i = 0; i < this.maxPages; i++) {
      this.pages[i] = false;
    }
    this.updatePage(1);
  }
  toggleVisible(issueIndex: number) {
    if (!this.currentPageIssues[issueIndex].visible) {
      this.githubService.getMarkdownHtmlFromString(this.currentPageIssues[issueIndex].body).then((prettyBody) => {
        this.currentPageIssues[issueIndex].body = prettyBody;
      });
    }
    this.currentPageIssues[issueIndex].visible = !this.currentPageIssues[issueIndex].visible;
  }

  updatePage(page: number) {
    this.currentPage = page;
    const startIndex = (page - 1) * this.pageSize;
    for (var i = 0; i < 10; i++) {
      this.currentPageIssues[i] = this.displayIssues[startIndex + i];
    }
  }


  nextPage() {
    if (this.currentPage != this.maxPages) {
      this.currentPage++;
      this.updatePage(this.currentPage);
    }
  }

  lastPage() {
    if (this.currentPage != 1) {
      this.currentPage--;
      this.updatePage(this.currentPage);
    }
  }
}
