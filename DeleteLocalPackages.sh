#!/bin/bash

export PACKAGEVERSION=2.0.0-alpha2.1000
export TARGETROOT=~/.nuget/packages

find $TARGETROOT/ -name $PACKAGEVERSION -exec rm -rf {} \;