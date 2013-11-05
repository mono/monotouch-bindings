BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAnalytics.dll

#Please do not remove libFlurry.a check
libFlurry.a:
	@if test -f ../../../monotouch-bindings-externals/FlurryAnalytics/libFlurry.a; then \
		cp ../../../monotouch-bindings-externals/FlurryAnalytics/libFlurry.a .; \
	else \
		echo "Please download libFlurry.a from http://www.flurry.com"; \
		open http://www.flurry.com; \
	fi

FlurryAnalytics.dll: Makefile AssemblyInfo.cs FlurryAnalytics.cs libFlurry.a
	$(BTOUCH)  FlurryAnalytics.cs AssemblyInfo.cs --out=$@ --link-with=libFlurry.a,libFlurry.a -x=extras.cs

clean:
	-rm -rf *.a *.dll
