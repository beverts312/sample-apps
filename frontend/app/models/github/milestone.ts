import { GithubUser } from './user';

export interface GithubMilestone {
    url: string,
    html_url: string,
    labels_url: string,
    id: number,
    number: number,
    state: string,
    title: string,
    description: string,
    creator: GithubUser,
    open_issues: number,
    closed_issues: number,
    created_at: Date,
    updated_at: Date,
    closed_at: Date,
    due_on: Date
}