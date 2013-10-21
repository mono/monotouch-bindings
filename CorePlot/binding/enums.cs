//
// enums.cs: definitions for CorePlot binding
//
// Authors:
//   Miguel de Icaza
//   Alex Soto
//

using System;
using System.Runtime.InteropServices;

namespace CorePlot
{
	public enum CPTAnimationCurve
	{
		Default,          //< Use the default animation curve.
		Linear,           //< Linear animation curve.
		BackIn,           //< Backing in animation curve.
		BackOut,          //< Backing out animation curve.
		BackInOut,        //< Backing in and out animation curve.
		BounceIn,         //< Bounce in animation curve.
		BounceOut,        //< Bounce out animation curve.
		BounceInOut,      //< Bounce in and out animation curve.
		CircularIn,       //< Circular in animation curve.
		CircularOut,      //< Circular out animation curve.
		CircularInOut,    //< Circular in and out animation curve.
		ElasticIn,        //< Elastic in animation curve.
		ElasticOut,       //< Elastic out animation curve.
		ElasticInOut,     //< Elastic in and out animation curve.
		ExponentialIn,    //< Exponential in animation curve.
		ExponentialOut,   //< Exponential out animation curve.
		ExponentialInOut, //< Exponential in and out animation curve.
		SinusoidalIn,     //< Sinusoidal in animation curve.
		SinusoidalOut,    //< Sinusoidal out animation curve.
		SinusoidalInOut,  //< Sinusoidal in and out animation curve.
		CubicIn,          //< Cubic in animation curve.
		CubicOut,         //< Cubic out animation curve.
		CubicInOut,       //< Cubic in and out animation curve.
		QuadraticIn,      //< Quadratic in animation curve.
		QuadraticOut,     //< Quadratic out animation curve.
		QuadraticInOut,   //< Quadratic in and out animation curve.
		QuarticIn,        //< Quartic in animation curve.
		QuarticOut,       //< Quartic out animation curve.
		QuarticInOut,     //< Quartic in and out animation curve.
		QuinticIn,        //< Quintic in animation curve.
		QuinticOut,       //< Quintic out animation curve.
		QuinticInOut      //< Quintic in and out animation curve.
	}

	public enum CPTAxisLabelingPolicy
	{
		None,              //< No labels provided; user sets labels and tick locations.
		LocationsProvided, //< User sets tick locations; axis makes labels.
		FixedInterval,     //< Fixed interval labeling policy.
		Automatic,         //< Automatic labeling policy.
		EqualDivisions     //< Divide the plot range into equal parts.
	}

	public enum CPTBarPlotField
	{
		BarLocation, //< Bar location on independent coordinate axis.
		BarTip,      //< Bar tip value.
		BarBase      //< Bar base (used only if @link CPTBarPlot::barBasesVary barBasesVary @endlink is YES).
	}

	public enum CPTNumericType
	{
		Integer, //< Integer
		Float,   //< Float
		Double   //< Double
	}

	public enum CPTErrorBarType
	{
		Custom,        //< Custom error bars
		ConstantRatio, //< Constant ratio error bars
		ConstantValue  //< Constant value error bars
	}

	public enum CPTScaleType
	{
		Linear,   //< Linear axis scale
		Log,      //< Logarithmic axis scale
		Angular,  //< Angular axis scale (not implemented)
		DateTime, //< Date/time axis scale (not implemented)
		Category  //< Category axis scale (not implemented)
	}

	public enum CPTCoordinate
	{
		X = 0, //< X axis
		Y = 1, //< Y axis
		Z = 2  //< Z axis
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPTRGBAColor 
	{
		public float Red, Green, Blue, Alpha;
	}

	public enum CPTSign 
	{
		None = 0, 
		Positive = 1, 
		Negative = -1
	}

	public enum CPTRectAnchor 
	{
		BottomLeft,  //< The bottom left corner
		Bottom,      //< The bottom center
		BottomRight, //< The bottom right corner
		Left,        //< The left middle
		Right,       //< The right middle
		TopLeft,     //< The top left corner
		Top,         //< The top center
		TopRight,    //< The top right
		Center       //< The center of the rect
	}

	public enum CPTAlignment 
	{
		Left,   //< Align horizontally to the left side.
		Center, //< Align horizontally to the center.
		Right,  //< Align horizontally to the right side.
		Top,    //< Align vertically to the top.
		Middle, //< Align vertically to the middle.
		Bottom  //< Align vertically to the bottom.
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPTGradientElement 
	{
		public CPTRGBAColor Color;
		public float Position;
		public IntPtr NextElement;
	}

	public enum CPTGradientBlendingMode 
	{
		Linear,          //< Linear blending mode
		Chromatic,       //< Chromatic blending mode
		InverseChromatic //< Inverse chromatic blending mode
	}

	public enum CPTGradientType 
	{
		Axial, //< Axial gradient
		Radial //< Radial gradient
	}

	public enum CPTLineCapType 
	{
		None,       //< No line cap.
		OpenArrow,  //< Open arrow line cap.
		SolidArrow, //< Solid arrow line cap.
		SweptArrow, //< Swept arrow line cap.
		Rectangle,  //< Rectangle line cap.
		Ellipse,    //< Elliptical line cap.
		Diamond,    //< Diamond line cap.
		Pentagon,   //< Pentagon line cap.
		Hexagon,    //< Hexagon line cap.
		Bar,        //< Bar line cap.
		Cross,      //< X line cap.
		Snow,       //< Snowflake line cap.
		Custom      //< Custom line cap.
	}

	public enum CPTPieChartField 
	{
		SliceWidth,           //< Pie slice width.
		SliceWidthNormalized, //< Pie slice width normalized [0, 1].
		SliceWidthSum         //< Cumulative sum of pie slice widths.
	}

	public enum CPTPieDirection 
	{
		Clockwise,       //< Pie slices are drawn in a clockwise direction.
		CounterClockwise //< Pie slices are drawn in a counter-clockwise direction.
	}

	public enum CPTPlotCachePrecision 
	{
		Auto,   //< Cache precision is determined automatically from the data. All cached data will be converted to match the last data loaded.
		Double, //< All cached data will be converted to double precision.
		Decimal //< All cached data will be converted to @ref NSDecimal.
	}

	public enum CPTDataTypeFormat 
	{
		Undefined = 0,        //< Undefined
		Integer,              //< Integer
		UnsignedInteger,      //< Unsigned integer
		FloatingPoint,        //< Floating point
		ComplexFloatingPoint, //< Complex floating point
		Decimal               //< NSDecimal
	}

	public enum CPTDataOrder 
	{
		RowsFirst,   //< Numeric data is arranged in row-major order.
		ColumnsFirst //< Numeric data is arranged in column-major order.
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPTNumericDataType 
	{
		public CPTDataTypeFormat DataTypeFormat;
		public ulong SampleBytes;
		public long ByteOrder;

		public CPTNumericDataType (CPTDataTypeFormat dataTypeFormat, ulong sampleBytes, long byteOrder)
		{
			DataTypeFormat = dataTypeFormat;
			SampleBytes = sampleBytes;
			ByteOrder = byteOrder;
		}
	}

	public enum CPTPlotField : uint
	{
		ScatterPlotFieldX = 0,
		ScatterPlotFieldY = 1,

		PieChartWidth = 0,
		PieChartWidthNormalized = 1,
		PieChartSliceWidhtSum = 2,

		BarLocation = 0,
		BarTip = 1,
		BarBase = 2,

		TradingRangeX = 0,
		TradingRangeOpen = 1,
		TradingRangeHigh = 2,
		TradingRangeLow = 3,
		TradingRangeClose = 4,

		RangePlotFieldX = 0,
		RangePlotFieldY = 1,
		RangePlotFieldHigh = 2,
		RangePlotFieldLow = 3,
		RangePlotFieldLeft = 4,
		RangePlotFieldRight = 5,
	}

	public enum CPTPlotRangeComparisonResult
	{
		NumberBelowRange, //< Number is below the range.
		NumberInRange,    //< Number is in the range.
		NumberAboveRange  //< Number is above the range.
	}

	public enum CPTPlotSymbolType
	{
		None,      //< No symbol.
		Rectangle, //< Rectangle symbol.
		Ellipse,   //< Elliptical symbol.
		Diamond,   //< Diamond symbol.
		Triangle,  //< Triangle symbol.
		Star,      //< 5-point star symbol.
		Pentagon,  //< Pentagon symbol.
		Hexagon,   //< Hexagon symbol.
		Cross,     //< X symbol.
		Plus,      //< Plus symbol.
		Dash,      //< Dash symbol.
		Snow,      //< Snowflake symbol.
		Custom     //< Custom symbol.
	}

	public enum CPTRangePlotField
	{
		X,     //< X values.
		Y,     //< Y values.
		High,  //< relative High values.
		Low,   //< relative Low values.
		Left,  //< relative Left values.
		Right, //< relative Right values.
	}

	public enum CPTScatterPlotField
	{
		X,
		Y
	}

	public enum CPTScatterPlotInterpolation
	{
		Linear,    //< Linear interpolation.
		Stepped,   //< Steps beginning at data point.
		Histogram, //< Steps centered at data point.
		Curved     //< Bezier curve interpolation.
	}

	public enum CPTTradingRangePlotStyle
	{
		OpenHighLowClose,
		CandleStick
	}

	public enum CPTTradingRangePlotField
	{
		X,    //< X values.
		Open, //< Open values.
		High, //< High values.
		Low,  //< Low values.
		Close //< Close values.
	}

	public enum CPTGraphLayerType
	{
		MinorGridLines, //< Minor grid lines.
		MajorGridLines, //< Major grid lines.
		AxisLines,      //< Axis lines.
		Plots,          //< Plots.
		AxisLabels,     //< Axis labels.
		AxisTitles      //< Axis titles.
	}
}