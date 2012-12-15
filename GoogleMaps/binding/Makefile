BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MDTOOL=/Applications/MonoDevelop.app/Contents/MacOS/mdtool

all: GoogleMaps.dll

googlemaps-ios-1.0.1.zip:
	curl -O https://dl.google.com/geosdk/googlemaps-ios-1.0.1.zip > $@

libGoogleAdMobAds.a: googlemaps-ios-1.0.1.zip
	unzip -p $< 'GoogleAdMobAdsSDK/libGoogleAdMobAds.a' > $@


libGoogleAnalytics.a: GoogleAnalyticsiOS_1.4.tar.gz
	tar xOzvf GoogleAnalyticsiOS_1.4.tar.gz 'Google Analytics SDK/Library/libGoogleAnalytics.a' > $@

GoogleAnalytics.dll: Makefile AssemblyInfo.cs googleanalytics.cs enums.cs libGoogleAnalytics.a
	-mkdir -p ios
	$(BTOUCH) --out=$@ -e googleanalytics.cs enums.cs --sourceonly=list --tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ @list enums.cs AssemblyInfo.cs -r:monotouch.dll -res:libGoogleAnalytics.a,libGoogleAnalytics.a

clean:
	-rm -rf list ios *.a *.dll *.o
