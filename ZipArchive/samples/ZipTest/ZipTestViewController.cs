using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MTZipArchive;

namespace ZipTest
{
	public partial class ZipTestViewController : UIViewController
	{
		public ZipTestViewController () : base ("ZipTestViewController", null)
		{
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
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}

		string theZipFile;

		partial void Zip (NSObject sender)
		{
			string path = Environment.CurrentDirectory;
			string fileName = "/file.zip";

			theZipFile = path + fileName;
			ZipArchive zip = new ZipArchive();

			zip.OnError += (object s, EventArgs e) => 
			{
				string error = s as String;
				Console.WriteLine("Error:" + error);
			};

			zip.CreateZipFile(theZipFile);
		
			bool added = zip.AddFile(path + "/xamarin.jpg", "xamarin.jpg");

			zip.CloseZipFile();

			if(added)
				new UIAlertView("Info", "Success: " + theZipFile, null, "Great", null).Show();
			else
				new UIAlertView("Info", "Something went wrong", null, "Great", null).Show();

			Console.WriteLine(theZipFile);

		}

		partial void UnZip (NSObject sender)
		{
			string theUnzippedFolder = Environment.CurrentDirectory + "/unzipped";

			ZipArchive zip = new ZipArchive();

			zip.OnError += (object s, EventArgs e) => 
			{
				string error = s as String;
				Console.WriteLine("Error:" + error);
			};

			zip.UnzipOpenFile(theZipFile);
			bool unzipped = zip.UnzipFileTo(theUnzippedFolder, true);
			zip.UnzipCloseFile();
		
			if(unzipped)
				new UIAlertView("Info", "Success: " + theUnzippedFolder, null, "Great", null).Show();
			else
				new UIAlertView("Info", "Something went wrong", null, "Great", null).Show();
			
			Console.WriteLine(theUnzippedFolder);
		}

	}
}

