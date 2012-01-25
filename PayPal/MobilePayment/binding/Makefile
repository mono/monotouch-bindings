BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1-5-5-070
VERSION=1.5.5

all: PayPalMPL.dll

PayPal-MPL-iOS-Library-v$(VERSION).zip: 
	curl https://www.x.com/sites/default/files/PayPalMPL_$(UVERSION)_iPhone_DevelopersPackage.zip > $@

libPayPalMPL.a: PayPal-MPL-iOS-Library-v$(VERSION).zip
	unzip -p $< 'PayPalMPL_iPhone_DevelopersPackage/Library/libPayPalMPL.a' > $@

PayPalMPL.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalEC.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with= libPayPalEC.a, libPayPalEC.a

clean:
	-rm -rf *.a *.dll
