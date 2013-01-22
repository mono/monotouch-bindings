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

		// This will hold the location of our 
		string theZipFile;

		// This is the Zip Implementation Method
		partial void Zip (NSObject sender)
		{
			// Get the current working directory and set the desired name of the Zip File
			string path = Environment.CurrentDirectory;
			string fileName = "/file.zip";

			theZipFile = path + fileName;

			// Create a new instance of ZipArchive
			ZipArchive zip = new ZipArchive();

			// You can subscribe to OnError event so you can handle
			// any errors situations 
			zip.OnError += (object s, EventArgs e) => 
			{
				string error = s as String;
				Console.WriteLine("Error:" + error);
			};

			// Create the Zip file on the desired path
			zip.CreateZipFile(theZipFile);
		
			// Add the files you want zip, this will return "true" if
			// the file was successfully added to zip file 
			bool added = zip.AddFile(path + "/xamarin.jpg", "xamarin.jpg");

			// Dont forget to close the zip file
			zip.CloseZipFile();

			if(added)
				new UIAlertView("Info", "Success: " + theZipFile, null, "Great", null).Show();
			else
				new UIAlertView("Info", "Something went wrong", null, "Ok", null).Show();

			Console.WriteLine(theZipFile);

		}

		partial void UnZip (NSObject sender)
		{
			// Set the desired output directory to place unzipped files
			string theUnzippedFolder = Environment.CurrentDirectory + "/unzipped";

			// Create a new instance of ZipArchiv
			ZipArchive zip = new ZipArchive();

			// You can subscribe to OnError event so you can handle
			// any errors situations 
			zip.OnError += (object s, EventArgs e) => 
			{
				string error = s as String;
				Console.WriteLine("Error:" + error);
			};

			// Open the zip file you want to unzip
			zip.UnzipOpenFile(theZipFile);

			// This will return true if succeeded to unzip
			bool unzipped = zip.UnzipFileTo(theUnzippedFolder, true);

			// Dont forget to close the zip file
			zip.UnzipCloseFile();
		
			if(unzipped)
				new UIAlertView("Info", "Success: " + theUnzippedFolder, null, "Great", null).Show();
			else
				new UIAlertView("Info", "Something went wrong", null, "Ok", null).Show();
			
			Console.WriteLine(theUnzippedFolder);
		}

	}
}

