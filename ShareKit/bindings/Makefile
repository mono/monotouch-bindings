BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=/Developer/usr/bin/xcodebuild

all: ShareKit.dll

ShareKit.dll: sharekit.cs enums.cs
	$(BTOUCH) -e sharekit.cs enums.cs --out=$@

clean:
	-rm -f *.a *.dll
