BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: Mobclix.dll

Mobclix.dll: Makefile AssemblyInfo.cs mobclix.cs enums.cs libMobclix.a
	$(BTOUCH) -e mobclix.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libMobclix.a,libMobclix.a

clean:
	-rm -f *.a *.dll
