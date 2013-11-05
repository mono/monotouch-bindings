BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
# MONOMAC variable needs to be edited to match your setup
MONOMAC=/Developer/MonoTouch/Source/monomac
MONOMAC_DLL=$(MONOMAC)/src/MonoMac.dll
BMAC=mono --debug $(MONOMAC)/src/bmac.exe
XAM_BMAC=/Library/Frameworks/Xamarin.Mac.framework/Versions/Current/usr/bin/bmac
XAMMAC_DLL=/Library/Frameworks/Xamarin.Mac.framework/Versions/Current/usr/lib/mono/XamMac.dll
VERSION=1.4

PROJECT_ROOT=CorePlot_$(VERSION)/Source/framework
PROJECT=$(PROJECT_ROOT)/CorePlot-CocoaTouch.xcodeproj
TARGET=CorePlot-CocoaTouch

all: ios

# to build for MonoMac, use the Mono.CoreplotMacOS.dll target directly.
osx: Xamarin.CorePlotMacOS.dll

ios: CorePlotiOS.dll

CorePlot-$(VERSION).zip:
	curl http://core-plot.googlecode.com/files/CorePlot_$(VERSION).zip > $@

CorePlot_$(VERSION)/License.txt: CorePlot-$(VERSION).zip
	unzip -o $^ -x "__MACOSX/*" "*/.DS_Store"
	touch CorePlot_$(VERSION)/License.txt
	patch -p0 -i thumb.patch

libCorePlot-CocoaTouch.a: CorePlot-$(VERSION).zip
	unzip -p $^ CorePlot_$(VERSION)/Binaries/iOS/$@ > $@

Xamarin.CorePlotMacOS.dll: Makefile coreplot.cs enums.cs extras.cs
	@mkdir -p xamarin
	$(XAM_BMAC) --ns CorePlot -o $@ -e coreplot.cs -s enums.cs -x extras.cs --tmpdir=xamarin -r:System.Drawing -baselib=$(XAMMAC_DLL)

Mono.CoreplotMacOS.dll: Makefile coreplot.cs enums.cs extras.cs
	@mkdir -p osx
	$(BMAC) --ns CorePlot -o $@ -e coreplot.cs -s enums.cs -x extras.cs --tmpdir=osx -r:System.Drawing -baselib=$(MONOMAC_DLL)

CorePlotiOS.dll: Makefile ios/coreplot.cs ios/enums.cs ios/extras.cs AssemblyInfo.cs libCorePlot-CocoaTouch.a
	@mkdir -p ios
	$(BTOUCH) -unsafe -o $@ -d=MONOTOUCH ios/coreplot.cs -s ios/enums.cs -x ios/extras.cs -x AssemblyInfo.cs --tmpdir=ios --link-with=libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a --baselib=/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll
#	$(BTOUCH) --ns CorePlot -o $@ -d=MONOTOUCH ios/coreplot.cs -s ios/enums.cs -x ios/extras.cs -x AssemblyInfo.cs --tmpdir=ios --link-with=libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a

ios/coreplot.cs: coreplot.cs
	@mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/enums.cs: enums.cs 
	@mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/extras.cs: extras.cs 
	@mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

clean: 
	-rm -rf *.a *.dll

merge-docs:
	cp "CorePlot_$(VERSION)/Documentation/doxygen touch.config" CorePlot_$(VERSION)/Documentation/doxygentouch.config
	SOURCE_ROOT=`pwd`/CorePlot_$(VERSION)/Documentation ../../RunDoxy CorePlot_$(VERSION) Documentation/doxygentouch.config `pwd`/../docs/ `pwd`/CorePlot_$(VERSION)/Documentation/CorePlotTouchDocs.docset/xml