TestFlight
==========

This is a MonoTouch binding for the TestFlight SDK which can be found at

     https://testflightapp.com/sdk/

The current version of this binding is for TestFlight SDK 3.0.0 released on 19 Feb 2014

Building
========

1. Download the sdk zip from the url to the binding directory.
2. Run `make` in the binding directory to build TestFlight.dll

Using TestFlight.dll with your own iOS App
==========================================

Simply add TestFlight.dll to your project's References in MonoDevelop and you
are good to go!

To use the thread safe TakeOff methode. Change TestFlight.TakeOff(token) to TestFlight.TakeOffThreadSafe(token)
This works much better with MonoTouch. Because it doesn't override the Build-in (.NET) Error handling.

Testflight settings
===================
The TestFlight settings are now implemented in C# as well.

- TestFlight.SetDisableInAppUpdates => Defaults to false. Setting to true, disables the in app update screen shown in BETA apps when there is a new version available on TestFlight.
- TestFlight.SetFlushSecondsInterval => Defaults to 60, 0 turns of the flush timer and 30 is the minimum value.
- TestFlight.SetLogOnCheckpoint=> Defaults to true. Because logging is synchronous, if you have a high preformance app, you might want to turn this off.
- TestFlight.SetLogToConsole => Defaults to true. Prints remote logs to Apple System Log.
- TestFlight.SetLogToSTDERR => Defaults to true. Sends remote logs to STDERR when debugger is attached.
- TestFlight.SetReinstallCrashHandlers => If set to true: Reinstalls crash handlers, to be used if a third party library installs crash handlers overtop of the TestFlight Crash Handlers.
- TestFlight.SetReportCrashes => Defaults to true. Sets the report crashes. If set to false, crash handlers are never installed. Must be set **before** calling `takeOff:`.
- TestFlight.SetSendLogOnlyOnCrash => Defaults to false. Setting to true stops remote logs from being sent when sessions end. They would only be sent in the event of a crash.
- TestFlight.SetSessionKeepAliveTimeout => Defaults to 30. Sets the session keep alive timeout. This is the amount of time a user can leave the app for and still continue the same session when they come back.

Future versions
===============

If the bindings aren't updated to the latest version, you could try to edit the makefile yourself.
But that way it isn't tested and you could be having unexpected crashes off your app.		