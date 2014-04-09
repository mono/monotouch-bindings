XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=objc-TimesSquare
PROJECT=$(PROJECT_ROOT)/TimesSquare.xcodeproj
TARGET=TimesSquare
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

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

libTimesSquare-arm64.a: objc-TimesSquare-master
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libTimesSquare.a $@

libTimesSquare.a: libTimesSquare-i386.a libTimesSquare-armv7.a libTimesSquare-armv7s.a libTimesSquare-arm64.a
	lipo -create -output $@ $^

TimesSquare.iOS.dll: ApiDefinition.cs StructsAndEnums.cs Makefile libTimesSquare.a
	-mkdir -p ios
	$(MONOXBUILD) /p:Configuration=Release TimesSquare.iOS.csproj
	cp bin/Release/TimesSquare.iOS.dll TimesSquare.iOS.dll

clean:
	-rm -rf list ios objc-TimesSquare *.a *dll *.mdb
