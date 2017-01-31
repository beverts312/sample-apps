# Notes API Backend  
This Notes API is written using .Net Core and will run on all platforms. It uses [redis](https://redis.io/) to persist the data.  

## Run without Docker  
Prerequisites: [.Net CLI](https://www.microsoft.com/net/core)  
1. Navigate to the `$repo_root/backend/src` Directory  
2. Run `dotnet restore` to install dependencies  
3. Run `dotnet build` to compile the code  
4. Run `dotnet run` to start the Application on port 5000  

If you want to start the application on port 80 you will likely need admin permissions: `sudo dotnet run --server.urls http://*`  
  
I have hardcoded values to a redis instance hosted in the cloud by RedisLabs, if you wish to use your own instance of redis set 
the `REDIS_URL` and `REDIS_PORT` environmental variables to point to your redis instance.  

If you have [Visual Studio Code](http://code.visualstudio.com/) with the [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) 
extension installed you can simply open this folder in code and it `F5`.  

## Run with Docker  
Prerequisites: [Docker](https://docs.docker.com/engine/installation/), [Docker Compose](https://github.com/docker/compose/releases)  

To run with my RedisLab hosted redis run: `docker-compose -f cloud.yml up -d`  
To run with Redis in a container run: `docker-compose -f local.yml up -d`  

To kill the containers and remove them run:  
```
docker-compose -f FILE_YOU_STARTED_WITH kill  
docker-compose -f FILE_YOU_STARTED_WITH rm -f
```  

## Run Unit Tests