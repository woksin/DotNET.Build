#!/bin/bash
export CURRENTDIR=$PWD;
export FOUND='';
find_nearest_parent_directory() {
    while [[ $PWD != / ]] ; do 
        if [ -z "$FOUND" ]; then
            FOUND=$(find "$PWD" -type d -maxdepth 1 -name "*$@" | head -1)
            echo $FOUND
        fi
        cd ..
    done
}

echo "before running"
export PACKAGEDIR=$(find_nearest_parent_directory 'Packages')
echo "after running $PACKAGEDIR"
cd $CURRENTDIR

echo "Current Directory: $CURRENTDIR"

if [ -z "$PACKAGEDIR" ]; then
    echo "No 'Packages' directory found"
    exit 1;
fi

if [ ! -z "$PACKAGEDIR" ]; then
    echo "'Packages' directory found: $PACKAGEDIR"
    echo "Clearing local dolittle packages 2.0.0-alpha2.1000 from nuget cache"
    find ~/.nuget/packages/ -name 2.0.0-alpha2.1000 -exec rm -rf {} \;
    echo "Removing existing packages in $PACKAGEDIR"
    rm $PACKAGEDIR/*
    echo "Creating nuget packages in $PACKAGEDIR"
    dotnet pack -p:PackageVersion=2.0.0-alpha2.1000 --include-symbols --include-source -o $PACKAGEDIR
    #remove symbols from the file name
    for f in $PACKAGEDIR/*.symbols.nupkg; do
        mv ${f} ${f/.symbols/}
    done
    echo "Created..."
    for entry in $PACKAGEDIR/*
    do
      echo $entry
    done
fi