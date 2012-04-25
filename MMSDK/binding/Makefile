BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: MMAdView.dll

MMAdView.dll: Makefile AssemblyInfo.cs MMAd.cs enums.cs libMMSDK_4.5.5.a
	$(BTOUCH) -e MMAd.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libMMSDK_4.5.5.a,libMMSDK_4.5.5.a

clean:
	-rm -f *.a *.dll
