XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=facebook-ios-sdk/src
PROJECT=$(PROJECT_ROOT)/facebook-ios-sdk.xcodeproj
TARGET=facebook-ios-sdk
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: MonoTouch.FacebookConnect.dll

facebook-ios-sdk:
	git clone git@github.com:facebook/facebook-ios-sdk.git

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

Resources: libFacebookSDK.a
	mkdir Resources
	cp -R facebook-ios-sdk/src/ImageResources Resources/ImageResources

MonoTouch.FacebookConnect.dll: libFacebookSDK.a Resources libarclite.a
	-mkdir -p ios
	$(MONOXBUILD) /p:Configuration=Release MonoTouch.FacebookConnect.csproj
	cp bin/Release/MonoTouch.FacebookConnect.dll MonoTouch.FacebookConnect.dll
#	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
#	$(SMCS) -noconfig -debug:full -debug+ -optimize- -out:MonoTouch.FacebookConnect.dll -resource:libFacebookSDK.a -resource:Resources/ImageResources/Contents/Resources/en.lproj/Localizable.strings,__monotouch_content_ImageResources_fContents_fResources_fen.lproj_fLocalizable.strings -resource:Resources/ImageResources/Contents/Resources/he.lproj/Localizable.strings,__monotouch_content_ImageResources_fContents_fResources_fhe.lproj_fLocalizable.strings -resource:Resources/ImageResources/Contents/Resources/en.lproj/Localizable.strings,__monotouch_content_ImageResources_fContents_fResources_fen.lproj_fLocalizable.strings -resource:Resources/ImageResources/Contents/Resources/he.lproj/Localizable.strings,__monotouch_content_ImageResources_fContents_fResources_fhe.lproj_fLocalizable.strings -resource:Resources/ImageResources/FBDialog/images/close.png,__monotouch_content_ImageResources_fFBDialog_fimages_fclose.png -resource:Resources/ImageResources/FBDialog/images/close@2x.png,__monotouch_content_ImageResources_fFBDialog_fimages_fclose@2x.png -resource:Resources/ImageResources/FBDialog/images/fbicon.png,__monotouch_content_ImageResources_fFBDialog_fimages_ffbicon.png -resource:Resources/ImageResources/FBFriendPickerView/images/default.png,__monotouch_content_ImageResources_fFBFriendPickerView_fimages_fdefault.png -resource:Resources/ImageResources/FBLoginView/images/bluetint.png,__monotouch_content_ImageResources_fFBLoginView_fimages_fbluetint.png -resource:Resources/ImageResources/FBLoginView/images/f_logo.png,__monotouch_content_ImageResources_fFBLoginView_fimages_ff__logo.png -resource:Resources/ImageResources/FBLoginView/images/facebook.png,__monotouch_content_ImageResources_fFBLoginView_fimages_ffacebook.png -resource:Resources/ImageResources/FBLoginView/images/login-button-small-pressed.png,__monotouch_content_ImageResources_fFBLoginView_fimages_flogin-button-small-pressed.png -resource:Resources/ImageResources/FBLoginView/images/login-button-small-pressed@2x.png,__monotouch_content_ImageResources_fFBLoginView_fimages_flogin-button-small-pressed@2x.png -resource:Resources/ImageResources/FBLoginView/images/login-button-small.png,__monotouch_content_ImageResources_fFBLoginView_fimages_flogin-button-small.png -resource:Resources/ImageResources/FBLoginView/images/login-button-small@2x.png,__monotouch_content_ImageResources_fFBLoginView_fimages_flogin-button-small@2x.png -resource:Resources/ImageResources/FBPlacePickerView/images/fb_generic_place.png,__monotouch_content_ImageResources_fFBPlacePickerView_fimages_ffb__generic__place.png -resource:Resources/ImageResources/FBProfilePictureView/images/fb_blank_profile_portrait.png,__monotouch_content_ImageResources_fFBProfilePictureView_fimages_ffb__blank__profile__portrait.png -resource:Resources/ImageResources/FBProfilePictureView/images/fb_blank_profile_square.png,__monotouch_content_ImageResources_fFBProfilePictureView_fimages_ffb__blank__profile__square.png -resource:Resources/ImageResources/images/facebook-logo.png,__monotouch_content_ImageResources_fimages_ffacebook-logo.png -resource:Resources/ImageResources/images/facebook-logo@2x.png,__monotouch_content_ImageResources_fimages_ffacebook-logo@2x.png -resource:Resources/ImageResources/images/silver-button-normal.png,__monotouch_content_ImageResources_fimages_fsilver-button-normal.png -resource:Resources/ImageResources/images/silver-button-normal@2x.png,__monotouch_content_ImageResources_fimages_fsilver-button-normal@2x.png -resource:Resources/ImageResources/images/silver-button-pressed.png,__monotouch_content_ImageResources_fimages_fsilver-button-pressed.png -resource:Resources/ImageResources/images/silver-button-pressed@2x.png,__monotouch_content_ImageResources_fimages_fsilver-button-pressed@2x.png -resource:Resources/ImageResources/images/loginBackgroundIPadLandscape.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPadLandscape.jpg -resource:Resources/ImageResources/images/loginBackgroundIPadLandscape@2x.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPadLandscape@2x.jpg -resource:Resources/ImageResources/images/loginBackgroundIPadPortrait.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPadPortrait.jpg -resource:Resources/ImageResources/images/loginBackgroundIPadPortrait@2x.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPadPortrait@2x.jpg -resource:Resources/ImageResources/images/loginBackgroundIPhonePortrait.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPhonePortrait.jpg -resource:Resources/ImageResources/images/loginBackgroundIPhonePortrait@2x.jpg,__monotouch_content_ImageResources_fimages_floginBackgroundIPhonePortrait@2x.jpg libFacebookSDK.linkwith.cs extensions.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+ -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

prepare: libFacebookSDK.a Resources libarclite.a

merge-docs: facebook-ios-sdk
	../../RunDoxy -g facebook-ios-sdk/src Doxyfile `pwd`/../docs

clean:
	-rm -rf libarclite.linkwith.cs *.a *.dll *.mdb bin/ obj/ list ios facebook-ios-sdk/ Resources/

cleanproject:
	-rm -rf *.dll bin/ obj/ list ios/
