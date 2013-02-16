BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: LAAnimatedGrid.dll

LAAnimatedGrid.dll: Makefile AssemblyInfo.cs ApiDefinition.cs StructsAndEnums.cs libLAAnimatedGrid.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:LAAnimatedGrid.dll -resource:libLAAnimatedGrid.a AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll
clean:
	-rm -rf list ios *.dll *.zip *.mdb
