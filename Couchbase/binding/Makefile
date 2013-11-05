BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Couchbase.dll

Couchbase.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libCouchbaseLite.a
	$(MONOXBUILD) /p:Configuration=Release Couchbase.iOS.csproj
	cp bin/Release/Couchbase.dll Couchbase.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb bin/ obj/
