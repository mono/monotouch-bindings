BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild


XCODEBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=WEPopoverLib/WEPopover
PROJECT=$(PROJECT_ROOT)/WEPopover.xcodeproj
TARGET=WEPopover


all: WEPopover.dll

WEPopover.dll: Makefile $(PROJECT_ROOT)/lib$(TARGET).a
	$(MONOXBUILD) /p:Configuration=Release WEPopover.csproj
	cp bin/Release/WEPopover.dll WEPopover.dll

WEPopoverLib/extern/WEPopover/README : 
	mkdir -p WEPopoverLib/extern
	git clone git@github.com:werner77/WEPopover.git WEPopoverLib/extern/WEPopover
	cd WEPopoverLib/extern/WEPopover && git checkout beffd9f38b2cd48235262f40e51944b2076b17d7

$(PROJECT_ROOT)/lib$(TARGET)-i386.a: WEPopoverLib/extern/WEPopover/README
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

$(PROJECT_ROOT)/lib$(TARGET)-armv7.a: WEPopoverLib/extern/WEPopover/README
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

$(PROJECT_ROOT)/lib$(TARGET)-armv7s.a: WEPopoverLib/extern/WEPopover/README
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

$(PROJECT_ROOT)/lib$(TARGET)-arm64.a: WEPopoverLib/extern/WEPopover/README
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@


$(PROJECT_ROOT)/lib$(TARGET).a: $(PROJECT_ROOT)/lib$(TARGET)-i386.a $(PROJECT_ROOT)/lib$(TARGET)-armv7.a $(PROJECT_ROOT)/lib$(TARGET)-armv7s.a $(PROJECT_ROOT)/lib$(TARGET)-arm64.a
	lipo -create -output $@ $^

	
clean:
	-rm -rf *.dll bin/ obj/ WEPopoverLib/extern/WEPopover
