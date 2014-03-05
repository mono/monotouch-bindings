BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=0.8

all: VENCalculatorInputViewBinding.dll

libVENCalculatorInputViewSDK.a: 
	cd ../libVENCalculatorInputView && make
VENCalculatorInputViewBinding.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libVENCalculatorInputViewSDK.a
	$(MONOXBUILD) /p:Configuration=Release VENCalculatorInputViewBinding.csproj
	cp bin/Release/VENCalculatorInputViewBinding.dll VENCalculatorInputViewBinding.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/  && cd ../libVENCalculatorInputView && make clean
