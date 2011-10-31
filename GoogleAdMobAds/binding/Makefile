BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: GoogleAdMobAds.dll

googleadmobadssdkios.zip: 
	curl http://dl.google.com/googleadmobadssdk/googleadmobadssdkios.zip > $@

libGoogleAdMobAds.a: googleadmobadssdkios.zip
	unzip -p $< 'GoogleAdMobAdsSDK/libGoogleAdMobAds.a' > $@

GoogleAdMobAds.dll: Makefile AssemblyInfo.cs admobads.cs enums.cs extensions.cs libGoogleAdMobAds.a
	$(BTOUCH) --out=$@ -e admobads.cs -s enums.cs -x extensions.cs -x AssemblyInfo.cs --link-with=libGoogleAdMobAds.a,libGoogleAdMobAds.a

clean:
	-rm -rf *.a *.dll
