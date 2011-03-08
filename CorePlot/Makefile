MONOMAC=/cvs/monomac

all: ios

osx: CorePlotMacOS.dll

ios: CorePlotiOS.dll

CorePlotMacOS.dll: coreplot.cs enums.cs 
	-mkdir osx
	MONO_PATH=$(MONOMAC)/src mono $(MONOMAC)/src/bmac.exe -e -unsafe -out=CorePlotMacOS.dll -tmpdir=osx coreplot.cs enums.cs -r:System.Drawing -lib:$(MONOMAC)/src

CorePlotiOS.dll: ios/coreplot.cs ios/enums.cs
	-mkdir ios
	/Developer/MonoTouch/usr/bin/btouch -d=MONOTOUCH -e ios/coreplot.cs ios/enums.cs --out=CorePlotiOS.dll --tmpdir=ios

ios/coreplot.cs: coreplot.cs
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

ios/enums.cs: enums.cs
	-mkdir ios
	sed 's/MonoMac/MonoTouch/g' < $^ > $@

clean: 
	-rm *dll