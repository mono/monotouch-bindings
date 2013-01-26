XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
VERSION=2.0
PROJECT_ROOT=cocos2d-iphone-$(VERSION)
PROJECT_TGZ=$(PROJECT_ROOT).tar.gz
PROJECT=$(PROJECT_ROOT)/cocos2d-ios.xcodeproj
TARGET=cocos2d
CONFIGURATION=Release

all: Cocos2D.dll

debug: CONFIGURATION = Debug
debug: all

$(PROJECT_TGZ):
	curl http://cocos2d-iphone.googlecode.com/files/$(PROJECT_TGZ) -o $(PROJECT_TGZ) 

$(PROJECT): $(PROJECT_TGZ)
	tar xfz $<

lib$(TARGET)-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/lib$(TARGET).a $@

lib$(TARGET)-armv7.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/lib$(TARGET).a $@

#lib$(TARGET)-armv7s.a: $(PROJECT)
#	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
#	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/lib$(TARGET).a $@

lib$(TARGET).a: lib$(TARGET)-i386.a lib$(TARGET)-armv7.a #lib$(TARGET)-armv7s.a
	lipo -create -output $@ $^

Cocos2D.dll: ApiDefinition.cs StructsAndEnums.cs Extra.cs AssemblyInfo.cs lib$(TARGET).a
	mkdir -p ios
	#$(BTOUCH) -e ApiDefinition.cs -s StructsAndEnums.cs AssemblyInfo.cs --tmpdir=ios --out=$@ --link-with=lib$(TARGET).a,lib$(TARGET).a
	$(BTOUCH) -unsafe ApiDefinition.cs -s StructsAndEnums.cs --tmpdir=ios --sourceonly ios/sources.list
	$(SMCS) -noconfig -o- -out:$@ -res:libcocos2d.a AssemblyInfo.cs StructsAndEnums.cs Extra.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll  
	cp $@ ../template/Cocos2D/
clean: 
	-rm -f *.a *.dll

clean-all: clean
	-rm -rf $(PROJECT_ROOT) $(PROJECT_TGZ) ios

.PHONY: clean clean-all

merge-docs: $(PROJECT)
	../../RunDoxy cocos2d-iphone-2.0 doxygen.config `pwd`/../docs