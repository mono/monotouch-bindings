SDKS=libThree20SDK.a libThree20CoreSDK.a libThree20NetworkSDK.a libThree20StyleSDK.a libThree20UISDK.a libThree20UICommonSDK.a libThree20UINavigatorSDK.a
STAMPS=simulator.stamp armv6.stamp armv7.stamp
MODULES=Core Network Style UI UICommon UINavigator
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
XBUILD=/Developer/usr/bin/xcodebuild
PROJECT_ROOT=three20/src/Three20
PROJECT=$(PROJECT_ROOT)/Three20.xcodeproj
BUILD_ROOT=three20/Build/Products
TARGET=Three20
VERSION=1.0.9

all: Three20.dll

three20: 
	git clone git@github.com:facebook/three20.git
	cd three20 && git reset --hard $(VERSION)

simulator.stamp: three20
	@mkdir -p libs
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv -f $(BUILD_ROOT)/Release-iphonesimulator/lib$(TARGET).a libs/lib$(TARGET)-i386.a
	for MODULE in $(MODULES); do \
	  mv -f $(BUILD_ROOT)/Release-iphonesimulator/lib$(TARGET)$${MODULE}.a libs/lib$(TARGET)$${MODULE}-i386.a; \
	done;
	@touch $@

armv%.stamp: three20
	@mkdir -p libs
	@ARCH="`echo $@ | sed -e s/.stamp//`"; \
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch $${ARCH} -configuration Release clean build; \
	mv -f $(BUILD_ROOT)/Release-iphoneos/lib$(TARGET).a libs/lib$(TARGET)-$${ARCH}.a; \
	for MODULE in $(MODULES); do \
	  mv -f $(BUILD_ROOT)/Release-iphoneos/lib$(TARGET)$${MODULE}.a libs/lib$(TARGET)$${MODULE}-$${ARCH}.a; \
	done;
	@touch $@

%SDK.a:
	@LIBNAME="`echo $@ | sed -e s/SDK.a//`"; \
	lipo -create -output $@ libs/$${LIBNAME}-i386.a libs/$${LIBNAME}-armv6.a libs/$${LIBNAME}-armv7.a

Three20.dll: Makefile three20.cs enums.cs AssemblyInfo.cs $(STAMPS) $(SDKS)
	$(BTOUCH) -out=$@ -e three20.cs enums.cs AssemblyInfo.cs --link-with=libThree20SDK.a,libThree20SDK.a \
		--link-with=libThree20CoreSDK.a,libThree20CoreSDK.a \
		--link-with=libThree20NetworkSDK.a,libThree20NetworkSDK.a \
		--link-with=libThree20StyleSDK.a,libThree20StyleSDK.a \
		--link-with=libThree20UISDK.a,libThree20UISDK.a \
		--link-with=libThree20UICommonSDK.a,libThree20UICommonSDK.a \
		--link-with=libThree20UINavigatorSDK.a,libThree20UINavigatorSDK.a

clean:
	-rm -rf libs *.a *.dll *.stamp
