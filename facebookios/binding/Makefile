MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
DATE=20150430
VERSION=4.1.0

all: Facebook-Unified.dll

FacebookSDKs-iOS-$(DATE).pkg:
	curl -O https://developers.facebook.com/resources/FacebookSDKs-iOS-$(DATE).pkg > $@
	pkgutil --expand FacebookSDKs-iOS-$(DATE).pkg FacebookSDKs-iOS-$(DATE)
	cd FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/ && tar xvf Payload

FBSDKCoreKit.a: FacebookSDKs-iOS-$(DATE).pkg
	cp FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/Documents/FacebookSDK/Bolts.framework/Bolts Bolts.a
	cp FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/Documents/FacebookSDK/FBSDKCoreKit.framework/FBSDKCoreKit FBSDKCoreKit.a
	cp FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/Documents/FacebookSDK/FBSDKLoginKit.framework/FBSDKLoginKit FBSDKLoginKit.a
	cp FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/Documents/FacebookSDK/FBSDKMessengerShareKit.framework/FBSDKMessengerShareKit FBSDKMessengerShareKit.a
	cp FacebookSDKs-iOS-$(DATE)/FacebookSDK.pkg/Documents/FacebookSDK/FBSDKShareKit.framework/FBSDKShareKit FBSDKShareKit.a

Facebook-Unified.dll: Makefile ApiDefinition.cs StructsAndEnums.cs FBSDKCoreKit.a
	$(MONOXBUILD) /t:Clean Facebook.csproj
	$(MONOXBUILD) /p:Configuration=Release Facebook.csproj
	mkdir -p build/unified/
	cp bin/unified/Release/Facebook.dll build/unified/Facebook.dll

prepare: FBSDKCoreKit.a

clean:
	-rm -rf list ios Resources/ FacebookSDKs-iOS-$(DATE)/ bin/ obj/ build/ *.sln *.userprefs *.dll *.o *.zip *.pkg *.mdb *.a
