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
cocos2d\
cocosDenshion\
CorePlot\
Couchbase\
Crittercism\
Datatrans\
DropboxChooser\
DropBoxSync\
Estimote\
facebook\
FlurryAnalytics\
GCDiscreetNotification\
GoogleAdMobAds\
GoogleAnalytics\
GoogleCast\
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
Taplytics\
TestFairy\
TestFlight\
TimesSquare\
TSMiniWebBrowser\
UrbanAirShip\
VENCalculatorInputView\
WEPopover\
ZipArchive
