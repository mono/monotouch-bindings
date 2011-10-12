XBUILD=/Developer/usr/bin/xcodebuild
PROJECT_ROOT=facebook-ios-sdk/src
PROJECT=$(PROJECT_ROOT)/facebook-ios-sdk.xcodeproj

all: FacebookConnect.dll

facebook-ios-sdk:
	git clone git@github.com:facebook/facebook-ios-sdk.git

libFacebook-i386.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target facebook-ios-sdk -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/libfacebook_ios_sdk.a $@

libFacebook-armv6.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target facebook-ios-sdk -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libfacebook_ios_sdk.a $@

libFacebook-armv7.a: facebook-ios-sdk
	$(XBUILD) -project $(PROJECT) -target facebook-ios-sdk -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libfacebook_ios_sdk.a $@

libFacebookSDK.a: libFacebook-i386.a libFacebook-armv6.a libFacebook-armv7.a
	lipo -create -output libFacebookSDK.a $^

FacebookConnect.dll: FacebookConnect.cs libFacebookSDK.a
	/Developer/MonoTouch/usr/bin/btouch -e FacebookConnect.cs --out=$@ --link-with=libFacebookSDK.a,libFacebookSDK.a

clean:
	-rm -f *.a *.dll
