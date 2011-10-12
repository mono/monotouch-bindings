all: MGSplitViewController.dll

libMGSplitViewController-i386.a: 
	/Developer/usr/bin/xcodebuild -project MGSplitViewController/MGSplitViewController.xcodeproj -target MGSplitViewController -sdk iphonesimulator -configuration Release clean build
	mv -f MGSplitViewController/build/Release-iphonesimulator/libMGSplitViewController.a libMGSplitViewController-i386.a

libMGSplitViewController-armv6.a: 
	/Developer/usr/bin/xcodebuild -project MGSplitViewController/MGSplitViewController.xcodeproj -target MGSplitViewController -sdk iphoneos -arch armv6 -configuration Release clean build
	mv -f MGSplitViewController/build/Release-iphoneos/libMGSplitViewController.a libMGSplitViewController-armv6.a

libMGSplitViewController-armv7.a: 
	/Developer/usr/bin/xcodebuild -project MGSplitViewController/MGSplitViewController.xcodeproj -target MGSplitViewController -sdk iphoneos -arch armv7 -configuration Release clean build
	mv -f MGSplitViewController/build/Release-iphoneos/libMGSplitViewController.a libMGSplitViewController-armv7.a

libMGSplitViewControllerSDK.a: libMGSplitViewController-i386.a libMGSplitViewController-armv6.a libMGSplitViewController-armv7.a
	lipo -create -output libMGSplitViewControllerSDK.a libMGSplitViewController-i386.a libMGSplitViewController-armv6.a libMGSplitViewController-armv7.a

MGSplitViewController.dll: api.cs enums.cs AssemblyInfo.cs libMGSplitViewControllerSDK.a
	/Developer/MonoTouch/usr/bin/btouch api.cs enums.cs AssemblyInfo.cs --out=MGSplitViewController.dll --link-with=libMGSplitViewControllerSDK.a,libMGSplitViewControllerSDK.a

clean:
	-rm -f *.a *.dll
