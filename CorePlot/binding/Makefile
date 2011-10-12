BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOMAC=/cvs/monomac

all: ios

osx: CorePlotMacOS.dll

ios: CorePlotiOS.dll

CorePlot-0.4.zip:
	curl http://core-plot.googlecode.com/files/CorePlot_0.4.zip > CorePlot_0.4.zip

CorePlot_0.4: CorePlot_0.4.zip
	unzip CorePlot_0.4.zip > /dev/null 2>&1

CorePlotMacOS.dll: coreplot.cs enums.cs extras.cs Makefile CorePlot_0.4
	-mkdir -p osx
	MONO_PATH=$(MONOMAC)/src mono $(MONOMAC)/src/bmac.exe -e -unsafe coreplot.cs enums.cs --sourceonly=list --tmpdir=osx -r:System.Drawing -lib:$(MONOMAC)/src
	dmcs $(BUILD_FLAGS) -out:CorePlotMacOS.dll enums.cs coreplot.cs @list -r:System.Drawing -lib:$(MONOMAC)/src

CorePlotiOS.dll: ios/coreplot.cs ios/enums.cs ios/extras.cs AssemblyInfo.cs Makefile CorePlot_0.4
	-mkdir -p ios
	$(BTOUCH) -d=MONOTOUCH -e ios/coreplot.cs ios/enums.cs AssemblyInfo.cs --sourceonly=list --tmpdir=ios --link-with=CorePlot_0.4/Binaries/iOS/libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a
	$(SMCS) $(BUILD_FLAGS) -out:CorePlotiOS.dll -define:MONOTOUCH @list AssemblyInfo.cs ios/enums.cs ios/extras.cs -r:monotouch.dll -res:CorePlot_0.4/Binaries/iOS/libCorePlot-CocoaTouch.a,libCorePlot-CocoaTouch.a

ios/coreplot.cs: coreplot.cs
	-mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/enums.cs: enums.cs 
	-mkdir -p ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/extras.cs: extras.cs 
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

clean: 
	-rm -rf *.dll __MACOSX list
