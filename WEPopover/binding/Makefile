BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: WEPopover.dll

WEPopover.dll: Makefile AssemblyInfo.cs WEPopover.cs libWEPopover.a
	$(BTOUCH)  WEPopover.cs AssemblyInfo.cs --out=$@ --link-with=libWEPopover.a,libWEPopover.a -x=Extras.cs

clean:
	-rm -f *.a *.dll