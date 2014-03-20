BTOUCH=/Developer/MonoTouch/usr/bin/btouch
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=4.1.0
all: InMobiSdk.dll

InMobi_iOS_SDK.zip:
	curl -O https://dl.inmobi.com/SDK/InMobi_iOS_SDK.zip > $@
	unzip InMobi_iOS_SDK.zip InMobi-iOS-SDK-$(VERSION)/Libs/libInMobi-$(VERSION).a

libInMobi.a: InMobi_iOS_SDK.zip
	cp InMobi-iOS-SDK-$(VERSION)/Libs/libInMobi-$(VERSION).a libInMobi.a

InMobiSdk.dll: Makefile libInMobi.a
	$(MONOXBUILD) /p:Configuration=Release InMobiSdk.csproj
	cp bin/Release/InMobiSdk.dll InMobiSdk.dll

clean:
	-rm -rf *.a  bin/ obj/ *.dll *.zip *.mdb *.sln InMobi-iOS-SDK-$(VERSION)/
