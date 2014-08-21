#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

## Add Sample projects here
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=LookbackSample/LookbackSample.sln

all: setup
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done

setup:
	cp ../binding/Lookback-Resources/*.* LookbackSample/
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
