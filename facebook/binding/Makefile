XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=facebook-ios-sdk/src
PROJECT=$(PROJECT_ROOT)/facebook-ios-sdk.xcodeproj
TARGET=facebook-ios-sdk
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

# 	If you updated the binding to a newer Facebook version don't forget to change
#	the Git TAG of newer the version you are binding against
FBVERSIONTAG=sdk-version-3.8.0

all: MonoTouch.FacebookConnect.dll

facebook-ios-sdk:
	git clone git@github.com:facebook/facebook-ios-sdk.git && cd facebook-ios-sdk && git checkout tags/$(FBVERSIONTAG)

libFacebook-i386.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/libfacebook_ios_sdk.a $@

libFacebook-armv7.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libfacebook_ios_sdk.a $@

libFacebook-armv7s.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libfacebook_ios_sdk.a $@

libFacebookSDK.a: libFacebook-i386.a libFacebook-armv7.a libFacebook-armv7s.a
	lipo -create -output $@ $^

libarclite.a:
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.linkwith.cs > libarclite.linkwith.cs

# Not needed anymore (v3.8.0)
#Resources: libFacebookSDK.a
#	mkdir Resources
#	cp -R facebook-ios-sdk/src/FacebookSDKResources.bundle Resources/FacebookSDKResources.bundle
#	cp -R facebook-ios-sdk/src/FBUserSettingsViewResources.bundle Resources/FBUserSettingsViewResources.bundle

MonoTouch.FacebookConnect.dll: libFacebookSDK.a libarclite.a
	-mkdir -p ios
	$(MONOXBUILD) /p:Configuration=Release MonoTouch.FacebookConnect.csproj
	cp bin/Release/MonoTouch.FacebookConnect.dll MonoTouch.FacebookConnect.dll

prepare: libFacebookSDK.a libarclite.a

merge-docs: facebook-ios-sdk
	../../RunDoxy -g facebook-ios-sdk/src Doxyfile `pwd`/../docs

clean:
	-rm -rf libarclite.linkwith.cs *.a *.dll *.mdb bin/ obj/ *.sln *.userprefs build/ list ios facebook-ios-sdk/ Resources/

cleanproject:
	-rm -rf *.dll bin/ obj/ list ios/
