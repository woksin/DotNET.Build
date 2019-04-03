#!/bin/bash

export PACKAGEVERSION=2.1000.0
export TARGETROOT=~/.nuget/packages

find $TARGETROOT/ -name $PACKAGEVERSION -exec rm -rf {} \;