BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=6.7.0

all: GoogleAdMobAds.dll

googlemobileadssdkios.zip:
	curl -O http://dl.google.com/googleadmobadssdk/googlemobileadssdkios.zip > $@
	unzip googlemobileadssdkios.zip GoogleAdMobAdsSdkiOS-$(VERSION)/libGoogleAdMobAds.a

libGoogleAdMobAds.a: googlemobileadssdkios.zip
	cp GoogleAdMobAdsSdkiOS-$(VERSION)/libGoogleAdMobAds.a libGoogleAdMobAds.a

GoogleAdMobAds.dll: Makefile ApiDefinition.cs StructsAndEnums.cs extensions.cs libAdmobExporter.a libAdmobExporter.linkwith.cs libGoogleAdMobAds.a libGoogleAdMobAds.linkwith.cs
	$(MONOXBUILD) /p:Configuration=Release GoogleAdMobAds.csproj
	cp bin/Release/GoogleAdMobAds.dll GoogleAdMobAds.dll

prepare: libGoogleAdMobAds.a

clean:
	-rm -rf list ios Resources/ GoogleAdMobAdsSdkiOS-$(VERSION)/ bin/ obj/ *.dll *.zip *.mdb *.sln libGoogleAdMobAds.a 
	
