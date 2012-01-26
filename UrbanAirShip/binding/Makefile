BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: UrbanAirship.dll

UrbanAirship.dll: Makefile AssemblyInfo.cs common.cs enums.cs libUAirship-1.1.3.a
	$(BTOUCH)  common.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libUAirship-1.1.3.a,libUAirship-1.1.3.a 

clean:
	-rm -f *.a *.dll
