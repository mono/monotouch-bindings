using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Estimote.iOS;
using MonoTouch.CoreLocation;

//The ProximityDemo from https://github.com/Estimote/iOS-SDK/tree/master/ProximityDemo converted to Xamarin.iOS.
//It makes use of the Estimote SDK wrapper.
namespace EstimoteSample.iOS
{
	public partial class ProximityDemoViewController : UIViewController
	{
		ESTBeaconManager estBeaconManager;

		public ProximityDemoViewController () : base ("ProximityDemoViewController", null)
		{
		}

		public class BeaconManager : ESTBeaconManagerDelegate
		{
			ESTBeacon selectedBeacon;
			UILabel _distanceLabel;

			public BeaconManager (UILabel label)
			{
				_distanceLabel = label;
			}

			public override void DidRangeBeacons (ESTBeaconManager manager, NSArray[] beacons, ESTBeaconRegion region)
			{
				if(beacons.Length > 0)
				{
					if(selectedBeacon == null)
					{
						// initialy pick closest beacon
						selectedBeacon = (ESTBeacon)beacons.GetValue(0);
					}
					else
					{
						for(int i=0;i<beacons.Length;i++)
						{
							ESTBeacon cBeacon = (ESTBeacon)beacons.GetValue(i);
							// update beacon if same as selected initially
							if(selectedBeacon.Ibeacon.Major.UInt16Value == cBeacon.Ibeacon.Major.UInt16Value
								&& selectedBeacon.Ibeacon.Minor.UInt16Value == cBeacon.Ibeacon.Minor.UInt16Value)
							{
								selectedBeacon = cBeacon;
							}
						}
					}

					// beacon array is sorted based on distance
					// closest beacon is the first one
					string labelTextStr = String.Format("Beacon: {0} \nMajor: {1}, Minor: {2}\nRSSI: {3}\nRegion: ", 
						selectedBeacon.Ibeacon.ProximityUuid.AsString(),
						selectedBeacon.Ibeacon.Major.UInt16Value,
						selectedBeacon.Ibeacon.Minor.UInt16Value,
						selectedBeacon.Ibeacon.Rssi
						);

					// calculate and set new y position
					switch(selectedBeacon.Ibeacon.Proximity)
					{
						case CLProximity.Unknown:
							labelTextStr += "Unknown";
						break;
						case CLProximity.Immediate:
							labelTextStr += "Immediate";
						break;
						case CLProximity.Near:
							labelTextStr += "Near";
						break;
						case CLProximity.Far:
							labelTextStr += "Far";
						break;
					}

					NSString labelText = new NSString(labelTextStr);
					_distanceLabel.Text = labelText;
				}
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// setup Estimote beacon manager

			var myBeaconManager = new BeaconManager(distanceLabel);

			estBeaconManager = new ESTBeaconManager();

			estBeaconManager.Delegate = myBeaconManager;
			estBeaconManager.AvoidUnknownStateBeacons = true;

			// create sample region object (you can additionaly pass major / minor values)
			ESTBeaconRegion region = new ESTBeaconRegion("EstimoteSampleRegion");

			// start looking for estimote beacons in region
			// when beacon ranged beaconManager:didRangeBeacons:inRegion: invoked
			estBeaconManager.StartRangingBeaconsInRegion(region);
		}
	}
}

