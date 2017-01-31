import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { GithubIssue } from '../models/github/issue';

import { Config } from '../config';

let config = (new Config()).github;
@Injectable()
export class GithubService {

    constructor(private http: Http) { }

    getIssues(user: string, repo: string, days: number): Promise<GithubIssue[]> {
        let date = new Date();
        const uriPath = config.userPaths.issuesUri.replace('##USER##', config.user).replace('##REPO##', config.repo)
        const params = "?since=" + date.setDate(date.getDate() - 7).toString(); 
        let url = config.baseUri + uriPath + params
        return this.http
            .get(url)
            .toPromise()
            .then(res => res.json() as GithubIssue[])
            .catch(this.handleError);
    }


    handleError(err: Error): void {
        console.log(err.message);
    }
}
