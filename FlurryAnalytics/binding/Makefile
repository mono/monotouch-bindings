BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAnalytics.dll

FlurryAnalytics.dll: Makefile AssemblyInfo.cs FlurryAnalytics.cs libFlurry.a
	$(BTOUCH)  FlurryAnalytics.cs AssemblyInfo.cs --out=$@ --link-with=libFlurry.a,libFlurry.a -x=extras.cs

clean:
	-rm -f *.a *.dll
