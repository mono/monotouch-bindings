namespace MonoTouch.SparkInspector
{
  using System;
  using MonoTouch.ObjCRuntime;
  using MonoTouch.Foundation;
  
  [BaseType (typeof (NSObject))]
  interface SparkInspector
  {
	
    [Static]
    [Export("enableObservation")]
    void EnableObservation();
  }
}

