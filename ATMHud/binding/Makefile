XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=atmhud-sdk
PROJECT=$(PROJECT_ROOT)/atmhud-sdk.xcodeproj
TARGET=atmhud-sdk

all: ATMHud.dll

libATMHud-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libATMHud-armv6.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libATMHud-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libATMHudSDK.a: libATMHud-i386.a libATMHud-armv6.a libATMHud-armv7.a
	lipo -create -output $@ $^

ATMHud.dll: atmhud.cs enums.cs AssemblyInfo.cs libATMHudSDK.a
	$(BTOUCH) -e atmhud.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libATMHudSDK.a,libATMHudSDK.a

clean: 
	-rm -f *.a *.dll
