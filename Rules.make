all: build-binding build-docs

build-binding:
	(cd binding; make)

build-docs:
	 mdoc update -L /Developer/MonoTouch/usr/lib/mono/2.1/ --out docs binding/$(ASSEMBLY)