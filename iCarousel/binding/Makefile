BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.7.4
# iCarouselSDK Version 1.7.4

all: iCarouselSDK.dll

iCarouselSDK.dll: Makefile libiCarousel.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libiCarousel.a
	$(MONOXBUILD) /p:Configuration=Release iCarouselSDK.csproj
	cp bin/Release/iCarouselSDK.dll iCarouselSDK.dll

clean:
	-rm -rf list ios Resources/ bin/ obj/ *.dll *.o *.mdb 
