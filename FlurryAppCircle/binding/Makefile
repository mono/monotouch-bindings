BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: FlurryAppCircle.dll

#Please do not remove libFlurryAppCircle.a check
libFlurryAppCircle.a:
	@if test -f ../../../monotouch-bindings-externals/FlurryAppCircle/libFlurryAppCircle.a; then \
		cp ../../../monotouch-bindings-externals/FlurryAppCircle/libFlurryAppCircle.a .; \
	else \
		echo "Please download libFlurry.a from http://www.flurry.com"; \
		open http://www.flurry.com; \
	fi

FlurryAppCircle.dll: Makefile AssemblyInfo.cs flurry.cs libFlurryAppCircle.a
	$(BTOUCH) flurry.cs AssemblyInfo.cs --out=$@ --link-with=libFlurryAppCircle.a,libFlurryAppCircle.a
	

clean:
	-rm -rf *.a *.dll
