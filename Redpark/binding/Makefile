BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Redpark.dll

#Please do not remove libRscMgrUniv.a check
libRscMgrUniv.a:
	@if test -f ../../../monotouch-bindings-externals/Redpark/libRscMgrUniv.a; then \
		cp ../../../monotouch-bindings-externals/Redpark/libRscMgrUniv.a .; \
	else \
		echo "Please download libRscMgrUniv.a from http://redpark.com/developers/"; \
		open http://redpark.com/developers/; \
	fi

Redpark.dll: Makefile AssemblyInfo.cs RedParkSerial.cs enums.cs extras.cs libRscMgrUniv.a 
	$(BTOUCH)  RedParkSerial.cs AssemblyInfo.cs enums.cs -x:extras.cs --out=$@ --link-with=libRscMgrUniv.a,libRscMgrUniv.a

clean:
	-rm -f *.a *.dll
