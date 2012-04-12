BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: UrbanAirship.dll

UrbanAirship.dll: Makefile AssemblyInfo.cs common.cs enums.cs libUAirship-1.2.0.a
	$(BTOUCH)  common.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libUAirship-1.2.0.a,libUAirship-1.2.0.a 

clean:
	-rm -f *.a *.dll
