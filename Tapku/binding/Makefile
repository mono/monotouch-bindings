XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=tapkulibrary/src
PROJECT=$(PROJECT_ROOT)/TapkuLibrary.xcodeproj
TARGET=TapkuLibrary
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Tapku.dll

tapku-ios-sdk:
	git clone git://github.com/devinross/tapkulibrary.git

libTapkuLibrary-i386.a: tapku-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libTapkuLibrary-armv7.a: tapku-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@
	
libTapkuLibrary-armv7s.a: tapku-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@	


libTapkuLibraryUniversal.a:  lib$(TARGET)-armv7.a lib$(TARGET)-i386.a lib$(TARGET)-armv7s.a
	lipo -create -output $@ $^


Tapku.dll: clean lib$(TARGET)Universal.a
	$(MONOXBUILD) /p:Configuration=Release TapKu.csproj
	cp bin/Release/TapKu.dll TapKu.dll

clean:
	-rm -rf *.a *.dll tapkulibrary/

