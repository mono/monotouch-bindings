XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
PROJECT_ROOT=VENCalculatorInputView
PROJECT=$(PROJECT_ROOT)/VENCalculatorInputView.xcodeproj
TARGET=VENCalculatorInputView

VERSIONTAG=v1.1.1

all: VENCalculatorInputViewBinding.dll

libVENCalculatorInputView-sdk:
	git clone https://github.com/venmo/VENCalculatorInputView.git && cd VENCalculatorInputView && git checkout tags/$(VERSIONTAG)

libVENCalculatorInputView-resources: libVENCalculatorInputView-sdk
	mkdir Resources
	cp ${PROJECT_ROOT}/VENCalculatorInputView/Images/* Resources/
	ibtool --output-format human-readable-text --compile Resources/VENCalculatorInputView.nib VENCalculatorInputView/VENCalculatorInputView/VENCalculatorInputView.xib
 
libVENCalculatorInputView-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libVENCalculatorInputView-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputView-armv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputView-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputViewSDK.a: libVENCalculatorInputView-i386.a libVENCalculatorInputView-armv7.a libVENCalculatorInputView-armv7s.a libVENCalculatorInputView-arm64.a
	lipo -create -output $@ $^

VENCalculatorInputViewBinding.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libVENCalculatorInputView-resources libVENCalculatorInputViewSDK.a
	$(MONOXBUILD) /p:Configuration=Release VENCalculatorInputViewBinding.csproj
	cp bin/Release/VENCalculatorInputViewBinding.dll VENCalculatorInputViewBinding.dll

prepare: libVENCalculatorInputView-resources libVENCalculatorInputViewSDK.a

clean:
	rm -rf list ios *.dll *.zip *.mdb *.sln *.a *.dll *.png *.nib *.xib bin/ obj/ VENCalculatorInputView/ Resources/