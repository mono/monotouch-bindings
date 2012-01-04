BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Datatrans.dll

Datatrans.dll: datatrans.cs enums.cs AssemblyInfo.cs libdtipl.a
	$(BTOUCH) -v -e datatrans.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libdtipl.a,libdtipl.a

clean: 
	-rm -f *.dll
