using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;
using System.Security.Cryptography;

namespace GoogleMapsAdvSample
{
	public class PolygonsViewController : UIViewController
	{
		public PolygonsViewController () : base ()
		{
			Title = "Polygons";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (39.13006, -77.508545, 4);
			var mapView = MapView.FromCamera (RectangleF.Empty, camera);

			// Create the first polygon.
			var polygon = new Polygon () {
				Path = PathOfNewYorkState (),
				Title = "New York",
				FillColor = UIColor.FromRGBA (0.25f, 0, 0, 0.05f),
				StrokeColor = UIColor.Black,
				StrokeWidth = 2,
				Tappable = true,
				Map = mapView
			};

			// Copy the existing polygon and its settings and use it as a base for the
			// second polygon.

			polygon = (Polygon) polygon.Copy ();
			polygon.Title = "North Carolina";
			polygon.Path = PathOfNorthCarolina ();
			polygon.FillColor = UIColor.FromRGBA (0, 0.25f, 0, 0.05f);
			polygon.Map = mapView;

			mapView.TappedOverlay += (sender, e) => {
				// When a polygon is tapped, randomly change its fill color to a new hue.
				if (e.Overlay is Polygon) {
					var pol = e.Overlay as Polygon;
					var hue = GetRandomNumber ();
					pol.FillColor = UIColor.FromHSBA (hue, 1, 1, 0.05f);
				}
			};

			View = mapView;
		}

		Google.Maps.Path PathOfNewYorkState ()
		{
			var path = new MutablePath ();
			path.AddLatLong (42.5142, -79.7624);
			path.AddLatLong (42.7783, -79.0672);
			path.AddLatLong (42.8508, -78.9313);
			path.AddLatLong (42.9061, -78.9024);
			path.AddLatLong (42.9554, -78.9313);
			path.AddLatLong (42.9584, -78.9656);
			path.AddLatLong (42.9886, -79.0219);
			path.AddLatLong (43.0568, -79.0027);
			path.AddLatLong (43.0769, -79.0727);
			path.AddLatLong (43.1220, -79.0713);
			path.AddLatLong (43.1441, -79.0302);
			path.AddLatLong (43.1801, -79.0576);
			path.AddLatLong (43.2482, -79.0604);
			path.AddLatLong (43.2812, -79.0837);
			path.AddLatLong (43.4509, -79.2004);
			path.AddLatLong (43.6311, -78.6909);
			path.AddLatLong (43.6321, -76.7958);
			path.AddLatLong (43.9987, -76.4978);
			path.AddLatLong (44.0965, -76.4388);
			path.AddLatLong (44.1349, -76.3536);
			path.AddLatLong (44.1989, -76.3124);
			path.AddLatLong (44.2049, -76.2437);
			path.AddLatLong (44.2413, -76.1655);
			path.AddLatLong (44.2973, -76.1353);
			path.AddLatLong (44.3327, -76.0474);
			path.AddLatLong (44.3553, -75.9856);
			path.AddLatLong (44.3749, -75.9196);
			path.AddLatLong (44.3994, -75.8730);
			path.AddLatLong (44.4308, -75.8221);
			path.AddLatLong (44.4740, -75.8098);
			path.AddLatLong (44.5425, -75.7288);
			path.AddLatLong (44.6647, -75.5585);
			path.AddLatLong (44.7672, -75.4088);
			path.AddLatLong (44.8101, -75.3442);
			path.AddLatLong (44.8383, -75.3058);
			path.AddLatLong (44.8676, -75.2399);
			path.AddLatLong (44.9211, -75.1204);
			path.AddLatLong (44.9609, -74.9995);
			path.AddLatLong (44.9803, -74.9899);
			path.AddLatLong (44.9852, -74.9103);
			path.AddLatLong (45.0017, -74.8856);
			path.AddLatLong (45.0153, -74.8306);
			path.AddLatLong (45.0046, -74.7633);
			path.AddLatLong (45.0027, -74.7070);
			path.AddLatLong (45.0007, -74.5642);
			path.AddLatLong (44.9920, -74.1467);
			path.AddLatLong (45.0037, -73.7306);
			path.AddLatLong (45.0085, -73.4203);
			path.AddLatLong (45.0109, -73.3430);
			path.AddLatLong (44.9874, -73.3547);
			path.AddLatLong (44.9648, -73.3379);
			path.AddLatLong (44.9160, -73.3396);
			path.AddLatLong (44.8354, -73.3739);
			path.AddLatLong (44.8013, -73.3324);
			path.AddLatLong (44.7419, -73.3667);
			path.AddLatLong (44.6139, -73.3873);
			path.AddLatLong (44.5787, -73.3736);
			path.AddLatLong (44.4916, -73.3049);
			path.AddLatLong (44.4289, -73.2953);
			path.AddLatLong (44.3513, -73.3365);
			path.AddLatLong (44.2757, -73.3118);
			path.AddLatLong (44.1980, -73.3818);
			path.AddLatLong (44.1142, -73.4079);
			path.AddLatLong (44.0511, -73.4367);
			path.AddLatLong (44.0165, -73.4065);
			path.AddLatLong (43.9375, -73.4079);
			path.AddLatLong (43.8771, -73.3749);
			path.AddLatLong (43.8167, -73.3914);
			path.AddLatLong (43.7790, -73.3557);
			path.AddLatLong (43.6460, -73.4244);
			path.AddLatLong (43.5893, -73.4340);
			path.AddLatLong (43.5655, -73.3969);
			path.AddLatLong (43.6112, -73.3818);
			path.AddLatLong (43.6271, -73.3049);
			path.AddLatLong (43.5764, -73.3063);
			path.AddLatLong (43.5675, -73.2582);
			path.AddLatLong (43.5227, -73.2445);
			path.AddLatLong (43.2582, -73.2582);
			path.AddLatLong (42.9715, -73.2733);
			path.AddLatLong (42.8004, -73.2898);
			path.AddLatLong (42.7460, -73.2664);
			path.AddLatLong (42.4630, -73.3708);
			path.AddLatLong (42.0840, -73.5095);
			path.AddLatLong (42.0218, -73.4903);
			path.AddLatLong (41.8808, -73.4999);
			path.AddLatLong (41.2953, -73.5535);
			path.AddLatLong (41.2128, -73.4834);
			path.AddLatLong (41.1011, -73.7275);
			path.AddLatLong (41.0237, -73.6644);
			path.AddLatLong (40.9851, -73.6578);
			path.AddLatLong (40.9509, -73.6132);
			path.AddLatLong (41.1869, -72.4823);
			path.AddLatLong (41.2551, -72.0950);
			path.AddLatLong (41.3005, -71.9714);
			path.AddLatLong (41.3108, -71.9193);
			path.AddLatLong (41.1838, -71.7915);
			path.AddLatLong (41.1249, -71.7929);
			path.AddLatLong (41.0462, -71.7517);
			path.AddLatLong (40.6306, -72.9465);
			path.AddLatLong (40.5368, -73.4628);
			path.AddLatLong (40.4887, -73.8885);
			path.AddLatLong (40.5232, -73.9490);
			path.AddLatLong (40.4772, -74.2271);
			path.AddLatLong (40.4861, -74.2532);
			path.AddLatLong (40.6468, -74.1866);
			path.AddLatLong (40.6556, -74.0547);
			path.AddLatLong (40.7618, -74.0156);
			path.AddLatLong (40.8699, -73.9421);
			path.AddLatLong (40.9980, -73.8934);
			path.AddLatLong (41.0343, -73.9854);
			path.AddLatLong (41.3268, -74.6274);
			path.AddLatLong (41.3583, -74.7084);
			path.AddLatLong (41.3811, -74.7101);
			path.AddLatLong (41.4386, -74.8265);
			path.AddLatLong (41.5075, -74.9913);
			path.AddLatLong (41.6000, -75.0668);
			path.AddLatLong (41.6719, -75.0366);
			path.AddLatLong (41.7672, -75.0545);
			path.AddLatLong (41.8808, -75.1945);
			path.AddLatLong (42.0013, -75.3552);
			path.AddLatLong (42.0003, -75.4266);
			path.AddLatLong (42.0013, -77.0306);
			path.AddLatLong (41.9993, -79.7250);
			path.AddLatLong (42.0003, -79.7621);
			path.AddLatLong (42.1827, -79.7621);
			path.AddLatLong (42.5146, -79.7621);
			return path;
		}

		Google.Maps.Path PathOfNorthCarolina ()
		{
			var path = new MutablePath ();
			path.AddLatLong (33.7963, -78.4850);
			path.AddLatLong (34.8037, -79.6742);
			path.AddLatLong (34.8206, -80.8003);
			path.AddLatLong (34.9377, -80.7880);
			path.AddLatLong (35.1019, -80.9377);
			path.AddLatLong (35.0356, -81.0379);
			path.AddLatLong (35.1457, -81.0324);
			path.AddLatLong (35.1660, -81.3867);
			path.AddLatLong (35.1985, -82.2739);
			path.AddLatLong (35.2041, -82.3933);
			path.AddLatLong (35.0637, -82.7765);
			path.AddLatLong (35.0817, -82.7861);
			path.AddLatLong (34.9996, -83.1075);
			path.AddLatLong (34.9918, -83.6183);
			path.AddLatLong (34.9918, -84.3201);
			path.AddLatLong (35.2131, -84.2885);
			path.AddLatLong (35.2680, -84.2226);
			path.AddLatLong (35.2310, -84.1113);
			path.AddLatLong (35.2815, -84.0454);
			path.AddLatLong (35.4058, -84.0248);
			path.AddLatLong (35.4719, -83.9424);
			path.AddLatLong (35.5166, -83.8559);
			path.AddLatLong (35.5512, -83.6938);
			path.AddLatLong (35.5680, -83.5181);
			path.AddLatLong (35.6327, -83.3849);
			path.AddLatLong (35.7142, -83.2475);
			path.AddLatLong (35.7799, -82.9962);
			path.AddLatLong (35.8445, -82.9276);
			path.AddLatLong (35.9224, -82.8191);
			path.AddLatLong (35.9958, -82.7710);
			path.AddLatLong (36.0613, -82.6419);
			path.AddLatLong (35.9702, -82.6103);
			path.AddLatLong (35.9547, -82.5677);
			path.AddLatLong (36.0236, -82.4730);
			path.AddLatLong (36.0669, -82.4194);
			path.AddLatLong (36.1168, -82.3535);
			path.AddLatLong (36.1345, -82.2862);
			path.AddLatLong (36.1467, -82.1461);
			path.AddLatLong (36.1035, -82.1228);
			path.AddLatLong (36.1268, -82.0267);
			path.AddLatLong (36.2797, -81.9360);
			path.AddLatLong (36.3527, -81.7987);
			path.AddLatLong (36.3361, -81.7081);
			path.AddLatLong (36.5880, -81.6724);
			path.AddLatLong (36.5659, -80.7234);
			path.AddLatLong (36.5438, -80.2977);
			path.AddLatLong (36.5449, -79.6729);
			path.AddLatLong (36.5449, -77.2559);
			path.AddLatLong (36.5505, -75.7562);
			path.AddLatLong (36.3129, -75.7068);
			path.AddLatLong (35.7131, -75.4129);
			path.AddLatLong (35.2041, -75.4720);
			path.AddLatLong (34.9794, -76.0748);
			path.AddLatLong (34.5258, -76.4951);
			path.AddLatLong (34.5880, -76.8109);
			path.AddLatLong (34.5314, -77.1378);
			path.AddLatLong (34.3910, -77.4481);
			path.AddLatLong (34.0481, -77.7983);
			path.AddLatLong (33.7666, -77.9260);
			path.AddLatLong (33.7963, -78.4863);
			return path;
		}

		float GetRandomNumber ()
		{ 
			var rng = new RNGCryptoServiceProvider();
			var bytes = new Byte[8];
			rng.GetBytes (bytes);
			var ul = BitConverter.ToUInt64 (bytes, 0) / (1 << 11);
			return (float) (ul / (Double)(1UL << 53));
		}

	}
}

