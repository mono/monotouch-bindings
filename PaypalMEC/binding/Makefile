BTOUCH=/Developer/MonoTouch/usr/bin/btouch
UVERSION=1-0-3-070
VERSION=1.0.3

all: PayPalMECL.dll

#Please do not remove libPayPalEC.a check
libPayPalEC.a:
	@if test -f ../../../monotouch-bindings-externals/PaypalMEC/libPayPalEC.a; then \
		cp ../../../monotouch-bindings-externals/PaypalMEC/libPayPalEC.a .; \
	else \
		curl https://www.x.com/sites/default/files/PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage.zip > PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage.zip; \
		unzip -p $< 'PayPalMECL_$(UVERSION)-iPhone_DevelopersPackage/MECL Library/libPayPalEC.a' > $@; \
		PayPalMECL_1-0-3-070-iPhone_DevelopersPackage.zip; \
	fi

PayPalMECL.dll: Makefile AssemblyInfo.cs paypal.cs enums.cs libPayPalEC.a
	$(BTOUCH) --out=$@ -e paypal.cs enums.cs AssemblyInfo.cs --link-with=libPayPalEC.a,libPayPalEC.a

clean:
	-rm -rf *.a *.dll *.zip
