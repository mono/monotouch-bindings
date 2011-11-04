BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: GoogleAdMobAds.dll

googleadmobadssdkios.zip: 
	curl http://dl.google.com/googleadmobadssdk/googleadmobadssdkios.zip > $@

libGoogleAdMobAds.a: googleadmobadssdkios.zip
	unzip -p $< 'GoogleAdMobAdsSDK/libGoogleAdMobAds.a' > $@

# Note: The following rule works only with MonoTouch >= 5.0.3 due to a bug in btouch wrt the -x option
#GoogleAdMobAds.dll: Makefile AssemblyInfo.cs admobads.cs enums.cs extensions.cs libGoogleAdMobAds.a
#	$(BTOUCH) --out=$@ -e admobads.cs -s enums.cs -x extensions.cs -x AssemblyInfo.cs --link-with=libGoogleAdMobAds.a,libGoogleAdMobAds.a

GoogleAdMobAds.dll: Makefile AssemblyInfo.cs admobads.cs enums.cs extensions.cs libGoogleAdMobAds.a
	-mkdir -p ios
	$(BTOUCH) --out=$@ -e admobads.cs enums.cs --sourceonly=list --tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ @list enums.cs extensions.cs AssemblyInfo.cs -r:monotouch.dll -res:libGoogleAdMobAds.a,libGoogleAdMobAds.a

clean:
	-rm -rf list ios *.a *.dll
