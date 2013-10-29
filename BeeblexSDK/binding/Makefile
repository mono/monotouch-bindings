XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
VERSION=c2eda48
PROJECT_ROOT=BlueParabola-Beeblex-SDK-$(VERSION)
PROJECT_TGZ=$(PROJECT_ROOT).tar.gz
PROJECT=$(PROJECT_ROOT)/Beeblex-SDK.xcodeproj
TARGET=Beeblex-SDK
CONFIGURATION=Release

all: BeeblexSDK.dll

debug: CONFIGURATION = Debug
debug: all

$(PROJECT_TGZ):
	curl -L -o $(PROJECT_TGZ) https://github.com/BlueParabola/Beeblex-SDK/tarball/$(VERSION)

$(PROJECT): $(PROJECT_TGZ)
	tar xfz $<

# Xcode Project already builds Fat lib ARMv7 ARMv7s and i386
lib$(TARGET).a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration $(CONFIGURATION) clean build "GCC_SYMBOLS_PRIVATE_EXTERN=NO"
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/lib$(TARGET).a $@

BeeblexSDK.dll: ApiDefinition.cs Extensions.cs AssemblyInfo.cs lib$(TARGET).a
	mkdir -p ios
	$(BTOUCH) -unsafe ApiDefinition.cs --tmpdir=ios --sourceonly ios/sources.list
	$(SMCS) -noconfig -o- -out:$@ -res:libBeeblex-SDK.a AssemblyInfo.cs Extensions.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean: 
	-rm -rf *.a *.dll $(PROJECT_ROOT) $(PROJECT_TGZ) ios/
.PHONY: clean