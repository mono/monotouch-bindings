XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
VERSION=6.1.1
PROJECT_ROOT=Chipmunk-$(VERSION)
PROJECT_TGZ=$(PROJECT_ROOT).tgz
PROJECT=$(PROJECT_ROOT)/xcode/Chipmunk6.xcodeproj
PROJECT_URL=http://chipmunk-physics.net/release/Chipmunk-6.x/$(PROJECT_TGZ)
TARGET=ChipmunkStatic-iPhone
CONFIGURATION=Release
XCODEEXTRA=GCC_PREPROCESSOR_DEFINITIONS="CHIPMUNK_BIND" 

all: Chipmunk.dll

debug: CONFIGURATION=Debug
debug: all

CS_SRC=					\
	src/Arbiter.cs			\
	src/AssemblyInfo.cs		\
	src/Body.cs			\
	src/BoundingBox.cs		\
	src/ChipmunkObject.cs		\
	src/Helper.cs			\
	src/Shape.cs			\
	src/Space.cs			\
	src/Constraint.cs

Chipmunk.dll: $(CS_SRC) libChipmunk-iPhone.a
	$(SMCS) -noconfig -o- -out:$@ -res:libChipmunk-iPhone.a $(CS_SRC) -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll  

# build libChipmunk-iPhone.a
###########################

$(PROJECT_TGZ):
	curl $(PROJECT_URL)  -o $(PROJECT_TGZ) 

$(PROJECT): $(PROJECT_TGZ) chipmunk-diff
	rm -rf $(PROJECT_ROOT)
	tar xfz $<
	patch -d $(PROJECT_ROOT) -p1 < chipmunk-diff

lib$(TARGET)-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -arch i386 -configuration $(CONFIGURATION) $(XCODEEXTRA) clean build
	-mv $(PROJECT_ROOT)/xcode/build/$(CONFIGURATION)-iphonesimulator/libChipmunk-iPhone.a $@

lib$(TARGET)-arm.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration $(CONFIGURATION) $(XCODEEXTRA) clean build
	-mv $(PROJECT_ROOT)/xcode/build/$(CONFIGURATION)-iphoneos/libChipmunk-iPhone.a $@

libChipmunk-iPhone.a: lib$(TARGET)-i386.a lib$(TARGET)-arm.a
	lipo -create -output $@ $^

# clean
#######

clean: 
	-rm -rf *.a *.dll $(PROJECT_ROOT)

clean-all: clean
	-rm -rf $(PROJECT_TGZ) 
