BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: DropBoxSync.dll

DropBoxSync.zip: 
	curl -L https://dl.dropbox.com/shz/fp8nbrl21iqwhv8/QKlj_3ZHS5/dropbox-ios-sync-sdk-1.0?top_level_offset=14 > $@

DropBox.a: DropBoxSync.zip
	unzip -p $< 'dropbox-ios-sync-sdk-1.0/Dropbox.framework/Dropbox' > $@

DropBoxSync.dll: Makefile AssemblyInfo.cs ApiDefinition.cs StructsAndEnums.cs DropBox.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:DropBoxSync.dll -resource:DropBox.a -resource:AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios *.a *.dll *.zip *.mdb
