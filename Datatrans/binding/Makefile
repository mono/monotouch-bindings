VERSION=1.9.1
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
all: Datatrans.dll

iOS_Library.zip: 
	@echo "It appears that you do not have a copy of libdtipl.a (version $(VERSION)) which"
	@echo "is needed to build the Datatrans bindings."
	@echo
	@echo "You'll need to obtain a copy of libdtipl.a from Datatrans:"
	@echo
	@echo "Home page : http://pilot.datatrans.biz/showcase/Showcase.jsp?mn=4&sb=1"
	@echo "Library   : http://pilot.datatrans.biz/showcase/doc/iOS_Library.zip"
	@echo "Manual    : http://pilot.datatrans.biz/showcase/doc/User_Manual_english.pdf"
	@echo
	@echo "Trying to download it..."
	@echo
	curl http://pilot.datatrans.biz/showcase/doc/iOS_Library.zip > $@
	unzip iOS_Library.zip

libdtipl.a: iOS_Library.zip
	unzip -o $< 
	ln -sf DTiPLv$(VERSION)/lib/libdtipl.a .
	mkdir Resources
	cp -R DTiPLv$(VERSION)/resources/dtipl-resources.bundle Resources/dtipl-resources.bundle

Datatrans.dll: Makefile libdtipl.a
	$(MONOXBUILD) /p:Configuration=Release Datatrans.csproj
	cp bin/Release/Datatrans.dll Datatrans.dll

clean: 
	-rm -rf *.dll iOS_Library.zip libdtipl.a dtipl-resources.bundle DTiPLv$(VERSION)/ ios Resources/ bin/ obj/

