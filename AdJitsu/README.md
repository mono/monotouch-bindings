Bindings to the AdJitsu library
===============================

MonoTouch bindings for the AdJitsu library.


Building 
========

To build the sample, load the solution into MonoDevelop and run it,
the sample is a copy of the sample Adjitsu SDK app.

If you want to update the bindings to the Adjitsu library update the
adjitsu.cs file and run the "make" command. Not that you will need to
obtain a copy of the AdJitsu native library from adjitsu.com.


API
===

The code lives in the AdJitsu namespace, with the AdJitsuView and
AdJitsuViewDelegate classes.  This supports the MonoTouch dual event
system: either use the Delegate property in the AdJitsuView to connect
an instance of the AdJitsuViewDelegate, or you can connect
individually to the various C# events on the view, like this:

    ad = new AdJitsuView (bounds);
    ad.FinishedLoadingScene += delegate {
        Console.WriteLine ("done");
    };


Using AdJitsu.dll with your own iOS App
=======================================

Simply add AdJitsu.dll to your project's References and you are good to go!

Note: Projects using AdJitsu must target the ARMv7 architecture for devices.
To configure your project to target ARMv7 in MonoDevelop, open your project
options (Project > {ProjectName} Options > iPhone Build) and for the iPhone
and iPad platforms (not iPhoneSimulator!), add "--armv7" to the field
labaled: "Additional mtouch arguments".
