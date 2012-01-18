BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: WEPopover.dll

WEPopover.dll: Makefile AssemblyInfo.cs WEPopover.cs libWEPopoverUniversal.a
	$(BTOUCH)  WEPopover.cs AssemblyInfo.cs --out=$@ --link-with=libWEPopoverUniversal.a,libWEPopoverUniversal.a -x=Extras.cs

clean:
	-rm -f *.a *.dll