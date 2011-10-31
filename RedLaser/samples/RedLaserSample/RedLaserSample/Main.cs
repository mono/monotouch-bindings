/*
 * A MonoTouch implementation of RedLaser's SDK sample
 * 
 * Chris Branson, November 2009
 * Chris Branson, August 2010 - updated to support RedLaser SDK 2.8.2
 * Chris Branson, April 2011 - updated to support RedLaser SDK 3.0.0
 * 
 * This is the sample view controller and demonstrates initialisation of
 * the barcode picker controller, setting of properties and handling
 * of events.
 * 
 * Please refer to README.TXT for important information regarding this solution.
 * 
 */

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RedLaserSample
{
	public class Application
	{
		static void Main (string[] args)
        {
			try
			{
            		UIApplication.Main (args, null, "RLSampleAppDelegate");
			}
			catch (Exception ex)
			{	
				// any unhandled exceptions end up here
				Console.WriteLine(ex);
			}
        }
	}
}