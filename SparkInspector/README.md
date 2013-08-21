Bindings to the Spark Inspector Framework
===============================

MonoTouch bindings for `SparkInspector.framework` to use with the [Spark Inspector App](http://sparkinspector.com/)


Building 
========

Run `make` to build the bindings. It assumes you have Spark Inspector installed in `/Applications/Spark Inspector.app`


Usage
===

Add the `.csproj` to your solution and add SparkInspector in your project References.

Then add these lines to your App delegate's `FinishedLaunching`

    #if DEBUG
	  SparkInspector.EnableObservation ();
    #endif

