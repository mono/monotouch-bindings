BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOMAC=/cvs/monomac
VERSION=0.4

all: ios

osx: CorePlotMacOS.dll

ios: CorePlotiOS.dll

CorePlot-$(VERSION).zip:
	curl http://core-plot.googlecode.com/files/CorePlot_$(VERSION).zip > $@

libCorePlot-CocoaTouch.a: CorePlot-$(VERSION).zip
	unzip -p $^ CorePlot_$(VERSION)/Binaries/iOS/$@ > $@

CorePlotMacOS.dll: coreplot.cs enums.cs extras.cs Makefile CorePlot_0.4
	-mkdir -p osx
	MONO_PATH=$(MONOMAC)/src mono $(MONOMAC)/src/bmac.exe -e -unsafe coreplot.cs enums.cs --sourceonly=list --tmpdir=osx -r:System.Drawing -lib:$(MONOMAC)/src
	dmcs $(BUILD_FLAGS) -out:CorePlotMacOS.dll enums.cs coreplot.cs @list -r:System.Drawing -lib:$(MONOMAC)/src

CorePlotiOS.dll: Makefile ios/coreplot.cs ios/enums.cs ios/extras.cs AssemblyInfo.cs libCorePlot-CocoaTouch.a
	-mkdir -p ios
	$(BTOUCH) -d=MONOTOUCH -e ios/coreplot.cs ios/enums.cs AssemblyInfo.cs --sourceonly=list --tmpdir=ios --link-with=CorePlot_0.4/Binaries/iOS/libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a
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
