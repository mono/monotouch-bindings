MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

# 	If you updated the binding to a newer Taplytics version don't forget to change
#	the Git TAG of newer the version you are binding against
TPVERSIONTAG=1.2.42

all: TaplyticsSDK.dll

taplytics-ios-sdk:
	git clone git@github.com:taplytics/taplytics-ios-sdk.git && cd taplytics-ios-sdk && git checkout tags/$(TPVERSIONTAG)

Taplytics: taplytics-ios-sdk
	cp taplytics-ios-sdk/Taplytics.framework/Versions/A/Taplytics Taplytics

TaplyticsSDK.dll: Taplytics
	$(MONOXBUILD) /p:Configuration=Release TaplyticsSDK.csproj
	cp bin/Release/TaplyticsSDK.dll TaplyticsSDK.dll

prepare: Taplytics

clean:
	-rm -rf *.a *.dll *.mdb bin/ obj/ *.sln *.userprefs taplytics-ios-sdk/ Taplytics
