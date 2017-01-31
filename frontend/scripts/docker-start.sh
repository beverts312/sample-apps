#!/bin/bash

cd $(dirname $0)
source setup.sh

echo "Removing Dev Dependencies"
npm prune --production
if [[ $? -ne 0 ]] ; then
    echo "Removal of dev pacakges failed, see details above"
    exit 1
fi
echo "Workspace ready for docker build"


docker build -t beverts312/frontend .
if [[ $? -ne 0 ]] ; then
  echo "Image Build Failed, see details above"
  exit 1
fi

docker-compose up -d  
