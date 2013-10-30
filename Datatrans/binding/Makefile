VERSION=1.6.2
BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
all: Datatrans.dll

iPhone_Library.zip: 
	@echo "It appears that you do not have a copy of libdtipl.a (version $(VERSION)) which"
	@echo "is needed to build the Datatrans bindings."
	@echo
	@echo "You'll need to obtain a copy of libdtipl.a from Datatrans:"
	@echo
	@echo "Home page : http://pilot.datatrans.biz/showcase/Showcase.jsp?mn=4&sb=1"
	@echo "Library   : http://pilot.datatrans.biz/showcase/doc/iPhone_Library.zip"
	@echo "Manual    : http://pilot.datatrans.biz/showcase/doc/User_Manual_english.pdf"
	@echo
	@echo "Trying to download it..."
	@echo
	curl http://pilot.datatrans.biz/showcase/doc/iPhone_Library.zip > $@
	unzip iPhone_Library.zip

libdtipl.a: iPhone_Library.zip
	unzip -o $< 
	ln -sf DTiPLv$(VERSION)/lib/libdtipl.a .
	(cd ../sample/DatatarnsSample; ln -fs ../../binding/DTiPLv$(VERSION)/resources/dtipl-resources.bundle .)

Datatrans.dll: Makefile Datatrans.cs enums.cs AssemblyInfo.cs libdtipl.a
	-mkdir -p ios
	$(BTOUCH) -o $@ -d=MONOTOUCH -e Datatrans.cs enums.cs --sourceonly=list -tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ -define:MONOTOUCH @list enums.cs AssemblyInfo.cs -r:monotouch.dll -res:libdtipl.a


clean: 
	-rm -rf *.dll iPhone_Library.zip libdtipl.a dtipl-resources.bundle DTiPLv1.7/
	-rm -rf ios

