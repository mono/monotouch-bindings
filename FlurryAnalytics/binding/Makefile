BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAnalytics.dll

FlurryAnalytics.dll: Makefile AssemblyInfo.cs FlurryAnalytics.cs libFlurryAnalytics.a
	$(BTOUCH)  FlurryAnalytics.cs AssemblyInfo.cs --out=$@ --link-with=libFlurryAnalytics.a,libFlurryAnalytics.a

clean:
	-rm -f *.a *.dll
