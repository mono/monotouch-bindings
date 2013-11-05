BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: WEPopover.dll

WEPopover.dll: Makefile libWEPopoverUniversal.a
	$(MONOXBUILD) /p:Configuration=Release WEPopover.csproj
	cp bin/Release/WEPopover.dll WEPopover.dll
	
clean:
	-rm -rf *.dll bin/ obj/