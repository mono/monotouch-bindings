BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAppCircle.dll

FlurryAppCircle.dll: Makefile AssemblyInfo.cs flurry.cs libFlurryAppCircle.a
	$(BTOUCH)  flurry.cs AssemblyInfo.cs --out=$@ --link-with=libFlurryAppCircle.a,libFlurryAppCircle.a
	

clean:
	-rm -f *.a *.dll
