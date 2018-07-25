#!/bin/bash
export PACKAGEDIR=$PWD/Packages
export PACKAGEVERSION=2.0.0-alpha2.1000
export TARGETROOT=~/.nuget/packages

find $TARGETROOT/ -name $PACKAGEVERSION -exec rm -rf {} \;

if [ ! -d "$PACKAGEDIR" ]; then
    mkdir $PACKAGEDIR
fi

#rm $PACKAGEDIR/*
dotnet pack -p:PackageVersion=$PACKAGEVERSION --include-symbols --include-source -o $PACKAGEDIR

for f in $PACKAGEDIR/*.symbols.nupkg; do
  mv ${f} ${f/.symbols/}
done
# Convert files to lowercase
for i in $PACKAGEDIR/*; do mv $i `echo $i | tr [:upper:] [:lower:]`; done

for f in $PACKAGEDIR/*.nupkg; do
    echo ""
    packagename=$(basename ${f%.2.0.0-alpha2.1000.nupkg})
    target=$TARGETROOT/$packagename/$PACKAGEVERSION

    mkdir -pv $target && cp -v $f $target
    tar -xzf $target/$(basename $f) -C $target

done