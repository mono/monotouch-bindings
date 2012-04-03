BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Couchbase.dll

Couchbase.dll: Makefile AssemblyInfo.cs couchbase.cs Couchbase
	$(BTOUCH)  couchbase.cs AssemblyInfo.cs --out=$@ --link-with=Couchbase,Couchbase

clean:
	-rm -f *.a *.dll
