#### Dropbox Sync v1.0.5
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: DropBoxSync.iOS.dll

DropBoxSync.zip: 
	curl -L "https://dl.dropbox.com/shz/wiltmm1qyos5mqx/WydqpgZj3e/Dropbox.framework/Dropbox.framework?token_hash=AAEabVT0u2EiA5BRnen6AMKk34y8lU1NYkSoMekHB3TOpg&top_level_offset=48&dl=1" > $@

Dropbox.a: DropBoxSync.zip
	unzip -p $< 'Dropbox.framework/Dropbox' > $@

DropBoxSync.iOS.dll: Makefile Dropbox.linkwith.cs ApiDefinition.cs StructsAndEnums.cs Dropbox.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:DropBoxSync.iOS.dll -resource:Dropbox.a Dropbox.linkwith.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios *.a *.dll *.zip *.mdb
