IOS=AtomcraftHud FacebookConnect MGSplitViewController RedLaser Tapku AdJitsu
OSX=
DUAL=CorePlot

all: ios

ios:
	make build DIRS="$(IOS)"
	make build-specific TARGET=ios DIRS="$(DUAL)"

osx:
	make build-specific TARGET=osx DIRS="$(OSX)"

build:
	for i in $(DIRS); do (cd $$i; make); done

build-specific:
	for i in $(DIRS); do (cd $$i; make $(TARGET)); done

clean:
	for i in $(IOS) $(OSX) $(DUAL); do (cd $$i; make clean); done
