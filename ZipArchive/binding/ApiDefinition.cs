using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MTZipArchive
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//

	delegate void ZipArchiveProgressUpdateHandler (int percentage, int filesProcessed, int numFiles);

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ZipArchiveDelegate 
	{
		[Export("ErrorMessage:"), EventArgs("ZipArchiveDel"), EventName("OnError")]
		void ErrorMessage (string msg);

		[Export("OverWriteOperation:"), DelegateName("ZipArchiveCondition"), DefaultValue("true")]
		bool OverWriteOperation (string file);
	}

	[BaseType (typeof (NSObject),
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (ZipArchiveDelegate) })]
	interface ZipArchive 
	{
		[Wrap ("WeakDelegate")]
		ZipArchiveDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("CreateZipFile2:")]
		bool CreateZipFile(string zipFile);

		[Export("CreateZipFile2:Password:")]
		bool CreateZipFile(string zipFile, string password);

		[Export("addFileToZip:newname:")]
		bool AddFile(string file, string newName);

		[Export("CloseZipFile2")]
		bool CloseZipFile();

		[Export("UnzipOpenFile:")]
		bool UnzipOpenFile(string file);
		
		[Export("UnzipOpenFile:Password:")]
		bool UnzipOpenFile(string file, string password);
		
		[Export("UnzipFileTo:overWrite:")]
		bool UnzipFileTo(string path, bool overwrite);
		
		[Export("UnzipCloseFile")]
		bool UnzipCloseFile();
	}
}

