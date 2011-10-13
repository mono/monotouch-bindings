BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0.3

all: PayPal.dll

PayPal-MEC-iOS-Library-v$(VERSION).zip: 
	curl https://www.x.com/sites/default/files/PayPal_MECL_$(VERSION)_iPhone-Developer-Package.zip > $@

DevPackage: PayPal-MEC-iOS-Library-v$(VERSION).zip
	unzip $^

libPayPalEC.a: DevPackage
	-mv 'DevPackage/MECL Library/libPayPalEC.a' $@

PayPal.dll: libPayPalEC.a Makefile AssemblyInfo.cs paypal.cs enums.cs
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalEC.a,libPayPalEC.a

clean:
	-rm -rf *.a DevPackage __MACOSX *.dll
