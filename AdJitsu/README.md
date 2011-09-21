Bindings to the Adjitsu library
===============================

MonoTouch bindings for the AdJitsu library.

Building 
========

To build the sample, load the solution into MonoDevelop and run it,
the sample is a copy of the sample Adjitsu SDK app.  You need to
obtain the libAdjitsuSDK.a yourself and place it in this directory.

If you want to update the bindings to the Adjitsu library update the
adjitsu.cs file and run the "make" command.

API
===

The code lives in the Adjitsu namespace, with the AdjitsuView and
AdjitsuViewDelegate classes.  This supports the MonoTouch dual event
system: either use the Delegate property in the AdjitsuView to connect
an instance of the AdjitsuViewDelegate, or you can connect
individually to the various C# events on the view, like this:

    ad = new AdjitsuView (bounds);
    ad.FinishedLoadingScene += delegate {
        Console.WriteLine ("done");
    };

Using Adjitsu.dll with your own Software
========================================

To link this application with MonoTouch, make sure that your iPhone
Build settings pass the following options to mtouch:

For Simulator:

    --cxx --gcc_flags "-framework AVFoundation -framework CoreLocation -framework CoreMedia -framework CoreMotion -framework CoreText -framework MediaPlayer -framework MobileCoreServices -framework OpenGLES -framework QuartzCore -L${ProjectDir} -lAdJitsuSDK -force_load ${ProjectDir}/libAdJitsuSDK.a -lxml2 -lsqlite3 -framework CoreGraphics -framework QuartzCore"

For Device, you must add "--armv7" to the command line, make it look like this:

    --armv7 --cxx --gcc_flags "-framework AVFoundation -framework CoreLocation -framework CoreMedia -framework CoreMotion -framework CoreText -framework MediaPlayer -framework MobileCoreServices -framework OpenGLES -framework QuartzCore -L${ProjectDir} -lAdJitsuSDK -force_load ${ProjectDir}/libAdJitsuSDK.a -lxml2 -lsqlite3 -framework CoreGraphics -framework QuartzCore"

The requirement for --armv7 is because AdJitsu does not ship libraries
that will run on the older phones.