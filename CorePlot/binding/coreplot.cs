//
// ApiDefinition.cs: API binding to the CorePlot library
//
// Authors:
//   Miguel de Icaza
//   Alex Soto
//

using System;
using System.Drawing;
using MonoMac;
using MonoMac.Foundation;
using MonoMac.CoreGraphics;
using MonoMac.ObjCRuntime;
using MonoMac.CoreAnimation;

#if MONOTOUCH
using MonoTouch.UIKit;
using CPTNativeImage = MonoTouch.UIKit.UIImage;
using CPTNativeEvent = MonoTouch.UIKit.UIEvent;
#else
using MonoMac.AppKit;
using CPTNativeImage = MonoMac.AppKit.NSImage;
using CPTNativeEvent = MonoMac.AppKit.NSEvent;
#endif

namespace CorePlot
{
	interface ICPTAnimationDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTAnimationDelegate 
	{
		[Export ("animationDidStart:")]
		void AnimationDidStart (CPTAnimationOperation operation);

		[Export ("animationDidFinish:")]
		void AnimationDidFinish (CPTAnimationOperation operation);

		[Export ("animationCancelled:")]
		void AnimationCancelled (CPTAnimationOperation operation);

		[Export ("animationWillUpdate:")]
		void AnimationWillUpdate (CPTAnimationOperation operation);

		[Export ("animationDidUpdate:")]
		void AnimationDidUpdate (CPTAnimationOperation operation);
	}

	[BaseType (typeof (NSObject))]
	interface CPTAnimation 
	{	
		[Export ("timeOffset", ArgumentSemantic.Assign)]
		float TimeOffset { get; }

		[Export ("defaultAnimationCurve", ArgumentSemantic.Assign)]
		CPTAnimationCurve DefaultAnimationCurve { get; set; }

		[Static]
		[Export ("sharedInstance")]
		CPTAnimation GetSharedInstance { get; }

		[Static]
		[Export ("animate:property:period:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, CPTAnimationPeriod period, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Export ("addAnimationOperation:")]
		CPTAnimationOperation AddAnimationOperation (CPTAnimationOperation animationOperation);

		[Export ("removeAnimationOperation:")]
		void RemoveAnimationOperation (CPTAnimationOperation animationOperation);

		[Export ("removeAllAnimationOperations")]
		void RemoveAllAnimationOperations ();
	}

	[BaseType (typeof (NSObject))]
	interface CPTAnimationOperation 
	{
		[Export ("period", ArgumentSemantic.Retain)]
		CPTAnimationPeriod Period { get; set; }

		[Export ("animationCurve", ArgumentSemantic.Assign)]
		CPTAnimationCurve AnimationCurve { get; set; }

		[Export ("boundObject", ArgumentSemantic.Retain)]
		NSObject BoundObject { get; set; }

		[Export ("boundGetter")]
		Selector BoundGetter { get; }

		[Export ("boundSetter")]
		Selector BoundSetter { get; }

		[Wrap ("WeakDelegate")]
		CPTAnimationDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface CPTAnimationPeriod 
	{
		[Export ("startValue", ArgumentSemantic.Copy)]
		NSValue StartValue { get; set; }

		[Export ("endValue", ArgumentSemantic.Copy)]
		NSValue EndValue { get; set; }

		[Export ("duration")]
		float Duration { get; set; }

		[Export ("delay")]
		float Delay { get; set; }

		[Export ("startOffset")]
		float StartOffset { get; }

		[Static]
		[Export ("periodWithStart:end:duration:withDelay:")]
		CPTAnimationPeriod FromStart (float start, float end, float duration, float delay);

		[Static]
		[Export ("periodWithStartPoint:endPoint:duration:withDelay:")]
		CPTAnimationPeriod FromStartPoint (PointF startPoint, PointF endPoint, float duration, float delay);

		[Static]
		[Export ("periodWithStartSize:endSize:duration:withDelay:")]
		CPTAnimationPeriod FromStartSize (SizeF startSize, SizeF endSize, float duration, float delay);

		[Static]
		[Export ("periodWithStartRect:endRect:duration:withDelay:")]
		CPTAnimationPeriod FromStartSize (RectangleF startRect, RectangleF endRect, float duration, float delay);

		[Static]
		[Export ("periodWithStartDecimal:endDecimal:duration:withDelay:")]
		CPTAnimationPeriod FromStartDecimal (NSDecimal startDecimal, NSDecimal endDecimal, float duration, float delay);

		[Static]
		[Export ("periodWithStartPlotRange:endPlotRange:duration:withDelay:")]
		CPTAnimationPeriod FromStartPlotRange (CPTPlotRange startPlotRangle, CPTPlotRange endPlotRangle, float duration, float delay);

		[Export ("initWithStart:end:duration:withDelay:")]
		IntPtr Constructor (float start, float end, float duration, float delay);

		[Export ("initWithStartPoint:endPoint:duration:withDelay:")]
		IntPtr Constructor (PointF startPoint, PointF endPoint, float duration, float delay);

		[Export ("initWithStartSize:endSize:duration:withDelay:")]
		IntPtr Constructor (SizeF startSize, SizeF endSize, float duration, float delay);

		[Export ("initWithStartRect:endRect:duration:withDelay:")]
		IntPtr Constructor (RectangleF startRect, RectangleF endRect, float duration, float delay);

		[Export ("initWithStartDecimal:endDecimal:duration:withDelay:")]
		IntPtr Constructor (NSDecimal startDecimal, NSDecimal endDecimal, float duration, float delay);

		[Export ("initWithStartPlotRange:endPlotRange:duration:withDelay:")]
		IntPtr Constructor (CPTPlotRange startPlotRangle, CPTPlotRange endPlotRangle, float duration, float delay);

		[Export ("tweenedValueForProgress:")]
		NSValue TweenedValue (float progress);

		[Static]
		[Export ("animate:property:from:to:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, float from, float to, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:from:to:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, float from, float to, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:from:to:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, float from, float to, float duration);

		[Static]
		[Export ("animate:property:fromPoint:toPoint:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, PointF fromPoint, PointF toPoint, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromPoint:toPoint:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, PointF fromPoint, PointF toPoint, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromPoint:toPoint:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, PointF fromPoint, PointF toPoint, float duration);

		[Static]
		[Export ("animate:property:fromSize:toSize:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, SizeF fromSize, SizeF toSize, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromSize:toSize:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, SizeF fromSize, SizeF toSize, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromSize:toSize:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, SizeF fromSize, SizeF toSize, float duration);

		[Static]
		[Export ("animate:property:fromRect:toRect:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, RectangleF fromRect, RectangleF toRect, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromRect:toRect:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, RectangleF fromRect, RectangleF toRect, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromRect:toRect:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, RectangleF fromRect, RectangleF toRect, float duration);

		[Static]
		[Export ("animate:property:fromDecimal:toDecimal:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, NSDecimal fromDecimal, NSDecimal toDecimal, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromDecimal:toDecimal:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, NSDecimal fromDecimal, NSDecimal toDecimal, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromDecimal:toDecimal:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, NSDecimal fromDecimal, NSDecimal toDecimal, float duration);

		[Static]
		[Export ("animate:property:fromPlotRange:toPlotRange:duration:withDelay:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, CPTPlotRange fromPlotRange, CPTPlotRange toPlotRange, float duration, float delay, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromPlotRange:toPlotRange:duration:animationCurve:delegate:")]
		CPTAnimationOperation Animate (NSObject obj, string property, CPTPlotRange fromPlotRange, CPTPlotRange toPlotRange, float duration, CPTAnimationCurve animationCurve, ICPTAnimationDelegate animationDelegate);

		[Static]
		[Export ("animate:property:fromPlotRange:toPlotRange:duration:")]
		CPTAnimationOperation Animate (NSObject obj, string property, CPTPlotRange fromPlotRange, CPTPlotRange toPlotRange, float duration);
	}

	[BaseType (typeof (NSObject))]
	interface CPTAnnotation 
	{
		[Export ("contentLayer", ArgumentSemantic.Retain)]
		CPTLayer ContentLayer { get; set; }

		[Export ("annotationHostLayer", ArgumentSemantic.Assign)]
		CPTAnnotationHostLayer AnnotationHostLayer { get; set; }

		[Export ("contentAnchorPoint", ArgumentSemantic.Assign)]
		PointF ContentAnchorPoint { get; set; }

		[Export ("displacement", ArgumentSemantic.Assign)]
		PointF Displacement { get; set; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		PointF Rotation { get; set; }

		// CPTAnnotation (AbstractMethods) Category

		[Export ("positionContentLayer")]
		void PositionContentLayer ();
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAnnotationHostLayer 
	{
		[Export ("annotations", ArgumentSemantic.Retain)]
		CPTAnnotation [] Annotations { get; }

		[Export ("addAnnotation:")] [PostGet ("Annotations")]
		void AddAnnotation (CPTAnnotation annotation);

		[Export ("removeAnnotation:")] [PostGet ("Annotations")]
		void RemoveAnnotation (CPTAnnotation annotation);

		[Export ("removeAllAnnotations")]
		void RemoveAllAnnotations ();
	}

	interface ICPTAxisDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTAxisDelegate 
	{
		[Export ("axisShouldRelabel:")]
		bool ShouldRelabel (CPTAxis axis);

		[Export ("axisDidRelabel:")]
		void DidRelabel (CPTAxis axis);

		[Export ("axis:shouldUpdateAxisLabelsAtLocations:")]
		bool ShouldUpdateAxisLabelsAtLocations (CPTAxis axis, NSSet locations);

		[Export ("axis:shouldUpdateMinorAxisLabelsAtLocations:")]
		bool ShouldUpdateMinorAxisLabelsAtLocations (CPTAxis axis, NSSet locations);

		[Export ("axis:labelWasSelected:")]
		void LabelWasSelected (CPTAxis axis, CPTAxisLabel label);

		[Export ("axis:labelWasSelected:withEvent:")]
		void LabelWasSelected (CPTAxis axis, CPTAxisLabel label, CPTNativeEvent nativeEvent);

		[Export ("axis:minorTickLabelWasSelected:")]
		void MinorTickLabelWasSelected (CPTAxis axis, CPTAxisLabel label);

		[Export ("axis:minorTickLabelWasSelected:withEvent:")]
		void MinorTickLabelWasSelected (CPTAxis axis, CPTAxisLabel label, CPTNativeEvent nativeEvent);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAxis 
	{
		[Wrap ("WeakDelegate")] [New]
		CPTAxisDelegate Delegate { get; set; }

		// Axis

		[Export ("axisLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle AxisLineStyle { get; set; }

		[Export ("coordinate", ArgumentSemantic.Assign)]
		CPTCoordinate Coordinate { get; set; }

		[Export ("labelingOrigin", ArgumentSemantic.Assign)]
		NSDecimal LabelingOrigin { get; set; }

		[Export ("tickDirection", ArgumentSemantic.Assign)]
		CPTSign TickDirection { get; set; }

		[Export ("visibleRange", ArgumentSemantic.Copy)]
		CPTPlotRange VisibleRange { get; set; }

		[Export ("visibleAxisRange", ArgumentSemantic.Copy)]
		CPTPlotRange VisibleAxisRange { get; set; }

		[Export ("axisLineCapMin", ArgumentSemantic.Copy)]
		CPTLineCap AxisLineCapMin { get; set; }

		[Export ("axisLineCapMax", ArgumentSemantic.Copy)]
		CPTLineCap AxisLineCapMax { get; set; }

		// Title

		[Export ("titleTextStyle", ArgumentSemantic.Copy)]
		CPTTextStyle TitleTextStyle { get; set; }

		[Export ("axisTitle", ArgumentSemantic.Retain)]
		CPTAxisTitle AxisTitle { get; set; }

		[Export ("titleOffset", ArgumentSemantic.Assign)]
		float TitleOffset { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("titleRotation", ArgumentSemantic.Assign)]
		float TitleRotation { get; set; }

		[Export ("titleLocation", ArgumentSemantic.Assign)]
		NSDecimal TitleLocation { get; set; }

		[Export ("defaultTitleLocation", ArgumentSemantic.Assign)]
		NSDecimal DefaultTitleLocation { get; set; }

		// Labels

		[Export ("labelingPolicy", ArgumentSemantic.Assign)]
		CPTAxisLabelingPolicy LabelingPolicy { get; set; }

		[Export ("labelOffset", ArgumentSemantic.Assign)]
		float LabelOffset { get; set; }

		[Export ("minorTickLabelOffset", ArgumentSemantic.Assign)]
		float MinorTickLabelOffset { get; set; }

		[Export ("labelRotation", ArgumentSemantic.Assign)]
		float LabelRotation { get; set; }

		[Export ("minorTickLabelRotation", ArgumentSemantic.Assign)]
		float MinorTickLabelRotation { get; set; }

		[Export ("labelAlignment", ArgumentSemantic.Assign)]
		CPTAlignment LabelAlignment { get; set; }

		[Export ("minorTickLabelAlignment", ArgumentSemantic.Assign)]
		CPTAlignment MinorTickLabelAlignment { get; set; }

		[Export ("labelTextStyle", ArgumentSemantic.Copy)]
		CPTTextStyle LabelTextStyle { get; set; }

		[Export ("minorTickLabelTextStyle", ArgumentSemantic.Copy)]
		CPTTextStyle MinorTickLabelTextStyle { get; set; }

		[Export ("tickLabelDirection", ArgumentSemantic.Assign)]
		CPTSign TickLabelDirection { get; set; }

		[Export ("minorTickLabelDirection", ArgumentSemantic.Assign)]
		CPTSign MinorTickLabelDirection { get; set; }

		[Export ("labelFormatter", ArgumentSemantic.Retain)]
		NSFormatter LabelFormatter { get; set; }

		[Export ("minorTickLabelFormatter", ArgumentSemantic.Retain)]
		NSFormatter MinorTickLabelFormatter { get; set; }

		[Export ("axisLabels", ArgumentSemantic.Retain)]
		NSSet AxisLabels { get; set; }

		[Export ("minorTickAxisLabels", ArgumentSemantic.Retain)]
		NSSet MinorTickAxisLabels { get; set; }

		[Export ("needsRelabel", ArgumentSemantic.Assign)]
		bool NeedsRelabel { get; set; }

		[Export ("labelExclusionRanges", ArgumentSemantic.Retain)]
		NSObject [] LabelExclusionRanges { get; set; }

		[Export ("labelShadow", ArgumentSemantic.Retain)]
		CPTShadow LabelShadow { get; set; }

		[Export ("minorTickLabelShadow", ArgumentSemantic.Retain)]
		CPTShadow MinorTickLabelShadow { get; set; }

		// Major Ticks

		[Export ("majorIntervalLength", ArgumentSemantic.Assign)]
		NSDecimal MajorIntervalLength { get; set; }

		[Export ("majorTickLength", ArgumentSemantic.Assign)]
		float MajorTickLength { get; set; }

		[Export ("majorTickLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle MajorTickLineStyle { get; set; }

		[Export ("majorTickLocations", ArgumentSemantic.Retain)]
		NSSet MajorTickLocations { get; set; }

		[Export ("preferredNumberOfMajorTicks", ArgumentSemantic.Assign)]
		uint PreferredNumberOfMajorTicks { get; set; }

		// Minor Ticks

		[Export ("minorTicksPerInterval", ArgumentSemantic.Assign)]
		uint MinorTicksPerInterval { get; set; }

		[Export ("minorTickLength", ArgumentSemantic.Assign)]
		float MinorTickLength { get; set; }

		[Export ("minorTickLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle MinorTickLineStyle { get; set; }

		[Export ("minorTickLocations", ArgumentSemantic.Retain)]
		NSSet MinorTickLocations { get; set; }

		// Grid Lines

		[Export ("majorGridLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle MajorGridLineStyle { get; set; }

		[Export ("minorGridLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle MinorGridLineStyle { get; set; }

		[Export ("gridLinesRange", ArgumentSemantic.Copy)]
		CPTPlotRange GridLinesRange { get; set; }

		// Background Bands

		[Export ("alternatingBandFills", ArgumentSemantic.Copy)]
		NSObject [] AlternatingBandFills { get; set; }

		[Export ("backgroundLimitBands", ArgumentSemantic.Retain)]
		NSObject [] BackgroundLimitBands { get; set; }

		// Plot Space

		[Export ("plotSpace", ArgumentSemantic.Retain)]
		CPTPlotSpace PlotSpace { get; set; }

		// Name Layers

		[Export ("separateLayers", ArgumentSemantic.Assign)]
		bool SeparateLayers { get; set; }

		[Export ("plotArea", ArgumentSemantic.Assign)]
		CPTPlotArea PlotArea { get; set; }

		[Export ("minorGridLines", ArgumentSemantic.Assign)]
		CPTGridLines MinorGridLines { get; }

		[Export ("majorGridLines", ArgumentSemantic.Assign)]
		CPTGridLines MajorGridLines { get; }

		[Export ("axisSet", ArgumentSemantic.Retain)]
		CPTAxisSet AxisSet { get; }

		// Title

		[Export ("updateAxisTitle")]
		void UpdateAxisTitle ();

		// Labels

		[Export ("relabel")]
		void Relabel ();

		[Export ("setNeedsRelabel")]
		void SetNeedsRelabel ();

		[Export ("updateMajorTickLabels")]
		void UpdateMajorTickLabels ();

		[Export ("updateMinorTickLabels")]
		void UpdateMinorTickLabels ();

		// Ticks

		[Export ("filteredMajorTickLocations:")]
		NSSet FilteredMajorTickLocations (NSSet allLocations);

		[Export ("filteredMinorTickLocations:")]
		NSSet FilteredMinorTickLocations (NSSet allLocations);

		// Background Bands

		[Export ("addBackgroundLimitBand:")]
		void AddBackgroundLimitBand (CPTLimitBand limitBand);

		[Export ("removeBackgroundLimitBand:")]
		void RemoveBackgroundLimitBand (CPTLimitBand limitBand);

		// CPTAxis(AbstractMethods) Category

		[Export ("viewPointForCoordinateDecimalNumber:")]
		PointF ViewPointForCoordinateDecimalNumber (NSDecimal coordinateDecimalNumber);

		[Export ("drawGridLinesInContext:isMajor:")]
		void DrawGridLinesInContext (CGContext context, bool isMajor);

		[Export ("drawBackgroundBandsInContext:")]
		void DrawBackgroundBandsInContext (CGContext  context);

		[Export ("drawBackgroundLimitsInContext:")]
		void DrawBackgroundLimitsInContext (CGContext context);
	}

	[BaseType (typeof (NSObject))]
	interface CPTAxisLabel 
	{
		[Export ("contentLayer", ArgumentSemantic.Retain)]
		CPTLayer ContentLayer { get; set; }

		[Export ("offset", ArgumentSemantic.Assign)]
		float Offset { get; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		float Rotation { get; set; }

		[Export ("alignment", ArgumentSemantic.Assign)]
		CPTAlignment Alignment { get; set; }

		[Export ("tickLocation", ArgumentSemantic.Assign)]
		NSDecimal TickLocation { get; set; }

		[Export ("initWithText:textStyle:")]
		IntPtr Constructor (string newText, CPTTextStyle style);

		[Export ("initWithContentLayer:")]
		IntPtr Constructor (CPTLayer layer);

		[Export ("positionRelativeToViewPoint:forCoordinate:inDirection:")]
		void PositionRelativeToViewPoint (PointF viewPoint, CPTCoordinate coordinate, CPTSign direction);

		[Export ("positionBetweenViewPoint:andViewPoint:forCoordinate:inDirection:")]
		void PositionBetweenViewPoint (PointF firstPoint, PointF secondPoint, CPTCoordinate coordinate, CPTSign direction);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAxisSet 
	{
		[Export ("axes", ArgumentSemantic.Retain)]
		CPTAxis [] Axes { get; set; }

		[Export ("borderLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle BorderLineStyle { get; set; }

		[Export ("relabelAxes")]
		void RelabelAxes ();

		[Export ("axisForCoordinate:atIndex:")]
		CPTAxis AxisForCoordinate (CPTCoordinate coordinate, uint index);
	}

	[BaseType (typeof (CPTAxisLabel))]
	interface CPTAxisTitle 
	{

	}

	interface ICPTBarPlotDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTBarPlotDataSource : CPTPlotDataSource 
	{
		[Export ("barFillsForBarPlot:recordIndexRange:")]
		CPTFill [] GetBarFills (CPTBarPlot barPlot, NSRange recordIndexRange);

		[Export ("barFillForBarPlot:recordIndex:")]
		CPTFill GetBarFill (CPTBarPlot barPlot, uint recordIndex);

		[Export ("barLineStylesForBarPlot:recordIndexRange:")]
		CPTLineStyle [] GetBarLineStyles (CPTBarPlot barPlot, NSRange recordIndexRange);

		[Export ("barLineStyleForBarPlot:recordIndex:")]
		CPTLineStyle GetBarLineStyle (CPTBarPlot barPlot, uint recordIndex);

		[Export ("legendTitleForBarPlot:recordIndex:")]
		string GetLegendTitle (CPTBarPlot barPlot, uint recordIndex);

		[Export ("attributedLegendTitleForBarPlot:recordIndex:")]
		NSAttributedString GetAttributedLegendTitle (CPTBarPlot barPlot, uint recordIndex);
	}

	interface ICPTBarPlotDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTBarPlotDelegate : CPTPlotDelegate 
	{
		[Export ("barPlot:barWasSelectedAtRecordIndex:")]
		void BarSelected (CPTBarPlot barPlot, uint recordIndex);

		[Export ("barPlot:barWasSelectedAtRecordIndex:withEvent:")]
		void BarSelected (CPTBarPlot barPlot, uint recordIndex, CPTNativeEvent nativeEvent);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTBarPlot 
	{
		[Wrap ("WeakDataSource")][New]
		CPTBarPlotDataSource DataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTBarPlotDelegate Delegate { get; set; }

		[Export ("barWidthsAreInViewCoordinates", ArgumentSemantic.Assign)]
		bool BarWidthsAreInViewCoordinates { get; set; }

		[Export ("barWidth", ArgumentSemantic.Assign)]
		NSDecimal BarWidth { get; set; }

		[Export ("barWidthScale", ArgumentSemantic.Assign)]
		float BarWidthScale { get; set; }

		[Export ("barOffset", ArgumentSemantic.Assign)]
		NSDecimal BarOffset { get; set; }

		[Export ("barOffsetScale", ArgumentSemantic.Assign)]
		float BarOffsetScale { get; set; }

		[Export ("barCornerRadius", ArgumentSemantic.Assign)]
		float BarCornerRadius { get; set; }

		[Export ("barBaseCornerRadius", ArgumentSemantic.Assign)]
		float BarBaseCornerRadius { get; set; }

		[Export ("barsAreHorizontal", ArgumentSemantic.Assign)]
		bool BarsAreHorizontal { get; set; }

		[Export ("baseValue", ArgumentSemantic.Assign)]
		NSDecimal BaseValue { get; set; }

		[Export ("barBasesVary", ArgumentSemantic.Assign)]
		bool BarBasesVary { get; set; }

		[Export ("plotRange", ArgumentSemantic.Copy)]
		CPTPlotRange PlotRange { get; set; }

		[Export ("lineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle LineStyle { get; set; }

		[Export ("fill", ArgumentSemantic.Copy)]
		CPTFill Fill { get; set; }

		[Static]
		[Export ("tubularBarPlotWithColor:horizontalBars:")]
		CPTBarPlot TubularBarPlot (CPTColor color, bool horizontal);

		[Export ("plotRangeEnclosingBars")]
		CPTPlotRange PlotRangeEnclosingBars ();
	}

	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTBorderedLayer 
	{
		[Export ("borderLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle BorderLineStyle { get; set; }

		[Export ("fill", ArgumentSemantic.Copy)]
		CPTFill Fill { get; set; }

		[Export ("inLayout")]
		bool InLayout { get; set; }

		[Export ("renderBorderedLayerAsVectorInContext:")]
		void RenderBorderedLayerAsVectorInContext (CGContext context);
	}

	[BaseType (typeof (NSNumberFormatter))]
	interface CPTCalendarFormatter 
	{
		[Export ("dateFormatter", ArgumentSemantic.Retain)]
		NSDateFormatter DateFormatter { get; set; }

		[Export ("referenceDate", ArgumentSemantic.Copy)]
		NSDate ReferenceDate { get; set; }

		[Export ("referenceCalendar", ArgumentSemantic.Copy)]
		NSCalendar ReferenceCalendar { get; set; }

		[Export ("referenceCalendarUnit", ArgumentSemantic.Assign)]
		NSCalendarUnit ReferenceCalendarUnit { get; set; }

		[Export ("initWithDateFormatter:")]
		IntPtr Constructor (NSDateFormatter aDateFormatter);
	}

	[BaseType (typeof (NSObject))]
	interface CPTColor 
	{
		[Export ("cgColor", ArgumentSemantic.Assign)]
		CGColor Color { get; }

		[Export ("opaque", ArgumentSemantic.Assign)]
		bool Opaque { [Bind ("isOpaque")] get; }

		[Static]
		[Export ("clearColor")]
		CPTColor ClearColor { get; }

		[Static]
		[Export ("whiteColor")]
		CPTColor WhiteColor { get; }

		[Static]
		[Export ("lightGrayColor")]
		CPTColor LightGrayColor { get; }

		[Static]
		[Export ("grayColor")]
		CPTColor GrayColor { get; }

		[Static]
		[Export ("darkGrayColor")]
		CPTColor DarkGrayColor { get; }

		[Static]
		[Export ("blackColor")]
		CPTColor BlackColor { get; }

		[Static]
		[Export ("redColor")]
		CPTColor RedColor { get; }

		[Static]
		[Export ("greenColor")]
		CPTColor GreenColor { get; }

		[Static]
		[Export ("blueColor")]
		CPTColor BlueColor { get; }

		[Static]
		[Export ("cyanColor")]
		CPTColor CyanColor { get; }

		[Static]
		[Export ("yellowColor")]
		CPTColor YellowColor { get; }

		[Static]
		[Export ("magentaColor")]
		CPTColor MagentaColor { get; }

		[Static]
		[Export ("orangeColor")]
		CPTColor OrangeColor { get; }

		[Static]
		[Export ("purpleColor")]
		CPTColor PurpleColor { get; }

		[Static]
		[Export ("brownColor")]
		CPTColor BrownColor { get; }

		[Static]
		[Export ("colorWithCGColor:")]
		CPTColor FromCGColor (CGColor newCGColor);

		[Static]
		[Export ("colorWithComponentRed:green:blue:alpha:")]
		CPTColor FromRgba (float red, float green, float blue, float alpha);

		[Static]
		[Export ("colorWithGenericGray:")]
		CPTColor FromGenericGray (float gray);

		[Export ("initWithCGColor:")]
		IntPtr Constructor (CGColor cgColor);

		[Export ("initWithComponentRed:green:blue:alpha:")]
		IntPtr Constructor (float red, float green, float blue, float alpha);

		[Export ("colorWithAlphaComponent:")]
		CPTColor ColorWithAlphaComponent (float alpha);
	}

	[BaseType (typeof (NSObject))]
	interface CPTColorSpace 
	{
		[Export ("cgColorSpace")]
		CGColorSpace ColorSpace { get; }

		[Static]
		[Export ("genericRGBSpace")]
		CPTColorSpace GenericRGBSpace { get; }

		[Export ("initWithCGColorSpace:")]
		IntPtr Constructor (CGColorSpace colorSpace);
	}

	[BaseType (typeof (NSObject))]
	interface CPTConstraints 
	{
		[Static]
		[Export ("constraintWithLowerOffset:")]
		CPTConstraints FromLowerOffset (float newOffset);

		[Static]
		[Export ("constraintWithUpperOffset:")]
		CPTConstraints FromUpperOffset (float newOffset);

		[Static]
		[Export ("constraintWithRelativeOffset:")]
		CPTConstraints FromRelativeOffset (float newOffset);

		[Export ("isEqualToConstraint:")]
		bool IsEqualToConstraint (CPTConstraints otherConstraint);

		[Export ("positionForLowerBound:upperBound:")]
		float PositionForLowerBound (float lowerBound, float upperBound);
	}

	[BaseType (typeof (NSObject))]
	interface CPTFill 
	{
		[Static]
		[Export ("fillWithColor:")]
		CPTFill FromColor (CPTColor aColor);

		[Static]
		[Export ("fillWithGradient:")]
		CPTFill FromGradient (CPTGradient aGradient);

		[Static]
		[Export ("fillWithImage:")]
		CPTFill FromImage (CPTImage anImage);

		[Export ("initWithColor:")]
		IntPtr Constructor (CPTColor aColor);

		[Export ("initWithGradient:")]
		IntPtr Constructor (CPTGradient aGradient);

		[Export ("initWithImage:")]
		IntPtr Constructor (CPTImage anImage);

		[Export ("opaque", ArgumentSemantic.Assign)]
		bool Opaque { [Bind ("isOpaque")] get; }

		[Export ("fillRect:inContext:")]
		void FillRect (RectangleF theRect, CGContext inContext);

		[Export ("fillPathInContext:")]
		void FillPath (CGContext inContext);
	}

	delegate double CPTDataSourceFunction (double param);

	[BaseType (typeof (NSObject))]
	interface CPTFunctionDataSource 
	{
		[Export ("dataPlot", ArgumentSemantic.Assign)]
		CPTPlot DataPlot { get; }

		[Export ("resolution")]
		float Resolution { get; set; }

		[Export ("dataRange", ArgumentSemantic.Retain)]
		CPTPlotRange DataRange { get; }

#if MONOTOUCH 
		[Static]
		[Export ("dataSourceForPlot:withFunction:")]
		CPTFunctionDataSource FromPlot (CPTPlot plot, [CCallback] CPTDataSourceFunction handler);

		[Export ("initForPlot:withFunction:")]
		IntPtr Constructor (CPTPlot plot, [CCallback] CPTDataSourceFunction handler);
#else
		// TODO: [CCallback] is not implemented yet on Mac, remove compiler if when it is available
#endif
	}

	[BaseType (typeof (NSObject))]
	interface CPTGradient 
	{
		[Export ("opaque", ArgumentSemantic.Assign)]
		bool Opaque { [Bind ("isOpaque")] get; }

		[Export ("blendingMode", ArgumentSemantic.Assign)]
		CPTGradientBlendingMode BlendingMode { get; }

		[Export ("gradientType", ArgumentSemantic.Assign)]
		CPTGradientType GradientType { get; set; }

		[Export ("angle", ArgumentSemantic.Assign)]
		float Angle { get; set; }

		[Export ("startAnchor", ArgumentSemantic.Assign)]
		PointF StartAnchor { get; set; }

		[Export ("endAnchor", ArgumentSemantic.Assign)]
		PointF EndAnchor { get; set; }

		[Static]
		[Export ("gradientWithBeginningColor:endingColor:")]
		CPTGradient Create (CPTColor beginningColor, CPTColor endingColor);

		[Static]
		[Export ("gradientWithBeginningColor:endingColor:beginningPosition:endingPosition:")]
		CPTGradient Create (CPTColor beginningColor, CPTColor endingColor, float beginningPosition, float endingPosition);

		[Static]
		[Export ("aquaSelectedGradient")]
		CPTGradient AquaSelectedGradient { get; }

		[Static]
		[Export ("aquaNormalGradient")]
		CPTGradient AquaNormalGradient { get; }

		[Static]
		[Export ("aquaPressedGradient")]
		CPTGradient AquaPressedGradient { get; }

		[Static]
		[Export ("unifiedSelectedGradient")]
		CPTGradient UnifiedSelectedGradient { get; }

		[Static]
		[Export ("unifiedNormalGradient")]
		CPTGradient UnifiedNormalGradient { get; }

		[Static]
		[Export ("unifiedPressedGradient")]
		CPTGradient UnifiedPressedGradient { get; }

		[Static]
		[Export ("unifiedDarkGradient")]
		CPTGradient UnifiedDarkGradient { get; }

		[Static]
		[Export ("sourceListSelectedGradient")]
		CPTGradient SourceListSelectedGradient { get; }

		[Static]
		[Export ("sourceListUnselectedGradient")]
		CPTGradient SourceListUnselectedGradient { get; }

		[Static]
		[Export ("rainbowGradient")]
		CPTGradient RainbowGradient { get; }

		[Static]
		[Export ("hydrogenSpectrumGradient")]
		CPTGradient HydrogenSpectrumGradient { get; }

		[Export ("gradientWithAlphaComponent:")]
		CPTGradient GradientWithAlphaComponent (float alpha);

		[Export ("gradientWithBlendingMode:")]
		CPTGradient GradientWithBlendingMode (CPTGradientBlendingMode mode);

		[Export ("addColorStop:atPosition:")]
		CPTGradient AddColorStop (CPTColor color, float position);

		[Export ("removeColorStopAtIndex:")]
		CPTGradient RemoveColorStop (int index);

		[Export ("removeColorStopAtPosition:")]
		CPTGradient RemoveColorStop (float position);

		[Export ("newColorStopAtIndex:")]
		CGColor NewColorStop (int atIndex);

		[Export ("newColorAtPosition:")]
		CGColor NewColorAtPosition (float position);

		[Export ("drawSwatchInRect:inContext:")]
		void DrawSwatch (Rectangle inRectangle, CGContext context);

		[Export ("fillRect:inContext:")]
		void FillRect (RectangleF rectangle, CGContext context);

		[Export ("fillPathInContext:")]
		void FillPath (CGContext inContext);
	}

	#if MONOTOUCH
	[BaseType (typeof (UIView))]
	interface CPTGraphHostingView 
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("hostedGraph", ArgumentSemantic.Retain)]
		CPTGraph HostedGraph { get; set; }

		[Export ("collapsesLayers", ArgumentSemantic.Assign)]
		bool CollapsesLayers { get; set; }

		[Export ("allowPinchScaling", ArgumentSemantic.Assign)]
		bool AllowPinchScaling { get; set; }

		[Export ("printRect")]
		RectangleF PrintRect { get; set; }
	}
	#else
	[BaseType (typeof (NSView))]
	interface CPTGraphHostingView 
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("hostedLayer")]
		CPTLayer HostedLayer { get; set; }

		[Export ("printRect")]
		RectangleF PrintRect { get; set; }
	}
	#endif

	[BaseType (typeof (NSObject))]
	interface CPTImage 
	{
		[Export ("image", ArgumentSemantic.Assign)]
		CGImage Image { get; set; }

		[Export ("scale", ArgumentSemantic.Assign)]
		float Scale { get; set; }

		[Export ("tiled", ArgumentSemantic.Assign)]
		bool Tiled { [Bind ("isTiled")] get; set; }

		[Export ("tileAnchoredToContext", ArgumentSemantic.Assign)]
		bool TileAnchoredToContext { get; set; }

		[Export ("opaque", ArgumentSemantic.Assign)]
		bool Opaque { [Bind ("isOpaque")] get; set; }

		[Static]
		[Export ("imageWithCGImage:scale:")]
		CPTImage FRomCGImage (CGImage anImage, float newScale);

		[Static]
		[Export ("imageWithCGImage:")]
		CPTImage FRomCGImage (CGImage anImage);

		[Static]
		[Export ("imageForPNGFile:")]
		CPTImage FromPngFile (string path);

		[Export ("initWithCGImage:scale:")]
		IntPtr Constructor (CGImage anImage, float newScale);

		[Export ("initWithCGImage:")]
		IntPtr Constructor (CGImage anImage);

		[Export ("initForPNGFile:")]
		IntPtr Constructor (string path);

		[Export ("drawInRect:inContext:")]
		void Draw (RectangleF rect, CGContext context);
	}

	[BaseType (typeof (CALayer))]
	interface CPTLayer : ICPTResponder
	{
#if MONOTOUCH
		[Notification]
		[Field ("CPTLayerBoundsDidChangeNotification", "__Internal")]
		NSString LayerBoundsDidChangeNotification { get; }
#endif
		[Export ("CPTGraph", ArgumentSemantic.Assign)]
		CPTGraph Graph { get; set; }

		[Export ("paddingLeft")]
		float PaddingLeft { get; set; }

		[Export ("paddingTop")]
		float PaddingTop { get; set; }

		[Export ("paddingRight")]
		float PaddingRight { get; set; }

		[Export ("paddingBottom")]
		float PaddingBottom { get; set; }

		[Export ("contentsScale")] [New]
		float ContentsScale { get; set; }

		[Export ("useFastRendering", ArgumentSemantic.Assign)]
		bool UseFastRendering { get; }

		[Export ("shadow", ArgumentSemantic.Copy)]
		CPTShadow Shadow { get; set; }

		[Export ("shadowMargin")]
		SizeF ShadowMargin { get; set; }

		[Export ("masksToBorder", ArgumentSemantic.Assign)]
		bool MasksToBorder { get; set; }

		[Export ("outerBorderPath", ArgumentSemantic.Assign)]
		CGPath OuterBorderPath { get; set; }

		[Export ("innerBorderPath", ArgumentSemantic.Assign)]
		CGPath InnerBorderPath { get; set; }

		[Export ("maskingPath", ArgumentSemantic.Assign)]
		CGPath Maskingpath { get; }

		[Export ("sublayerMaskingPath", ArgumentSemantic.Assign)]
		CGPath SublayerMaskingPath { get; }

		[Export ("identifier", ArgumentSemantic.Copy)]
		NSObject Identifier { get; set; }

		[Export ("sublayersExcludedFromAutomaticLayout")]
		NSSet SublayersExcludedFromAutomaticLayout { get; }

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF newFrame);

		[Export ("renderAsVectorInContext:")]
		void RenderAsVector (CGContext context);

		[Export ("recursivelyRenderInContext:")]
		void RecursivelyRender (CGContext context);

		[Export ("layoutAndRenderInContext:")]
		void LayoutAndRender (CGContext context);

		[Export ("dataForPDFRepresentationOfLayer")]
		NSData GetPDFRepresentationOfLayer ();

		[Export ("applySublayerMaskToContext:forSublayer:withOffset:")]
		void ApplySublayerMask (CGContext toContext, CPTLayer forSublayer, PointF offset);

		[Export ("applyMaskToContext:")]
		void ApplyMaskToContext (CGContext context);

		[Export ("pixelAlign")]
		void PixelAlign ();

		[Export ("sublayerMarginLeft:top:right:bottom:")]
		void SublayerMargin (float left, float top, float right, float bottom);

		[Export ("logLayers")]
		void LogLayers ();
	}

	[BaseType (typeof (CPTAnnotation))]
	interface CPTLayerAnnotation
	{
		[Export ("anchorLayer", ArgumentSemantic.Assign)]
		CPTLayer AnchorLayer { get; }

		[Export ("rectAnchor", ArgumentSemantic.Assign)]
		CPTRectAnchor RectAnchor { get; set; }

		[Export ("initWithAnchorLayer:")]
		IntPtr Constructor (CPTLayer anchorLayer);
	}

	interface ICPTLegendDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTLegendDelegate 
	{
		[Export ("legend:shouldDrawSwatchAtIndex:forPlot:inRect:inContext:")]
		bool ShouldDrawSwatch (CPTLegend legend, uint index, CPTPlot plot, RectangleF rect, CGContext context);

		[Export ("legend:legendEntryForPlot:wasSelectedAtIndex:")]
		void WasSelected (CPTLegend legend, CPTPlot plot, uint SelectedIndex);

		[Export ("legend:legendEntryForPlot:wasSelectedAtIndex:withEvent:")]
		void WasSelected (CPTLegend legend, CPTPlot plot, uint SelectedIndex, CPTNativeEvent nativeEvent);
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTLegend 
	{
		[Wrap ("WeakDelegate")] [New]
		CPTLegendDelegate Delegate { get; set; }

#if MONOTOUCH
		[Notification]
		[Field ("CPTLegendNeedsRedrawForPlotNotification", "__Internal")]
		NSString LegendNeedsRedrawForPlotNotification { get; }

		[Notification]
		[Field ("CPTLegendNeedsLayoutForPlotNotification", "__Internal")]
		NSString LegendNeedsLayoutForPlotNotification { get; }

		[Notification]
		[Field ("CPTLegendNeedsReloadEntriesForPlotNotification", "__Internal")]
		NSString LegendNeedsReloadEntriesForPlotNotification { get; }
#endif

		[Export ("textStyle", ArgumentSemantic.Copy)]
		CPTTextStyle TextStyle { get; set; }

		[Export ("swatchSize", ArgumentSemantic.Assign)]
		SizeF SwatchSize { get; set; }

		[Export ("swatchBorderLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle SwatchBorderLineStyle { get; set; }

		[Export ("swatchCornerRadius", ArgumentSemantic.Assign)]
		float SwatchCornerRadius { get; set; }

		[Export ("swatchFill", ArgumentSemantic.Copy)]
		CPTFill SwatchFill { get; set; }

		[Export ("layoutChanged", ArgumentSemantic.Assign)]
		bool LayoutChanged { get; }

		[Export ("numberOfRows", ArgumentSemantic.Assign)]
		int Rows { get; set; }

		[Export ("numberOfColumns", ArgumentSemantic.Assign)]
		int Columns { get; set; }

		[Export ("equalRows", ArgumentSemantic.Assign)]
		bool EqualRows { get; set; }

		[Export ("equalColumns", ArgumentSemantic.Assign)]
		bool EqualColumns { get; set; }

		[Export ("rowHeights", ArgumentSemantic.Copy)]
		NSNumber [] RowHeights { get; set; }

		[Export ("rowHeightsThatFit", ArgumentSemantic.Copy)]
		NSNumber [] RowHeightsThatFit { get; }

		[Export ("columnWidths", ArgumentSemantic.Copy)]
		NSNumber [] ColumnWidths { get; set; }

		[Export ("columnWidthsThatFit", ArgumentSemantic.Retain)]
		NSNumber [] ColumnWidthsThatFit { get; }

		[Export ("columnMargin", ArgumentSemantic.Assign)]
		float ColumnMargin { get; set; }

		[Export ("rowMargin", ArgumentSemantic.Assign)]
		float RowMargin { get; set; }

		[Export ("titleOffset", ArgumentSemantic.Assign)]
		float TitleOffset { get; set; }

		[Static]
		[Export ("legendWithPlots:")]
		CPTLegend FromPlots (CPTPlot [] newPlots);

		[Static]
		[Export ("legendWithGraph:")]
		CPTLegend FromGraph (CPTGraph graph);

		[Export ("initWithPlots:")]
		IntPtr Constructor (CPTPlot [] newPlots);

		[Export ("initWithGraph:")]
		IntPtr Constructor (CPTGraph graph);

		[Export ("allPlots")]
		CPTPlot [] AllPlots { get; }

		[Export ("plotAtIndex:")]
		CPTPlot GetPlot (int atIndex);

		[Export ("plotWithIdentifier:")]
		CPTPlot GetPlot (NSObject identifier);

		[Export ("addPlot:"), PostGet ("AllPlots")]
		void AddPlot (CPTPlot plot);

		[Export ("insertPlot:atIndex:"), PostGet ("AllPlots")]
		void Insert (CPTPlot plot, int index);

		[Export ("removePlot:"), PostGet ("AllPlots")]
		void RemovePlot (CPTPlot plot);

		[Export ("removePlotWithIdentifier:"), PostGet ("AllPlots")]
		void RemovePlot (NSObject identifier);

		[Export ("setLayoutChanged")]
		void SetLayoutChanged ();
	}

	[BaseType (typeof (NSObject))]
	interface CPTLegendEntry 
	{
		[Export ("plot", ArgumentSemantic.Assign)]
		CPTPlot Plot { get; set; }

		[Export ("index", ArgumentSemantic.Assign)]
		int Index { get; set; }

		[Export ("textStyle", ArgumentSemantic.Retain)]
		CPTTextStyle TextStyle { get; set; }

		[Export ("row", ArgumentSemantic.Assign)]
		int Row { get; set; }

		[Export ("column", ArgumentSemantic.Assign)]
		int Column { get; set; }

		[Export ("titleSize", ArgumentSemantic.Assign)]
		SizeF TitleSize { get; }

		[Export ("drawTitleInRect:inContext:scale:")]
		void DrawTitleInRectinContextscale (RectangleF rect, CGContext context, float scale);
	}

	[BaseType (typeof (NSObject))]
	interface CPTLimitBand 
	{
		[Export ("range", ArgumentSemantic.Retain)]
		CPTPlotRange Range { get; set; }

		[Export ("fill", ArgumentSemantic.Retain)]
		CPTFill Fill { get; set; }

		[Static]
		[Export ("limitBandWithRange:fill:")]
		CPTLimitBand FromRange (CPTPlotRange newRange, CPTFill newFill);

		[Export ("initWithRange:fill:")]
		IntPtr Constructor (CPTPlotRange newRange, CPTFill newFill);
	}

	[BaseType (typeof (NSObject))]
	interface CPTLineCap 
	{
		[Export ("size", ArgumentSemantic.Assign)]
		SizeF Size { get; set; }

		[Export ("lineCapType", ArgumentSemantic.Assign)]
		CPTLineCapType LineCapType { get; set; }

		[Export ("lineStyle", ArgumentSemantic.Retain)]
		CPTLineStyle LineStyle { get; set; }

		[Export ("fill", ArgumentSemantic.Retain)]
		CPTFill Fill { get; set; }

		[Export ("customLineCapPath", ArgumentSemantic.Assign)]
		CGPath CustomLineCapPath { get; set; }

		[Export ("usesEvenOddClipRule", ArgumentSemantic.Assign)]
		bool UsesEvenOddClipRule { get; set; }

		[Static]
		[Export ("lineCap")]
		CPTLineCap LineCap { get; }

		[Static]
		[Export ("openArrowPlotLineCap")]
		CPTLineCap OpenArrowPlotLineCap { get; }

		[Static]
		[Export ("solidArrowPlotLineCap")]
		CPTLineCap SolidArrowPlotLineCap { get; }

		[Static]
		[Export ("sweptArrowPlotLineCap")]
		CPTLineCap SweptArrowPlotLineCap { get; }

		[Static]
		[Export ("rectanglePlotLineCap")]
		CPTLineCap RectanglePlotLineCap { get; }

		[Static]
		[Export ("ellipsePlotLineCap")]
		CPTLineCap EllipsePlotLineCap { get; }

		[Static]
		[Export ("diamondPlotLineCap")]
		CPTLineCap DiamondPlotLineCap { get; }

		[Static]
		[Export ("pentagonPlotLineCap")]
		CPTLineCap PentagonPlotLineCap { get; }

		[Static]
		[Export ("hexagonPlotLineCap")]
		CPTLineCap HexagonPlotLineCap { get; }

		[Static]
		[Export ("barPlotLineCap")]
		CPTLineCap BarPlotLineCap { get; }

		[Static]
		[Export ("crossPlotLineCap")]
		CPTLineCap CrossPlotLineCap { get; }

		[Static]
		[Export ("snowPlotLineCap")]
		CPTLineCap SnowPlotLineCap { get; }

		[Static]
		[Export ("customLineCapWithPath:")]
		CPTLineCap GetCustomLineCap (CGPath aPath);

		[Export ("renderAsVectorInContext:atPoint:inDirection:")]
		void RenderAsVector (CGContext context, PointF center, PointF direction);
	}

	[BaseType (typeof (NSObject))]
	interface CPTLineStyle 
	{
		[Export ("lineCap", ArgumentSemantic.Assign)]
		CGLineCap LineCap { get; set; }

		[Export ("lineJoin", ArgumentSemantic.Assign)]
		CGLineJoin LineJoin { get; set; }

		[Export ("miterLimit", ArgumentSemantic.Assign)]
		float MiterLimit { get; set; }

		[Export ("lineWidth", ArgumentSemantic.Assign)]
		float LineWidth { get; set; }

		[Export ("dashPattern", ArgumentSemantic.Retain)]
		NSObject [] DashPattern { get; set; }

		[Export ("patternPhase", ArgumentSemantic.Assign)]
		float PatternPhase { get; set; }

		[Export ("lineColor", ArgumentSemantic.Retain)]
		CPTColor LineColor { get; set; }

		[Export ("lineFill", ArgumentSemantic.Retain)]
		CPTFill LineFill { get; set; }

		[Export ("lineGradient", ArgumentSemantic.Retain)]
		CPTGradient LineGradient { get; set; }

		[Export ("opaque", ArgumentSemantic.Assign)]
		bool Opaque { [Bind ("isOpaque")] get; }

		[Static]
		[Export ("lineStyle")]
		CPTLineStyle LineStyle { get; }

		[Export ("setLineStyleInContext:")]
		void SetLineStyleInContext (CGContext theContext);

		[Export ("strokePathInContext:")]
		void StrokePath (CGContext context);

		[Export ("strokeRect:dinContext:")]
		void StrokeRect (RectangleF rect, CGContext context);
	}

	[BaseType (typeof (CPTLineStyle))]
	interface CPTMutableLineStyle 
	{
		[Export ("lineCap", ArgumentSemantic.Assign)] [New]
		CGLineCap LineCap { get; set; }

		[Export ("lineJoin", ArgumentSemantic.Assign)] [New]
		CGLineJoin LineJoin { get; set; }

		[Export ("miterLimit", ArgumentSemantic.Assign)] [New]
		float MiterLimit { get; set; }

		[Export ("lineWidth", ArgumentSemantic.Assign)] [New]
		float LineWidth { get; set; }

		[Export ("dashPattern", ArgumentSemantic.Retain)] [New]
		NSObject [] DashPattern { get; set; }

		[Export ("patternPhase", ArgumentSemantic.Assign)] [New]
		float PatternPhase { get; set; }

		[Export ("lineColor", ArgumentSemantic.Retain)] [New]
		CPTColor LineColor { get; set; }

		[Export ("lineFill", ArgumentSemantic.Retain)] [New]
		CPTFill LineFill { get; set; }

		[Export ("lineGradient", ArgumentSemantic.Retain)] [New]
		CPTGradient LineGradient { get; set; }
	}

	[BaseType (typeof (CPTNumericData))]
	interface CPTMutableNumericData 
	{
		[Export ("mutableBytes")]
		IntPtr MutableBytes { get; }

		[Export ("shape")] [New]
		NSNumber [] Shape { get; set; }
	}

	[BaseType (typeof (CPTPlotRange))]
	interface CPTMutablePlotRange 
	{
		[Export ("location")] [New]
		NSDecimal Location { get; set; }

		[Export ("length")] [New]
		NSDecimal Length { get; set; }

		[Export ("unionPlotRange:")]
		void UnionPlotRange (CPTPlotRange otherRange);

		[Export ("intersectionPlotRange:")]
		void IntersectionPlot (CPTPlotRange otherRange);

		[Export ("shiftLocationToFitInRange:")]
		void ShiftLocation (CPTPlotRange otherRange);

		[Export ("shiftEndToFitInRange:")]
		void ShiftEnd (CPTPlotRange otherRange);

		[Export ("expandRangeByFactor:")]
		void ExpandRange (NSDecimal factor);
	}

	[BaseType (typeof (CPTShadow))]
	interface CPTMutableShadow 
	{
		[Export ("shadowOffset", ArgumentSemantic.Assign)] [New]
		SizeF ShadowOffset { get; set; }

		[Export ("shadowBlurRadius", ArgumentSemantic.Assign)]  [New]
		float ShadowBlurRadius { get; set; }

		[Export ("shadowColor", ArgumentSemantic.Retain)]  [New]
		CPTColor ShadowColor { get; set; }
	}

	[BaseType (typeof (CPTTextStyle))]
	interface CPTMutableTextStyle 
	{
		[Export ("fontName", ArgumentSemantic.Copy)] [New]
		string FontName { get; set; }

		[Export ("fontSize", ArgumentSemantic.Assign)] [New]
		float FontSize { get; set; }

		[Export ("color", ArgumentSemantic.Copy)] [New]
		CPTColor Color { get; set; }

#if MONOTOUCH
		[Export ("textAlignment", ArgumentSemantic.Assign)]  [New]
		UITextAlignment TextAlignment { get; set; }

		[Export ("lineBreakMode", ArgumentSemantic.Assign)]  [New]
		UILineBreakMode LineBreakMode { get; set; }
#else
		[Export ("textAlignment", ArgumentSemantic.Assign)]  [New]
		NSTextAlignment TextAlignment { get; set; }

		[Export ("lineBreakMode", ArgumentSemantic.Assign)]  [New]
		NSLineBreakMode LineBreakMode { get; set; }
#endif

	}

	[BaseType (typeof (NSObject))]
	interface CPTNumericData 
	{
		[Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		[Export ("void", ArgumentSemantic.Assign)]
		IntPtr Bytes { get; }

		[Export ("length", ArgumentSemantic.Copy)]
		uint Length { get; }

#if MONOTOUCH
		[Export ("dataType", ArgumentSemantic.Assign)]
		CPTNumericDataType DataType { get; }
#else
		[Export ("dataType", ArgumentSemantic.Assign)]
		/*CPTNumericDataType*/ IntPtr DataType { get; }
#endif

		[Export ("dataTypeFormat", ArgumentSemantic.Assign)]
		CPTDataTypeFormat DataTypeFormat { get; }

#if MONOTOUCH
		[Export ("sampleBytes", ArgumentSemantic.Assign)]
		ulong SampleBytes { get; }

		[Export ("byteOrder", ArgumentSemantic.Assign)]
		long ByteOrder { get; }
#else
		[Export ("sampleBytes", ArgumentSemantic.Assign)]
		IntPtr SampleBytes { get; }

		[Export ("byteOrder", ArgumentSemantic.Assign)]
		int ByteOrder { get; }
#endif

		[Export ("shape", ArgumentSemantic.Copy)]
		NSNumber [] Shape { get; }

		[Export ("numberOfDimensions", ArgumentSemantic.Assign)]
		int NumberOfDimensions { get; }

		[Export ("numberOfSamples", ArgumentSemantic.Assign)]
		int NumberOfSamples { get; }

		//TODO: Test if the CPTNumericDataType struct works
#if MONOTOUCH
		[Static]
		[Export ("numericDataWithData:dataType:shape:")]
		CPTNumericData FromData (NSData newData, CPTNumericDataType newDataType, NSNumber [] shapeArray);

		[Static]
		[Export ("numericDataWithData:dataTypeString:shape:")]
		CPTNumericData FromData (NSData newData, string newDataTypeString, NSArray shapeArray);

		[Static]
		[Export ("numericDataWithArray:dataType:shape:")]
		CPTNumericData FromArray (NSArray newData, CPTNumericDataType newDataType, NSArray shapeArray);

		[Static]
		[Export ("numericDataWithArray:dataTypeString:shape:")]
		CPTNumericData FromArray (NSArray newData, string newDataTypeString, NSArray shapeArray);

		[Static]
		[Export ("numericDataWithData:dataType:shape:dataOrder:")]
		CPTNumericData FromData (NSData newData, CPTNumericDataType newDataType, NSNumber [] shapeArray, CPTDataOrder order);

		[Static]
		[Export ("numericDataWithData:dataTypeString:shape:dataOrder:")]
		CPTNumericData FromData (NSData newData, string newDataTypeString, NSArray shapeArray, CPTDataOrder order);

		[Static]
		[Export ("numericDataWithArray:dataType:shape:dataOrder:")]
		CPTNumericData FromArray (NSArray newData, CPTNumericDataType newDataType, NSArray shapeArray, CPTDataOrder order);

		[Static]
		[Export ("numericDataWithArray:dataTypeString:shape:dataOrder:")]
		CPTNumericData FromArray (NSArray newData, string newDataTypeString, NSArray shapeArray, CPTDataOrder order);

		[Export ("initWithData:dataType:shape:")]
		IntPtr Constructor (NSData newData, CPTNumericDataType newDataType, NSArray shapeArray);

		[Export ("initWithData:dataTypeString:shape:")]
		IntPtr Constructor (NSData newData, string newDataTypeString, NSArray shapeArray);

		[Export ("initWithArray:dataType:shape:")]
		IntPtr Constructor (NSArray newData, CPTNumericDataType newDataType, NSArray shapeArray);

		[Export ("initWithArray:dataTypeString:shape:")]
		IntPtr Constructor (NSArray newData, string newDataTypeString, NSArray shapeArray);

		[Export ("initWithData:dataType:shape:dataOrder:")]
		IntPtr Constructor (NSData newData, CPTNumericDataType newDataType, NSArray shapeArray, CPTDataOrder order);

		[Export ("initWithData:dataTypeString:shape:dataOrder:")]
		IntPtr Constructor (NSData newData, string newDataTypeString, NSArray shapeArray, CPTDataOrder order);

		[Export ("initWithArray:dataType:shape:dataOrder:")]
		IntPtr Constructor (NSArray newData, CPTNumericDataType newDataType, NSArray shapeArray, CPTDataOrder order);

		[Export ("initWithArray:dataTypeString:shape:dataOrder:")]
		IntPtr Constructor (NSArray newData, string newDataTypeString, NSArray shapeArray, CPTDataOrder order);
#else
		[Static]
		[Export ("numericDataWithData:dataType:shape:")]
		CPTNumericData FromData (NSData newData, /*CPTNumericDataType*/ IntPtr newDataType, NSNumber [] shapeArray);

		[Static]
		[Export ("numericDataWithData:dataTypeString:shape:")]
		CPTNumericData FromData (NSData newData, string newDataTypeString, NSArray shapeArray);

		[Static]
		[Export ("numericDataWithArray:dataType:shape:")]
		CPTNumericData FromArray (NSArray newData, /*CPTNumericDataType*/ IntPtr newDataType, NSArray shapeArray);

		[Static]
		[Export ("numericDataWithArray:dataTypeString:shape:")]
		CPTNumericData FromArray (NSArray newData, string newDataTypeString, NSArray shapeArray);

		[Export ("initWithData:dataType:shape:")]
		IntPtr Constructor (NSData newData, IntPtr /* cpnumericdatatype */ newDataType, NSArray shapeArray);

		[Export ("initWithData:dataTypeString:shape:")]
		IntPtr Constructor (NSData newData, string newDataTypeString, NSArray shapeArray);

		[Export ("initWithArray:dataType:shape:")]
		IntPtr Constructor (NSArray newData, IntPtr /*CPTNumericDataType */ newDataType, NSArray shapeArray);

		[Export ("initWithArray:dataTypeString:shape:")]
		IntPtr Constructor (NSArray newData, string newDataTypeString, NSArray shapeArray);
#endif

		[Export ("samplePointer:")]
		void SamplePointer (int sample);

		[Export ("sampleValue:")]
		NSNumber SampleValue (int sample);

		[Export ("sampleArray")]
		NSObject [] SampleArray ();
	}

	[Category]
	[BaseType (typeof (CPTNumericData))]
	interface CPTNumericData_TypeConversion 
	{
		[Export ("dataByConvertingToDataType:")]
		CPTNumericData DataByConvertingToDataType (CPTNumericDataType newDataType);

		[Export ("dataByConvertingToType:sampleBytes:byteOrder:")]
		CPTNumericData DataByConvertingToType (CPTDataTypeFormat newDataType, ulong newSampleBytes, long newByteOrder);

		[Export ("convertData:dataType:toData:dataType:")]
		void ConvertData (NSData sourceData, CPTNumericDataType sourceDataType, NSMutableData destData, CPTNumericDataType destDataType);

		[Export ("swapByteOrderForData:sampleSize:")]
		void SwapByteOrder (NSMutableData sourceData, ulong sampleSize);
	}

	interface ICPTPieChartDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTPieChartDataSource : CPTPlotDataSource 
	{
		[Export ("sliceFillsForPieChart:recordIndexRange:")]
		CPTFill [] GetSliceFills (CPTPieChart pieChart, NSRange indexRange);

		[Export ("sliceFillForPieChart:recordIndex:")]
		CPTFill GetSliceFill (CPTPieChart pieChart, uint recordIndex);

		[Export ("radialOffsetsForPieChart:recordIndexRange:")]
		NSValue [] GetRaidlOffsets (CPTPieChart pieChart, NSRange indexRange);

		[Export ("radialOffsetForPieChart:recordIndex:")]
		float GetRaidlOffset (CPTPieChart pieChart, uint recordIndex);

		[Export ("legendTitleForPieChart:recordIndex:")]
		string GetLegendTitle (CPTPieChart pieChart, uint recordIndex);

		[Export ("attributedLegendTitleForPieChart:recordIndex:")]
		NSAttributedString GetAttributedLegendTitle (CPTPieChart pieChart, uint recordIndex);
	}

	interface ICPTPieChartDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTPieChartDelegate : CPTPlotDelegate 
	{
		[Export ("pieChart:sliceWasSelectedAtRecordIndex:")]
		void SliceSelected (CPTPieChart plot, uint recordIndex);

		[Export ("pieChart:sliceWasSelectedAtRecordIndex:withEvent:")]
		void SliceSelected (CPTPieChart plot, uint recordIndex, CPTNativeEvent theEvent);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTPieChart 
	{
		[Wrap ("WeakDataSource")][New]
		CPTPieChartDataSource DataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTPieChartDelegate Delegate { get; set; }

		[Export ("pieRadius")]
		float PieRadius { get; set; }

		[Export ("pieInnerRadius")]
		float PieInnerRadius { get; set; }

		[Export ("startAngle")]
		float StartAngle { get; set; }

		[Export ("endAngle")]
		float EndAngle { get; set; }

		[Export ("sliceDirection")]
		CPTPieDirection SliceDirection { get; set; }

		[Export ("centerAnchor")]
		PointF CenterAnchor { get; set; }

		[Export ("borderLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle BorderLineStyle { get; set; }

		[Export ("overlayFill", ArgumentSemantic.Copy)]
		CPTFill OverlayFill { get; set; }

		[Export ("labelRotationRelativeToRadius", ArgumentSemantic.Assign)]
		bool LabelRotationRelativeToRadius { get; set; }

		[Export ("pieSliceIndexAtAngle:")]
		uint PieSliceIndex (float angle);

		[Export ("medianAngleForPieSliceIndex:")]
		float MedianAngle (uint index);

		[Static]
		[Export ("defaultPieSliceColorForIndex:")]
		CPTColor DefaultPieSliceColorForIndex (int pieSliceIndex);
	}

	interface ICPTPlotDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTPlotDataSource 
	{
		[Abstract]
		[Export ("numberOfRecordsForPlot:")]
		int NumberOfRecordsForPlot (CPTPlot plot);

		[Export ("numbersForPlot:field:recordIndexRange:")]
		NSNumber [] NumbersForPlot (CPTPlot forPlot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("numberForPlot:field:recordIndex:")]
		NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, uint index);

		[Export ("doublesForPlot:field:recordIndexRange:")]
		IntPtr DoublesForPlot (CPTPlot plot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("doubleForPlot:field:recordIndex:")]
		double DoubleForPlot (CPTPlot plot, CPTPlotField forFieldEnum, uint index);

		[Export ("dataForPlot:field:recordIndexRange:")]
		CPTNumericData DataForPlot (CPTPlot plot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("dataForPlot:recordIndexRange:")]
		IntPtr DataForPlot (CPTPlot plot, NSRange indexRange);

		[Export ("dataLabelsForPlot:recordIndexRange:")]
		CPTLayer [] DataLabelsForPlot (CPTPlot plot, NSRange indexRange);

		[Export ("dataLabelForPlot:recordIndex:")]
		CPTLayer DataLabelForPlot (CPTPlot plot, uint recordIndex);
	}

	interface ICPTPlotDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTPlotDelegate 
	{
		[Export ("plot:dataLabelWasSelectedAtRecordIndex:")]
		void DataLabelWasSelected (CPTPlot plot, uint index);

		[Export ("plot:dataLabelWasSelectedAtRecordIndex:withEvent:")]
		void DataLabelWasSelected (CPTPlot plot, uint index, CPTNativeEvent theEvent);

		[Export ("dataLabelForPlot:didFinishDrawing:")]
		void DidFinishDrawing (CPTPlot plot);
	}

	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTPlot 
	{
		[Wrap ("WeakDataSource")]
		CPTPlotDataSource DataSource { get; set; }

		[Export ("dataSource", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTPlotDelegate Delegate { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("plotSpace", ArgumentSemantic.Retain)]
		CPTPlotSpace PlotSpace { get; set; }

		[Export ("plotArea", ArgumentSemantic.Retain)]
		CPTPlotArea PlotArea { get; }

		[Export ("dataNeedsReloading", ArgumentSemantic.Assign)]
		bool DataNeedsReloading { get; }

		[Export ("cachedDataCount", ArgumentSemantic.Assign)]
		uint CachedDataCount { get; }

		[Export ("doublePrecisionCache", ArgumentSemantic.Assign)]
		bool DoublePrecisionCache { get; }

		[Export ("cachePrecision", ArgumentSemantic.Assign)]
		CPTPlotCachePrecision CachePrecision { get; set; }

#if MONOTOUCH
		[Export ("doubleDataType", ArgumentSemantic.Assign)]
		CPTNumericDataType DoubleDataType { get; }

		[Export ("decimalDataType", ArgumentSemantic.Assign)]
		CPTNumericDataType DecimalDataType { get; }
#else
		[Export ("doubleDataType", ArgumentSemantic.Assign)]
		/*CPTNumericDataType*/ IntPtr DoubleDataType { get; }

		[Export ("decimalDataType", ArgumentSemantic.Assign)]
		/* CPTNumericDataType*/ IntPtr DecimalDataType { get; }
#endif

		[Export ("needsRelabel", ArgumentSemantic.Assign)]
		bool NeedsRelabel { get; }

		[Export ("adjustLabelAnchors", ArgumentSemantic.Assign)]
		bool AdjustLabelAnchors { get; set; }

		[Export ("showLabels", ArgumentSemantic.Assign)]
		bool ShowLabels { get; set; }

		[Export ("labelOffset", ArgumentSemantic.Assign)]
		float LabelOffset { get; set; }

		[Export ("labelRotation", ArgumentSemantic.Assign)]
		float LabelRotation { get; set; }

		[Export ("labelField", ArgumentSemantic.Assign)]
		uint LabelField { get; set; }

		[Export ("labelTextStyle", ArgumentSemantic.Copy)]
		CPTTextStyle LabelTextStyle { get; set; }

		[Export ("labelFormatter", ArgumentSemantic.Retain)]
		NSFormatter LabelFormatter { get; set; }

		[Export ("labelShadow", ArgumentSemantic.Retain)]
		CPTShadow LabelShadow { get; set; }

		[Export ("alignsPointsToPixels", ArgumentSemantic.Assign)]
		bool AlignsPointsToPixels { get; set; }

		[Export ("setNeedsRelabel")]
		void SetNeedsRelabel ();

		[Export ("relabel")]
		void Relabel ();

		[Export ("relabelIndexRange:")]
		void RelabelIndexRange (NSRange indexRange);

		[Export ("repositionAllLabelAnnotations")]
		void RepositionAllLabelAnnotations ();

		[Export ("setDataNeedsReloading")]
		void SetDataNeedsReloading ();

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("reloadDataIfNeeded")]
		void ReloadDataIfNeeded ();

		[Export ("reloadDataInIndexRange:")]
		void ReloadDataInIndexRange (NSRange indexRange);

		[Export ("insertDataAtIndex:numberOfRecords:")]
		void InsertData (uint index, uint numberOfRecords);

		[Export ("deleteDataInIndexRange:")]
		void DeleteData (NSRange indexRange);

		[Static]
		[Export ("nilData")]
		NSObject NullData ();

		[Export ("numbersFromDataSourceForField:recordIndexRange:")]
		NSObject NumbersFromDataSource (CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("loadNumbersForAllFieldsFromDataSourceInRecordIndexRange:")]
		bool LoadNumbersForAllFieldsFromDataSourceInRecordIndexRange (NSRange indexRange);

		[Export ("cachedNumbersForField:")]
		CPTMutableNumericData CachedNumbersForField (CPTPlotField forFieldEnum);

		[Export ("cachedNumberForField:recordIndex:")]
		NSNumber CachedNumberForField (CPTPlotField forFieldEnum, uint index);

		[Export ("cachedDoubleForField:recordIndex:")]
		double CachedDoubleForField (CPTPlotField forFieldEnum, uint index);

		[Export ("cachedDecimalForField:recordIndex:")]
		NSDecimal CachedDecimalForField (CPTPlotField forFieldEnum, uint index);

		[Export ("cachedValueForKey:recordIndex:")]
		NSObject CachedValueForKey (string key, uint index);

		[Export ("cacheNumbers:forField:")]
		void CacheNumbers (NSObject numbers, CPTPlotField forFieldEnum);

		[Export ("cacheNumbers:forField:atRecordIndex:")]
		void CacheNumbers (NSObject numbers, CPTPlotField forFieldEnum, uint index);

		[Export ("cacheArray:forKey:")]
		void CacheArray (NSObject [] array, string key);

		[Export ("cacheArray:forKey:atRecordIndex:")]
		void CacheArray (NSObject [] array, string key, uint index);

		[Export ("plotRangeForField:")]
		CPTPlotRange PlotRangeForField (CPTPlotField forFieldEnum);

		[Export ("plotRangeForCoordinate:")]
		CPTPlotRange PlotRangeForCoordinate (CPTCoordinate coord);

		[Export ("numberOfLegendEntries")]
		uint NumberOfLegendEntries { get; }

		[Export ("titleForLegendEntryAtIndex:")]
		string GetTitleForLegendEntry (uint index);

		[Export ("attributedTitleForLegendEntryAtIndex:")]
		NSAttributedString GetAttributedTitleForLegendEntry (uint index);

		[Export ("drawSwatchForLegend:atIndex:inRect:inContext:")]
		void DrawSwatch (CPTLegend legent, int index, RectangleF rect, CGContext context);

		[Export ("numberOfFields")]
		int NumberOfFields { get; }

		[Export ("fieldIdentifiers")]
		NSObject [] FieldIdentifiers ();

		[Export ("fieldIdentifiersForCoordinate:")]
		NSObject [] FieldIdentifiersForCoordinate (CPTCoordinate coord);

		[Export ("positionLabelAnnotation:forIndex:")]
		void PositionLabelAnnotationforIndex (CPTPlotSpaceAnnotation label, uint index);

		[Export ("dataIndexFromInteractionPoint:")]
		uint DataIndexFromInteractionPoint (PointF point);
	}

	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTPlotArea 
	{
		[Export ("minorGridLineGroup", ArgumentSemantic.Retain)]
		CPTGridLineGroup MinorGridLineGroup { get; set; }

		[Export ("majorGridLineGroup", ArgumentSemantic.Retain)]
		CPTGridLineGroup MajorGridLineGroup { get; set; }

		[Export ("axisSet", ArgumentSemantic.Retain)]
		CPTAxisSet AxisSet { get; set; }

		[Export ("plotGroup", ArgumentSemantic.Retain)]
		CPTPlotGroup PlotGroup { get; set; }

		[Export ("axisLabelGroup", ArgumentSemantic.Retain)]
		CPTAxisLabelGroup AxisLabelGroup { get; set; }

		[Export ("axisTitleGroup", ArgumentSemantic.Retain)]
		CPTAxisLabelGroup AxisTitleGroup { get; set; }

		[Export ("topDownLayerOrder", ArgumentSemantic.Retain)]
		NSNumber [] TopDownLayerOrder { get; set; }

		[Export ("borderLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle BorderLineStyle { get; set; }

		[Export ("fill", ArgumentSemantic.Copy)]
		CPTFill Fill { get; set; }

		[Export ("updateAxisSetLayersForType:")]
		void UpdateAxisSetLayers (CPTGraphLayerType forLayerType);

		[Export ("setAxisSetLayersForType:")]
		void SetAxisSetLayers (CPTGraphLayerType forLayerType);

		[Export ("sublayerIndexForAxis:layerType:")]
		uint SublayerIndex (CPTAxis forAxis, CPTGraphLayerType layerType);
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTPlotAreaFrame 
	{
		[Export ("plotArea", ArgumentSemantic.Retain)]
		CPTPlotArea PlotArea { get; }

		[Export ("axisSet", ArgumentSemantic.Retain)]
		CPTAxisSet AxisSet { get; set; }

		[Export ("plotGroup", ArgumentSemantic.Retain)]
		CPTPlotGroup PlotGroup { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface CPTPlotRange 
	{
		[Export ("location")]
		NSDecimal Location { get; }

		[Export ("length")]
		NSDecimal Length { get; }

		[Export ("end")]
		NSDecimal End { get; }

		[Export ("locationDouble")]
		double LocationDouble { get; }

		[Export ("lengthDouble")]
		double LengthDouble { get; }

		[Export ("endDouble")]
		double EndDouble { get; }

		[Export ("minLimit")]
		NSDecimal MinLimit { get; }

		[Export ("midPoint")]
		NSDecimal MidPoint { get; }

		[Export ("maxLimit")]
		NSDecimal MaxLimit { get; }

		[Export ("minLimitDouble")]
		double MinLimitDouble { get; }

		[Export ("midPointDouble")]
		double MidPointDouble { get; }

		[Export ("maxLimitDouble")]
		double MaxLimitDouble { get; }

		[Static]
		[Export ("plotRangeWithLocation:length:")]
		CPTPlotRange FromLocation (NSDecimal location, NSDecimal lenght);

		[Export ("initWithLocation:length:")]
		IntPtr Constructor (NSDecimal location, NSDecimal lenght);

		[Export ("contains:")]
		bool Contains (NSDecimal number);

		[Export ("containsDouble:")]
		bool Contains (double number);

		[Export ("isEqualToRange:")]
		bool IsEqualToRange (CPTPlotRange otherRange);

		[Export ("containsRange:")]
		bool ContainsRange (CPTPlotRange otherRange);

		[Export ("intersectsRange:")]
		bool IntersectsRange (CPTPlotRange otherRange);

		[Export ("compareToNumber:")]
		CPTPlotRangeComparisonResult Compare (NSNumber number);

		[Export ("compareToDecimal:")]
		CPTPlotRangeComparisonResult Compare (NSDecimal number);

		[Export ("compareToDouble:")]
		CPTPlotRangeComparisonResult Compare (double number);
	}

	interface ICPTPlotSpaceDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTPlotSpaceDelegate 
	{
		[DelegateName ("CPTEventShouldScalePredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldScaleBy:aboutPoint:")]
		bool ShouldScale (CPTPlotSpace space, float interactionScale, PointF interactionPoint);

		[DelegateName ("CPTDisplacement"), DefaultValueFromArgument ("proposedDisplacementVector")]
		[Export ("plotSpace:willDisplaceBy:")]
		PointF WillDisplace (CPTPlotSpace space, PointF proposedDisplacementVector);

		[DelegateName ("CPTWillChangePlotRange"), DefaultValueFromArgument ("newRange")]
		[Export ("plotSpace:willChangePlotRangeTo:forCoordinate:")]
		CPTPlotRange WillChangePlotRange (CPTPlotSpace space, CPTPlotRange newRange, CPTCoordinate coordinate);

		[EventArgs ("CPTPlotChanged")]
		[Export ("plotSpace:didChangePlotRangeForCoordinate:")]
		void DidChangePlotRange (CPTPlotSpace space, CPTCoordinate coordinate);

		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceDownEvent:atPoint:")]
		bool ShouldHandlePointingDeviceDown (CPTPlotSpace space, CPTNativeEvent theEvent, PointF point);

		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceDraggedEvent:atPoint:")]
		bool ShouldHandlePointingDeviceDragged (CPTPlotSpace space, CPTNativeEvent theEvent, PointF point);

		[DelegateName ("CPTEventPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceCancelledEvent:")]
		bool ShouldHandlePointingDeviceCancelled (CPTPlotSpace space, CPTNativeEvent theEvent);

		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceUpEvent:atPoint:")]
		bool ShouldHandlePointingDeviceUp (CPTPlotSpace space, CPTNativeEvent theEvent, PointF point);
	}

	[BaseType (typeof (NSObject), 
	Delegates=new string [] { "WeakDelegate" }, 
	Events= new Type [] { typeof (CPTPlotSpaceDelegate) })]
	interface CPTPlotSpace : ICPTResponder
	{
#if MONOTOUCH
		[Notification]
		[Field ("CPTPlotSpaceCoordinateMappingDidChangeNotification", "__Internal")]
		NSString PlotSpaceCoordinateMappingDidChangeNotification { get; }
#endif
		[Export ("identifier", ArgumentSemantic.Copy)]
		NSObject Identifier { get; set; }

		[Export ("allowsUserInteraction", ArgumentSemantic.Assign)]
		bool AllowsUserInteraction { get; set; }

		[Export ("graph", ArgumentSemantic.Assign)]
		CPTGraph Graph { get; set; }

		[Wrap ("WeakDelegate")]
		CPTPlotSpaceDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("numberOfCoordinates", ArgumentSemantic.Assign)]
		uint NumberOfCoordinates { get; }

		[Export ("plotAreaViewPointForPlotPoint:")]
		PointF PlotAreaViewPoint (ref NSDecimal plotPoint);

		[Export ("plotAreaViewPointForPlotPoint:numberOfCoordinates:")]
		PointF PlotAreaViewPoint (ref NSDecimal plotPoint, uint numberOfCoordinates);

		[Export ("plotAreaViewPointForDoublePrecisionPlotPoint:")]
		PointF PlotAreaViewPoint (ref double plotPoint);

		[Export ("plotAreaViewPointForDoublePrecisionPlotPoint:numberOfCoordinates:")]
		PointF PlotAreaViewPoint (ref double plotPoint, uint numberOfCoordinates);

		[Export ("plotPoint:forPlotAreaViewPoint:")]
		void PlotPointforPlotAreaViewPoint (ref NSDecimal plotPoint, PointF plotAreaViewPoint);

		[Export ("plotPoint:numberOfCoordinates:forPlotAreaViewPoint:")]
		void PlotPointforPlotAreaViewPoint (ref NSDecimal plotPoint, uint numberOfCoordinates, PointF plotAreaViewPoint);

		[Export ("doublePrecisionPlotPoint:forPlotAreaViewPoint:")]
		void PlotPoint (ref double plotPoint, PointF plotAreaViewPoint);

		[Export ("doublePrecisionPlotPoint:numberOfCoordinates:forPlotAreaViewPoint:")]
		void PlotPoint (ref double plotPoint, uint numberOfCoordinates, PointF plotAreaViewPoint);

		[Export ("plotAreaViewPointForEvent:")]
		PointF GetPlotAreaViewPoint (CPTNativeEvent theEvent);

		[Export ("plotPoint:forEvent:")]
		void PlotPoint (ref NSDecimal plotPoint, CPTNativeEvent theEvent);

		[Export ("plotPoint:numberOfCoordinates:forEvent:")]
		void PlotPoint (ref NSDecimal plotPoint, uint numberOfCoordinates, CPTNativeEvent theEvent);

		[Export ("doublePrecisionPlotPoint:forEvent:")]
		void PlotPoint (ref double plotPoint, CPTNativeEvent theEvent);

		[Export ("doublePrecisionPlotPoint:numberOfCoordinates:forEvent:")]
		void PlotPoint (ref double plotPoint, uint numberOfCoordinates, CPTNativeEvent theEvent);
	
		[Export ("setPlotRange:forCoordinate:")]
		void SetPlotRange (CPTPlotRange newRange, CPTCoordinate coordinate);

		[Export ("plotRangeForCoordinate:")]
		CPTPlotRange GetPlotRange (CPTCoordinate coordinate);

		[Export ("setScaleType:forCoordinate:")]
		void SetScaleType (CPTScaleType scaleType, CPTCoordinate forCoordinate);

		[Export ("scaleTypeForCoordinate:")]
		CPTScaleType GetScaleType (CPTCoordinate forCoordinate);

		[Export ("scaleToFitPlots:")]
		void ScaleToFitPlots (CPTPlot [] plots);

		[Export ("scaleBy:aboutPoint:")]
		void Scale (float interactionScale, PointF interactionPoint);
	}

	[BaseType (typeof (CPTAnnotation))]
	interface CPTPlotSpaceAnnotation
	{
		// Decimals!!
		[Export ("anchorPlotPoint", ArgumentSemantic.Copy)]
		NSNumber [] AnchorPlotPoint { get; set; }

		[Export ("plotSpace", ArgumentSemantic.Retain)]
		CPTPlotSpace PlotSpace { get; }

		[Export ("initWithPlotSpace:anchorPlotPoint:")]
		IntPtr Constructor (CPTPlotSpace space, NSNumber [] plotPoint);
	}

	[BaseType (typeof (NSObject))]
	interface CPTPlotSymbol 
	{
		[Export ("anchorPoint", ArgumentSemantic.Assign)]
		PointF AnchorPoint { get; set; }

		[Export ("size", ArgumentSemantic.Assign)]
		SizeF Size { get; set; }

		[Export ("symbolType", ArgumentSemantic.Assign)]
		CPTPlotSymbolType SymbolType { get; set; }

		[Export ("lineStyle", ArgumentSemantic.Retain)]
		CPTLineStyle LineStyle { get; set; }

		[Export ("fill", ArgumentSemantic.Retain)]
		CPTFill Fill { get; set; }

		[Export ("shadow", ArgumentSemantic.Copy)]
		CPTShadow Shadow { get; set; }

		[Export ("customSymbolPath", ArgumentSemantic.Assign)]
		CGPath CustomSymbolPath { get; set; }

		[Export ("usesEvenOddClipRule", ArgumentSemantic.Assign)]
		bool UsesEvenOddClipRule { get; set; }

		[Static]
		[Export ("plotSymbol")]
		CPTPlotSymbol PlotSymbol { get; }

		[Static]
		[Export ("crossPlotSymbol")]
		CPTPlotSymbol CrossPlotSymbol { get; }

		[Static]
		[Export ("ellipsePlotSymbol")]
		CPTPlotSymbol EllipsePlotSymbol { get; }

		[Static]
		[Export ("rectanglePlotSymbol")]
		CPTPlotSymbol RectanglePlotSymbol { get; }

		[Static]
		[Export ("plusPlotSymbol")]
		CPTPlotSymbol PlusPlotSymbol { get; }

		[Static]
		[Export ("starPlotSymbol")]
		CPTPlotSymbol StarPlotSymbol { get; }

		[Static]
		[Export ("diamondPlotSymbol")]
		CPTPlotSymbol DiamondPlotSymbol { get; }

		[Static]
		[Export ("trianglePlotSymbol")]
		CPTPlotSymbol TrianglePlotSymbol { get; }

		[Static]
		[Export ("pentagonPlotSymbol")]
		CPTPlotSymbol PentagonPlotSymbol { get; }

		[Static]
		[Export ("hexagonPlotSymbol")]
		CPTPlotSymbol HexagonPlotSymbol { get; }

		[Static]
		[Export ("dashPlotSymbol")]
		CPTPlotSymbol DashPlotSymbol { get; }

		[Static]
		[Export ("snowPlotSymbol")]
		CPTPlotSymbol SnowPlotSymbol { get; }

		[Static]
		[Export ("customPlotSymbolWithPath:")]
		CPTPlotSymbol CustomPlotSymbolFromPath (CGPath Path);

		[Export ("renderInContext:atPoint:scale:alignToPixels:")]
		void RenderInContext (CGContext inContext, PointF centerPoint, float scale, bool alignToPixels);

		[Export ("renderAsVectorInContext:atPoint:scale:")]
		void RenderAsVector (CGContext inContext, PointF centerPoint, float scale);
	}

	interface ICPTRangePlotDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTRangePlotDataSource : CPTPlotDataSource 
	{
		[Export ("barLineStylesForRangePlot:recordIndexRange:")]
		CPTLineStyle [] BarLineStyles (CPTRangePlot plot, NSRange indexRange);

		[Export ("barLineStyleForRangePlot:recordIndexRange:")]
		CPTLineStyle BarLineStyle (CPTRangePlot plot, uint recordIndex);
	}

	interface ICPTRangePlotDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTRangePlotDelegate : CPTPlotDelegate 
	{
		[Export ("rangePlot:rangeWasSelectedAtRecordIndex:")]
		void RangeWasSelected (CPTRangePlot plot, uint recordIndex);

		[Export ("rangePlot:rangeWasSelectedAtRecordIndex:withEvent:")]
		void RangeWasSelected (CPTRangePlot plot, uint recordIndex, CPTNativeEvent theEvent);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTRangePlot 
	{
		[Wrap ("WeakDataSource")][New]
		CPTRangePlotDataSource DataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTRangePlotDelegate Delegate { get; set; }

		[Export ("barLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle BarLineStyle { get; set; }

		[Export ("barWidth")]
		float BarWidth { get; set; }

		[Export ("gapHeight")]
		float GapHeight { get; set; }

		[Export ("gapWidth")]
		float GapWidth { get; set; }

		[Export ("areaFill", ArgumentSemantic.Copy)]
		CPTFill AreaFill { get; set; }
	}

	interface ICPTResponder { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTResponder 
	{
		[Abstract]
		[Export ("pointingDeviceDownEvent:atPoint:")]
		bool PointingDeviceDownEvent (CPTNativeEvent theEvent, PointF interactionPoint);

		[Abstract]
		[Export ("pointingDeviceUpEvent:atPoint:")]
		bool PointingDeviceUpEvent (CPTNativeEvent theEvent, PointF interactionPoint);

		[Abstract]
		[Export ("pointingDeviceDraggedEvent:atPoint:")]
		bool PointingDeviceDraggedEvent (CPTNativeEvent theEvent, PointF interactionPoint);

		[Abstract]
		[Export ("pointingDeviceCancelledEvent:atPoint:")]
		bool PointingDeviceCancelledEvent (CPTNativeEvent theEvent, PointF interactionPoint);
	}

	interface ICPTScatterPlotDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTScatterPlotDataSource : CPTPlotDataSource 
	{
		[Export ("symbolsForScatterPlot:recordIndexRange:")]
		CPTPlotSymbol [] GetSymbols (CPTScatterPlot plot, NSRange indexRange);

		[Export ("symbolForScatterPlot:recordIndex:")]
		CPTPlotSymbol GetSymbol (CPTScatterPlot plot, uint recordIndex);
	}

	interface ICPTScatterPlotDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTScatterPlotDelegate : CPTPlotDelegate 
	{
		[Export ("scatterPlot:plotSymbolWasSelectedAtRecordIndex:")]
		void PlotSymbolWasSelected (CPTScatterPlot plot, uint recordIndex);

		[Export ("scatterPlot:plotSymbolWasSelectedAtRecordIndex:withEvent:")]
		void PlotSymbolWasSelected (CPTScatterPlot plot, uint recordIndex, CPTNativeEvent theEvent);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTScatterPlot 
	{
		[Wrap ("WeakDataSource")][New]
		CPTScatterPlotDataSource DataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTScatterPlotDelegate Delegate { get; set; }

		[Export ("areaBaseValue")]
		NSDecimal AreaBaseValue { get; set; }

		[Export ("areaBaseValue2")]
		NSDecimal AreaBaseValue2 { get; set; }

		[Export ("interpolation", ArgumentSemantic.Assign)]
		CPTScatterPlotInterpolation Interpolation { get; set; }

		[Export ("dataLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle DataLineStyle { get; set; }

		[Export ("plotSymbol", ArgumentSemantic.Copy)]
		CPTPlotSymbol PlotSymbol { get; set; }

		[Export ("areaFill", ArgumentSemantic.Copy)]
		CPTFill AreaFill { get; set; }

		[Export ("areaFill2", ArgumentSemantic.Copy)]
		CPTFill AreaFill2 { get; set; }

		[Export ("plotSymbolMarginForHitDetection")]
		float PlotSymbolMarginForHitDetection { get; set; }

		[Export ("indexOfVisiblePointClosestToPlotAreaPoint:")]
		uint IndexOfVisiblePointClosestToPlotAreaPoint (PointF viewPoint);

		[Export ("plotAreaPointOfVisiblePointAtIndex:")]
		PointF PlotAreaPointOfVisiblePointAtIndex (int index);

		[Export ("plotSymbolForRecordIndex:")]
		CPTPlotSymbol PlotSymbolForRecordIndex (int index);
	}

	[BaseType (typeof (NSObject))]
	interface CPTShadow 
	{
		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		SizeF ShadowOffset { get; }

		[Export ("shadowBlurRadius", ArgumentSemantic.Assign)]
		float ShadowBlurRadius { get; }

		[Export ("shadowColor", ArgumentSemantic.Retain)]
		CPTColor ShadowColor { get; }

		[Static]
		[Export ("shadow")]
		CPTShadow GetShadow { get; }

		[Export ("setShadowInContext:")]
		void SetShadowInContext (CGContext context);
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTTextLayer 
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }

		[Export ("textStyle", ArgumentSemantic.Retain)]
		CPTTextStyle TextStyle { get; set; }

		[Export ("attributedText", ArgumentSemantic.Retain)]
		NSAttributedString AttributedText { get; set; }

		[Export ("maximumSize")]
		SizeF MaximumSize { get; set; }

		[Export ("initWithText:")]
		IntPtr Constructor (string newText);

		[Export ("initWithText:style:")]
		IntPtr Constructor (string newText, CPTTextStyle newStyle);

		[Export ("initWithAttributedText:")]
		IntPtr Constructor (NSAttributedString newText);

		[Export ("sizeThatFits")]
		SizeF SizeThatFits { get; }

		[Export ("sizeToFit")]
		void SizeToFit ();
	}

	[BaseType (typeof (NSObject))]
	interface CPTTextStyle 
	{
		[Export ("fontName", ArgumentSemantic.Copy)]
		string FontName { get; }

		[Export ("fontSize", ArgumentSemantic.Assign)]
		float FontSize { get; }

		[Export ("color", ArgumentSemantic.Copy)]
		CPTColor Color { get; }

#if MONOTOUCH
		[Export ("textAlignment", ArgumentSemantic.Assign)]
		UITextAlignment TextAlignment { get; }

		[Export ("lineBreakMode", ArgumentSemantic.Assign)]
		UILineBreakMode LineBreakMode { get; }
#else
		[Export ("textAlignment", ArgumentSemantic.Assign)]
		NSTextAlignment TextAlignment { get; }

		[Export ("lineBreakMode", ArgumentSemantic.Assign)]
		NSLineBreakMode LineBreakMode { get; }
#endif
		[Static]
		[Export ("textStyle")]
		CPTTextStyle CreateTextStyle ();

		[Export ("sizeWithTextStyle:")]
		SizeF SizeWithTextStyle (CPTTextStyle style);

		[Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary Attributes { get; }

		[Static]
		[Export ("textStyleWithAttributes:")]
		CPTTextStyle FromAttributes (NSDictionary attributes);

		[Export ("drawInRect:withTextStyle:inContext:")]
		void Draw (RectangleF rectangle, CPTTextStyle style, CGContext context);
	}

	[BaseType (typeof (NSObject))]
	interface CPTTheme 
	{
		[Field ("kCPTDarkGradientTheme", "__Internal")]
		NSString DarkGradientTheme { get; }

		[Field ("kCPTPlainBlackTheme", "__Internal")]
		NSString PlainBlackTheme { get; }

		[Field ("kCPTPlainWhiteTheme", "__Internal")]
		NSString PlainWhiteTheme { get; }

		[Field ("kCPTSlateTheme", "__Internal")]
		NSString SlateTheme { get; }

		[Field ("kCPTStocksTheme", "__Internal")]
		NSString StocksTheme { get; }

		[Static]
		[Export ("registerTheme:")]
		void RegisterTheme (Class themeClass);

		[Static]
		[Export ("themeClasses")]
		Class [] ThemeClasses ();

		[Static]
		[Export ("themeNamed:")]
		CPTTheme ThemeNamed (NSString themeName);

		[Static]
		[Export ("name")]
		string Name ();

		[Export ("applyThemeToGraph:")]
		void ApplyThemeToGraph (CPTGraph graph);

		[Export ("newGraph")]
		NSObject NewGraph ();

		[Export ("applyThemeToBackground:")]
		void ApplyThemeToBackground (CPTGraph graph);

		[Export ("applyThemeToPlotArea:")]
		void ApplyThemeToPlotArea (CPTPlotAreaFrame plotAreaFrame);

		[Export ("applyThemeToAxisSet:")]
		void ApplyThemeToAxisSet (CPTAxisSet axisSet);
	}

	[BaseType (typeof (NSNumberFormatter))]
	interface CPTTimeFormatter 
	{
		[Export ("dateFormatter", ArgumentSemantic.Retain)]
		NSDateFormatter DateFormatter { get; set; }

		[Export ("referenceDate", ArgumentSemantic.Copy)]
		NSDate ReferenceDate { get; set; }

		[Export ("initWithDateFormatter:")]
		IntPtr Constructor (NSDateFormatter aDateFormatter);
	}

	interface ICPTTradingRangePlotDataSource { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTTradingRangePlotDataSource : CPTPlotDataSource 
	{
		[Export ("increaseFillsForTradingRangePlot:recordIndexRange:")]
		CPTFill [] IncreaseFills (CPTTradingRangePlot plot, NSRange indexRange);

		[Export ("increaseFillForTradingRangePlot:recordIndex:")]
		CPTFill IncreaseFill (CPTTradingRangePlot plot, uint recordIndex);

		[Export ("decreaseFillsForTradingRangePlot:recordIndexRange:")]
		CPTFill [] DecreaseFills (CPTTradingRangePlot plot, NSRange indexRange);

		[Export ("decreaseFillForTradingRangePlot:recordIndex:")]
		CPTFill DecreaseFill (CPTTradingRangePlot plot, uint recordIndex);

		[Export ("lineStylesForTradingRangePlot:recordIndexRange:")]
		CPTLineStyle [] GetLineStyles (CPTTradingRangePlot plot, NSRange indexRange);

		[Export ("lineStyleForTradingRangePlot:recordIndex:")]
		CPTLineStyle GetLineStyle (CPTTradingRangePlot plot, uint recordIndex);

		[Export ("increaseLineStylesForTradingRangePlot:recordIndexRange:")]
		CPTLineStyle [] IncreaseLineStyles (CPTTradingRangePlot plot, NSRange indexRange);

		[Export ("increaseLineStyleForTradingRangePlot:recordIndex:")]
		CPTLineStyle IncreaseLineStyle (CPTTradingRangePlot plot, uint recordIndex);

		[Export ("decreaseLineStylesForTradingRangePlot:recordIndexRange:")]
		CPTLineStyle [] DecreaseLineStyles (CPTTradingRangePlot plot, NSRange indexRange);

		[Export ("decreaseLineStyleForTradingRangePlot:recordIndex:")]
		CPTLineStyle DecreaseLineStyles (CPTTradingRangePlot plot, uint recordIndex);
	}

	interface ICPTTradingRangePlotDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CPTTradingRangePlotDelegate : CPTPlotDelegate 
	{
		[Export ("tradingRangePlot:barWasSelectedAtRecordIndex:")]
		void BarWasSelected (CPTTradingRangePlot plot, uint recordIndex);

		[Export ("tradingRangePlot:barWasSelectedAtRecordIndex:withEvent:")]
		void BarWasSelected (CPTTradingRangePlot plot, uint recordIndex, CPTNativeEvent theEvent);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTTradingRangePlot 
	{
		[Wrap ("WeakDataSource")][New]
		CPTTradingRangePlotDataSource DataSource { get; set; }

		[Wrap ("WeakDelegate")] [New]
		CPTTradingRangePlotDelegate Delegate { get; set; }

		[Export ("plotStyle", ArgumentSemantic.Assign)]
		CPTTradingRangePlotStyle PlotStyle { get; set; }

		[Export ("barWidth", ArgumentSemantic.Assign)]
		float BarWidth { get; set; }

		[Export ("stickLength", ArgumentSemantic.Assign)]
		float StickLength { get; set; }

		[Export ("barCornerRadius", ArgumentSemantic.Assign)]
		float BarCornerRadius { get; set; }

		[Export ("lineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle LineStyle { get; set; }

		[Export ("increaseLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle IncreaseLineStyle { get; set; }

		[Export ("decreaseLineStyle", ArgumentSemantic.Copy)]
		CPTLineStyle DecreaseLineStyle { get; set; }

		[Export ("increaseFill", ArgumentSemantic.Copy)]
		CPTFill IncreaseFill { get; set; }

		[Export ("decreaseFill", ArgumentSemantic.Copy)]
		CPTFill DecreaseFill { get; set; }
	}

	[BaseType (typeof (CPTAxis))]
	interface CPTXYAxis 
	{
		[Export ("orthogonalCoordinateDecimal")]
		NSDecimal OrthogonalCoordinateDecimal { get; set; }

		[Export ("axisConstraints", ArgumentSemantic.Retain)]
		CPTConstraints AxisConstraints { get; set; }
	}

	[BaseType (typeof (CPTAxisSet))]
	interface CPTXYAxisSet 
	{
		[Export ("xAxis", ArgumentSemantic.Retain)]
		CPTXYAxis XAxis { get; }

		[Export ("yAxis", ArgumentSemantic.Retain)]
		CPTXYAxis YAxis { get; }
	}

	[BaseType (typeof (CPTGraph))]
	interface CPTXYGraph 
	{
		[Export ("initWithFrame:xScaleType:yScaleType:")]
		IntPtr Constructor (RectangleF newFrame, CPTScaleType newXScaleType, CPTScaleType newYScaleType);
	}

	[BaseType (typeof (CPTPlotSpace))]
	interface CPTXYPlotSpace 
	{
		[Export ("xRange", ArgumentSemantic.Copy)]
		CPTPlotRange XRange { get; set; }

		[Export ("yRange", ArgumentSemantic.Copy)]
		CPTPlotRange YRange { get; set; }

		[Export ("globalXRange", ArgumentSemantic.Copy)]
		CPTPlotRange GlobalXRange { get; set; }

		[Export ("globalYRange", ArgumentSemantic.Copy)]
		CPTPlotRange GlobalYRange { get; set; }

		[Export ("xScaleType", ArgumentSemantic.Assign)]
		CPTScaleType XScaleType { get; set; }

		[Export ("yScaleType", ArgumentSemantic.Assign)]
		CPTScaleType YScaleType { get; set; }

		[Export ("allowsMomentum", ArgumentSemantic.Assign)]
		bool AllowsMomentum { get; set; }

		[Export ("elasticGlobalXRange", ArgumentSemantic.Assign)]
		bool ElasticGlobalXRange { get; set; }

		[Export ("elasticGlobalYRange", ArgumentSemantic.Assign)]
		bool ElasticGlobalYRange { get; set; }
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTGridLines 
	{
		[Export ("axis", ArgumentSemantic.Assign)]
		CPTAxis Axis { get; set; }

		[Export ("major", ArgumentSemantic.Assign)]
		bool Major { get; set; }
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTGraph 
	{
		[Export ("hostingView", ArgumentSemantic.Assign)]
		CPTGraphHostingView HostingView { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("titleTextStyle", ArgumentSemantic.Copy)]
		CPTTextStyle TitleTextStyle { get; set; }

		[Export ("titleDisplacement", ArgumentSemantic.Assign)]
		PointF TitleDisplacement { get; set; }

		[Export ("titlePlotAreaFrameAnchor", ArgumentSemantic.Assign)]
		CPTRectAnchor TitlePlotAreaFrameAnchor { get; set; }

		[Export ("axisSet", ArgumentSemantic.Retain)]
		CPTAxisSet AxisSet { get; set; }

		[Export ("plotAreaFrame", ArgumentSemantic.Retain)]
		CPTPlotAreaFrame PlotAreaFrame { get; set; }

		[Export ("defaultPlotSpace", ArgumentSemantic.Retain)]
		CPTPlotSpace DefaultPlotSpace { get; }

		[Export ("topDownLayerOrder", ArgumentSemantic.Retain)]
		NSNumber [] TopDownLayerOrder { get; set; }

		[Export ("legent", ArgumentSemantic.Retain)]
		CPTLegend Legend { get; set; }

		[Export ("legendAnchor", ArgumentSemantic.Assign)]
		CPTRectAnchor LegendAnchor { get; set; }

		[Export ("legendDisplacement", ArgumentSemantic.Assign)]
		PointF LegendDisplacement { get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("reloadDataIfNeeded")]
		void ReloadDataIfNeeded ();

		[Export ("allPlots")]
		CPTPlot [] AllPlots { get; }

		[Export ("plotAtIndex:")]
		CPTPlot PlotAt (int index);

		[Export ("plotWithIdentifier:")]
		CPTPlot PlotWithIdentifier (NSObject identifier);

		[Export ("addPlot:"), PostGet ("AllPlots")]
		void AddPlot (CPTPlot plot);

		[Export ("addPlot:toPlotSpace:"), PostGet ("AllPlots")]
		void AddPlot (CPTPlot plot, CPTPlotSpace toPlotSpace);

		[Export ("removePlot:"), PostGet ("AllPlots")]
		void RemovePlot (CPTPlot plot);

		[Export ("removePlotWithIdentifier:"), PostGet ("AllPlots")]
		void RemovePlot (NSObject identifier);

		[Export ("insertPlot:atIndex:"), PostGet ("AllPlots")]
		void InsertPlot (CPTPlot plot, uint index);

		[Export ("insertPlot:atIndex:intoPlotSpace:"), PostGet ("AllPlots")]
		void InsertPlot (CPTPlot plot, uint index, CPTPlotSpace intoPlotSpace);

		[Export ("allPlotSpaces")]
		CPTPlotSpace [] PlotSpaces { get; }

		[Export ("plotSpaceAtIndex:")]
		CPTPlotSpace PlotSpaceAt (uint index);

		[Export ("plotSpaceWithIdentifier:")]
		CPTPlotSpace PlotSpaceWithIdentifier (NSObject identifier);

		[Export ("addPlotSpace:"), PostGet ("PlotSpaces")]
		void AddPlotSpace (CPTPlotSpace space);

		[Export ("removePlotSpace:"), PostGet ("PlotSpaces")]
		void RemovePlotSpace (CPTPlotSpace plotSpace);

		[Export ("applyTheme:")]
		void ApplyTheme (CPTTheme theme);

		[Export ("newPlotSpace")]
		CPTPlotSpace NewPlotSpace ();

		[Export ("newAxisSet")]
		CPTAxisSet NewAxisSet ();
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTGridLineGroup 
	{
		[Export ("plotArea", ArgumentSemantic.Assign)]
		CPTPlotArea PlotArea { get; set; }

		[Export ("major", ArgumentSemantic.Assign)]
		bool Major { get; set; }
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTPlotGroup 
	{
		[Export ("addPlot:")]
		void AddPlot (CPTPlot plot);

		[Export ("removePlot:")]
		void RemovePlot (CPTPlot plot);

		[Export ("insertPlot:atIndex:")]
		void InsertPlot (CPTPlot plot, uint index);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAxisLabelGroup 
	{

	}
}