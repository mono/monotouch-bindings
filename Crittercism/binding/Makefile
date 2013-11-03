BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Crittercism.dll

libCrittercism.a:
	@echo "You'll need to obtain a copy of libCrittercism.a"
	@echo "from https://app.crittercism.com/downloads/ios"
	@echo
	@open https://app.crittercism.com/downloads/ios
	exit 1

Crittercism.dll: Makefile Crittercism.linkwith.cs ApiDefinition.cs libCrittercism.a
	$(BTOUCH) ApiDefinition.cs Crittercism.linkwith.cs --out=$@ --link-with=libCrittercism.a,libCrittercism.a
