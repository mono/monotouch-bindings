BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: DropBoxSync.iOS.dll

DropBoxSync.zip: 
	curl -L "https://dl.dropbox.com/shz/vmgga8sf8tduqpn/LJCXOVNr7L/Dropbox.framework/Dropbox.framework?token_hash=AAFliKaJE9Xme-7o-2d6t8FVBHx_FHMW4fxwMVOQFT44TQ&top_level_offset=48&dl=1" > $@

Dropbox.a: DropBoxSync.zip
	unzip -p $< 'Dropbox.framework/Dropbox' > $@

DropBoxSync.iOS.dll: Makefile AssemblyInfo.cs ApiDefinition.cs StructsAndEnums.cs Dropbox.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:DropBoxSync.iOS.dll -resource:Dropbox.a AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios *.a *.dll *.zip *.mdb
