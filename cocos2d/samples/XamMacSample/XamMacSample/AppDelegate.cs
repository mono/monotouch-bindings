using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

using MonoMac.Cocos2D;

namespace XamMacSample
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;
		
		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			var layer = new CCLayer ();
			var director = (CCDirectorMac)CCDirector.SharedDirector;
#if DEBUG
			director.DisplayStats = true;
#endif
			mainWindowController = new MainWindowController ();
			var window = mainWindowController.Window;
			director.View = window.GLView;
			window.AcceptsMouseMovedEvents = false;
			window.Center ();

			director.Run (new HelloWorldLayer().Scene ());

			mainWindowController.Window.MakeKeyAndOrderFront (this);
		}
	}
}

