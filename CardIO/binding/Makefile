BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
VERSION=3.6.4
# Card.IO iOS Version 3.5.4

all: Card.IO.iOS.dll

Prepare:
	curl -L -o Card.IO-iOS-$(VERSION).zip https://github.com/card-io/card.io-iOS-SDK/releases/download/v$(VERSION)/card.io_ios_sdk_$(VERSION).zip
	unzip Card.IO-iOS-$(VERSION).zip
	cp card.io_ios_sdk_$(VERSION)/CardIO/libCardIO.a libCardIO.a
	
Card.IO.iOS.dll: Prepare
	$(MDTOOL) build -c:"Release" Card.IO.iOS.csproj
	cp bin/Release/Card.IO.iOS.dll Card.IO.iOS.dll

clean:
	-rm -rf Resources/ bin/ obj/ *.dll *.o *.mdb *.a card.io_ios_sdk_$(VERSION)/ *.zip 
