BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=/Developer/usr/bin/xcodebuild
PROJECT_ROOT=tapkulibrary/src
PROJECT=$(PROJECT_ROOT)/TapkuLibrary.xcodeproj
TARGET=TapkuLibrary

all: Tapku.dll

tapkulibrary: 
	git clone git@github.com:devinross/tapkulibrary.git

libTapku-i386.a: tapkulibrary
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libTapku-armv6.a: tapkulibrary
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libTapku-armv7.a: tapkulibrary
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libTapkuSDK.a: libTapku-i386.a libTapku-armv6.a libTapku-armv7.a
	lipo -create -output $@ $^

Tapku.dll: Makefile tapku.cs AssemblyInfo.cs libTapkuSDK.a
	$(BTOUCH) -out=$@ -e tapku.cs AssemblyInfo.cs --link-with=libTapkuSDK.a,libTapkuSDK.a

clean:
	-rm -f *.a *.dll
