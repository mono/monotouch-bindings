BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
VERSION=3.5.7
# HockeyApp iOS Version 3.5.7

all: HockeyApp.iOS.dll

Prepare:
	curl -L -o HockeySDK-iOS-$(VERSION).zip http://download.hockeyapp.net/sdk/ios/HockeySDK-iOS-$(VERSION).zip
	unzip HockeySDK-iOS-$(VERSION).zip
	cp HockeySDK-iOS/HockeySDK.embeddedframework/HockeySDK.framework/HockeySDK HockeySDK.a
	cp -r HockeySDK-iOS/HockeySDK.embeddedframework/Resources/HockeySDKResources.bundle HockeySDKResources.bundle

HockeyApp.iOS.dll: Prepare
	$(MDTOOL) build -c:"Release" HockeyApp.iOS.csproj
	cp bin/Release/HockeyApp.iOS.dll HockeyApp.iOS.dll

clean:
	-rm -rf Resources/ bin/ obj/ *.dll *.o *.mdb *.a Hockey-SDK-iOS-$(VERSION)/ *.zip HockeySDKResources.bundle HockeySDK-iOS/
