!/bin/bash

echo "Setting working dir"
cd $(dirname $0)

echo "Preparing workspace for docker build"
echo "Retrieving packages"
npm install
if [[ $? -ne 0 ]] ; then
    echo "Package install failed, see details above"
    exit 1
fi

echo "Transpiling Typescript to Javascript"
npm run build
if [[ $? -ne 0 ]] ; then
    echo "Transpile failed, see details above"
    exit 1
fi

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
