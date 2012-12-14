BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Parse.dll

parse-library-1.1.22.zip: 
	@echo "You need to download 'parse-library-1.1.22.zip' from http://parse.com"
	@exit 1

parse-framework.stamp: parse-library-1.1.22.zip
	unzip $^
	touch parse-framework.stamp

Parse.dll: Makefile parse-framework.stamp AssemblyInfo.cs ParseLib.cs extra.cs enums.cs
	$(BTOUCH) -unsafe ParseLib.cs -s enums.cs -x AssemblyInfo.cs -x extra.cs --out=$@ --link-with=Parse.framework/Parse,Parse --outdir=tmp

clean:
	-rm -rf Parse.framework tmp *.a *.dll *.stamp
