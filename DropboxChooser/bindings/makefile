#### Dropbox Chooser v1.0

BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: DropboxChooser.iOS.dll

dropbox-ios-chooser-sdk-1.0.zip:
	curl -L "http://dl.dropboxusercontent.com/s/uf3893wfnk4f3p9/dropbox-ios-chooser-sdk-1.0.zip" > $@

libDBChooser.a: dropbox-ios-chooser-sdk-1.0.zip
	unzip -p $< 'dropbox-ios-chooser-sdk-1.0/DBChooser.framework/DBChooser' > $@

DropboxChooser.iOS.dll: Makefile libDBChooser.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libDBChooser.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:DropboxChooser.iOS.dll -resource:libDBChooser.a libDBChooser.linkwith.cs StructsAndEnums.cs @ios/sources.list -target:library -unsafe+ -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios *.a *.dll *.zip *.mdb

