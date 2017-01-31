#!/bin/bash

cd $(dirname $0)
if [[ $? -ne 0 ]] ; then
  echo "Failed to get to the proper directory"
  exit 1
fi

docker-compose kill
if [[ $? -ne 0 ]] ; then
  echo "Failed to kill container"
  exit 1
fi

docker-compose rm -f
if [[ $? -ne 0 ]] ; then
  echo "Failed to remove container"
  exit 1
fi