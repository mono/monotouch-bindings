BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=ShareKitLibrary
PROJECT=$(PROJECT_ROOT)/ShareKitLibrary.xcodeproj
TARGET=ShareKitLibrary

all: ShareKit.dll

libShareKitLibrary-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@


libShareKitLibrary-armv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libShareKitLibrary-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@


libShareKitLibraryUniversal.a: lib$(TARGET)-armv7.a lib$(TARGET)-armv7s.a lib$(TARGET)-i386.a
	lipo -create -output $@ $^

ShareKit.dll: AssemblyInfo.cs sharekit.cs enums.cs lib$(TARGET)Universal.a
	make libShareKitLibrary-i386.a
	make libShareKitLibrary-armv7s.a
	make libShareKitLibrary-armv7.a
	make libShareKitLibraryUniversal.a
	$(BTOUCH) -e sharekit.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libShareKitLibraryUniversal.a,libShareKitLibraryUniversal.a

clean:
	-rm -rf *.a *.dll ShareKitLibrary/build/
