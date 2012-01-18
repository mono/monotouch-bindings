BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Redpark.dll

Redpark.dll: Makefile AssemblyInfo.cs RedParkSerial.cs enums.cs libRscMgrUniv.a 
	$(BTOUCH)  RedParkSerial.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libRscMgrUniv.a,libRscMgrUniv.a

clean:
	-rm -f *.a *.dll
