MonoTouch AdMob Bindings
========================

Here is the required files to use btouch, just use the following command 
in shell in order to generate the dll

bash /Developer/MonoTouch/usr/bin/btouch libGoogleAdMobAds.cs -s:enums.cs extensions.cs

also don't forget to include the libGoogleAdMobAds.a to your project and
set its build action to NOTHING

and add this to your additional btouch arguments

-v -v -v -gcc_flags "-framework AudioToolbox -framework MessageUI -framework SystemConfiguration -L${ProjectDir} -lGoogleAdMobAds -force_load ${ProjectDir}/libGoogleAdMobAds.a"


Alex Soto
@dalexsoto
https://github.com/dalexsoto/


