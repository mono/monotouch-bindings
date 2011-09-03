MONOMAC=/cvs/monomac

all: ios

osx: CorePlotMacOS.dll

ios: CorePlotiOS.dll

BUILD_FLAGS=-unsafe -target:library -nowarn:436

CorePlotMacOS.dll: coreplot.cs enums.cs extras.cs Makefile
	-mkdir osx
	MONO_PATH=$(MONOMAC)/src mono $(MONOMAC)/src/bmac.exe -e -unsafe coreplot.cs enums.cs --sourceonly=list --tmpdir=osx -r:System.Drawing -lib:$(MONOMAC)/src
	dmcs $(BUILD_FLAGS) -out:CorePlotMacOS.dll enums.cs coreplot.cs @list -r:System.Drawing -lib:$(MONOMAC)/src

CorePlotiOS.dll: ios/coreplot.cs ios/enums.cs ios/extras.cs Makefile
	-mkdir ios
	/Developer/MonoTouch/usr/bin/btouch -d=MONOTOUCH -e ios/coreplot.cs ios/enums.cs --sourceonly=list --tmpdir=ios
	/Developer/MonoTouch/usr/bin/smcs $(BUILD_FLAGS) -out:CorePlotiOS.dll -define:MONOTOUCH @list ios/enums.cs ios/extras.cs -r:monotouch.dll

ios/coreplot.cs: coreplot.cs
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/enums.cs: enums.cs 
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/extras.cs: extras.cs 
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

clean: 
	-rm *dll