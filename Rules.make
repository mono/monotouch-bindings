all: build-binding build-docs

build-binding:
	(cd binding; make)

build-docs:
	MONO_PATH=/Developer/MonoTouch/usr/lib/mono/2.1/ mdoc update --out docs binding/$(ASSEMBLY)