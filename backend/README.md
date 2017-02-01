# Notes API Backend  
This Notes API is written using .Net Core and will run on all platforms. It uses [redis](https://redis.io/) to persist the data.  

## Configuration  
The only values that can be configured are the `REDIS_URL` and `REDIS_PORT`. I have defaulted the values to a instance hosted by RedisLabs. 
You can overwrite the default values by setting them as environmental variables.  

## Run without Docker  
Prerequisites: [.Net CLI](https://www.microsoft.com/net/download/core#/current) (1.1.0) 
  
Fast way (Mac/Linux):  
1. Navigate to `$repo_root/backend`  
2. Run `./start.sh` to install dependencies, build projects, run tests, start api

Manual Way To Build/Run API:   
1. Navigate to the `$repo_root/backend/src` Directory  
2. Run `dotnet restore` to install dependencies  
3. Run `dotnet build` to compile the code  
4. Run `dotnet run` to start the Application on port 5000 (If you want to start the application on port 80 you will likely need admin permissions: `sudo dotnet run --server.urls http://*`)  

Manual Way to Build/Run Tests (must build project first):  
1. Navigate to the `$repo_root/backend/test` Directory  
2. Run `dotnet restore` to install dependencies  
3. Run `dotnet test` to run the unit tests  

### IDE  
If you have [Visual Studio Code](http://code.visualstudio.com/) with the [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) 
extension installed you can simply open this folder in code and it `F5` to start debugging the application.  

## Run with Docker  
Prerequisites: [Docker](https://docs.docker.com/engine/installation/) (1.12+), [Docker Compose](https://github.com/docker/compose/releases)(1.10)  

I have provided 2 compose files([cloud.yml](./cloud.yml),[local.yml](./local.yml)), both of them build the image and map port 80 of the container to port 80 of the machine the compose file run on. 

To run with my RedisLab hosted redis run: `docker-compose -f cloud.yml up -d`  
To run with Redis in a container run: `docker-compose -f local.yml up -d`  

To kill the containers and remove them run:  
```
docker-compose -f FILE_YOU_STARTED_WITH kill  
docker-compose -f FILE_YOU_STARTED_WITH rm -f
```  

### Troubleshooting  
If you see a message about a port conflict this likely means you already have another container or app using that port. 
To resolve this kill any containers running on port 80 (`docker ps` will list the containers and ports, `docker kill $ID` will kill a container).  
