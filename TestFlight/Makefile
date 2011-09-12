all: testflight.dll

testflight.dll: Makefile testflight.cs
	/Developer/MonoTouch/usr/bin/btouch testflight.cs --out=testflight.dll

clean:
	-rm *dll