all: paypal.dll

paypal.dll: Makefile defs.cs paypal.cs 
	/Developer/MonoTouch/usr/bin/btouch paypal.cs defs.cs --out=paypal.dll

clean:
	-rm *dll