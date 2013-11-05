#### SparkInspector
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: SparkInspector.dll

SparkInspector.a: 
	

#Please do not remove SparkInspector.a check
SparkInspector.a:
	@if test -f ../../../monotouch-bindings-externals/SparkInspector/SparkInspector; then \
		cp ../../../monotouch-bindings-externals/SparkInspector/SparkInspector ./SparkInspector.a; \
	else \
		cp $< "/Applications/Spark Inspector.app/Contents/Resources/Frameworks/SparkInspector.framework/Versions/A/SparkInspector" $@; \
	fi

SparkInspector.dll: Makefile SparkInspector.linkwith.cs ApiDefinition.cs SparkInspector.a
	-mkdir -p ios
	$(BTOUCH) -unsafe -d:DEBUG ApiDefinition.cs -tmpdir:ios -sourceonly:ios/sources.list
	$(SMCS) -noconfig -debug+ -debug:full -optimize- -out:SparkInspector.dll -resource:SparkInspector.a SparkInspector.linkwith.cs @ios/sources.list -target:library -unsafe+  -define:DEBUG -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll

clean:
	-rm -rf list ios *.a *.dll *.mdb bin/ obj/
