BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: TapIt.dll

TapIt.dll: Makefile ApiDefinition.cs libTapIt.a StructsAndEnums.cs
	$(BTOUCH) -unsafe ApiDefinition.cs libTapIt.linkwith.cs StructsAndEnums.cs --out=$@ --link-with=libTapIt.a,libTapIt.a 

clean:
	-rm -rf *.dll 
