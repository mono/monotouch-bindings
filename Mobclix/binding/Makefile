BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: Mobclix.dll

#Please do not remove libMobclix.a check
libMobclix.a:
	@if test -f ../../../monotouch-bindings-externals/Mobclix/libMobclix.a; then \
		cp ../../../monotouch-bindings-externals/Mobclix/libMobclix.a .; \
	else \
		echo "Please download libFlurry.a from http://www.flurry.com"; \
		open http://www.flurry.com; \
	fi

Mobclix.dll: Makefile AssemblyInfo.cs mobclix.cs enums.cs libMobclix.a
	$(BTOUCH) -e mobclix.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libMobclix.a,libMobclix.a

clean:
	-rm -rf *.a *.dll
