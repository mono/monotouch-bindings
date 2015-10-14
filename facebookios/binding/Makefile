MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
DATE=20151007
VERSION=4.7

all: Facebook-Unified.dll

FBSDKCoreKit.a:
	curl -O https://developers.facebook.com/resources/FacebookSDKs-iOS-$(DATE).zip > FacebookSDKs-iOS-$(DATE).zip
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'Bolts.framework/Bolts' > Bolts.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKCoreKit.framework/FBSDKCoreKit' > FBSDKCoreKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKLoginKit.framework/FBSDKLoginKit' > FBSDKLoginKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKMessengerShareKit.framework/FBSDKMessengerShareKit' > FBSDKMessengerShareKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKShareKit.framework/FBSDKShareKit' > FBSDKShareKit.a

Resources/FacebookSDKStrings.bundle:
	mkdir -p Resources
	unzip FacebookSDKs-iOS-$(DATE).zip 'FacebookSDKStrings.bundle/*' -d Resources/

Facebook-Unified.dll: Makefile ApiDefinition.cs StructsAndEnums.cs FBSDKCoreKit.a Resources/FacebookSDKStrings.bundle
	$(MONOXBUILD) /t:Clean Facebook.csproj
	$(MONOXBUILD) /p:Configuration=Release Facebook.csproj
	mkdir -p build/unified/
	cp bin/unified/Release/Facebook.dll build/unified/Facebook.dll

prepare: FBSDKCoreKit.a

clean:
	-rm -rf list ios Resources/ FacebookSDKs-iOS-$(DATE)/ bin/ obj/ build/ *.sln *.userprefs *.dll *.o *.zip *.pkg *.mdb *.a
