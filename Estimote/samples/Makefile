#### Sample Builder
#### Author: Woutercx wouter4@gmail.com

MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=EstimoteSample.iOS/EstimoteSample.iOS.sln

all:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
