BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
CLANG=clang -isysroot /Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS5.0.sdk
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: GoogleAnalytics.dll

GoogleAnalyticsiOS_2.0beta4.zip:
	curl -O http://dl.google.com/dl/gaformobileapps/GoogleAnalyticsiOS_2.0beta4.zip

#STUBS = armv6.o armv7.o i386.o
#
#armv6.o: stub.m
#	$(CLANG) -c -arch armv6 stub.m -o armv6.o
#
#armv7.o: stub.m
#	$(CLANG) -c -arch armv7 stub.m -o armv7.o
#
#i386.o: stub.m Makefile
#	clang -isysroot /Developer/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator5.0.sdk -fobjc-abi-version=2 -fobjc-legacy-dispatch -c -arch i386 stub.m -o i386.o 


libGoogleAnalytics.a: GoogleAnalyticsiOS_2.0beta4.zip
	unzip -p $< 'GoogleAnalyticsiOS_2.0beta4/Library/libGoogleAnalytics.a' > $@

GoogleAnalytics.dll: Makefile ApiDefinition.cs StructsAndEnums.cs extras.cs libGoogleAnalytics.a
	$(MONOXBUILD) /p:Configuration=Release GoogleAnalytics.csproj
	cp bin/Release/GoogleAnalytics.dll GoogleAnalytics.dll
	#-mkdir -p ios
	#$(BTOUCH) --out=$@ -e googleanalytics.cs enums.cs --sourceonly=list --tmpdir=ios
	#$(SMCS) $(BUILD_FLAGS) -out:$@ @list enums.cs extras.cs AssemblyInfo.cs -r:monotouch.dll -res:libGoogleAnalytics.a,libGoogleAnalytics.a

clean:
	-rm -rf list ios *.a *.dll *.o *.zip bin/ obj/
