BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: mtiks.dll

mtiks.dll: Makefile AssemblyInfo.cs MTIKS.cs libmTiks.a
	$(BTOUCH) -e MTIKS.cs AssemblyInfo.cs --out=$@ --link-with=libmTiks.a,libmTiks.a

clean:
	-rm -f *.a *.dll
