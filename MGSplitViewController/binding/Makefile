XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=MGSPlitViewController
PROJECT=$(PROJECT_ROOT)/MGSplitViewController.xcodeproj
TARGET=MGSplitViewController

all: MGSplitViewController.dll

libMGSplitViewController-i386.a: 
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv -f $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMGSplitViewController-%.a: 
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch $* -configuration Release clean build
	mv -f $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMGSplitViewControllerSDK.a: libMGSplitViewController-i386.a libMGSplitViewController-armv7.a libMGSplitViewController-armv7s.a
	lipo -create -output $@ $^

MGSplitViewController.dll: api.cs enums.cs AssemblyInfo.cs libMGSplitViewControllerSDK.a
	$(BTOUCH) -e api.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libMGSplitViewControllerSDK.a,libMGSplitViewControllerSDK.a

clean:
	-rm -f *.a *.dll
