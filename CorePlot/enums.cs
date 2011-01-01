//
// enums.cs: definitions for CorePlot binding
//
// Author:
//   Miguel de Icaza
//
using System;
using System.Runtime.InteropServices;

namespace MonoMac.CorePlot {

	public enum CPNumericType {
		Integer, Float, Double
	}

	public enum CPErrorBarType {
		Custom, ConstantRatio, ConstantValue
	}

	public enum CPScaleType {
		Linear, LogN, Log10, Angular, DateTime, Category
	}

	public enum CPCoordinate {
		X, Y, Z
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CPRgbaColor {
		public float Red, Green, Blue, Alpha;
	}

	public enum CPSign {
		None = 0, Positive = 1, Negative = -1
	}

	public enum CPConstraint {
		None, Fixed
	}

	public enum CPRectAnchor {
		BottomLeft, Bottom, BottomRight, Left, Right, TopLeft, Top, TopRight, Center
	}

	public enum CPAlignment {
		Left, Center, Right, Top, Middle, Bottom
	}

	public enum CPDataTypeFormat {
		Undefined, Integer, UnsignedInteger, FloatingPoint, ComplexFloatingPoint, Decimal
	}
	
	public struct CPNumericDataType {
		public CPDataTypeFormat DataTypeFormat;
		public IntPtr SampleByteCount;
		public int ByteOrder;
	}

	public enum CPPlotRangeComparisonResult {
		NumberBelowRange, NumberInRange, NumberAboveRange
	}

	public enum CPGradientBlendingMode {
		Linear, Chromatic, InverseChromatic
	}

	public enum CPGradientType {
		Axial, Radial
	}

	public enum CPGraphLayerType {
		MinorGridLines, MajorGridLines, AxiLines, Plots, AxisLabels, AxisTitles
	}

	public enum CPAxisLabelingPolicy {
		None, LocationsProvided, FixedInternal, PolicyAutomatic, PolicyLogarithmic
	}

	public enum CPPlotCachePrecision {
		Auto, Double, Decimal
	}
}