BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
XBUILD=/Developer/usr/bin/xcodebuild
MONOMAC=/cvs/monomac
VERSION=0.9

PROJECT_ROOT=CorePlot_$(VERSION)/Source/framework
PROJECT=$(PROJECT_ROOT)/CorePlot-CocoaTouch.xcodeproj
TARGET=CorePlot-CocoaTouch

all: ios

osx: CorePlotMacOS.dll

ios: CorePlotiOS.dll

CorePlot-$(VERSION).zip:
	curl http://core-plot.googlecode.com/files/CorePlot_$(VERSION).zip > $@

CorePlot_$(VERSION)/License.txt: CorePlot-$(VERSION).zip
	unzip -o $^ -x "__MACOSX/*" "*/.DS_Store"
	touch CorePlot_$(VERSION)/License.txt
	patch -p0 -i thumb.patch

libCorePlot-CocoaTouch-i386.a: CorePlot_$(VERSION)/License.txt
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv -f $(PROJECT_ROOT)/../build/Release-iphonesimulator/lib$(TARGET).a $@

libCorePlot-CocoaTouch-armv6.a: CorePlot_$(VERSION)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	mv -f $(PROJECT_ROOT)/../build/Release-iphoneos/lib$(TARGET).a $@

libCorePlot-CocoaTouch-armv7.a: CorePlot_$(VERSION)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	mv -f $(PROJECT_ROOT)/../build/Release-iphoneos/lib$(TARGET).a $@

# Note: This is disabled because the prebuilt binaries seem to be thumb
#libCorePlot-CocoaTouch.a: CorePlot-$(VERSION).zip
#	unzip -p $^ CorePlot_$(VERSION)/Binaries/iOS/$@ > $@

libCorePlot-CocoaTouch.a: libCorePlot-CocoaTouch-i386.a libCorePlot-CocoaTouch-armv6.a libCorePlot-CocoaTouch-armv7.a
	lipo -create -output $@ $^

CorePlotMacOS.dll: Makefile coreplot.cs enums.cs extras.cs
	-mkdir -p osx
	MONO_PATH=$(MONOMAC)/src mono $(MONOMAC)/src/bmac.exe -e -unsafe coreplot.cs enums.cs --sourceonly=list --tmpdir=osx -r:System.Drawing -lib:$(MONOMAC)/src
	dmcs $(BUILD_FLAGS) -out:CorePlotMacOS.dll enums.cs coreplot.cs @list -r:System.Drawing -lib:$(MONOMAC)/src

# Note: The following rule works only with MonoTouch >= 5.0.3 due to a bug in btouch wrt the -x option
#CorePlotiOS.dll: Makefile ios/coreplot.cs ios/enums.cs ios/extras.cs AssemblyInfo.cs libCorePlot-CocoaTouch.a
#	-mkdir -p ios
#	$(BTOUCH) -o $@ -d=MONOTOUCH -e ios/coreplot.cs -s ios/enums.cs -x ios/extras.cs -x AssemblyInfo.cs --tmpdir=ios --link-with=libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a

CorePlotiOS.dll: Makefile ios/coreplot.cs ios/enums.cs ios/extras.cs AssemblyInfo.cs libCorePlot-CocoaTouch.a
	-mkdir -p ios
	$(BTOUCH) -o $@ -d=MONOTOUCH -e ios/coreplot.cs ios/enums.cs --sourceonly=list --tmpdir=ios --link-with=libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a
	$(SMCS) $(BUILD_FLAGS) -out:CorePlotiOS.dll -define:MONOTOUCH @list AssemblyInfo.cs ios/enums.cs ios/extras.cs -r:monotouch.dll -res:libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a

ios/coreplot.cs: coreplot.cs
	-mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/enums.cs: enums.cs 
	-mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/extras.cs: extras.cs 
	-mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

clean: 
	-rm -rf *.a *.dll list
