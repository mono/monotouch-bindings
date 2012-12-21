//
// coreplot.cs: API binding to the CorePlot library
//
// TODO: events for CPTAxis
//
// Author:
//   Miguel de Icaza
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
using CPTNativeImage = UIImage;
using CPTNativeEvent = UIEvent;
#else
using MonoMac.AppKit;
using CPTNativeImage = NSImage;
using CPTNativeEvent = NSEvent;
#endif

namespace MonoMac.CorePlot {

	[BaseType (typeof (NSObject))]
	interface CPTAnnotation {
		[Export ("contentLayer")]
		CPTLayer ContentLayer { get; set; }

		[Export ("annotationHostLayer")]
		CPTAnnotationHostLayer AnnotationHostLayer { get; set; }

		[Export ("contentAnchorPoint")]
		PointF ContentAnchorPoint { get; set; }

		[Export ("displacement")]
		PointF Displacement { get; set; }

		[Export ("rotation")]
		float Rotation { get; set; }

		[Export ("positionContentLayer")]
		void PositionContentLayer ();
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAnnotationHostLayer {
		[Export ("annotations")]
		CPTAnnotation [] Annotations { get; }

		[Export ("addAnnotation:"), PostGet ("Annotations")]
		void Add (CPTAnnotation annotation);

		[Export ("removeAnnotation:"), PostGet ("Annotations")]
		void Remove (CPTAnnotation annotation);

		[Export ("removeAllAnnotations"), PostGet ("Annotations")]
		void RemoveAll ();
	}


	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTAxisDelegate {
		[Abstract, DelegateName ("CPTAxisPredicate"), DefaultValue (false)]
		[Export ("axisShouldRelabel:")]
		bool AxisShouldRelabel (CPTAxis axis);

		[Abstract, DelegateName ("CPTAxisPredicate")]
		[Export ("axisDidRelabel:")]
		void AxisDidRelabel (CPTAxis axis);

		[DelegateName ("CPTAxisNSSetPredicate"), DefaultValue (false)]
		[Export ("axis:shouldUpdateAxisLabelsAtLocations:")]
		bool ShouldUpdateAxisLablesAtLocations (CPTAxis axis, NSSet locations);

		[DelegateName ("CPTAxisPredicate"), DefaultValue (false)]
		[Export ("axis:shouldUpdateMinorAxisLabelsAtLocations:")]
		bool ShouldUpdateMinorAxisLablesAtLocations (CPTAxis axis, NSSet locations);
		
	}

	[BaseType (typeof (CPTLayer), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (CPTAxisDelegate)})]
	interface CPTAxis {
		[Export ("delegates"), NullAllowed, New]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate"), New]
		CPTAxisDelegate Delegate { get; set; }

		[Export ("axisLineStyle")]
		CPTLineStyle AxisLineStyle { get; set;  }

		[Export ("coordinate")]
		CPTCoordinate Coordinate { get; set;  }

		[Export ("labelingOrigin")]
		NSDecimal LabelingOrigin { get; set;  }

		[Export ("titleLocation")]
		NSDecimal TitleLocation { get; set;  }

		[Export ("defaultTitleLocation")]
		NSDecimal DefaultTitleLocation { get;  }

		[Export ("majorIntervalLength")]
		NSDecimal MajorIntervalLength { get; set;  }

		[Export ("tickDirection")]
		CPTSign TickDirection { get; set;  }

		[Export ("visibleAxisRange")]
		CPTPlotRange VisibleAxisRange { get; set; }

		[Export ("visibleRange")]
		CPTPlotRange VisibleRange { get; set;  }

		[Export ("titleTextStyle")]
		CPTTextStyle TitleTextStyle { get; set;  }

		[Export ("axisTitle")]
		CPTAxisTitle AxisTitle { get; set;  }

		[Export ("titleOffset")]
		float TitleOffset { get; set;  }

		[Export ("title")]
		string Title { get; set;  }

		[Export ("titleRotation")]
		float TitleRotation { get; set; }
		
		[Export ("labelingPolicy")]
		CPTAxisLabelingPolicy LabelingPolicy { get; set;  }

		[Export ("labelOffset")]
		float LabelOffset { get; set;  }

		[Export ("minorTickLabelOffset")]
		float MinorTickLabelOffset { get; set; }
		
		[Export ("minorTickLabelRotation")]
		float MinorTickLabelRotation { get; set; }

		[Export ("minorTickLabelAlignment")]
		CPTAlignment MinorTickLabelAlignment { get; set; }

		[Export ("minorTickLabelTextStyle")]
		CPTTextStyle MinorTickLabelTextStyle { get; set; }

		[Export ("minorTickLabelFormatter")]
		NSNumberFormatter MinorTickLabelFormatter { get; set; }
		
		[Export ("minorTickAxisLabels")]
		NSSet MinorTickAxisLabels { get; set; }

		[Export ("labelRotation")]
		float LabelRotation { get; set;  }

		[Export ("labelAlignment")]
		CPTAlignment LabelAlignment { get; set;  }

		[Export ("labelTextStyle")]
		CPTTextStyle LabelTextStyle { get; set;  }

		[Export ("labelFormatter")]
		/*NSNumberFormatter*/ NSObject LabelFormatter { get; set;  }

		[Export ("axisLabels")]
		NSSet AxisLabels { get; set;  }

		[Export ("needsRelabel")]
		bool NeedsRelabel { get;  }

		[Export ("labelExclusionRanges")]
		NSObject [] LabelExclusionRanges { get; set;  }

		[Export ("majorTickLength")]
		float MajorTickLength { get; set;  }

		[Export ("majorTickLineStyle")]
		CPTLineStyle MajorTickLineStyle { get; set;  }

		[Export ("majorTickLocations")]
		NSSet MajorTickLocations { get; set;  }

		[Export ("preferredNumberOfMajorTicks")]
		int PreferredNumberOfMajorTicks { get; set;  }

		[Export ("minorTicksPerInterval")]
		int MinorTicksPerInterval { get; set;  }

		[Export ("minorTickLength")]
		float MinorTickLength { get; set;  }

		[Export ("minorTickLineStyle")]
		CPTLineStyle MinorTickLineStyle { get; set;  }

		[Export ("minorTickLocations")]
		NSSet MinorTickLocations { get; set;  }

		[Export ("majorGridLineStyle")]
		CPTLineStyle MajorGridLineStyle { get; set;  }

		[Export ("minorGridLineStyle")]
		CPTLineStyle MinorGridLineStyle { get; set;  }

		[Export ("gridLinesRange")]
		CPTPlotRange GridLinesRange { get; set;  }

		[Export ("alternatingBandFills")]
		NSObject AlternatingBandFills { get; set;  }

		[Export ("backgroundLimitBands")]
		CPTLimitBand [] BackgroundLimitBands { get;  }

		[Export ("plotSpace")]
		CPTPlotSpace PlotSpace { get; set;  }

		[Export ("separateLayers")]
		bool SeparateLayers { get; set;  }

		[Export ("plotArea")]
		CPTPlotArea PlotArea { get; set;  }

		[Export ("minorGridLines")]
		CPTGridLines MinorGridLines { get;  }

		[Export ("majorGridLines")]
		CPTGridLines MajorGridLines { get;  }

		[Export ("axisSet")]
		CPTAxisSet AxisSet { get;  }

		[Export ("relabel")]
		void Relabel ();

		[Export ("setNeedsRelabel")]
		void SetNeedsRelabel ();

		[Export ("filteredMajorTickLocations:")]
		NSSet FilteredMajorTickLocations (NSSet allLocations);

		[Export ("filteredMinorTickLocations:")]
		NSSet FilteredMinorTickLocations (NSSet allLocations);

		[Export ("addBackgroundLimitBand:"), PostGet ("BackgroundLimitBands")]
		void AddBackgroundLimitBand (CPTLimitBand limitBand);

		[Export ("removeBackgroundLimitBand:"), PostGet ("BackgroundLimitBands")]
		void RemoveBackgroundLimitBand (CPTLimitBand limitBand);

		[Export ("viewPointForCoordinateDecimalNumber:")]
		PointF ViewPointForCoordinateDecimalNumber (NSDecimal coordinateDecimalNumber);

		[Export ("drawGridLinesInContext:isMajor:")]
		void DrawGridLines (CGContext context, bool major);

		[Export ("drawBackgroundBandsInContext:")]
		void DrawBackgroundBands (CGContext context);

		[Export ("drawBackgroundLimitsInContext:")]
		void DrawBackgroundLimits (CGContext context);
	}

	[BaseType (typeof (NSObject))]
	interface CPTAxisLabel {
		[Export ("contentLayer")]
		CPTLayer ContentLayer { get; set;  }

		[Export ("offset")]
		float Offset { get; set;  }

		[Export ("rotation")]
		float Rotation { get; set;  }

		[Export ("alignment")]
		CPTAlignment Alignment { get; set;  }

		[Export ("tickLocation")]
		NSDecimal TickLocation { get; set;  }

		[Export ("initWithText:textStyle:")]
		IntPtr Constructor (string newText, CPTTextStyle style);

		[Export ("initWithContentLayer:")]
		IntPtr Constructor (CPTLayer layer);

		[Export ("positionRelativeToViewPoint:forCoordinate:inDirection:")]
		void ComputePositionRelative (PointF viewPoint, CPTCoordinate forCoordinate, CPTSign inDirection);

		[Export ("positionBetweenViewPoint:andViewPoint:forCoordinate:inDirection:")]
		void ComputePositionBetween (PointF firstPoint, PointF secondPoint, CPTCoordinate coordinate, CPTSign direction);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAxisLabelGroup {
	}

	[BaseType (typeof (CPTAxisLabel))]
	interface CPTAxisTitle {
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTAxisSet {
		[Export ("axes")]
		CPTAxis [] Axes { get; set;  }

		[Export ("borderLineStyle")]
		CPTLineStyle BorderLineStyle { get; set;  }

		[Export ("relabelAxes")]
		void RelabelAxes ();

		[Export ("axisForCoordinate:atIndex:")]
		
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTBarPlot {
		[Export ("barWidthsAreInViewCoordinates")]
		bool BarWidthsAreInViewCoordinates { get; set; }
		
		[Export ("barWidth")]
		NSDecimal BarWidth { get; set;  }

		[Export ("barOffset")]
		NSDecimal BarOffset { get; set;  }

		[Export ("barCornerRadius")]
		float BarCornerRadius { get; set;  }

		[Export ("lineStyle")]
		CPTLineStyle LineStyle { get; set;  }

		[Export ("barBaseCornerRadius")]
		flaot BarBaseCornerRadius { get; set; }
		
		[Export ("fill")]
		CPTFill Fill { get; set;  }

		[Export ("barsAreHorizontal")]
		bool BarsAreHorizontal { get; set;  }

		[Export ("baseValue")]
		NSDecimal BaseValue { get; set;  }

		[Export ("barBaseVary")]
		bool BarBaseVary { get; set; }

		[Export ("plotRange")]
		CPTPlotRange PlotRange { get; set;  }

		[Export ("barLabelOffset")]
		float BarLabelOffset { get; set;  }

		[Export ("barLabelTextStyle")]
		CPTTextStyle BarLabelTextStyle { get; set;  }

		[Static]
		[Export ("tubularBarPlotWithColor:horizontalBars:")]
		CPTBarPlot CreateTubularBarPlot (CPTColor color, bool horizontalBars);

#if false
		[Field ("CPTBarPlotBindingBarLocations", "__Internal")]
		NSString BindingBarLocations { get; }

		[Field ("CPTBarPlotBindingBarTips", "__Internal")]
		NSString BindingBarTips { get; }

		[Field ("CPTBarPlotBindingBarBases", "__Internal")]
		NSString BindingBarBases { get; }

		[Field ("CPTBarPlotBindingBarFills", "__Internal")]
		NSString BindingBarFills { get; }

		[Field ("CPTBarPlotBindingBarLineStyles", "__Internal")]
		NSString BindingBarLineStyles { get; }
#endif

		[Export ("plotRangeEnclosingBars")]
		CPTPlotRange PlotRangeEnclosingBars ();
	}

	[BaseType (typeof (CPTPlotDataSource))]
	[Model]
	interface CPTBarPlotDataSource {
		[Export ("barFillForBarPlot:recordIndex:")]
		CPTFill GetBarFill (CPTBarPlot barPlot, int recordIndex);

		[Export ("barFillsForBarPlot:recordIndexRange:")]
		CPTFill [] GetBarFills (CPTBarPlot barPlot, NSRange recordIndexRange);

		[Export ("legendTitleForBarPlot:recordIndex:")]
		string GetLegentTitle (CPTBarPlot barPlot, int recordIndex);

		[Export ("barFillForBarPlot:recordIndex:")]
		CPTFill GetBarFill (CPTBarPlot barPlot, int recordIndex);

		[Export ("barLineStylesForBarPlot:recordIndexRange:")]
		CPTLineStyle [] GetBarLineStyles (CPTBarPlot barPlot, NSRange recordIndexRange);

		[Export ("barLineStyleForBarPlot:recordIndex:")]
		CPTLineStyle GetBarLineStyle (CPTBarPlot barPlot, int recordIndex);

		
	}

	[BaseType (typeof (CPTPlotSpaceDelegate))]
	[Model]
	interface CPTBarPlotDelegate {
		[Export ("barPlot:barWasSelectedAtRecordIndex:")]
		void BarSelected (CPTBarPlot plot, int recordIndex);

		[Export ("barPlot:barWasSelectedAtRecordIndex:withEvent:")]
		void BarSelected (CPTBarPlot plot, int recordIndex, CPTNativeEvent evt);
	}
	
	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTBorderedLayer {
		[Export ("borderLineStyle")]
		CPTLineStyle BorderLineStyle { get; set; }

		[Export ("fill")]
		CPTFill Fill { get; set; }

		[Export ("inLayout")]
		bool InLayout { get; set; }

		[Export ("renderBorderedLayer:asVectorInContext:")]
		void RenderBorderedLayer (CPTBorderedLayer layer, CGContext asVectorContext);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTBorderLayer {
		[Export ("maskedLayer")]
		CPTBorderedLayer BorderedLayer { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	interface CPTColor {
		[Export ("cgColor")]
		CGColor CGColor { get;  }

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
	interface CPTColorSpace {
		[Export ("cgColorSpace")]
		CGColorSpace ColorSpace { get; }

		[Static,Export ("genericRGBSpace")]
		CPTColorSpace GenericRGBSpace { get; }

		[Export ("initWithCGColorSpace:")]
		IntPtr Constructor (CGColorSpace colorSpace);
	}
		
	[BaseType (typeof (NSObject))]
	interface CPTConstrainedPosition {
		[Export ("position")]
		float Position { get; set;  }

		[Export ("lowerBound")]
		float LowerBound { get; set;  }

		[Export ("upperBound")]
		float UpperBound { get; set;  }

		//[Export ("constraints")]
		//CPTConstraints Constraints { get; set;  }

		[Export ("initWithPosition:lowerBound:upperBound:")]
		IntPtr Constructor (float newPosition, float newLowerBound, float newUpperBound);

		[Export ("initWithAlignment:lowerBound:upperBound:")]
		IntPtr Constructor (CPTAlignment newAlignment, float newLowerBound, float newUpperBound);

		[Export ("adjustPositionForOldLowerBound:oldUpperBound:")]
		void AdjustPosition (float oldLowerBound, float oldUpperBound);
	}
	
	[BaseType (typeof (NSObject))]
	interface CPTFill {
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

		[Export ("fillRect:inContext:")]
		void FillRect (RectangleF theRect, CGContext inContext);

		[Export ("fillPathInContext:")]
		void FillPath (CGContext inContext);
	}

	[BaseType (typeof (NSObject))]
	interface CPTGradient {
		[Export ("blendingMode")]
		CPTGradientBlendingMode BlendingMode { get;  }

		[Export ("angle")]
		float Angle { get; set;  }

		[Export ("gradientType")]
		CPTGradientType GradientType { get; set;  }

		[Static]
		[Export ("gradientWithBeginningColor:endingColor:")]
		CPTGradient Create (CPTColor beginningColor, CPTColor endingColor);

		[Static]
		[Export ("gradientWithBeginningColor:endingColor:beginningPosition:endingPosition:")]
		CPTGradient Create  (CPTColor beginningColor, CPTColor endingColor, float beginningPosition, float endingPosition);

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

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTGraph {
		[Export ("title")]
		string Title { get; set;  }

		[Export ("titleTextStyle")]
		CPTMutableTextStyle TitleTextStyle { get; set;  }

		[Export ("titleDisplacement")]
		PointF TitleDisplacement { get; set;  }

		[Export ("titlePlotAreaFrameAnchor")]
		CPTRectAnchor TitlePlotAreaFrameAnchor { get; set;  }

		[Export ("axisSet")]
		CPTAxisSet AxisSet { get; set;  }

		[Export ("plotAreaFrame")]
		CPTPlotAreaFrame PlotAreaFrame { get; set;  }

		[Export ("defaultPlotSpace")]
		CPTPlotSpace DefaultPlotSpace { get;  }

		[Export ("topDownLayerOrder")]
		NSNumber [] TopDownLayerOrder { get; set;  }

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
		void InsertPlot (CPTPlot plot, int index);

		[Export ("insertPlot:atIndex:intoPlotSpace:"), PostGet ("AllPlots")]
		void InsertPlot (CPTPlot plot, int index, CPTPlotSpace intoPlotSpace);

		[Export ("allPlotSpaces")]
		CPTPlotSpace [] PlotSpaces { get; }

		[Export ("plotSpaceAtIndex:")]
		CPTPlotSpace PlotSpaceAt (int index);

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

		[Export ("legent")]
		CPTLegend Legend { get; set; }

		[Export ("legendAnchor")]
		CPTRectAnchor LegendAnchor { get; set; }

		[Export ("legendDisplacement")]
		PointF LegendDisplacement { get; set; }

		[Export ("hostingView")]
		CPTGraphHostingView HostingView { get; set; }
	}
	
	[BaseType (typeof (CPTLayer))]
	interface CPTGridLineGroup {
		[Export ("plotArea")]
		CPTPlotArea PlotArea { get; set;  }

		[Export ("major")]
		bool Major { get; set;  }
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTGridLines {
		[Export ("axis")]
		CPTAxis Axis { get; set;  }

		[Export ("major")]
		bool Major { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface CPTImage {
		[Export ("image")]
		CGImage Image { get; set;  }

		[Export ("tiled")]
		bool Tiled { [Bind ("isTiled")] get; set;  }

		[Export ("tileAnchoredToContext")]
		bool TileAnchoredToContext { get; set;  }

		[Static]
		[Export ("imageWithCGImage:")]
		CPTImage FRomCGImage (CGImage anImage);

		[Static]
		[Export ("imageForPNGFile:")]
		CPTImage FromPngFile (string path);

		[Export ("initWithCGImage:")]
		IntPtr Constructor (CGImage anImage);

		[Export ("initForPNGFile:")]
		IntPtr Constructor (string path);

		[Export ("drawInRect:inContext:")]
		void Draw (RectangleF rect, CGContext context);
	}

	[BaseType (typeof (CALayer))]
	interface CPTLayer {
		[Export ("CPTGraph")]
		CPTGraph Graph { get; set;  }

		[Export ("paddingLeft")]
		float PaddingLeft { get; set;  }

		[Export ("paddingTop")]
		float PaddingTop { get; set;  }

		[Export ("paddingRight")]
		float PaddingRight { get; set;  }

		[Export ("paddingBottom")]
		float PaddingBottom { get; set;  }

		[Export ("useFastRendering")]
		bool UseFastRendering { get;  }

		[Export ("masksToBorder")]
		bool MasksToBorder { get; set;  }

		[Export ("outerBorderPath")]
		CGPath OuterBorderPath { get; set;  }

		[Export ("innerBorderPath")]
		CGPath InnerBorderPath { get; set;  }

		[Export ("maskingPath")]
		CGPath Maskingpath { get;  }

		[Export ("sublayerMaskingPath")]
		CGPath SublayerMaskingPath { get;  }

		[Export ("identifier")]
		NSObject Identifier { get; set; }

		[Export ("logLayers")]
		void LogLayers ();

		[Export ("contentsScale")]
		float ContentsScale { get; set; }

		[Export ("layoutManager")]
		CPTLayoutManager LayoutManager { get; set;  }

		[Export ("sublayersExcludedFromAutomaticLayout")]
		NSSet SublayersExcludedFromAutomaticLayout { get;  }

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

		[Static]
		[Export ("defaultZPosition")]
		float DefaultZPosition { get; }

		[Export ("pixelAlign")]
		void PixelAlign ();

#if MONOTOUCH
		[Export ("uiColor")]
		UIColor Color { get; }

		[Export ("imageOfLayer")]
		UIImage GetImageOfLayer ();

#else
		[Export ("nsColor")]
		NSColor Color { get; }

		[Export ("imageOfLayer")]
		NSImage GetImageOfLayer ();
#endif
		//
		// From CPTResponder
		//
		[Export ("pointingDeviceDownEvent:atPoint:")]
		bool PointingDeviceDown (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceUpEvent:atPoint:")]
		bool PointingDeviceUp (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceDraggedEvent:atPoint:")]
		bool PointingDeviceDragged (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceCancelledEvent:")]
		bool PointingDeviceCancelledEvent (NSObject theEvent);
		
	}

	[BaseType (typeof (CPTAnnotation))]
	interface CPTLayerAnnotation {
		[Export ("anchorLayer")]
		CPTLayer AnchorLayer { get; }

		[Export ("rectAnchor")]
		CPTRectAnchor RectAnchor { get; set; }

		[Export ("initWithAnchorLayer:")]
		IntPtr Constructor (CPTLayer anchorLayer);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTLayoutManager {
		[Export ("invalidateLayoutOfLayer:")]
		void InvalidateLayoutOfLayer (CALayer layer);

		[Export ("layoutSublayersOfLayer:")]
		void LayoutSublayersOfLayer (CALayer layer);

		[Export ("preferredSizeOfLayer:")]
		SizeF PreferredSizeOfLayer (CALayer layer);

		[Export ("minimumSizeOfLayer:")]
		SizeF MinimumSizeOfLayer (CALayer layer);

		[Export ("maximumSizeOfLayer:")]
		SizeF MaximumSizeOfLayer (CALayer layer);
	}

	[BaseType (typeof (NSObject))]
	interface CPTLimitBand {
		[Export ("range")]
		CPTPlotRange Range { get; set;  }

		[Export ("fill")]
		CPTFill Fill { get; set;  }

		[Static]
		[Export ("limitBandWithRange:fill:")]
		CPTLimitBand FromRange (CPTPlotRange newRange, CPTFill newFill);

		[Export ("initWithRange:fill:")]
		IntPtr Constructor (CPTPlotRange newRange, CPTFill newFill);
	}

	[BaseType (typeof (NSObject))]
	interface CPTLineStyle {
		[Export ("lineCap")]
		CGLineCap LineCap { get; set; }

		[Export ("lineJoin")]
		CGLineJoin LineJoin { get; set; }

		[Export ("miterLimit")]
		float MiterLimit { get; set; }

		[Export ("lineWidth")]
		float LineWidth { get; set; }

		[Export ("dashPattern")]
		NSArray DashPattern { get; set; }

		[Export ("patternPhase")]
		float PatternPhase { get; set; }

		[Export ("lineColor")]
		CPTColor LineColor { get; set; }

		[Export ("lineFill")]
		CPTFill LineFill { get; set; }

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

	[BaseType (typeof (CPTLayer))]
	interface CPTMaskLayer {
	}
	
	[BaseType (typeof (NSObject))]
	interface CPTMutableLineStyle {
	}

	[BaseType (typeof (NSObject))]
	interface CPTNumericData {
		[Export ("data")]
		NSData Data { get;  }

		[Export ("void")]
		IntPtr Bytes { get;  }

		[Export ("length")]
		int Length { get;  }

		[Export ("dataType")]
		/*CPTNumericDataType*/ IntPtr DataType { get;  }

		[Export ("dataTypeFormat")]
		CPTDataTypeFormat DataTypeFormat { get;  }

		[Export ("sampleBytes")]
		IntPtr SampleBytes { get;  }

		[Export ("byteOrder")]
		int ByteOrder { get;  }

		[Export ("shape")]
		NSNumber [] Shape { get;  }

		[Export ("numberOfDimensions")]
		int NumberOfDimensions { get;  }

		[Export ("numberOfSamples")]
		int NumberOfSamples { get;  }

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

		[Export ("samplePointer:")]
		void SamplePointer (int sample);

		[Export ("sampleValue:")]
		NSNumber SampleValue (int sample);

		[Export ("sampleArray")]
		NSObject [] SampleArray ();
	}

	[BaseType (typeof (CPTNumericData))]
	interface CPTMutableNumericData {
		[Export ("mutableBytes")]
		IntPtr MutableBytes { get;  }

		[Export ("shape")]
		NSNumber [] Shape { get; set;  }

#if false

// Removed from 1.1

		[Static]
		[Export ("numericDataWithData:dataType:shape:")]
		CPTMutableNumericData FromData (NSData newData, /* CPTNumericDataType */ IntPtr newDataType, NSNumber [] shapeArray);

		[Static]
		[Export ("numericDataWithData:dataTypeString:shape:")]
		CPTMutableNumericData FromData (NSData newData, string newDataTypeString, NSNumber [] shapeArray);

		[Export ("initWithData:dataType:shape:")]
		IntPtr Constructor (NSData newData, /*CPTNumericDataType*/ IntPtr newDataType, NSNumber [] shapeArray);
#endif
	}


	[BaseType (typeof (CPTPlotDataSource))]
	[Model]
	interface CPTPieChartDataSource {
		[Export ("sliceFillForPieChart:recordIndex:")]
		CPTFill GetSliceFill (CPTPieChart pieChart, int recordIndex);

		[Export ("sliceLabelForPieChart:recordIndex:")]
		CPTTextLayer GetSliceLabel (CPTPieChart pieChart, int recordIndex);

		[Export ("radialOffsetForPieChart:recordIndex:")]
		float GetRaidlOffset (CPTPieChart pieChart, int recordIndex);

		[Export ("legendTitleForPieChart:recordIndex:")]
		string GetLegendTitle (CPTPieChart pieChart, int recordIndex);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTPieChartDelegate {
		[Abstract]
		[Export ("pieChart:sliceWasSelectedAtRecordIndex:")]
		[EventArgs ("CPTPieChartSliceSelected")]
		void SliceSelected (CPTPieChart plot, int recordIndex);

	}

	[BaseType (typeof (CPTPlot), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (CPTPieChartDelegate)})]
	interface CPTPieChart {
		[Export ("pieRadius")]
		float PieRadius { get; set;  }

		[Export ("sliceLabelOffset")]
		float SliceLabelOffset { get; set;  }

		[Export ("startAngle")]
		float StartAngle { get; set;  }

		[Export ("sliceDirection")]
		CPTPieDirection SliceDirection { get; set;  }

		[Export ("centerAnchor")]
		PointF CenterAnchor { get; set;  }

		[Export ("borderLineStyle")]
		CPTLineStyle BorderLineStyle { get; set;  }

		[Export ("pieInnerRadius")]
		float PieInnerRadius { get; set; }

		[Export ("overlayFill")]
		CPTFill OverlayFill { get; set; }
		
		[Static]
		[Export ("defaultPieSliceColorForIndex:")]
		CPTColor DefaultPieSliceColorForIndex (int pieSliceIndex);
	}

	[BaseType (typeof (NSObject))]
	[Model][Abstract]
	interface CPTPlotDataSource {
		[Export ("numberOfRecordsForPlot:")]
		int NumberOfRecordsForPlot (CPTPlot plot);

		[Export ("numbersForPlot:field:recordIndexRange:")]
		NSNumber [] NumbersForPlot (CPTPlot forPlot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("numberForPlot:field:recordIndex:")]
		NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, int index);

		[Export ("doublesForPlot:field:recordIndexRange:")]
		IntPtr DoublesForPlot (CPTPlot plot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("doubleForPlot:field:recordIndex:")]
		double DoubleForPlot (CPTPlot plot, CPTPlotField forFieldEnum, int index);

		[Export ("dataForPlot:field:recordIndexRange:")]
		CPTNumericData DataForPlot (CPTPlot plot, CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("recordIndexRangeForPlot:plotRange:")]
		NSRange RecordIndexRange (CPTPlot forPlot, CPTPlotRange plotRange);

		[Export ("dataLabelForPlot:recordIndex:")]
		CPTLayer DataLabelForPlot (CPTPlot plot, int recordIndex);
	}

	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTPlot {
		[Export ("dataSource"), NullAllowed]
		CPTPlotDataSource DataSource { get; set;  }

		[Export ("identifier")]
		NSObject Identifier { get; set;  }

		[Export ("title")]
		string Title { get; set; }
		
		[Export ("plotSpace")]
		CPTPlotSpace PlotSpace { get; set;  }

		[Export ("plotArea")]
		CPTPlotArea PlotArea { get;  }

		[Export ("dataNeedsReloading")]
		bool DataNeedsReloading { get;  }

		[Export ("cachedDataCount")]
		int CachedDataCount { get;  }

		[Export ("doublePrecisionCache")]
		bool DoublePrecisionCache { get;  }

		[Export ("cachePrecision")]
		CPTPlotCachePrecision CachePrecision { get; set;  }

		[Export ("doubleDataType")]
		/*CPTNumericDataType*/ IntPtr DoubleDataType { get;  }

		[Export ("decimalDataType")]
		/* CPTNumericDataType*/ IntPtr DecimalDataType { get;  }

		[Export ("needsRelabel")]
		bool NeedsRelabel { get;  }

		[Export ("labelOffset")]
		float LabelOffset { get; set;  }

		[Export ("labelRotation")]
		float LabelRotation { get; set;  }

		[Export ("labelField")]
		int LabelField { get; set;  }

		[Export ("labelTextStyle")]
		CPTMutableTextStyle LabelTextStyle { get; set;  }

		[Export ("labelFormatter")]
		NSObject /* NSNumberFormatter */ LabelFormatter { get; set;  }


		[Export ("setNeedsRelabel")]
		void SetNeedsRelabel ();

		[Export ("relabel")]
		void Relabel ();

		[Export ("relabelIndexRange:")]
		void RelabelIndexRange (NSRange indexRange);

		[Export ("setDataNeedsReloading")]
		void SetDataNeedsReloading ();

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("reloadDataIfNeeded")]
		void ReloadDataIfNeeded ();

		[Export ("reloadDataInIndexRange:")]
		void ReloadDataInIndexRange (NSRange indexRange);

		[Export ("insertDataAtIndex:numberOfRecords:")]
		void InsertData (int index, int numberOfRecords);

		[Export ("deleteDataInIndexRange:")]
		void DeleteData (NSRange indexRange);

		[Export ("numbersFromDataSourceForField:recordIndexRange:")]
		NSObject NumbersFromDataSource (CPTPlotField forFieldEnum, NSRange indexRange);

		[Export ("cachedNumbersForField:")]
		CPTMutableNumericData CachedNumbersForField (CPTPlotField forFieldEnum);

		[Export ("cachedNumberForField:recordIndex:")]
		NSNumber CachedNumberForField (CPTPlotField forFieldEnum, int index);

		[Export ("cachedDoubleForField:recordIndex:")]
		double CachedDoubleForField (CPTPlotField forFieldEnum, int index);

		[Export ("cachedDecimalForField:recordIndex:")]
		NSDecimal CachedDecimalForField (CPTPlotField forFieldEnum, int index);

		[Export ("cacheNumbers:forField:")]
		void CacheNumbers (NSObject numbers, CPTPlotField forFieldEnum);

		[Export ("cacheNumbers:forField:atRecordIndex:")]
		void CacheNumbers (NSObject numbers, CPTPlotField forFieldEnum, int index);

		[Export ("plotRangeForField:")]
		CPTPlotRange PlotRangeForField (CPTPlotField forFieldEnum);

		[Export ("plotRangeForCoordinate:")]
		CPTPlotRange PlotRangeForCoordinate (CPTCoordinate coord);

		[Export ("numberOfLegendEntries")]
		int NumberOfLegendEntries { get; }

		[Export ("titleForLegendEntryAtIndex:")]
		string GetTitleForLegendEntry (int index);

	        [Export ("drawSwatchForLegend:atIndex:inRect:inContext:")]
		void DrawSwatch (CPTLegend legent, int index, RectangleF rect, CGContext context);

		[Export ("numberOfFields")]
		int NumberOfFields { get; }

		[Export ("fieldIdentifiers")]
		NSObject [] FieldIdentifiers ();

		[Export ("fieldIdentifiersForCoordinate:")]
		NSObject [] FieldIdentifiersForCoordinate (CPTCoordinate coord);

		[Export ("positionLabelAnnotation:forIndex:")]
		void PositionLabelAnnotationforIndex (CPTPlotSpaceAnnotation label, int index);
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTRangePlot {
		[Export ("barLineStyle")]
		CPTLineStyle BarLineStyle { get; set; }

		[Export ("barWidth")]
		float BarWidth { get; set; }
		
		[Export ("gapHeight")]
		float GapHeight { get; set; }
		
		[Export ("gapWidth")]
		float GapWidth { get; set; }

		[Export ("areaFill")]
		CPTFill AreaFill { get; set; }
	}
	
	[BaseType (typeof (CPTAnnotationHostLayer))]
	interface CPTPlotArea {
		[Export ("minorGridLineGroup")]
		CPTGridLineGroup MinorGridLineGroup { get; set;  }

		[Export ("majorGridLineGroup")]
		CPTGridLineGroup MajorGridLineGroup { get; set;  }

		[Export ("axisSet")]
		CPTAxisSet AxisSet { get; set;  }

		[Export ("plotGroup")]
		CPTPlotGroup PlotGroup { get; set;  }

		[Export ("axisLabelGroup")]
		CPTAxisLabelGroup AxisLabelGroup { get; set;  }

		[Export ("axisTitleGroup")]
		CPTAxisLabelGroup AxisTitleGroup { get; set;  }

		[Export ("topDownLayerOrder")]
		NSNumber [] TopDownLayerOrder { get; set;  }

		[Export ("borderLineStyle")]
		CPTLineStyle BorderLineStyle { get; set;  }

		[Export ("fill")]
		CPTFill Fill { get; set;  }

		[Export ("updateAxisSetLayersForType:")]
		void UpdateAxisSetLayers (CPTGraphLayerType forLayerType);

		[Export ("setAxisSetLayersForType:")]
		void SetAxisSetLayers (CPTGraphLayerType forLayerType);

		[Export ("sublayerIndexForAxis:layerType:")]
		int SublayerIndex (CPTAxis forAxis, CPTGraphLayerType layerType);
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTPlotAreaFrame {
		[Export ("plotArea")]
		CPTPlotArea PlotArea { get;  }

		[Export ("axisSet")]
		CPTAxisSet AxisSet { get; set;  }

		[Export ("plotGroup")]
		CPTPlotGroup PlotGroup { get; set;  }
	}


	[BaseType (typeof (CPTLayer))]
	interface CPTPlotGroup {
		[Export ("identifier")]
		NSObject Identifier { get; set;  }

		[Export ("addPlot:")]
		void AddPlot (CPTPlot plot);

		[Export ("removePlot:")]
		void RemovePlot (CPTPlot plot);

	}

	[BaseType (typeof (NSObject))]
	interface CPTPlotRange {
		[Export ("location")]
		NSDecimal Location { get; set;  }

		[Export ("length")]
		NSDecimal Length { get; set;  }

		[Export ("end")]
		NSDecimal End { get;  }

		[Export ("minLimit")]
		NSDecimal MinLimit { get;  }

		[Export ("midPoint")]
		NSDecimal MidPoint { get; }
		
		[Export ("maxLimit")]
		NSDecimal MaxLimit { get;  }

		[Export ("expandRangeByFactor:")]
		void ExpandRangeByFactor (NSDecimal factor);

		[Static]
		[Export ("plotRangeWithLocation:length:")]
		CPTPlotRange FromLocationAndLength (NSDecimal loc, NSDecimal len);

		[Export ("initWithLocation:length:")]
		IntPtr Constructor (NSDecimal loc, NSDecimal len);

		[Export ("contains:")]
		bool Contains (NSDecimal number);

		[Export ("compareToDecimal:")]
		CPTPlotRangeComparisonResult CompareToDecimal (NSDecimal number);

		[Export ("locationDouble")]
		double LocationDouble { get;  }

		[Export ("lengthDouble")]
		double LengthDouble { get;  }

		[Export ("endDouble")]
		double EndDouble { get;  }

		[Export ("minLimitDouble")]
		double MinLimitDouble { get;  }

		[Export ("maxLimitDouble")]
		double MaxLimitDouble { get;  }

		[Export ("containsDouble:")]
		bool ContainsDouble (double number);

		[Export ("isEqualToRange:")]
		bool IsEqualToRange (CPTPlotRange otherRange);

		[Export ("unionPlotRange:")]
		void UnionPlotRange (CPTPlotRange otherRange);

		[Export ("intersectionPlotRange:")]
		void IntersectionPlotRange (CPTPlotRange otherRange);

		[Export ("shiftLocationToFitInRange:")]
		void ShiftLocationToFitInRange (CPTPlotRange otherRange);

		[Export ("shiftEndToFitInRange:")]
		void ShiftEndToFitInRange (CPTPlotRange otherRange);

		[Export ("compareToNumber:")]
		CPTPlotRangeComparisonResult CompareToNumber (NSNumber number);

		[Export ("compareToDouble:")]
		CPTPlotRangeComparisonResult CompareToDouble (double number);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTPlotSpaceDelegate {
		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceDownEvent:atPoint:")]
		bool ShouldHandlePointingDeviceDownEvent (CPTPlotSpace space, NSObject evt, PointF point);

		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceDraggedEvent:atPoint:")]
		bool ShouldHandlePointingDeviceDraggedEvent (CPTPlotSpace space, NSObject evt, PointF point);

		[DelegateName ("CPTEventPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceCancelledEvent:")]
		bool ShouldHandlePointingDeviceCancelledEvent (CPTPlotSpace space, NSObject evt);

		[DelegateName ("CPTEventPointPredicate"), DefaultValue (false)]
		[Export ("plotSpace:shouldHandlePointingDeviceUpEvent:atPoint:")]
		bool ShouldHandlePointingDeviceUpEvent (CPTPlotSpace space, NSObject evt, PointF atPoint);
		
		[DelegateName ("CPTDisplacement"), DefaultValueFromArgument ("proposedDisplacementVector")]
		[Export ("plotSpace:willDisplaceBy:")]
		PointF WillDisplaceBy (CPTPlotSpace space, PointF proposedDisplacementVector);

		[DelegateName ("CPTWillChangePlotRange"), DefaultValueFromArgument ("toNewRange")]
		[Export ("plotSpace:willChangePlotRangeTo:forCoordinate:")]
		CPTPlotRange WillChangePlotRange (CPTPlotSpace space, CPTPlotRange toNewRange, CPTCoordinate forCoordinate);

		[EventArgs ("CPTPlotChanged")]
		[Export ("plotSpace:didChangePlotRangeForCoordinate:")]
		void DidChangePlotRange (CPTPlotSpace space, CPTCoordinate forCoordinate);
	}

	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events= new Type [] { typeof (CPTPlotSpaceDelegate) })]
	interface CPTPlotSpace {
		[Export ("identifier")]
		NSObject Identifier { get; set;  }

		[Export ("allowsUserInteraction")]
		bool AllowsUserInteraction { get; set;  }

		[Export ("graph")]
		CPTGraph Graph { get; set;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		CPTPlotSpaceDelegate Delegate { get; set;  }

		[Export ("plotAreaViewPointForDoublePrecisionPlotPoint:")]
		PointF PlotAreaViewPoint (double plotPoint);

		[Export ("plotAreaViewPointForPlotPoint:")]
		PointF PlotAreaViewPoint (NSDecimal forPlotPoint);

		[Export ("plotPoint:forPlotAreaViewPoint:")]
		void PlotPointforPlotAreaViewPoint (ref NSDecimal plotPoint, PointF plotAreaViewPoint);

		[Export ("doublePrecisionPlotPoint:forPlotAreaViewPoint:")]
		void PlotPoint (ref double plotPoint, PointF plotAreaViewPoint);

		[Export ("setPlotRange:forCoordinate:")]
		void SetPlotRange (CPTPlotRange newRange, CPTCoordinate coordinate);

		[Export ("plotRangeForCoordinate:")]
		CPTPlotRange GetPlotRange (CPTCoordinate coordinate);

		[Export ("setScaleType:forCoordinate:")]
		void SetScaleType (CPTScaleType scaleType, CPTCoordinate forCoordinate);

		[Export ("scaleTypeForCoordinate")]
		CPTScaleType GetScaleType (CPTCoordinate forCoordinate);
		
		[Export ("scaleToFitPlots:")]
		void ScaleToFitPlots (CPTPlot [] plots);

		[Export ("scaleBy:aboutPoint:")]
		void Scale (float interactionScale, PointF interactionPoint);
		
		//
		// From CPTResponder
		//
		[Export ("pointingDeviceDownEvent:atPoint:")]
		bool PointingDeviceDown (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceUpEvent:atPoint:")]
		bool PointingDeviceUp (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceDraggedEvent:atPoint:")]
		bool PointingDeviceDragged (NSObject theEvent, PointF interactionPoint);

		[Export ("pointingDeviceCancelledEvent:")]
		bool PointingDeviceCancelledEvent (NSObject theEvent);
	}


	[BaseType (typeof (CPTPlotSpace))]
	interface CPTXYPlotSpace {
		[Export ("xRange")]
		CPTPlotRange XRange { get; set;  }

		[Export ("yRange")]
		CPTPlotRange YRange { get; set;  }

		[Export ("globalXRange")]
		CPTPlotRange GlobalXRange { get; set;  }

		[Export ("globalYRange")]
		CPTPlotRange GlobalYRange { get; set;  }

		[Export ("xScaleType")]
		CPTScaleType XScaleType { get; set;  }

		[Export ("yScaleType")]
		CPTScaleType YScaleType { get; set;  }
	}

	[BaseType (typeof (CPTAnnotation))]
	interface CPTPlotSpaceAnnotation {
		// Decimal numbers
		[Export ("anchorPlotPoint")]
		NSNumber [] AnchorPlotPoint { get; set;  }

		[Export ("plotSpace")]
		CPTPlotSpace PlotSpace { get;  }

		[Export ("initWithPlotSpace:anchorPlotPoint:")]
		IntPtr Constructor (CPTPlotSpace space, NSNumber [] plotPoint);
	}


	[BaseType (typeof (NSObject))]
	interface CPTPlotSymbol {
		[Export ("size")]
		SizeF Size { get; set;  }

		[Export ("symbolType")]
		CPTPlotSymbolType SymbolType { get; set;  }

		[Export ("lineStyle")]
		CPTLineStyle LineStyle { get; set;  }

		[Export ("fill")]
		CPTFill Fill { get; set;  }

		[Export ("customSymbolPath")]
		CGPath CustomSymbolPath { get; set;  }

		[Export ("usesEvenOddClipRule")]
		bool UsesEvenOddClipRule { get; set;  }

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

		[Export ("renderInContext:atPoint:scale:")]
		void RenderInContext (CGContext inContext, PointF centerPoint, float scale);

		[Export ("renderAsVectorInContext:atPoint:scale:")]
		void RenderAsVector (CGContext inContext, PointF centerPoint, float scale);
	}

	[BaseType (typeof (CPTLayer))]
	interface CPTTextLayer {
		[Export ("text")]
		string Text { get; set;  }

		[Export ("textStyle")]
		CPTTextStyle TextStyle { get; set;  }

		[Export ("initWithText:")]
		IntPtr Constructor (string newText);

		[Export ("initWithText:style:")]
		IntPtr Constructor (string newText, CPTTextStyle newStyle);

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("sizeThatFits")]
		SizeF SizeThatFits { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTTextStyleDelegate {
		[Abstract]
		[Export ("textStyleDidChange:")]
		void TextStyleDidChange (CPTTextStyle textStyle);
	}

	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (CPTTextStyleDelegate) })]
	interface CPTTextStyle {
		[Export ("delegate"), NullAllowedAttribute]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		CPTTextStyleDelegate Delegate { get; set; }

		[Export ("fontName")]
		string FontName { get; set;  }

		[Export ("fontSize")]
		float FontSize { get; set;  }

		[Export ("color")]
		CPTColor Color { get; set;  }

		[Static]
		[Export ("textStyle")]
		CPTTextStyle CreateTextStyle ();

		[Export ("sizeWithTextStyle:")]
		SizeF SizeWithTextStyle (CPTTextStyle style);

		[Export ("drawInRect:withTextStyle:inContext:")]
		void Draw (RectangleF rectangle, CPTTextStyle style, CGContext context);
	}

	[BaseType (typeof (NSObject))]
	interface CPTTheme {
		[Export ("name")]
		string Name { get; set;  }

		[Export ("graphClass")]
		Class GraphClass { get; set;  }

		[Static]
		[Export ("themeClasses")]
		NSArray ThemeClasses { get; }

		[Static]
		[Export ("themeNamed:")]
		CPTTheme ThemeNamed (string theme);

		[Static]
		[Export ("addTheme:")]
		void AddTheme (CPTTheme newTheme);

		[Static]
		[Export ("defaultName")]
		string DefaultName { get; }

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

#if false
		[Field ("kCPTDarkGradientTheme", "__Internal")]
		NSString DarkGradientTheme { get; }

		[Field ("kCPTPlainWhiteTheme", "__Internal")]
		NSString PlainWhiteTheme { get; }
		
		[Field ("kCPTPlainBlackTheme", "__Internal")]
		NSString PlainBlackTheme { get; }
		
		[Field ("kCPTSlateTheme", "__Internal")]
		NSString SlateTheme { get; }
		
		[Field ("kCPTStocksTheme", "__Internal")]
		NSString StocksTheme { get; }
#endif
	}


	// No longer missing NSNumberFormatter
	[BaseType (typeof (NSNumberFormatter))]
	interface CPTTimeFormatter {
		[Export ("dateFormatter")]
		NSDateFormatter DateFormatter { get; set; }

		[Export ("referenceDate")]
		NSDate ReferenceDate { get; set; }

		[Export ("initWithDateFormatter:")]
		IntPtr Constructor (NSDateFormatter reference);
	}

	[BaseType (typeof (NSNumberFormatter))]
	interface CPTCalendarFormatter {
		[Export ("dateFormatter")]
		NSDateFormatter DateFormatter { get; set; }

		[Export ("referenceDate")]
		NSDate ReferenceDate { get; set; }

		[Export ("referenceCalendar")]
		NSCalendar ReferenceCalendar { get; set; }

		[Export ("referenceCalendarUnit")]
		NSCalendarUnit ReferenceCalendarUnit { get; set; }
	}

	[BaseType (typeof (CPTPlot))]
	interface CPTTradingRangePlot {
		[Export ("lineStyle")]
		CPTLineStyle LineStyle { get; set;  }

		[Export ("increaseLineStyle")]
		CPTLineStyle IncreaseLineStyle { get; set; }
		
		[Export ("decreaseLineStyle")]
		CPTLineStyle DecreaseLineStyle { get; set; }
		
		[Export ("increaseFill")]
		CPTFill IncreaseFill { get; set;  }

		[Export ("decreaseFill")]
		CPTFill DecreaseFill { get; set;  }

		[Export ("plotStyle")]
		CPTTradingRangePlotStyle PlotStyle { get; set;  }

		[Export ("barWidth")]
		float BarWidth { get; set;  }

		[Export ("stickLength")]
		float StickLength { get; set;  }
	}

	[BaseType (typeof (CPTTheme))]
	interface CPTXYTheme {
	}
	
	[BaseType (typeof (CPTXYTheme))]
	interface CPTDarkGradientTheme {
	}

	[BaseType (typeof (CPTXYTheme))]
	interface CPTPlainBlackTheme {
	}

	[BaseType (typeof (CPTXYTheme))]
	interface CPTPlainWhiteTheme {
	}

	[BaseType (typeof (CPTXYTheme))]
	interface CPTSlateTheme {
	}

	[BaseType (typeof (CPTXYTheme))]
	interface CPTStocksTheme {
	}

	[BaseType (typeof (CPTPlotSpace))]
	interface CPTPolarPlotSpace {
	}

	[BaseType (typeof (CPTGraph))]
	interface CPTXYGraph {
		[Export ("initWithFrame:xScaleType:yScaleType:")]
		IntPtr Constructor (RectangleF newFrame, CPTScaleType newXScale, CPTScaleType newYScale);
	}
	
	[BaseType (typeof (CPTGraph))]
	interface CPTDerivedXYGraph : CPTXYGraph {
	}
	
	[BaseType (typeof (CPTGraph))]
	interface CPTGraphXY {
		[Export ("initWithFrame:xScaleType:yScaleType:")]
		IntPtr Constructor (RectangleF frame, CPTScaleType xScaleType, CPTScaleType yScaleType);
	}

	[BaseType (typeof (CPTAxis))]
	interface CPTXYAxis {
		[Export ("orthogonalCoordinateDecimal")]
		NSDecimal OrthogonalCoordinateDecimal { get; set;  }
//[Export ("constraints")]
//CPTConstraints Constraints { get; set;  }

		[Export ("isFloatingAxis")]
		bool IsFloatingAxis { get; set;  }
	}

	[BaseType (typeof (CPTAxisSet))]
	interface CPTXYAxisSet  : CPTAxisSet {
		[Export ("xAxis")]
		CPTXYAxis XAxis { get; }

		[Export ("yAxis")]
		CPTXYAxis YAxis { get; }
	}
	

	[BaseType (typeof (CPTPlotDataSource))]
	[Model]
	interface CPTScatterPlotDataSource {
		[Export ("symbolsForScatterPlot:recordIndexRange:")]
		CPTPlotSymbol [] GetSymbols (CPTScatterPlot plot, NSRange indexRange);

		[Export ("symbolForScatterPlot:recordIndex:")]
		CPTPlotSymbol GetSymbol (CPTScatterPlot plot, int recordIndex);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTScatterPlotDelegate {
		[Abstract]
		[Export ("scatterPlot:plotSymbolWasSelectedAtRecordIndex:"), EventArgs ("CPTScatterSymbolSelected")]
		void PlotSymbolSelected (CPTScatterPlot plot, int recordIndex);
	}

	[BaseType (typeof (CPTPlot), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (CPTScatterPlotDelegate)})]
	interface CPTScatterPlot {
		[Export ("dataLineStyle")]
		CPTLineStyle DataLineStyle { get; set;  }

		[Export ("plotSymbol")]
		CPTPlotSymbol PlotSymbol { get; set;  }

		[Export ("areaFill")]
		CPTFill AreaFill { get; set;  }

		[Export ("areaFill2")]
		CPTFill AreaFill2 { get; set;  }

		[Export ("areaBaseValue")]
		NSDecimal AreaBaseValue { get; set;  }

		[Export ("areaBaseValue2")]
		NSDecimal AreaBaseValue2 { get; set;  }

		[Export ("interpolation")]
		CPTScatterPlotInterpolation Interpolation { get; set;  }

		[Export ("plotSymbolMarginForHitDetection")]
		float PlotSymbolMarginForHitDetection { get; set;  }

		[Export ("indexOfVisiblePointClosestToPlotAreaPoint:")]
		int IndexOfVisiblePointClosestToPlotAreaPoint (PointF viewPoint);

		[Export ("plotAreaPointOfVisiblePointAtIndex:")]
		PointF PlotAreaPointOfVisiblePointAtIndex (int index);

		[Export ("plotSymbolForRecordIndex:")]
		CPTPlotSymbol PlotSymbolForRecordIndex (int index);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CPTLegendDelegate {
		[Export ("legend:shouldDrawSwatchAtIndex:forPlot:inRect:inContext:")]
		bool ShouldDrawSwatch (int index, CPTPlot plot, RectangleF rect, CGContext context);
	}

	[BaseType (typeof (CPTBorderedLayer))]
	interface CPTLegend {
		[Export ("textStyle")]
		CPTTextStyle TextStyle { get; set;  }

		[Export ("swatchSize")]
		SizeF SwatchSize { get; set;  }

		[Export ("swatchBorderLineStyle")]
		CPTLineStyle SwatchBorderLineStyle { get; set;  }

		[Export ("swatchCornerRadius")]
		float SwatchCornerRadius { get; set;  }

		[Export ("swatchFill")]
		CPTFill SwatchFill { get; set;  }

		[Export ("layoutChanged")]
		bool LayoutChanged { get;  }

		[Export ("numberOfRows")]
		int Rows { get; set;  }

		[Export ("numberOfColumns")]
		int Columns { get; set;  }

		[Export ("equalRows")]
		bool EqualRows { get; set;  }

		[Export ("equalColumns")]
		bool EqualColumns { get; set;  }

		[Export ("rowHeights")]
		NSNumber [] RowHeights { get; set;  }

		[Export ("rowHeightsThatFit")]
		NSNumber RowHeightsThatFit { get;  }

		[Export ("columnWidths")]
		NSNumber [] ColumnWidths { get; set;  }

		[Export ("columnWidthsThatFit")]
		NSNumber [] ColumnWidthsThatFit { get;  }

		[Export ("columnMargin")]
		float ColumnMargin { get; set;  }

		[Export ("rowMargin")]
		float RowMargin { get; set;  }

		[Export ("titleOffset")]
		float TitleOffset { get; set;  }

		[Static]
		[Export ("legendWithPlots:")]
		CPTLegend FromPlots  (CPTPlot [] newPlots);

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

	[BaseType (typeof (NSObject<NSCoding>))]
	interface CPTLegendEntry {
		[Export ("plot")]
		CPTPlot Plot { get; set;  }

		[Export ("index")]
		int Index { get; set;  }

		[Export ("textStyle")]
		CPTTextStyle TextStyle { get; set;  }

		[Export ("row")]
		int Row { get; set;  }

		[Export ("column")]
		int Column { get; set;  }

		[Export ("titleSize")]
		SizeF TitleSize { get;  }

		[Export ("drawTitleInRect:inContext:scale:")]
		void DrawTitleInRectinContextscale (RectangleF rect, CGContextRef context, float scale);
	}

	[BaseType (typeof (CPTTextStyle))]
	interface CPTMutableTextStyle {
	}
	
#if MONOTOUCH
	[BaseType (typeof (UIView))]
	interface CPTGraphHostingView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("hostedGraph")]
		CPTGraph HostedGraph { get; set; }

		[Export ("collapsesLayers")]
		bool CollapsesLayers { get; set; }

		[Export ("allowPinchScaling")]
		bool AllowPinchScaling { get; set; }

		[Export ("printRect")]
		RectangleF PrintRect { get; set; }
	}
#else
	[BaseType (typeof (NSView))]
	interface CPTGraphHostingView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("hostedLayer")]
		CPTLayer HostedLayer { get; set; }

		[Export ("printRect")]
		RectangleF PrintRect { get; set; }
	}
#endif
}
