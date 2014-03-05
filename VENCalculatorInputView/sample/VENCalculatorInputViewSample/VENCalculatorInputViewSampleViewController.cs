using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using VENCalculatorInputViewBinding;
using System.Diagnostics;

namespace VENCalculatorInputViewSample
{
	public partial class VENCalculatorInputViewSampleViewController : UIViewController
	{

		/// <summary>
		/// Gets the calculate accessory view.
		/// </summary>
		/// <value>The calculate accessory view.</value>
		public UIView CalcAccessoryView
		{
			get 
			{
				var aToolbar = new UIToolbar (new RectangleF(0,0,320,44));

				var aSpace = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

				var aCalc = new UIBarButtonItem ("Calculate", UIBarButtonItemStyle.Bordered, (obj,e) => 
				{
					this.View.EndEditing(true);
				});

				aToolbar.Items = new UIBarButtonItem[]{ aSpace, aCalc };


				return aToolbar;

			}
		}

		#region Constructors
		public VENCalculatorInputViewSampleViewController ()
			: base ("VENCalculatorInputViewSampleViewController_iPhone", null)
		{



		}
		#endregion

		#region overrides
		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//add a toolbar to the top of the keyboard
			calcField.InputAccessoryView = CalcAccessoryView;

			/*
			 * 
			 * Set the delegate to intercept the taps on the keybaord
			 * 
				calcField.CalculatorInputView.WeakDelegate = this;
			*
			*
			*/



		}

		#endregion

		#region Weak Delegate Functions
		[Export ("calculatorInputView:didTapKey:")]
		public void DidTapKey (VENCalculatorInputView inputView, string key)
		{
			Debug.WriteLine (key);
		}

		[Export ("calculatorInputViewDidTapBackspace:")]
		public void DidTapBackspace (VENCalculatorInputView calculatorInputView)
		{
			Debug.WriteLine (calculatorInputView.ToString());
		}

		#endregion
	}

	/// <summary>
	/// Calculate delegate class
	/// </summary>
	public class CalcDelegate : VENCalculatorInputViewDelegate
	{
		#region Delegate Overrides
		public override void DidTapKey (VENCalculatorInputView inputView, string key)
		{
			Debug.WriteLine (key);
		}

		public override void DidTapBackspace (VENCalculatorInputView calculatorInputView)
		{
			Debug.WriteLine (calculatorInputView.ToString());
		}

		#endregion
	}
}

