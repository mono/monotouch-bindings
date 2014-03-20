XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=objc-TimesSquare
PROJECT=$(PROJECT_ROOT)/TimesSquare.xcodeproj
TARGET=TimesSquare
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: TimesSquare.iOS.dll

objc-TimesSquare-master: clean
	git clone git@github.com:square/objc-TimesSquare.git

libTimesSquare-i386.a: objc-TimesSquare-master
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/libTimesSquare.a $@

libTimesSquare-armv7.a: objc-TimesSquare-master
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libTimesSquare.a $@

libTimesSquare-armv7s.a: objc-TimesSquare-master
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libTimesSquare.a $@

libTimesSquare.a: libTimesSquare-i386.a libTimesSquare-armv7.a libTimesSquare-armv7s.a
	lipo -create -output $@ $^

TimesSquare.iOS.dll: ApiDefinition.cs StructsAndEnums.cs Makefile AssemblyInfo.cs libTimesSquare.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:TimesSquare.iOS.dll -resource:libTimesSquare.a AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios objc-TimesSquare *.a *dll *.mdb
