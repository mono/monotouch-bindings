BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: flite.dll

flite.dll: Makefile AssemblyInfo.cs flite.cs extra.cs libflite.a
	$(BTOUCH) AssemblyInfo.cs --out=$@ --link-with=libflite.a,libflite.a  -x:extra.cs

clean:
	-rm -f *.a *.dll
