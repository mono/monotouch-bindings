BTOUCH=/Developer/MonoTouch/usr/bin/btouch
ZIP_VERSION=99510108
UNZIP_VERSION=101.01

all: MagTek.iDynamo.dll

$(ZIP_VERSION).zip:
	curl http://www.magtek.com/support/software/downloads/sw/$@ > $@

libMTSCRA.a: $(ZIP_VERSION).zip
	unzip -p $< '$(ZIP_VERSION)/Lib/Release-iphoneos/libMTSCRA.a' > $@ || rm -f $@

MagTek.iDynamo.dll: Makefile MagTek.iDynamo.cs enums.cs AssemblyInfo.cs libMTSCRA.a
	$(BTOUCH) -out:$@ MagTek.iDynamo.cs -s:enums.cs -x:AssemblyInfo.cs --link-with=libMTSCRA.a,libMTSCRA.a

clean:
	-rm -rf *.a *.dll *.zip
