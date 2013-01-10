BTOUCH=/Developer/MonoTouch/usr/bin/btouch
BUILDVER=build154
VERSION=3.3.0

all: RedLaser.dll

RedLaserDevSDK-$(VERSION).zip: 
	@echo "You'll need to obtain a copy of RedLaserDevSDK-$(VERSION).zip from"
	@echo "http://redlaser.com/sdk/index.php"
	@echo
	@open http://redlaser.com/sdk/index.php
	@exit 1

libRedLaserSDK.a: RedLaserDevSDK-$(VERSION).zip
	unzip -p $< 'RedLaserDevSDK-$(VERSION)$(BUILDVER)/RedLaser SDK Files/$@' > $@

RedLaser.dll: Makefile AssemblyInfo.cs redlaser.cs enums.cs extra.cs libRedLaserSDK.a
	$(BTOUCH) -unsafe --out=$@ redlaser.cs -s:enums.cs -x:AssemblyInfo.cs -x:extra.cs --link-with=libRedLaserSDK.a,libRedLaserSDK.a

clean:
	-rm -rf *.a *.dll
