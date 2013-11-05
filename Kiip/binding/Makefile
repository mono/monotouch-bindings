BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Kiip.dll

#Please do not remove libKiip.a check
libKiip.a:
	@if test -f ../../../monotouch-bindings-externals/Kiip/libKiip.a; then \
		cp ../../../monotouch-bindings-externals/Kiip/libKiip.a .; \
	else \
		echo "Please download libKiip.a from http://kiip.com"; \
		open http://kiip.com; \
	fi

Kiip.dll: Makefile libKiip.linkwith.cs ApiDefinition.cs libKiip.a StructsAndEnums.cs
	$(MONOXBUILD) /p:Configuration=Release binding.csproj

clean:
	-rm -rf *.a *.dll bin/ obj/
