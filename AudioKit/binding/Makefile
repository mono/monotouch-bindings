XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_PATH=AudioKit/Library/AudioKit.xcodeproj
TARGET=AudioKit
IPHONEOS_PATH=AudioKit/Library/build/Release-iphoneos
IPHONESIMULATOR_PATH=AudioKit/Library/build/Release-iphonesimulator
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
TAG=v1.3-02-16-2015

all: AudioKit-Classic.dll AudioKit-Unified.dll

AudioKit:
	git clone git@github.com:audiokit/AudioKit.git && cd AudioKit && git checkout tags/$(TAG) && git apply ../library.patch

libAudioKit.a: AudioKit
	$(XBUILD) -project $(PROJECT_PATH) -target $(TARGET) -sdk iphoneos -configuration Release clean build
	$(XBUILD) -project $(PROJECT_PATH) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	xcrun -sdk iphoneos lipo -create -output libAudioKit.a $(IPHONEOS_PATH)/libAudioKit.a $(IPHONESIMULATOR_PATH)/libAudioKit.a

AudioKit-Classic.dll: libAudioKit.a
	$(MONOXBUILD) /t:Clean AudioKit-Classic.csproj
	$(MONOXBUILD) /p:Configuration=Release AudioKit-Classic.csproj
	mkdir -p build/classic/
	cp bin/classic/Release/AudioKit.dll build/classic/AudioKit.dll

AudioKit-Unified.dll: libAudioKit.a
	$(MONOXBUILD) /t:Clean AudioKit.csproj
	$(MONOXBUILD) /p:Configuration=Release AudioKit.csproj
	mkdir -p build/unified/
	cp bin/unified/Release/AudioKit.dll build/unified/AudioKit.dll

prepare: libAudioKit.a

clean:
	-rm -rf list ios Resources/ AudioKit/ bin/ obj/ build/ *.sln *.userprefs *.zip *.a