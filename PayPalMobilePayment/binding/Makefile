BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1-5-5-070
VERSION=1.5.5

all: PayPalMPL.dll

PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage.zip: 
	curl https://www.x.com/sites/default/files/$@ > $@

libPayPalMPL.a: PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage.zip
	unzip -p $< 'PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage/Library/libPayPalMPL.a' > $@

PayPalMPL.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalMPL.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalMPL.a,libPayPalMPL.a

clean:
	-rm -rf *.a *.dll
