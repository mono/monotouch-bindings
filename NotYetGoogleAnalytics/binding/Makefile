#
# This makefile is worse than it should be because Google shipped a broken
# libGoogleAnalytics_Nothub.a, we build a stub class to satisfy the unused
# dependency.
#

BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
CLANG=clang -isysroot /Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS5.0.sdk

all: GoogleAnalytics.dll

GoogleAnalyticsiOS_1.4.tar.gz:
	curl -O http://dl.google.com/gaformobileapps/GoogleAnalyticsiOS_1.4.tar.gz

STUBS = armv6.o armv7.o i386.o

armv6.o: stub.m
	$(CLANG) -c -arch armv6 stub.m -o armv6.o

armv7.o: stub.m
	$(CLANG) -c -arch armv7 stub.m -o armv7.o

i386.o: stub.m Makefile
	clang -isysroot /Developer/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator5.0.sdk -fobjc-abi-version=2 -fobjc-legacy-dispatch -c -arch i386 stub.m -o i386.o 


libFixedGoogleAnalytics.a: libGoogleAnalytics_NoThumb.a $(STUBS)
	lipo libGoogleAnalytics_NoThumb.a -thin armv6 -output libarmv6.a
	ar -q libarmv6.a armv6.o
	lipo libGoogleAnalytics_NoThumb.a -thin armv7 -output libarmv7.a
	ar -q libarmv7.a armv7.o
	lipo libGoogleAnalytics_NoThumb.a -thin i386 -output libi386.a
	ar -q libi386.a i386.o
	lipo -create libarmv6.a libarmv7.a libi386.a -output libFixedGoogleAnalytics.a 

libGoogleAnalytics_NoThumb.a: GoogleAnalyticsiOS_1.4.tar.gz
	tar xOzvf GoogleAnalyticsiOS_1.4.tar.gz 'Google Analytics SDK/Library/libGoogleAnalytics_NoThumb.a' > $@

GoogleAnalytics.dll: Makefile AssemblyInfo.cs googleanalytics.cs enums.cs libFixedGoogleAnalytics.a
	-mkdir -p ios
	$(BTOUCH) --out=$@ -e googleanalytics.cs enums.cs --sourceonly=list --tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ @list enums.cs AssemblyInfo.cs -r:monotouch.dll -res:libFixedGoogleAnalytics.a,libFixedGoogleAnalytics.a

clean:
	-rm -rf list ios *.a *.dll *.o
