using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.TestFlight;
namespace TestFlightSample
{
	public partial class TestFlightSampleViewController : DialogViewController
	{
		public TestFlightSampleViewController () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("TestFlight") {
				new Section ("Checkpoints"){
					new StringElement ("Pass checkpoint 1", () => {
						TestFlight.PassCheckpoint("Checkpoint 1");
					}),
					new StringElement ("Pass checkpoint 2", () => {
						TestFlight.PassCheckpoint("Checkpoint 2");
					}),
				},
				new Section ("Options"){
					new StringElement("Set Flush Timeout to 30 sec.",()=>{
						TestFlight.SetFlushSecondsInterval(31);
					}),
					new StringElement("Disable log on Checkpoint",()=>{
						TestFlight.SetLogOnCheckpoint(false);
					}),
					new StringElement("Disable log to Console",()=>{
						TestFlight.SetLogToConsole(false);
					}),
					new StringElement("Disable log to STDERR",()=>{
						TestFlight.SetLogToSTDERR(false);
					}),
					new StringElement("Reinstall crashhandlers",()=>{
						TestFlight.SetReinstallCrashHandlers(true);
					}),
					new StringElement("Disable crash reporting",()=>{
						TestFlight.SetReportCrashes(false);
					}),
					new StringElement("Set send log on Crash only",()=>{
						TestFlight.SetSendLogOnlyOnCrash(true);
					}),
					new StringElement("Set Session timeout to 60 sec.",()=>{
						TestFlight.SetSessionKeepAliveTimeout(60);
					})
				},
			};
		}
	}
}
