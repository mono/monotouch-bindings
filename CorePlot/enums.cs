//
// enums.cs: definitions for CorePlot binding
//
// Author:
//   Miguel de Icaza
//
using System;
using System.Runtime.InteropServices;

namespace MonoMac.CorePlot {

	public enum CPTNumericType {
		Integer, Float, Double
	}

	public enum CPTErrorBarType {
		Custom, ConstantRatio, ConstantValue
	}

	public enum CPTScaleType {
		Linear, LogN, Log10, Angular, DateTime, Category
	}

	public enum CPTCoordinate {
		X, Y, Z
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPTRgbaColor {
		public float Red, Green, Blue, Alpha;
	}

	public enum CPTSign {
		None = 0, Positive = 1, Negative = -1
	}

	public enum CPTConstraint {
		None, Fixed
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPTConstraints {
		public CPTConstraint Lower;
		public CPTConstraint Upper;
	}

	public enum CPTRectAnchor {
		BottomLeft, Bottom, BottomRight, Left, Right, TopLeft, Top, TopRight, Center
	}

	public enum CPTAlignment {
		Left, Center, Right, Top, Middle, Bottom
	}

	public enum CPTDataTypeFormat {
		Undefined, Integer, UnsignedInteger, FloatingPoint, ComplexFloatingPoint, Decimal
	}
	
	public struct CPTNumericDataType {
		public CPTDataTypeFormat DataTypeFormat;
		public IntPtr SampleByteCount;
		public int ByteOrder;
	}

	public enum CPTPieDirection {
		Clockwise,
		CounterClockwise
	}
	
	public enum CPTPlotRangeComparisonResult {
		NumberBelowRange, NumberInRange, NumberAboveRange
	}

	public enum CPTScatterPlotInterpolation {
		Linear, Stepped, Histogram
	}
	
	public enum CPTGradientBlendingMode {
		Linear, Chromatic, InverseChromatic
	}

	public enum CPTGradientType {
		Axial, Radial
	}

	public enum CPTGraphLayerType {
		MinorGridLines, MajorGridLines, AxiLines, Plots, AxisLabels, AxisTitles
	}

	public enum CPTAxisLabelingPolicy {
		None, LocationsProvided, FixedInternal, PolicyAutomatic, PolicyLogarithmic
	}

	public enum CPTPlotCachePrecision {
		Auto, Double, Decimal
	}

	public enum CPTPlotField {
		ScatterPlotFieldX = 0,
		ScatterPlotFieldY = 1,
			
		PieChartWidth = 0,
		PieChartWidthNormalized = 1,
		PieChartSliceWidhtSum = 2,
			
		BarLocation = 2,
		BarLength = 3,

		TradingRangeX = 0,
		TradingRangeOpen = 1,
		TradingRangeHigh = 2,
		TradingRangeLow = 3,
		TradingRangeClose = 4,
	}

	public enum CPTPlotSymbolType {
		None, Rectangle, Ellipse, Diamond, Triangle,
		Star, Pentagon, Hexaon, Cross, Plus, Dash,
		Snow, Custom
	}

	public enum CPTTradingRangePlotStyle {
		OHLC, CandleStick
	}
}