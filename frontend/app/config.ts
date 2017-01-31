const githubService = {
    baseUri: 'https://api.github.com',
    userPaths: {
        baseUri: '/users',
        reposUri: '/repos',
        issuesUri: '/repos/##USER##/##REPO##/issues'
    },
    user: 'angular',
    repo: 'angular'
};

export class Config {
    public github = githubService;
}