IOS=AdJitsu ATMHud facebook FlurryAnalytics FlurryAppCircle  GebePrinter GoogleAdMobAds  MGSplitViewController Parse PayPal RedLaser Tapku TestFlight Three20 UrbanAirship
OSX=
DUAL=CorePlot

all: ios

ios:
	make build DIRS="$(IOS)"
	make build-specific TARGET=ios DIRS="$(DUAL)"

osx:
	make build-specific TARGET=osx DIRS="$(OSX)"

build:
	for i in $(DIRS); do (cd $$i && make); done

build-specific:
	for i in $(DIRS); do (cd $$i && make $(TARGET)); done

clean:
	for i in $(IOS) $(OSX) $(DUAL); do (cd $$i; make clean); done
