BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1-0-3-070
VERSION=1.0.3

all: PayPalMECL.dll

PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage.zip:
	curl https://www.x.com/sites/default/files/PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage.zip > $@

libPayPalEC.a: PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage.zip
	unzip -p $< 'PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage/MECL Library/libPayPalEC.a' > $@
	PayPalMECL_1-0-3-070-iPhone_DevelopersPackage.zip

PayPalMECL.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalEC.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalEC.a,libPayPalEC.a

clean:
	-rm -rf *.a *.dll
