BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.5.2

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

libdtipl.a: iPhone_Library.zip
	unzip -p $< 'DTiPLv$(VERSION)/lib/libdtipl.a' > $@

Datatrans.dll: Makefile datatrans.cs enums.cs AssemblyInfo.cs libdtipl.a
	$(BTOUCH) -e datatrans.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libdtipl.a,libdtipl.a

clean: 
	-rm -f *.dll iPhone_Library.zip libdtipl.a
