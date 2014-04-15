#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool

all:
	$(MDTOOL) build -c:"Release|iPhone" CardIOSampleiOS/CardIOSampleiOS.sln
	
clean:
	$(MDTOOL) build -c:"Release|iPhone" -t:Clean CardIOSampleiOS/CardIOSampleiOS.sln
	cd CardIOSampleiOS/CardIOSampleiOS/ && rm -rf bin/ obj/ *.dll *.o *.mdb

