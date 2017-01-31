# Angular Issue Search  
This app is written using [Angular 2.0](https://angular.io/) with [Typescript](http://www.typescriptlang.org/).  

## Run without Docker  
Prerequisites: [Node.Js](https://nodejs.org/en/download/), [npm](https://www.npmjs.com/) (on most operating systems this comes with Node.js)  

Manual Way To Build/Run the Web app:   
1. Navigate to the `$repo_root/frontend` Directory  
2. Run `npm install` to install dependencies  
3. Run `npm run start` to transpile code, start the app, and open your browser  

## Run with Docker  
Prerequisites: [Docker](https://docs.docker.com/engine/installation/), [Docker Compose](https://github.com/docker/compose/releases), [Node.Js](https://nodejs.org/en/download/), [npm](https://www.npmjs.com/) (on most operating systems this comes with Node.js)  

To build and run the image, navigate to this directory and run `./scripts/docker-start.sh`  
To kill and remove the container run `./scripts/remove.sh`  

### Troubleshooting  
If you see a message about a port conflict this likely means you already have another container or app using that port. 
To resolve this kill any containers running on port 80 (`docker ps` will list the containers and ports, `docker kill $ID` will kill a container).  
