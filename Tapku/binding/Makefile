BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=/Developer/usr/bin/xcodebuild
PROJECT_ROOT=tapkulibrary/src
PROJECT=$(PROJECT_ROOT)/TapkuLibrary.xcodeproj
TARGET=TapkuLibrary

all: TapkuLibrary.dll


libTapkuLibrary-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@


libTapkuLibrary-armv6.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libTapkuLibrary-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@


libTapkuLibraryUniversal.a: lib$(TARGET)-armv7.a lib$(TARGET)-armv6.a lib$(TARGET)-i386.a
	lipo -create -output $@ $^


TapkuLibrary.dll: AssemblyInfo.cs Tapku.cs lib$(TARGET)Universal.a
	make libTapkuLibrary-i386.a
	make libTapkuLibrary-armv6.a
	make libTapkuLibrary-armv7.a
	make libTapkuLibraryUniversal.a
	$(BTOUCH)  Tapku.cs AssemblyInfo.cs --out=$@ --link-with=libTapkuLibraryUniversal.a,libTapkuLibraryUniversal.a -x=extras.cs

clean:
	-rm -f *.a *.dll

