BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: mtiks.dll

#Please do not remove libmTiks.a check
libmTiks.a:
	@if test -f ../../../monotouch-bindings-externals/MTIKS/libmTiks.a; then \
		cp ../../../monotouch-bindings-externals/MTIKS/libmTiks.a .; \
	else \
		echo "Please download libFlurry.a from http://www.flurry.com"; \
		open http://www.flurry.com; \
	fi

mtiks.dll: Makefile AssemblyInfo.cs MTIKS.cs libmTiks.a
	$(BTOUCH) -e MTIKS.cs AssemblyInfo.cs --out=$@ --link-with=libmTiks.a,libmTiks.a

clean:
	-rm -f *.a *.dll
