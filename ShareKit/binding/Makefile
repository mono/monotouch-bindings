BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=//Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=sharekit
PROJECT=$(PROJECT_ROOT)/ShareKit.xcodeproj
TARGET=ShareKitLibrary

all: ShareKit.dll

libShareKitLibrary-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@


libShareKitLibrary-armv6.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libShareKitLibrary-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@


libShareKitLibraryUniversal.a: lib$(TARGET)-armv7.a lib$(TARGET)-armv6.a lib$(TARGET)-i386.a
	lipo -create -output $@ $^

ShareKit.dll: AssemblyInfo.cs sharekit.cs enums.cs lib$(TARGET)Universal.a
	make libShareKitLibrary-i386.a
	make libShareKitLibrary-armv6.a
	make libShareKitLibrary-armv7.a
	make libShareKitLibraryUniversal.a
	$(BTOUCH) -e sharekit.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libShareKitLibraryUniversal.a,libShareKitLibraryUniversal.a

clean:
	-rm -f *.a *.dll
