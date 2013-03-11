using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

using MonoMac.Cocos2D;

[assembly: MonoMac.RequiredFramework("cocos2d.dylib")]
namespace XamMacSample
{

	public partial class AppDelegate : NSApplicationDelegate
	{

		public AppDelegate ()
		{
			Type t = typeof(CCDirector);
			MonoMac.ObjCRuntime.Runtime.RegisterAssembly (t.Assembly);
		}

		public override void FinishedLaunching (NSObject notification)
		{
			var director = (CCDirectorMac)CCDirector.SharedDirector;
#if DEBUG
			director.DisplayStats = true;
#endif

			director.View = glView;
			//window.AcceptsMouseMovedEvents = false;
			//window.Center ();

			director.Run (new HelloWorldLayer().Scene ());

		}
	}
}

