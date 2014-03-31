#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool

all:
	$(MDTOOL) build -c:"Release|iPhone" HockeyAppSampleiOS/HockeyAppSampleiOS.sln
	
clean:
	$(MDTOOL) build -c:"Release|iPhone" -t:Clean HockeyAppSampleiOS/HockeyAppSampleiOS.sln
	cd HockeyAppSampleiOS/
	-rm -rf Resources/ bin/ obj/ *.dll *.o *.mdb
	cd ..
