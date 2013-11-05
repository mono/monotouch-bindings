BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1-5-5-070
VERSION=1.5.5

all: PayPalMPL.dll

#Please do not remove libPayPalMPL.a check
libPayPalMPL.a:
	@if test -f ../../../monotouch-bindings-externals/PayPalMobilePayment/libPayPalMPL.a; then \
		cp ../../../monotouch-bindings-externals/PayPalMobilePayment/libPayPalMPL.a .; \
	else \
		curl https://www.x.com/sites/default/files/PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage.zip > PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage.zip; \
		unzip -p $< 'PayPalMPL_$(UVERSION)-iPhone_DevelopersPackage/Library/libPayPalMPL.a' > $@; \
	fi

PayPalMPL.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalMPL.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalMPL.a,libPayPalMPL.a

clean:
	-rm -rf *.a *.dll *.zip
