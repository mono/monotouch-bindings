all: AdJitsu.dll

BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219

AdJitsu.dll: Makefile adjitsu.cs extra.cs
	-mkdir ios
	/Developer/MonoTouch/usr/bin/btouch adjitsu.cs -e --sourceonly=list --tmpdir=ios
	/Developer/MonoTouch/usr/bin/smcs $(BUILD_FLAGS) -out:AdJitsu.dll -define:MONOTOUCH @list extra.cs -r:monotouch.dll

clean:
	-rm -f *.dll
