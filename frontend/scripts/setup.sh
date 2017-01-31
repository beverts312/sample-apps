#!/bin/bash

echo "Setting working dir"
cd $(dirname $0)
cd ..

echo "Preparing workspace for docker build"
echo "Retrieving packages"
npm install
if [[ $? -ne 0 ]] ; then
    echo "Package install failed, see details above"
    exit 1
fi

echo "Transpiling Typescript to Javascript"
npm run tsc
if [[ $? -ne 0 ]] ; then
    echo "Transpile failed, see details above"
    exit 1
fi
