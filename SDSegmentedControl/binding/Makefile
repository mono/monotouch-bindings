BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: SegmentedControl.dll

SegmentedControl.dll: ApiDefinition.cs StructsAndEnums.cs Makefile libSDSegmentedControl.linkwith.cs libSDSegmentedControl.a
	$(MONOXBUILD) /p:Configuration=Release SegmentedControl.csproj
	cp bin/Release/SegmentedControl.dll SegmentedControl.dll

clean:
	-rm -rf bin obj libarclite.a *dll *.mdb libarclite.linkwith.cs
