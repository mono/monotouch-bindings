BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
VERSION=3.5.4
# HockeyApp iOS Version 3.5.4

all: HockeyApp.iOS.dll

HockeyApp.iOS.dll:
	$(MDTOOL) build -c:"Release" HockeyApp.iOS.csproj
	cp bin/Release/HockeyApp.iOS.dll HockeyApp.iOS.dll

clean:
	-rm -rf Resources/ bin/ obj/ *.dll *.o *.mdb 
