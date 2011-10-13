BTOUCH=/Developer/MonoTouch/usr/bin/btouch
BUILDVER=build98
VERSION=3.1.2

all: RedLaser.dll

RedLaserDevSDK-$(VERSION).zip: 
	@echo "You'll need to obtain a copy of RedLaserDevSDK-$(VERSION).zip from"
	@echo "http://redlaser.com/sdk/index.php"
	@echo
	@open http://redlaser.com/sdk/index.php
	@exit 1

libRedLaserSDK.a: RedLaserDevSDK-$(VERSION).zip
	unzip -p $< 'RedLaserDevSDK-$(VERSION)$(BUILDVER)/RedLaser SDK Files/$@' > $@

RedLaser.dll: Makefile AssemblyInfo.cs RedLaser.cs enum.cs libRedLaserSDK.a
	$(BTOUCH) --out=$@ -e RedLaser.cs enum.cs AssemblyInfo.cs --link-with=libRedLaserSDK.a,libRedLaserSDK.a

clean:
	-rm -rf *.a *.dll
