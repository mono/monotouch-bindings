XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=MGSPlitViewController
PROJECT=$(PROJECT_ROOT)/MGSplitViewController.xcodeproj
TARGET=MGSplitViewController

all: MGSplitViewController.dll

libMGSplitViewController-i386.a: 
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv -f $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMGSplitViewController-armv6.a: 
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	mv -f $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMGSplitViewController-armv7.a: 
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	mv -f $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMGSplitViewControllerSDK.a: libMGSplitViewController-i386.a libMGSplitViewController-armv6.a libMGSplitViewController-armv7.a
	lipo -create -output $@ $^

MGSplitViewController.dll: api.cs enums.cs AssemblyInfo.cs libMGSplitViewControllerSDK.a
	$(BTOUCH) -e api.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libMGSplitViewControllerSDK.a,libMGSplitViewControllerSDK.a

clean:
	-rm -f *.a *.dll
