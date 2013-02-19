BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: GoogleAdMobAds.dll

googleadmobadssdkios.zip: 
	curl http://dl.google.com/googleadmobadssdk/googleadmobadssdkios.zip > $@

libGoogleAdMobAds.a: googleadmobadssdkios.zip
	unzip -p $< 'GoogleAdMobAdsSdkiOS-6.3.0/libGoogleAdMobAds.a' > $@

GoogleAdMobAds.dll: Makefile AssemblyInfo.cs admobads.cs enums.cs extensions.cs libGoogleAdMobAds.a libAdmobExporter.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG admobads.cs -s:enums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:GoogleAdMobAds.dll -resource:libGoogleAdMobAds.a -resource:libAdmobExporter.a AssemblyInfo.cs extensions.cs enums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll
clean:
	-rm -rf list ios libGoogleAdMobAds.a *.dll *.zip *.mdb
