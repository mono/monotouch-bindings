BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=2.0.2
all: TestFlight.dll

TestFlightSDK$(VERSION).zip:
	@echo "You'll need to obtain a copy of TestFlightSDK$(VERSION).zip"
	@echo "from https://testflightapp.com/sdk/download"
	@echo
	@open https://testflightapp.com/sdk/download
	exit 1

libTestFlight.a: TestFlightSDK$(VERSION).zip
	unzip -p $^ $@ > $@
	
libarclite.a:
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a

TestFlight.dll: Makefile AssemblyInfo.cs testflight.cs testflight-threadsafe.cs testflight-cplusplus.cs libTestFlight.a libarclite.a
	$(BTOUCH) testflight.cs AssemblyInfo.cs -x:testflight-threadsafe.cs -x:testflight-cplusplus.cs --out=$@ --link-with=libTestFlight.a,libTestFlight.a --link-with=libarclite.a,libarclite.a

clean:
	-rm -f *.a *.dll