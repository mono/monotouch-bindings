XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=tapkulibrary/src
PROJECT=$(PROJECT_ROOT)/TapkuLibrary.xcodeproj
TARGET=TapkuLibrary

all: Tapku.dll

tapku-ios-sdk:
	git clone git://github.com/devinross/tapkulibrary.git

libTapkuLibrary-i386.a: tapku-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libTapkuLibrary-armv7.a: tapku-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@


libTapkuLibraryUniversal.a:  lib$(TARGET)-armv7.a lib$(TARGET)-i386.a
	lipo -create -output $@ $^


Tapku.dll: AssemblyInfo.cs Tapku.cs lib$(TARGET)Universal.a
	$(BTOUCH)  Tapku.cs AssemblyInfo.cs Enums.cs --out=$@ --link-with=libTapkuLibraryUniversal.a,libTapkuLibraryUniversal.a

clean:
	-rm -f *.a *.dll

