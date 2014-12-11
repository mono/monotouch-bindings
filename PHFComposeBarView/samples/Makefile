#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=\
	PHFComposeBarViewSample.sln \
	PHFComposeBarViewSample-Classic.sln \
	PHFComposeBarViewSample-Component.sln \
	PHFComposeBarViewSample-Classic-Component.sln \

all:
	cd ../binding/ && make all
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
