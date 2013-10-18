BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./external/iRateLib
PROJECT=$(PROJECT_ROOT)/iRateLib.xcodeproj
TARGET=iRateLib

all: MTiRate.dll

external/iRate : clean
	git clone git@github.com:nicklockwood/iRate.git external/iRate
	git --git-dir=external/iRate/.git  checkout d20486c9a2f7b

libiRateLib-i386.a: external/iRate
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libiRateLib-armv7.a: external/iRate
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libiRate.a: libiRateLib-i386.a libiRateLib-armv7.a
	lipo -create -output $@ $^

	

MTiRate.dll: Makefile iRate.cs AssemblyInfo.cs ApiDefinition.cs StructsAndEnums.cs libiRate.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -s:StructsAndEnums.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:MTiRate.dll -resource:libiRate.a iRate.cs AssemblyInfo.cs StructsAndEnums.cs @ios/sources.list -resource:iRate.bundle/de.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fde.lproj_fLocalizable.strings -resource:iRate.bundle/en.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fen.lproj_fLocalizable.strings -resource:iRate.bundle/es.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fes.lproj_fLocalizable.strings -resource:iRate.bundle/fr.lproj/Localizable.strings,__monotouch_content_iRate.bundle_ffr.lproj_fLocalizable.strings -resource:iRate.bundle/he.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fhe.lproj_fLocalizable.strings -resource:iRate.bundle/it.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fit.lproj_fLocalizable.strings -resource:iRate.bundle/ja.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fja.lproj_fLocalizable.strings -resource:iRate.bundle/ko.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fko.lproj_fLocalizable.strings -resource:iRate.bundle/pl.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fpl.lproj_fLocalizable.strings -resource:iRate.bundle/pt.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fpt.lproj_fLocalizable.strings -resource:iRate.bundle/ru.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fru.lproj_fLocalizable.strings -resource:iRate.bundle/tr.lproj/Localizable.strings,__monotouch_content_iRate.bundle_ftr.lproj_fLocalizable.strings -resource:iRate.bundle/zh-Hans.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fzh-Hans.lproj_fLocalizable.strings -resource:iRate.bundle/zh-Hant.lproj/Localizable.strings,__monotouch_content_iRate.bundle_fzh-Hant.lproj_fLocalizable.strings -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll


clean:
	-rm -rf list ios *.dll *.zip *.mdb *.a external/iRate
