BTOUCH=/Developer/MonoTouch/usr/bin/btouch-native
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.93

all: LineaProSdk.dll

#Please do not remove libdtdev.a check
libdtdev.a:
	@if test -f ../../../../monotouch-bindings-externals/LineaPRO/libdtdev.a; then \
		cp ../../../../monotouch-bindings-externals/LineaPRO/libdtdev.a .; \
	else \
		echo "\n\nYou must download DTDevices-iOS_2013-02-28_v1.zip from \nhttp://ipcprint.com/developer/ \nunzip and place libdtdev.a in this folder in order to compile.\n\n"; \
		open http://ipcprint.com/developer/; \
	fi

LineaProSdk.dll: Makefile libdtdev.linkwith.cs ApiDefinition.cs StructsAndEnums.cs Extas.cs LineaProSdkUnified.csproj libdtdev.a
	$(MONOXBUILD) /p:Configuration=Release LineaProSdkUnified.csproj
	cp bin/Release/LineaProSdk.dll LineaProSdk.dll

clean:
	-rm -rf list ios bin/ obj/ *.sln *.userprefs *.dll *.o *.a *.zip *.mdb Resources/