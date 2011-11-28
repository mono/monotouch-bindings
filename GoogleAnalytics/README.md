MonoTouch GoogleAnalytics bindings
=================================

This is a MonoTouch binding for Google's Analytics library located at:

http://code.google.com/mobile/analytics/

Building
========

To build the bindings, run the `make' command frmo within the bindings
directory.

Using GoogleAnalytics.dll wit your own iOS app
==============================================

Simply add the GoogleAnalytics.dll to your project's references in MonoDevelop
and you are good to go.

You will want to start with:

var tracker = GoogleAnalytics.GANTracker.SharedTracker;

Then you can use the various properties of the GANTracker in the tracker
variable
