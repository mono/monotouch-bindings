BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: opentok.dll

#Please do not remove Opentok check
Opentok:
	@if test -f ../../../monotouch-bindings-externals/OpenTok/Opentok; then \
		cp ../../../monotouch-bindings-externals/OpenTok/Opentok .; \
	else \
		echo "Please download Opentok from http://tokbox.com"; \
		open http://tokbox.com; \
	fi

opentok.dll: Makefile ApiDefinition.cs StructsAndEnums.cs Opentok
	$(MONOXBUILD) /p:Configuration=Release opentok.csproj
	cp bin/Release/opentok.dll opentok.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/ Opentok
