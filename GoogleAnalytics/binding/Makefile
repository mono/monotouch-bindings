BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: GoogleAnalytics.dll

GoogleAnalyticsiOS_1.4.tar.gz:
	curl -O http://dl.google.com/gaformobileapps/GoogleAnalyticsiOS_1.4.tar.gz

libGoogleAnalytics_NoThumb.a: GoogleAnalyticsiOS_1.4.tar.gz
	tar xOzvf GoogleAnalyticsiOS_1.4.tar.gz 'Google Analytics SDK/Library/libGoogleAnalytics_NoThumb.a' > $@

GoogleAnalytics.dll: Makefile AssemblyInfo.cs googleanalytics.cs enums.cs libGoogleAnalytics_NoThumb.a
	-mkdir -p ios
	$(BTOUCH) --out=$@ -e googleanalytics.cs enums.cs --sourceonly=list --tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ @list enums.cs AssemblyInfo.cs -r:monotouch.dll -res:libGoogleAnalytics_NoThumb.a,libGoogleAnalytics_NoThumb.a

clean:
	-rm -rf list ios *.a *.dll
