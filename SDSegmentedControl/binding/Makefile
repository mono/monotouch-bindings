BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: SegmentedControl.dll

libarclite.a: clean
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.linkwith.cs > libarclite.linkwith.cs

SegmentedControl.dll: ApiDefinition.cs StructsAndEnums.cs Makefile libSDSegmentedControl.linkwith.cs libSDSegmentedControl.a libarclite.a libarclite.linkwith.cs
	$(MONOXBUILD) /p:Configuration=Release SegmentedControl.csproj
	cp bin/Release/SegmentedControl.dll SegmentedControl.dll

clean:
	-rm -rf bin obj libarclite.a *dll *.mdb libarclite.linkwith.cs
