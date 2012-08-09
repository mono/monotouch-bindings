BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: InMobi.dll

InMobi.dll: Makefile AssemblyInfo.cs inmobi.cs enums.cs libInMobi_iOS.a
	$(BTOUCH) -e inmobi.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libInMobi_iOS.a,libInMobi_iOS.a

clean:
	-rm -f *.a *.dll
