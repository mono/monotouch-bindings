VERSION=1.5.2
BUILD_FLAGS=-unsafe -target:library -nowarn:436 -nowarn:219
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
RES=DTiPLv$(VERSION)/resources/dtipl-resources.bundle
ZIP=DTiPLv$(VERSION)
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
	unzip -x  'iPhone_Library.zip'

Datatrans.dll: Makefile Datatrans.cs enums.cs AssemblyInfo.cs libdtipl.a
	-mkdir -p ios
	$(BTOUCH) -o $@ -d=MONOTOUCH -e Datatrans.cs enums.cs --sourceonly=list -tmpdir=ios
	$(SMCS) $(BUILD_FLAGS) -out:$@ -define:MONOTOUCH @list enums.cs AssemblyInfo.cs -r:monotouch.dll -res:libdtipl.a -res:$(RES)/American_Express.pdf -res:$(RES)/AMXcvv.gif -res:$(RES)/Diners_Club_Logo.pdf -res:$(RES)/DTCreditCardInputViewController.nib -res:$(RES)/DTPaymentAuthorizationViewController.nib -res:$(RES)/ECAcvv.gif -res:$(RES)/Dutch.lproj/Localizable.strings,Dutch.lproj/Localizable.strings -res:$(RES)/English.lproj/Localizable.strings,English.lproj/Localizable.strings -res:$(RES)/French.lproj/Localizable.strings,French.lproj/Localizable.strings -res:$(RES)/German.lproj/Localizable.strings,German.lproj/Localizable.strings -res:$(RES)/Italian.lproj/Localizable.strings,Italian.lproj/Localizable.strings -res:$(RES)/MasterCard_Logo_SecureCode.pdf -res:$(RES)/PayPal_Logo.pdf -res:$(RES)/pf_card.png -res:$(RES)/pf_card@2x.png -res:$(RES)/pf_efinance.png -res:$(RES)/pf_efinance@2x.png -res:$(RES)/Visa_Logo_VBV.pdf -res:$(RES)/VIScvv.gif


clean: 
	-rm -f *.dll iPhone_Library.zip libdtipl.a 
	-rm -rf ios $(RES) $(ZIP)

