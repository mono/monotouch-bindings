XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=facebook-ios-sdk/src
PROJECT=$(PROJECT_ROOT)/facebook-ios-sdk.xcodeproj
TARGET=facebook-ios-sdk
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Facebook.dll

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

Resources: libFacebookSDK.a
	mkdir Resources
	cp -R facebook-ios-sdk/src/FacebookSDKResources.bundle Resources/FacebookSDKResources.bundle
	cp -R facebook-ios-sdk/src/FBUserSettingsViewResources.bundle Resources/FBUserSettingsViewResources.bundle

Facebook.dll: libFacebookSDK.a Resources
	-mkdir -p ios
	$(MONOXBUILD) /p:Configuration=Release MonoTouch.FacebookConnect.csproj
	cp bin/Release/MonoTouch.FacebookConnect.dll Facebook.dll
#	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
#	$(SMCS) -noconfig -debug:full -debug+ -optimize- -out:Facebook.dll -resource:libFacebookSDK.a -resource:Resources/FacebookSDKResources.bundle/Contents/Resources/en.lproj/Localizable.strings,__monotouch_content_FacebookSDKResources.bundle_fContents_fResources_fen.lproj_fLocalizable.strings -resource:Resources/FacebookSDKResources.bundle/Contents/Resources/he.lproj/Localizable.strings,__monotouch_content_FacebookSDKResources.bundle_fContents_fResources_fhe.lproj_fLocalizable.strings -resource:Resources/FBUserSettingsViewResources.bundle/Contents/Resources/en.lproj/Localizable.strings,__monotouch_content_FBUserSettingsViewResources.bundle_fContents_fResources_fen.lproj_fLocalizable.strings -resource:Resources/FBUserSettingsViewResources.bundle/Contents/Resources/he.lproj/Localizable.strings,__monotouch_content_FBUserSettingsViewResources.bundle_fContents_fResources_fhe.lproj_fLocalizable.strings -resource:Resources/FacebookSDKResources.bundle/FBDialog/images/close.png,__monotouch_content_FacebookSDKResources.bundle_fFBDialog_fimages_fclose.png -resource:Resources/FacebookSDKResources.bundle/FBDialog/images/close@2x.png,__monotouch_content_FacebookSDKResources.bundle_fFBDialog_fimages_fclose@2x.png -resource:Resources/FacebookSDKResources.bundle/FBDialog/images/fbicon.png,__monotouch_content_FacebookSDKResources.bundle_fFBDialog_fimages_ffbicon.png -resource:Resources/FacebookSDKResources.bundle/FBFriendPickerView/images/default.png,__monotouch_content_FacebookSDKResources.bundle_fFBFriendPickerView_fimages_fdefault.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/bluetint.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_fbluetint.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/f_logo.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_ff__logo.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/facebook.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_ffacebook.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/login-button-small-pressed.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_flogin-button-small-pressed.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/login-button-small-pressed@2x.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_flogin-button-small-pressed@2x.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/login-button-small.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_flogin-button-small.png -resource:Resources/FacebookSDKResources.bundle/FBLoginView/images/login-button-small@2x.png,__monotouch_content_FacebookSDKResources.bundle_fFBLoginView_fimages_flogin-button-small@2x.png -resource:Resources/FacebookSDKResources.bundle/FBPlacePickerView/images/fb_generic_place.png,__monotouch_content_FacebookSDKResources.bundle_fFBPlacePickerView_fimages_ffb__generic__place.png -resource:Resources/FacebookSDKResources.bundle/FBProfilePictureView/images/fb_blank_profile_portrait.png,__monotouch_content_FacebookSDKResources.bundle_fFBProfilePictureView_fimages_ffb__blank__profile__portrait.png -resource:Resources/FacebookSDKResources.bundle/FBProfilePictureView/images/fb_blank_profile_square.png,__monotouch_content_FacebookSDKResources.bundle_fFBProfilePictureView_fimages_ffb__blank__profile__square.png -resource:Resources/FBUserSettingsViewResources.bundle/images/facebook-logo.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_ffacebook-logo.png -resource:Resources/FBUserSettingsViewResources.bundle/images/facebook-logo@2x.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_ffacebook-logo@2x.png -resource:Resources/FBUserSettingsViewResources.bundle/images/silver-button-normal.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_fsilver-button-normal.png -resource:Resources/FBUserSettingsViewResources.bundle/images/silver-button-normal@2x.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_fsilver-button-normal@2x.png -resource:Resources/FBUserSettingsViewResources.bundle/images/silver-button-pressed.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_fsilver-button-pressed.png -resource:Resources/FBUserSettingsViewResources.bundle/images/silver-button-pressed@2x.png,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_fsilver-button-pressed@2x.png -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPadLandscape.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPadLandscape.jpg -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPadLandscape@2x.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPadLandscape@2x.jpg -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPadPortrait.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPadPortrait.jpg -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPadPortrait@2x.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPadPortrait@2x.jpg -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPhonePortrait.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPhonePortrait.jpg -resource:Resources/FBUserSettingsViewResources.bundle/images/loginBackgroundIPhonePortrait@2x.jpg,__monotouch_content_FBUserSettingsViewResources.bundle_fimages_floginBackgroundIPhonePortrait@2x.jpg libFacebookSDK.linkwith.cs extensions.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+ -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

prepare: libFacebookSDK.a Resources

merge-docs: facebook-ios-sdk
	../../RunDoxy -g facebook-ios-sdk/src Doxyfile `pwd`/../docs

clean:
	-rm -rf *.a *.dll *.mdb bin/ obj/ list ios facebook-ios-sdk/ Resources/
