BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=4.1.2
all: CrittercismSdk.dll

libCrittercism.a:
	@if test -f ../../../monotouch-bindings-externals/Crittercism/libCrittercism.a; then \
		cp ../../../monotouch-bindings-externals/Crittercism/libCrittercism.a .; \
	else \
		echo "Please download libCrittercism.a from https://app.crittercism.com/downloads/ios"; \
		open https://app.crittercism.com/downloads/ios; \
		exit 1; \
	fi

CrittercismSdk.dll: Makefile libCrittercism.linkwith.cs ApiDefinition.cs libCrittercism.a
	$(MONOXBUILD) /p:Configuration=Release CrittercismSdk.csproj
	cp bin/Release/CrittercismSdk.dll CrittercismSdk.dll

clean:
	-rm -rf *.a *.dll bin/ obj/