BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
TARGET=ziparchive
CONFIGURATION=Release

all: ZipArchive.dll

debug: CONFIGURATION = Debug
debug: all

ZipArchive.dll: ApiDefinition.cs AssemblyInfo.cs lib$(TARGET).a
	mkdir -p ios
	$(BTOUCH) -unsafe ApiDefinition.cs --tmpdir=ios --sourceonly ios/sources.list
	$(SMCS) -noconfig -o- -out:$@ -res:libziparchive.a AssemblyInfo.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean: 
	-rm -f *.dll

clean-all: clean
	-rm -rf ios

.PHONY: clean clean-all