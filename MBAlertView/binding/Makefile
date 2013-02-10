BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: AlertView.dll

AlertView.dll: Makefile AssemblyInfo.cs ApiDefinition.cs StructsAndEnums.cs libMBAlertView.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:AlertView.dll -resource:libMBAlertView.a AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll
clean:
	-rm -rf list ios *.dll *.zip *.mdb
