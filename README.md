All instructions assume you have cloned this repo (`git clone https://github.com/beverts312/sample-apps.git`)  
Both apps have been built and tested on Ubuntu 16.04 & Windows 10. They should work just fine on a MAC as well.  

## Build the Code yourself  
[Backend Instructions](./backend/README.md) - Notes API  
[Frontend Instructions](./frontend/README.md) - Angular Issue Search  

## Run Prebuilt Code using Docker  
As an alternate option to building the code locally, you can run prebuilt docker images using the [docker-compose.yml](./docker-compose.yml).  
First you must install [Docker](https://docs.docker.com/engine/installation/) (1.12+) and [Docker Compose](https://github.com/docker/compose/releases) (1.10).  
Then navigate to the directory you cloned this repo and run `docker-compose up -d`  
The API will be running on port 80 and the Frontend App will be running on 81.  

## Test against a hosted solution  
You can make calls aginst the backed at [http://interview.baileyeverts.com/api/notes](http://interview.baileyeverts.com/api/notes).  
You can view the angular frontend at [http://interview.baileyeverts.com](http://interview.baileyeverts.com).  
