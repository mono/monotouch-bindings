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

Simply add AdJitsu.dll to your project's References and you are good to go!

Note: Projects using AdJitsu must target the ARMv7 architecture for devices.
To configure your project to target ARMv7 in MonoDevelop, open your project
options (Project > {ProjectName} Options > iPhone Build) and for the iPhone
and iPad platforms (not iPhoneSimulator!), add "--armv7" to the field
labaled: "Additional mtouch arguments".
