VERSION=2.1-rc0a

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
PROJECT_ROOT=cocos2d-iphone-$(VERSION)
PROJECT_TGZ=$(PROJECT_ROOT).tar.gz
PROJECT=$(PROJECT_ROOT)/cocos2d-ios.xcodeproj
CONFIGURATION=Release

all: CocosDenshion.dll

debug: CONFIGURATION = Debug
debug: all

$(PROJECT_TGZ):
	curl http://cocos2d-iphone.googlecode.com/files/$(PROJECT_TGZ) -o $(PROJECT_TGZ) 

$(PROJECT): $(PROJECT_TGZ) 
	tar xfz $<

## libCocosDenshion
libCocosDenshion.a: libCocosDenshion-i386.a libCocosDenshion-armv7.a libCocosDenshion-armv7s.a
	lipo -create -output $@ $^

libCocosDenshion-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target CocosDenshion -sdk iphonesimulator -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/libCocosDenshion.a $@

libCocosDenshion-armv7.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target CocosDenshion -sdk iphoneos -arch armv7 -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libCocosDenshion.a $@

libCocosDenshion-armv7s.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target CocosDenshion -sdk iphoneos -arch armv7s -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libCocosDenshion.a $@

CocosDenshion.dll: ApiDefinition.cs StructsAndEnums.cs Extra.cs AssemblyInfo.cs libCocosDenshion.a
	-mkdir -p ios
	$(BTOUCH) -unsafe ApiDefinition.cs -s StructsAndEnums.cs --tmpdir=ios --sourceonly ios/sources.list 
	$(SMCS) -noconfig -o- -out:$@ -res:libCocosDenshion.a AssemblyInfo.cs StructsAndEnums.cs Extra.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean: 
	-rm -f *.a *.dll

clean-all: clean
	-rm -rf $(PROJECT_ROOT) $(PROJECT_TGZ) ios

.PHONY: clean clean-all tags

merge-docs: $(PROJECT)
	../../RunDoxy cocos2d-iphone-2.0 doxygen.config `pwd`/../docs
