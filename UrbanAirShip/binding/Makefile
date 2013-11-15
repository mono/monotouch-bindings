BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: UrbanAirship.dll

#Please do not remove libUAirship-1.4.0.a check
libUAirship-1.4.0.a:
	@if test -f ../../../monotouch-bindings-externals/UrbanAirShip/libUAirship-1.4.0.a; then \
		cp ../../../monotouch-bindings-externals/UrbanAirShip/libUAirship-1.4.0.a .; \
	else \
		echo "Please download libUAirship-1.4.0.a from http://urbanairship.com"; \
		open http://www.flurry.com; \
	fi

UrbanAirship.dll: Makefile AssemblyInfo.cs common.cs enums.cs libUAirship-1.4.0.a
	$(BTOUCH) -e common.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libUAirship-1.4.0.a,libUAirship-1.4.0.a 

clean:
	-rm -rf *.a *.dll
