BTOUCH=/Developer/MonoTouch/usr/bin/btouch

# Bound Version
VERSION=1.1.32

all: Parse.dll

# Please do not remove Parse check
Parse:
	@if test -f ../../../monotouch-bindings-externals/Parse/Parse; then \
		cp ../../../monotouch-bindings-externals/Parse/Parse .; \
	else \
		echo "Please download parse-library-$(VERSION).zip from https://parse.com/downloads/ios/parse-library/$(VERSION)"; \
		open https://parse.com/downloads/ios/parse-library/$(VERSION); \
	fi

Parse.dll: Makefile AssemblyInfo.cs ParseLib.cs extra.cs enums.cs Parse
	$(BTOUCH) -unsafe ParseLib.cs -s enums.cs -x AssemblyInfo.cs -x extra.cs --out=$@ --link-with=Parse,Parse --outdir=tmp

clean:
	-rm -rf Parse.framework tmp *.a *.dll *.stamp Parse
