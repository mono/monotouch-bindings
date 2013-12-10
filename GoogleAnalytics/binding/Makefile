BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
CLANG=clang -isysroot /Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS5.0.sdk
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: GoogleAnalytics.iOS.dll

GoogleAnalyticsServicesiOS_3.02.zip:
	curl -O http://dl.google.com/googleanalyticsservices/GoogleAnalyticsServicesiOS_3.02.zip

libGoogleAnalyticsServices.a: GoogleAnalyticsServicesiOS_3.02.zip
	unzip -p $< 'GoogleAnalyticsServicesiOS_3.02/libGoogleAnalyticsServices.a' > $@

GoogleAnalytics.iOS.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libGoogleAnalyticsServices.a
	$(MONOXBUILD) /p:Configuration=Release GoogleAnalytics.iOS.csproj
	cp bin/Release/GoogleAnalytics.iOS.dll GoogleAnalytics.iOS.dll

clean:
	-rm -rf list ios libGoogleAnalyticsServices.a *.dll *.o *.zip bin/ obj/
