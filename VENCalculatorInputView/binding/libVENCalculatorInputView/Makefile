XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
#BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=VENCalculatorInputView
OUTPUTPATH=.
PROJECT=$(PROJECT_ROOT)/VENCalculatorInputView.xcodeproj
TARGET=VENCalculatorInputView

VERSIONTAG=v1.1.1

all: libVENCalculatorInputViewSDK.a mopup

libVENCalculatorInputView-sdk:
	git clone https://github.com/venmo/VENCalculatorInputView.git && cd VENCalculatorInputView && git checkout tags/$(VERSIONTAG)

libVENCalculatorInputView-resources: libVENCalculatorInputView-sdk
	cp ${PROJECT_ROOT}/VENCalculatorInputView/Images/VENCalculatorIconBackspace.png ${OUTPUTPATH}/VENCalculatorIconBackspace.png && cp ${PROJECT_ROOT}/VENCalculatorInputView/Images/VENCalculatorIconBackspace@2x.png ${OUTPUTPATH}/VENCalculatorIconBackspace@2x.png && cp ${PROJECT_ROOT}/VENCalculatorInputView/VENCalculatorInputView.xib ${OUTPUTPATH}/VENCalculatorInputView.xib && ibtool --output-format human-readable-text --compile VENCalculatorInputView.nib VENCalculatorInputView.xib
 
libVENCalculatorInputView-i386.a: libVENCalculatorInputView-resources
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libVENCalculatorInputView-armv7.a: libVENCalculatorInputView-resources
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputView-armv7s.a: libVENCalculatorInputView-resources
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputView-arm64.a: libVENCalculatorInputView-resources
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libVENCalculatorInputViewSDK.a: libVENCalculatorInputView-i386.a libVENCalculatorInputView-armv7.a libVENCalculatorInputView-armv7s.a libVENCalculatorInputView-arm64.a
	lipo -create -output $@ $^

mopup:
	rm -rf VENCalculatorInputView && rm libVENCalculatorInputView-arm64.a && rm libVENCalculatorInputView-armv7.a && rm libVENCalculatorInputView-armv7s.a && rm libVENCalculatorInputView-i386.a && rm VENCalculatorInputView.xib

clean:
	-rm -f *.a *.dll *.png *.nib && rm -rf VENCalculatorInputView