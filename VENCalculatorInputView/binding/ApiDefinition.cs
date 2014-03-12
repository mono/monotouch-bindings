using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace VENCalculatorInputViewBinding
{
	interface IVENCalculatorInputViewDelegate { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface VENCalculatorInputViewDelegate {

		[Export ("calculatorInputView:didTapKey:")]
		void DidTapKey (VENCalculatorInputView inputView, string key);

		[Export ("calculatorInputViewDidTapBackspace:")]
		void  DidTapBackspace(VENCalculatorInputView calculatorInputView);
	}

	[BaseType (typeof (UIView))]
	interface VENCalculatorInputView 
	{

		[Export ("delegate", ArgumentSemantic.Assign)]
		IVENCalculatorInputViewDelegate Delegate { get; set; }

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
	interface VENMoneyCalculator {

		[Static, Export ("evaluateExpression:")]
		string EvaluateExpression (string expression);
	}
		
	[BaseType (typeof (UITextField))]
	interface VENCalculatorInputTextField : VENCalculatorInputViewDelegate
	{
		[Export ("inputView")]
		VENCalculatorInputView CalculatorInputView { get;}
	}
}

