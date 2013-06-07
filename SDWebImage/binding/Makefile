XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=SDWebImage
PROJECT=$(PROJECT_ROOT)/SDWebImage.xcodeproj
TARGET=SDWebImageFramework
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: SDWebImage.dll

SDWebImage: clean
	git clone --recursive git@github.com:rs/SDWebImage.git
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.linkwith.cs > libarclite.linkwith.cs

libSDWebImage.a: SDWebImage
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos6.1 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/SDWebImage.framework/Versions/A/SDWebImage $@

SDWebImage.dll: ApiDefinition.cs StructsAndEnums.cs Makefile SDWebImage.linkwith.cs libSDWebImage.a libarclite.a libarclite.linkwith.cs
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:SDWebImage.dll -resource:libarclite.a libarclite.linkwith.cs -resource:libSDWebImage.a SDWebImage.linkwith.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios SDWebImage *.a *dll *.mdb libarclite.linkwith.cs
