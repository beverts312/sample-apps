const githubService = {
    baseUri: 'https://api.github.com',
    userPaths: {
        baseUri: '/users',
        reposUri: '/repos',
        issuesUri: '/repos/##USER##/##REPO##/issues'
    },
    markdownPath: '/markdown',
    user: 'angular',
    repo: 'angular'
};

export class Config {
    public github = githubService;
}