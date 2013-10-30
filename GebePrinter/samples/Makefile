#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

#Add the path(s) to your .sln file in the projects var
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=

all:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
