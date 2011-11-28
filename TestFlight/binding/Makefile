BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=0.8.1

all: TestFlight.dll

TestFlightSDK$(VERSION).zip:
	@echo "You'll need to obtain a copy of TestFlightSDK$(VERSION).zip"
	@echo "from https://testflightapp.com/sdk/download"
	@echo
	@open https://testflightapp.com/sdk/download
	exit 1

libTestFlight.a: TestFlightSDK$(VERSION).zip
	unzip -p $^ $@ > $@

TestFlight.dll: Makefile AssemblyInfo.cs testflight.cs libTestFlight.a
	$(BTOUCH) -e testflight.cs AssemblyInfo.cs --out=$@ --link-with=libTestFlight.a,libTestFlight.a

clean:
	-rm -f *.a *.dll
