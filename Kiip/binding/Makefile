BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Kiip.dll

Kiip.dll: Makefile libKiip.linkwith.cs ApiDefinition.cs libKiip.a StructsAndEnums.cs
	$(BTOUCH) -unsafe ApiDefinition.cs libKiip.linkwith.cs StructsAndEnums.cs --out=$@ --link-with=libKiip.a,libKiip.a --outdir=tmp

clean:
	-rm -f *.a *.dll
