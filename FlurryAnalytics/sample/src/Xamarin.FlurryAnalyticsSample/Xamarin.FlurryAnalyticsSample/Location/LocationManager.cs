// 
//  Copyright 2011  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Linq;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;

namespace Xamarin.FlurryAnalyticsSample
{
	public class LocationManager
	{
		public static bool IsInitialized { get; private set; }
		public static CLLocationManager CoreLocationManager { get; set; }
		
		public static CLLocation OldLocation { get; private set; }
		public static CLLocation NewLocation { get; private set; }
		public static CLHeading NewHeading { get; private set; }
		
		static Action<CLLocationUpdatedEventArgs> _LocationUpdated;
		public static Action<CLLocationUpdatedEventArgs> LocationUpdated { 
			get { return _LocationUpdated; }
			set 
			{ 
				//Null and Duplicate Subscriber Check
				if (value == null)
					return;
				
				if(_LocationUpdated != null) {
					if(_LocationUpdated.GetInvocationList().Contains(value)) {
						return;
					}
				}
				
				_LocationUpdated += value; 
			}
		}
		
		static Action<CLHeading> _HeadingUpdated;
		public static Action<CLHeading> HeadingUpdated { 
			get { return _HeadingUpdated; }
			set 
			{
				//Null and Duplicate Subscriber Check
				if(value != null && _HeadingUpdated.GetInvocationList().Contains(value) == false) 
				{ 
					_HeadingUpdated += value; 
				}
			}
		}
		
		private static NSTimer UpdateLocationTimer;
		private static NSTimer UpdateHeadingTimer;
		
		public LocationManager()
		{
			Initialize();
		}
		
		public static void Initialize()
		{
			CoreLocationManager = new CLLocationManager();
			
			CoreLocationManager.StartUpdatingLocation();
			
			CoreLocationManager.UpdatedHeading += HandleCoreLocationManagerUpdatedHeading;
			CoreLocationManager.UpdatedLocation += HandleCoreLocationManagerUpdatedLocation;
			
			UpdateLocationTimer = NSTimer.CreateRepeatingTimer(TimeSpan.FromMinutes(1), InitializeLocationUpdate);
			UpdateHeadingTimer =NSTimer.CreateRepeatingTimer(TimeSpan.FromMinutes(1), InitializeHeadingUpdate);
		}
		
				
		public static void InitializeLocationUpdate()
		{
			CoreLocationManager.StartUpdatingLocation();
		}
		
		public static void InitializeHeadingUpdate()
		{
			CoreLocationManager.StartUpdatingHeading();	
		}
		
		static void HandleCoreLocationManagerUpdatedLocation (object sender, CLLocationUpdatedEventArgs e)
		{
			OldLocation = e.OldLocation;
			NewLocation = e.NewLocation;
			
			if(LocationUpdated != null)
				LocationUpdated(e);
		}

		static void HandleCoreLocationManagerUpdatedHeading (object sender, CLHeadingUpdatedEventArgs e)
		{
			NewHeading = e.NewHeading;
			
			if(HeadingUpdated != null)
				HeadingUpdated(e.NewHeading);
		}
		
		public static void RemoveSubscribers()
		{
			_LocationUpdated = null;
			_HeadingUpdated = null;
		}
		
		public static void Dispose()
		{
			LocationUpdated = null;
			OldLocation = null;
			NewLocation = null;
			NewHeading = null;
			
			UpdateHeadingTimer.Invalidate();
			UpdateLocationTimer.Invalidate();
			
			CoreLocationManager.StopUpdatingHeading();
			CoreLocationManager.StopUpdatingLocation();
			CoreLocationManager.Dispose();
		}
	}
}


