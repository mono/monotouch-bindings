using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace VENCalculatorInputViewBinding
{

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface VENCalculatorInputViewDelegate {

		[Export ("calculatorInputView:didTapKey:")]
		void DidTapKey (VENCalculatorInputView inputView, string key);

		[Export ("calculatorInputViewDidTapBackspace:")]
		void  DidTapBackspace(VENCalculatorInputView calculatorInputView);
	}

	[BaseType (typeof (UIView))]
	public partial interface VENCalculatorInputView 
	{

		[Export ("delegate", ArgumentSemantic.Assign)]
		VENCalculatorInputViewDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		 NSObject WeakDelegate { get; set; }

		[Export ("numberButtonCollection", ArgumentSemantic.Retain)]
		NSArray NumberButtons { get; set; }

		[Export ("operationButtonCollection", ArgumentSemantic.Retain)]
		NSArray OperationButtons { get; set; }

		[Export ("buttonTitleColor", ArgumentSemantic.Retain)]
		UIColor ButtonTitleColor { get; set; }

		[Export ("buttonTitleFont", ArgumentSemantic.Retain)]
		UIFont ButtonTitleFont { get; set; }

		[Export ("buttonHighlightedColor", ArgumentSemantic.Retain)]
		UIColor ButtonHighlightedColor { get; set; }

		[Export ("numberButtonBackgroundColor", ArgumentSemantic.Retain)]
		UIColor NumberButtonBackgroundColor { get; set; }

		[Export ("numberButtonBorderColor", ArgumentSemantic.Retain)]
		UIColor NumberButtonBorderColor { get; set; }

		[Export ("operationButtonBackgroundColor", ArgumentSemantic.Retain)]
		UIColor OperationButtonBackgroundColor { get; set; }

		[Export ("operationButtonBorderColor", ArgumentSemantic.Retain)]
		UIColor OperationButtonBorderColor { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface VENMoneyCalculator {

		[Static, Export ("evaluateExpression:")]
		string EvaluateExpression (string expression);
	}
		
	[BaseType (typeof (UITextField))]
	public partial interface VENCalculatorInputTextField : VENCalculatorInputViewDelegate
	{
		[Export ("inputView")]
		VENCalculatorInputView CalculatorInputView { get;}
	}
}

