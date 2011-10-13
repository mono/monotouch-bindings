BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1_5_5_060
VERSION=1.5.5

all: PayPal.dll

PayPal-MPL-iOS-Library-v$(VERSION).zip: 
	curl https://www.x.com/sites/default/files/PayPalMPL_$(UVERSION)_iPhone_DevelopersPackage.zip > $@

libPayPalMPL.a: PayPal-MPL-iOS-Library-v$(VERSION).zip
	unzip -p $< 'PayPalMPL_iPhone_DevelopersPackage/Library/libPayPalMPL.a' > $@

PayPal.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalMPL.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalMPL.a,libPayPalMPL.a

clean:
	-rm -rf *.a *.dll
