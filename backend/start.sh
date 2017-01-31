#!/bin/bash

cd $(dirname $0)
if [[ $? -ne 0 ]] ; then
  echo "Failed to get to the proper directory"
  exit 1
fi

dotnet restore
if [[ $? -ne 0 ]] ; then
  echo "Failed to get to the proper directory"
  exit 1
fi

cd src
dotnet build
if [[ $? -ne 0 ]] ; then
  echo "Failed to build API"
  exit 1
fi


cd ../test
dotnet build
if [[ $? -ne 0 ]] ; then
  echo "Test Project Build Failed"
  exit 1
fi

dotnet test
if [[ $? -ne 0 ]] ; then
  echo "Test Run failed"
  exit 1
fi

cd ../src
dotnet run

