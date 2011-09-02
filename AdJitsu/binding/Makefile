all: AdJitsu.dll

AdJitsu.dll: Makefile adjitsu.cs
	/Developer/MonoTouch/usr/bin/btouch adjitsu.cs -out=AdJitsu.dll

clean:
	-rm -f *.dll
