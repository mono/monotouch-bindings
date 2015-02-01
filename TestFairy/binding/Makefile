BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.2

all: TestFairy.iOS.dll

libTestFairy.a:
	@if test -f ../../../monotouch-bindings-externals/TestFairy/libTestFairy.a; then \
		cp ../../../monotouch-bindings-externals/TestFairy/libTestFairy.a .; \
	else \
		curl -s -o .sdk.zip "http://app.testfairy.com/ios-sdk/TestFairySDK-${VERSION}.zip"; \
		unzip -q -o .sdk.zip libTestFairy.a; \
		rm -f .sdk.zip; \
	fi

TestFairy.iOS.dll: Makefile libTestFairy.linkwith.cs ApiDefinition.cs StructsAndEnums.cs AssemblyInfo.cs TestFairy.iOS.csproj libTestFairy.a
	$(MONOXBUILD) /p:Configuration=Release TestFairy.iOS.csproj
	cp bin/Release/TestFairy.iOS.dll TestFairy.iOS.dll

clean:
	-rm -rf list ios *.sln *.userprefs *.dll *.o *.a *.zip *.mdb Resources/ lib/ bin/ obj/
