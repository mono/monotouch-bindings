XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
#BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/VENCalculatorInputView.xcodeproj
TARGET=VENCalculatorInputView

all: libVENCalculatorInputViewSDK.a

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

clean:
	-rm -f *.a *.dll