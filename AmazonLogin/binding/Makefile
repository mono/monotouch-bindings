#### Amazon LogIn
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Amazon.LogIn.dll

LoginWithAmazonSDKForiOS._TTH_.zip: 
	curl -L "https://images-na.ssl-images-amazon.com/images/G/01/lwa/sdk/LoginWithAmazonSDKForiOS._TTH_.zip" > $@

login-with-amazon-sdk.a: LoginWithAmazonSDKForiOS._TTH_.zip
	unzip -p $< 'LoginWithAmazonSDKForiOS/Build-universal/login-with-amazon-sdk.a' > $@

Amazon.LogIn.dll: Makefile login-with-amazon-sdk.linkwith.cs Extras.cs ApiDefinition.cs StructsAndEnums.cs login-with-amazon-sdk.a
	$(MONOXBUILD) /p:Configuration=Release Amazon.LogIn.csproj
	cp bin/Release/Amazon.LogIn.dll Amazon.LogIn.dll

clean:
	-rm -rf list ios bin/ obj/ *.dll *.o *.zip *.mdb *.a
