#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

# Add path to sln in PROJECTS var.
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=XamOpenTokTest/XamOpenTokTest.sln

all:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
