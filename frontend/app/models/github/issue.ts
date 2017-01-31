import { GithubUser } from './user';
import { GithubLabel } from './label';
import { GithubPullRequest } from './pull-request';
import { GithubMilestone } from './milestone';

export interface GithubIssue {
  id: number,
  url: string,
  repository_url: string,
  labels_url: string,
  comments_url: string,
  events_url: string,
  html_url: string,
  number: number,
  state: string,
  title: string,
  body: string,
  user: GithubUser,
  labels: GithubLabel[],
  assignee: GithubUser,
  milestone: GithubMilestone,
  locked: boolean,
  comments: number,
  pull_request: GithubPullRequest,
  closed_at: Date,
  created_at: Date,
  updated_at: Date
}
