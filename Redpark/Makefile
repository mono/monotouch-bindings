BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Parse.dll

Parse.dll: Makefile AssemblyInfo.cs Parse.cs Parse.a
	$(BTOUCH) -unsafe Parse.cs AssemblyInfo.cs --out=$@ --link-with=Parse.a,Parse.a

clean:
	-rm -f *.a *.dll
