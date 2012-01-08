BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAppCircle.dll

FlurryAppCircle.dll: Makefile AssemblyInfo.cs FlurryAppCircle.cs libFlurryAppCircle.a
	$(BTOUCH)  FlurryAppCircle.cs AssemblyInfo.cs --out=$@ --link-with=libFlurryAppCircle.a,libFlurryAppCircle.a -x=extras.cs
	

clean:
	-rm -f *.a *.dll
