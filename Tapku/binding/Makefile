BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Tapku.dll

Tapku.dll: Makefile AssemblyInfo.cs Tapku.cs Enums.cs libTapkuLibrary.a 
	$(BTOUCH)  Tapku.cs AssemblyInfo.cs Enums.cs --out=$@ --link-with=libTapkuLibrary.a,libTapkuLibrary.a

clean:
	-rm -f *.a *.dll
