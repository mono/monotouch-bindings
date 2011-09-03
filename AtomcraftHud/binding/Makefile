ATMHud_HEADERS = 			\
	ATMHud/ATMHudDelegate.h		\
	ATMHud/ATMHudQueueItem.h	\
	ATMHud/ATMHudView.h		\
	ATMHud/ATMProgressLayer.h	\
	ATMHud/ATMSoundFX.h		\
	ATMHud/ATMTextLayer.h		\
	ATMHud/ATMHud.h

ATMHud_SOURCES = 			\
	ATMHud/ATMHudQueueItem.m	\
	ATMHud/ATMHudView.m		\
	ATMHud/ATMProgressLayer.m	\
	ATMHud/ATMSoundFX.m		\
	ATMHud/ATMTextLayer.m		\
	ATMHud/ATMHud.m

ATMHud_FRAMEWORKS = 			\
	-framework AudioToolbox		\
	-framework CoreGraphics		\
	-framework Foundation		\
	-framework QuartzCore		\
	-framework UIKit

MIN_IPHONEOS_VERSION = 4.3
TARGET_SDK_VERSION = 4.3

COMMON_CFLAGS = -miphoneos-version-min=$(MIN_IPHONEOS_VERSION) -std=c99 -I./ATMHud

SIMULATOR_ROOT = /Developer/Platforms/iPhoneSimulator.platform/Developer
SIMULATOR_SDK = $(SIMULATOR_ROOT)/SDKs/iPhoneSimulator$(TARGET_SDK_VERSION).sdk
SIMULATOR_SDK_INCLUDE = $(SIMULATOR_SDK)/usr/include
SIMULATOR_INCLUDE = $(SIMULATOR_ROOT)/usr/include
SIMULATOR_ARCH = -arch i386
SIMULATOR_SUFFIX = Sim

SIMULATOR_CFLAGS = -gdwarf-2 -O2 -arch i386 -isysroot $(SIMULATOR_SDK)	\
	$(COMMON_CFLAGS)						\
	-I$(SIMULATOR_INCLUDE) -I$(SIMULATOR_SDK_INCLUDE) 		\
	-F$(SIMULATOR_SDK)/System/Library/Frameworks			\
	-F$(SIMULATOR_SDK)/System/Library/PrivateFrameworks		\
	-Diphoneos_version_min=$(MIN_IPHONEOS_VERSION) -DDEBUG

SIMULATOR_LDFLAGS = -static $(SIMULATOR_ARCH) -L$(SIMULATOR_SDK)/usr/lib -lobjc	\
	-F$(SIMULATOR_SDK)/System/Library/Frameworks				\
	-F$(SIMULATOR_SDK)/System/Library/PrivateFrameworks

DEVICE_ROOT = /Developer/Platforms/iPhoneOS.platform/Developer
DEVICE_SDK = $(DEVICE_ROOT)/SDKs/iPhoneOS$(TARGET_SDK_VERSION).sdk
DEVICE_SDK_INCLUDE = $(DEVICE_SDK)/usr/include
DEVICE_INCLUDE = $(DEVICE_ROOT)/usr/include
DEVICE_ARCH = -arch armv6
DEVICE_SUFFIX = Device

DEVICE_CFLAGS = -O2 $(DEVICE_ARCH) -isysroot $(DEVICE_SDK) 	\
	$(COMMON_CFLAGS)					\
	-I$(DEVICE_INCLUDE) -I$(DEVICE_SDK_INCLUDE) 		\
	-F$(DEVICE_SDK)/System/Library/Frameworks		\
	-F$(DEVICE_SDK)/System/Library/PrivateFrameworks	\
	-Diphoneos_version_min=$(MIN_IPHONEOS_VERSION)

DEVICE_LDFLAGS = -static $(DEVICE_ARCH) -L$(DEVICE_SDK)/usr/lib	-lobjc		\
	-F$(DEVICE_SDK)/System/Library/Frameworks				\
	-F$(DEVICE_SDK)/System/Library/PrivateFrameworks

all: libATMHudSim.a ATMHud.dll

ATMHud:
	git clone git@github.com:atomton/ATMHud.git
	patch -d ATMHud -p1 -i ../ATMHud.patch

libATMHud$(SIMULATOR_SUFFIX).a: ATMHud $(ATMHud_SOURCES)
	gcc $(SIMULATOR_CFLAGS) -o ATMHudQueueItem$(SIMULATOR_SUFFIX).o -c ATMHud/ATMHudQueueItem.m
	gcc $(SIMULATOR_CFLAGS) -o ATMHudView$(SIMULATOR_SUFFIX).o -c ATMHud/ATMHudView.m
	gcc $(SIMULATOR_CFLAGS) -o ATMProgressLayer$(SIMULATOR_SUFFIX).o -c ATMHud/ATMProgressLayer.m
	gcc $(SIMULATOR_CFLAGS) -o ATMSoundFX$(SIMULATOR_SUFFIX).o -c ATMHud/ATMSoundFX.m
	gcc $(SIMULATOR_CFLAGS) -o ATMTextLayer$(SIMULATOR_SUFFIX).o -c ATMHud/ATMTextLayer.m
	gcc $(SIMULATOR_CFLAGS) -o ATMHud$(SIMULATOR_SUFFIX).o -c ATMHud/ATMHud.m
	ar -rcs libATMHud$(SIMULATOR_SUFFIX).a ATM*$(SIMULATOR_SUFFIX).o

libATMHud$(DEVICE_SUFFIX).a: ATMHud $(ATMHud_SOURCES)
	gcc $(DEVICE_CFLAGS) -o ATMHudQueueItem$(DEVICE_SUFFIX).o -c ATMHud/ATMHudQueueItem.m
	gcc $(DEVICE_CFLAGS) -o ATMHudView$(DEVICE_SUFFIX).o -c ATMHud/ATMHudView.m
	gcc $(DEVICE_CFLAGS) -o ATMProgressLayer$(DEVICE_SUFFIX).o -c ATMHud/ATMProgressLayer.m
	gcc $(DEVICE_CFLAGS) -o ATMSoundFX$(DEVICE_SUFFIX).o -c ATMHud/ATMSoundFX.m
	gcc $(DEVICE_CFLAGS) -o ATMTextLayer$(DEVICE_SUFFIX).o -c ATMHud/ATMTextLayer.m
	gcc $(DEVICE_CFLAGS) -o ATMHud$(DEVICE_SUFFIX).o -c ATMHud/ATMHud.m
	ar -rcs libATMHud$(DEVICE_SUFFIX).a ATM*$(DEVICE_SUFFIX).o

ATMHud.dll: atmhud.cs enums.cs
	-@mkdir ios
	/Developer/MonoTouch/usr/bin/btouch -e atmhud.cs enums.cs --out=ATMHud.dll --tmpdir=ios

clean:
	-rm -rf ios *.o *.a *.dll
