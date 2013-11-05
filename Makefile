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

OSX=
DUAL=

IOS=\
AmazonLogin\
ATMHud\
BeeblexSDK\
BPStatusBar\
chipmunk\
cocosDenshion\
CorePlot\
Couchbase\
Datatrans\
DropboxChooser\
DropBoxSync\
facebook\
flite\
FlurryAnalytics\
FlurryAppCircle\
GCDiscreetNotification\
GoogleAdMobAds\
GoogleAnalytics\
GoogleMaps\
GooglePlusAndPlayGameServices\
iCarousel\
InMobi\
iRate\
KGStatusBar\
Kiip\
LAAnimatedGrid\
LineaPRO\
MagTek.iDynamo\
MBAlertView\
MBProgressHUD\
MGSplitViewController\
MMSDK\
Mobclix\
MTIKS\
OpenTok\
Parse\
PaypalMEC\
PayPalMobileExpressCheckout\
PayPalMobilePayment\
PHFComposeBarView\
RedLaser\
Redpark\
Route-Me\
SDSegmentedControl\
SDWebImage\
ShareKit\
SMCalloutView\
SparkInspector\
TapJoyConnect\
TestFlight\
TimesSquare\
TSMiniWebBrowser\
UrbanAirShip\
WEPopover\
ZipArchive