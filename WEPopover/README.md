WEPopver Bindings

https://github.com/werner77/WEPopover

Use the following commands in order to generate the DLL and use it within a MonoTouch project


btouch command (from inside the project directory):

/Developer/MonoTouch/usr/bin/btouch WEPopoverController.cs WEPopoverContainerView.cs WEPopoverParentView.cs WETouchableView.cs --outdir=gen -ns=WEPopover --unsafe --sourceonly=genfiles

smcs command (from inside the project directory): 

/Developer/MonoTouch/usr/bin/smcs -out:WEPopover.dll `cat genfiles` -unsafe -r:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -target:library

mtouch arguments (in the 'iPhone Build' Menu in MonoDevelop):

-v -v -v -v --gcc_flags "-framework CoreGraphics -framework CoreFoundation -framework UIKit -L${ProjectDir} -lWEPopover -force_load ${ProjectDir}/libWEPopover.a"

