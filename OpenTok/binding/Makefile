BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

# 	If you updated the binding to a newer OpenTok version don't forget to change
#	the Git TAG of newer the version you are binding against
OTVERSIONTAG=2.1.6

all: OpenTok.dll

Opentok:
	git clone git@github.com:opentok/opentok-ios-sdk-webrtc.git && cd opentok-ios-sdk-webrtc && git checkout tags/$(OTVERSIONTAG)
	cp opentok-ios-sdk-webrtc/Opentok.framework/Versions/A/Opentok .

Resources: Opentok
	mkdir Resources
	cp -R opentok-ios-sdk-webrtc/Opentok.framework/Versions/A/Resources/opentok.bundle Resources/opentok.bundle

OpenTok.dll: Makefile ApiDefinition.cs StructsAndEnums.cs Opentok Resources
	$(MONOXBUILD) /p:Configuration=Release OpenTok.csproj
	cp bin/Release/OpenTok.dll OpenTok.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/ Opentok opentok-ios-sdk-webrtc/ Resources/
