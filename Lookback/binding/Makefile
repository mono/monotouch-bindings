MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

# 	If you update the binding to a newer Lookback version don't forget to change
#	the Git TAG of newer the version you are binding against
VERSION=0.6.2

all: init LookbackHD.dll LookbackSafe.dll wrapup

init:
	rm -rf HD/ Safe/ bin/ obj/ Lookback *.userprefs

lookback-ios-sdk:
	@if test -f ../lookback/HD/Lookback.framework/Versions/A/Lookback; then \
		echo "Lookback SDK located."; \
	else \
		echo "Cannot find Lookback SDK. "; \
		echo "Initiating Lookback SDK download."; \
		open https://s3-eu-west-1.amazonaws.com/lookback-public/sdk/lookback-sdk-$(VERSION).zip; \
	fi

LookbackHD: lookback-ios-sdk
	cp ../lookback/HD/Lookback.framework/Versions/A/Lookback Lookback
	cp -R ../lookback/HD/Lookback.framework/Versions/A/Resources/ Lookback-Resources
	
LookbackHD.dll: LookbackHD
	$(MONOXBUILD) /p:Configuration=Release LookbackSDK.csproj
	mkdir HD
	cp bin/Release/LookbackSDK.dll HD/LookbackSDK.dll

LookbackSafe: lookback-ios-sdk
	cp ../lookback/Safe/Lookback.framework/Versions/A/Lookback Lookback
	cp -R ../lookback/Safe/Lookback.framework/Versions/A/Resources/ Lookback-Resources

LookbackSafe.dll: LookbackSafe
	$(MONOXBUILD) /p:Configuration=Release LookbackSDK.csproj
	mkdir Safe
	cp bin/Release/LookbackSDK.dll Safe/LookbackSDK.dll

wrapup:
	rm -rf bin/ obj/ Lookback *.userprefs
	
prepare: Lookback

clean:
	-rm -rf *.a *.dll *.mdb bin/ obj/ HD/ Safe/ *.userprefs *.zip *.storyboard *.png ../lookback/ Lookback Lookback-Resources ../samples/LookbackSample/GFSettings.storyboard ../samples/LookbackSample/lookback*.png ../samples/LookbackSample/bin ../samples/LookbackSample/obj