# Angular Issue Search  
This app is written using [Angular 2.0](https://angular.io/) with [Typescript](http://www.typescriptlang.org/).  

## Run without Docker  
Prerequisites: [Node.Js](https://nodejs.org/en/download/), [npm](https://www.npmjs.com/) (on most operating systems this comes with Node.js)  

Fast way (Mac/Linux):  
1. Navigate to `$repo_root/frontend`  
2. Run `./start.sh` to install dependencies, transpile code, start web app

Manual Way To Build/Run API:   
1. Navigate to the `$repo_root/frontend` Directory  
2. Run `npm install` to install dependencies  
3. Run `npm run build` to transpile the code  
4. Run `npm run start` to start and launch the applicaation  

### IDE  
If you have [Visual Studio Code](http://code.visualstudio.com/) with the [Chrome Debugger](https://marketplace.visualstudio.com/items?itemName=msjsdiag.debugger-for-chrome) 
extension installed and configured, you can follow steps 1-3 above to transpile, and then hit `F5` to debug.  

## Run with Docker  
Prerequisites: [Docker](https://docs.docker.com/engine/installation/), [Docker Compose](https://github.com/docker/compose/releases), [Node.Js](https://nodejs.org/en/download/), [npm](https://www.npmjs.com/) (on most operating systems this comes with Node.js)  

To build and run the image, navigate to this directory and run `./docker-start.sh`  
To kill and remove the container run `./remove.sh`  

### Troubleshooting  
If you see a message about a port conflict this likely means you already have another container or app using that port. 
To resolve this kill any containers running on port 80 (`docker ps` will list the containers and ports, `docker kill $ID` will kill a container).  
