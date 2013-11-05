using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Twitter;
using System.Drawing;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace TapkuSample
{
	public partial class TweetViewController : UIViewController
	{
		//loads the TweetViewController.xib file and connects it to this object
		public TweetViewController ()
		{
		}
		
		TWTweetComposeViewController tweetSheet;
		MKMapView mapView = null;
		
		public override void ViewDidLoad()
		{
			
			mapView = new MKMapView();
			RectangleF frame = new RectangleF(0,0,320,360);

			mapView.Frame = frame;
			mapView.ShowsUserLocation = true;
			
			
			var myAnnotation = new MyAnnotation(new CLLocationCoordinate2D(0,0), "Home", "is where the heart is");
			mapView.AddAnnotationObject(myAnnotation);
			
			
			UIButton detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
			
			mapView.GetViewForAnnotation = delegate(MKMapView mapViewForAnnotation, NSObject annotation) {
			
				var anv = mapView.DequeueReusableAnnotation("thislocation");
				if (anv == null)
				{
					anv = new MKPinAnnotationView(annotation, "thislocation");
					
					detailButton.TouchUpInside += (s, e) => { 
						Console.WriteLine ("Tapped");
					};
					anv.RightCalloutAccessoryView = detailButton;
				}
				else 
				{
					anv.Annotation = annotation;
				}
				anv.CanShowCallout = true;
				return anv;	
			};
			
			View.AddSubview(mapView);
		}
		
		public class MyAnnotation : MKAnnotation
		{
		   private CLLocationCoordinate2D _coordinate;
		   private string _title, _subtitle;
		   public override CLLocationCoordinate2D Coordinate {
				get { return _coordinate; }
				set { value = _coordinate;}
		   }
		   public override string Title {
				get { return _title; }
		   }
		   public override string Subtitle {
				get { return _subtitle; }
		   }
		   /// <summary>
		   /// Need this constructor to set the fields, since the public
		   /// interface of this class is all READ-ONLY
		   /// <summary>
		   public MyAnnotation (CLLocationCoordinate2D coord,
		                            string t, string s) : base()
		   {
		      _coordinate=coord;
		      _title=t; 
		      _subtitle=s;
		   }
		}
		
	}
}
