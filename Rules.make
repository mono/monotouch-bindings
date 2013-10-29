all: build-binding build-docs build-samples

build-binding:
	(cd binding; make)

build-docs:
	 mdoc update -L /Developer/MonoTouch/usr/lib/mono/2.1/ --out docs binding/$(ASSEMBLY)
	 
build-samples:
	(cd samples; make)
	
clean:
	(cd binding; make clean)
	(cd samples; make clean)