All instructions assume you have cloned this repo (`git clone https://github.com/beverts312/sample-apps.git`)  

## Build the Code yourself  
[Backend Instructions](./backend/README.md) - Notes API  
[Frontend Instructions](./frontend/README.md) - Angular Issue Search (In Progress)  

## Run Prebuilt Code using Docker  
As an alternate option to building the code locally, you can run prebuild docker images using the [docker-compose.yml](./docker-compose.yml).  
First you must install [Docker](https://docs.docker.com/engine/installation/) and [Docker Compose](https://github.com/docker/compose/releases).  
Then navigate to the directory you cloned this repo and run `docker-compose up -d`  
The API will be running on port 80 and the Frontend App will be running on 81.  
