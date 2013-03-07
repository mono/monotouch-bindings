ENABLE_CHIPMUNK_INTEGRATION=1
VERSION=2.1-rc0a

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
PROJECT_ROOT=cocos2d-iphone-$(VERSION)
PROJECT_TGZ=$(PROJECT_ROOT).tar.gz
PROJECT=$(PROJECT_ROOT)/cocos2d-ios.xcodeproj
CONFIGURATION=Release

ifeq ($(ENABLE_CHIPMUNK_INTEGRATION), 1)	
	XCODEEXTRA=GCC_PREPROCESSOR_DEFINITIONS="CC_ENABLE_CHIPMUNK_INTEGRATION=1" 
	CHIPMUNK_CS=	../../chipmunk/binding/src/Arbiter.cs			\
			../../chipmunk/binding/src/Body.cs			\
			../../chipmunk/binding/src/BoundingBox.cs		\
			../../chipmunk/binding/src/ChipmunkObject.cs		\
			../../chipmunk/binding/src/Helper.cs			\
			../../chipmunk/binding/src/Shape.cs			\
			../../chipmunk/binding/src/Space.cs			\
			../../chipmunk/binding/src/Constraint.cs

	CHIPMUNK_LIB= 	libChipmunk.a
CHIPMUNK_RES= -res:libChipmunk.a
else
	XCODEEXTRA=
	CHIPMUNK_CS=
	CHIPMUNK_LIB=
	CHIPMUNK_RES=
endif


all: Cocos2D.dll

debug: CONFIGURATION = Debug
debug: all

$(PROJECT_TGZ):
	curl http://cocos2d-iphone.googlecode.com/files/$(PROJECT_TGZ) -o $(PROJECT_TGZ) 

$(PROJECT_ROOT)/patched_for_chipmunk: $(PROJECT_TGZ) ../../chipmunk/binding/chipmunk-diff
	rm -rf $(PROJECT_ROOT)
	tar xfz $<
	patch -d $(PROJECT_ROOT)/external/Chipmunk -p1 < ../../chipmunk/binding/chipmunk-diff
	touch $(PROJECT_ROOT)/patched_for_chipmunk

$(PROJECT): $(PROJECT_ROOT)/patched_for_chipmunk

## libcocos2d
libcocos2d.a: libcocos2d-i386.a libcocos2d-armv7.a #libcocos2d-armv7s.a
	lipo -create -output $@ $^

libcocos2d-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target cocos2d -sdk iphonesimulator -configuration $(CONFIGURATION) $(XCODEEXTRA) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/libcocos2d.a $@

libcocos2d-armv7.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target cocos2d -sdk iphoneos -arch armv7 -configuration $(CONFIGURATION) $(XCODEEXTRA) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libcocos2d.a $@

libcocos2d-armv7s.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target cocos2d -sdk iphoneos -arch armv7s -configuration $(CONFIGURATION) $(XCODEEXTRA) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libcocos2d.a $@

## libChipmunk.a
libChipmunk.a: libChipmunk-i386.a libChipmunk-armv7.a #libChipmunk-armv7s.a
	lipo -create -output $@ $^

libChipmunk-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target Chipmunk -sdk iphonesimulator -configuration $(CONFIGURATION) GCC_PREPROCESSOR_DEFINITIONS="CHIPMUNK_BIND" clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/libChipmunk.a $@

libChipmunk-armv7.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target Chipmunk -sdk iphoneos -arch armv7 -configuration $(CONFIGURATION) GCC_PREPROCESSOR_DEFINITIONS="CHIPMUNK_BIND" clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libChipmunk.a $@

libChipmunk-armv7s.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target Chipmunk -sdk iphoneos -arch armv7s -configuration $(CONFIGURATION) GCC_PREPROCESSOR_DEFINITIONS="CHIPMUNK_BIND" clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/libChipmunk.a $@

Cocos2D.dll: ApiDefinition.cs StructsAndEnums.cs Extra.cs $(CHIPMUNK_CS) AssemblyInfo.cs libcocos2d.a $(CHIPMUNK_LIB)
	-mkdir -p ios
	$(BTOUCH) -unsafe ApiDefinition.cs -s StructsAndEnums.cs --tmpdir=ios --sourceonly ios/sources.list -d ENABLE_CHIPMUNK_INTEGRATION 
	$(SMCS) -noconfig -o- -out:$@ -res:libcocos2d.a $(CHIPMUNK_RES) AssemblyInfo.cs StructsAndEnums.cs Extra.cs @ios/sources.list $(CHIPMUNK_CS) -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll -define:ENABLE_CHIPMUNK_INTEGRATION
	cp $@ ../template/Cocos2D/
clean: 
	-rm -f *.a *.dll

clean-all: clean
	-rm -rf $(PROJECT_ROOT) $(PROJECT_TGZ) ios

.PHONY: clean clean-all tags

merge-docs: $(PROJECT)
	../../RunDoxy cocos2d-iphone-2.0 doxygen.config `pwd`/../docs

tags: ApiDefinition.cs StructsAndEnums.cs Extra.cs
	ctags --recurse -f tags --extra=+fq --fields=+ianmzS --C#-kinds=cimnp ios/Cocos2D
