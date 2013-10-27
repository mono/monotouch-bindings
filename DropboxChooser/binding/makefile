#### Dropbox Chooser v1.1

BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.1

all: DropboxChooser.iOS.dll

dropbox-ios-chooser-sdk-$(VERSION).zip:
	curl -L "https://dl.dropboxusercontent.com/s/e4k9i43pkrnff4z/dropbox-ios-dropins-sdk-1.1.zip" > $@
	unzip $@

DBChooser.a: dropbox-ios-chooser-sdk-$(VERSION).zip
	unzip -p $< 'dropbox-ios-dropins-sdk-1.1/DBChooser.framework/DBChooser' > $@

Resources: DBChooser.a
	mkdir Resources
	cp -R dropbox-ios-dropins-sdk-1.1/DBChooser.bundle Resources/DBChooser.bundle

DropboxChooser.iOS.dll: Makefile DBChooser.linkwith.cs ApiDefinition.cs StructsAndEnums.cs DBChooser.a Resources
	$(MONOXBUILD) /p:Configuration=Release Dropins.Chooser.iOS.csproj
	cp bin/Release/Dropins.Chooser.iOS.dll Dropins.Chooser.iOS.dll

prepare: DBChooser.a Resources

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/ Resources/ dropbox-ios-dropins-sdk-$(VERSION)/