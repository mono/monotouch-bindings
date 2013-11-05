using System;
using MonoTouch.UIKit;
using Redpark;
using System.Text;
using System.Drawing;
using MonoTouch.Foundation;

namespace Sample
{
	public class MainViewController : UIViewController
	{
		public RscMgr rscMgr;
		MainView MainView;
		StringBuilder sb;
		public MainViewController ()
		{
			sb = new StringBuilder();
			MainView = new MainView(this);
			View = MainView;
			rscMgr = new RscMgr();
			rscMgr.Delegate = new RedParkDelegate(this);
			rscMgr.Baud = 9600;
			Console.WriteLine("Baud {0}", rscMgr.Baud);
			rscMgr.SetParity(ParityType.None);
			rscMgr.SetStopBits(StopBitsType.One);
			NSNotificationCenter.DefaultCenter.AddObserver("UIKeyboardDidShowNotification",(notification)=>{
				var value = notification.UserInfo["UIKeyboardFrameBeginUserInfoKey"] as NSValue;
				MainView.KeyBoardHeight = value.RectangleFValue.Height;
				MainView.LayoutSubviews();
			});
			NSNotificationCenter.DefaultCenter.AddObserver("UIKeyboardDidHideNotification",(notification)=>{
				var value = notification.UserInfo["UIKeyboardFrameBeginUserInfoKey"] as NSValue;
				Console.WriteLine(value.RectangleFValue);
				MainView.KeyBoardHeight = 0f;
				MainView.LayoutSubviews();
			});

		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public void Connected(string protocol)
		{
			sb.AppendLine(string.Format("Connected: {0}",protocol));
			MainView.SetOutputText(sb.ToString());
		}
		public void CableDisconnected ()
		{
			sb.AppendLine("Disconected");
			MainView.SetOutputText(sb.ToString());
		}

		public void PortStatusChanged ()
		{
			sb.AppendLine("Status Changed");
			MainView.SetOutputText(sb.ToString());
		}

		public void ReadBytesAvailable (int len)
		{
			Console.WriteLine("Bytes Available");
			byte[] bytes = new byte[len];
			rscMgr.Read(bytes,0,len);
			string line = System.Text.Encoding.UTF8.GetString(bytes);
			sb.AppendLine(line);
			MainView.SetOutputText(sb.ToString());
		}
		public void SendText(string text)
		{
			byte[] buffer = Encoding.UTF8.GetBytes(text);
			rscMgr.Write(buffer,0,buffer.Length);
			sb.AppendLine(string.Format("Sent: {0}",text));
			MainView.SetOutputText(sb.ToString());
		}
	
	}
	public class MainView : UIView
	{
		public float KeyBoardHeight = 0f;
		UITextField Input;
		UITextView Output;
		UIButton send;
		MainViewController Parent;
		public MainView(MainViewController parent)
		{
			Parent = parent;
			Input = new UITextField(){BackgroundColor = UIColor.White, TextColor = UIColor.Black};
			Input.ReturnKeyType = UIReturnKeyType.Send;
			Input.ShouldReturn = delegate{
				Parent.SendText(Input.Text.ToString());
				Input.Text = "";
				return true;
			};
			Output = new UITextView(){BackgroundColor = UIColor.Black, TextColor = UIColor.Green,Editable = false};
			send = UIButton.FromType(UIButtonType.RoundedRect);
			send.SetTitle("Send", UIControlState.Normal);
			send.TouchDown += delegate {
				Parent.SendText(Input.Text.ToString());
				Input.Text = "";
			};
			this.AddSubview(Input);
			this.AddSubview(Output);
			this.AddSubview(send);
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			float padding = 5f;
			float buttonWidth = 50f;
			var frame = new RectangleF(padding,padding,this.Bounds.Width - (padding *3) - buttonWidth,50);
			Input.Frame = frame;
			var buttonLeft = frame.Right + padding;
			frame = new RectangleF(buttonLeft,padding,buttonWidth,50);
			send.Frame = frame;

			var outputTop = frame.Bottom + padding;
			frame = new RectangleF(padding,outputTop,this.Bounds.Width - (padding * 2),this.Bounds.Height - (outputTop + padding) - KeyBoardHeight);
			Output.Frame = frame;
			
			Output.ScrollRangeToVisible(new NSRange(Output.Text.Length - 1,1));

		}

		public void SetOutputText(string text)
		{
			Output.Text = text;
			Output.ScrollRangeToVisible(new NSRange(text.Length - 1,1));
		}
	}
	
	public class RedParkDelegate : RscMgrDelegate{
		MainViewController Manager;
		public RedParkDelegate(MainViewController manager)
		{
			Manager = manager;
		}
		#region implemented abstract members of RscMgrDelegate

		public override void CableConnected (string protocol)
		{
			Manager.Connected(protocol);
		}

		public override  void CableDisconnected ()
		{
			Manager.CableDisconnected();
		}

		public override void PortStatusChanged ()
		{
			Manager.PortStatusChanged();
		}

		public override void ReadBytesAvailable (int len)
		{
			Manager.ReadBytesAvailable(len);
		}

#endregion


	}

}

