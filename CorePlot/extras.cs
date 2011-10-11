//
// extras.cs: Extensions to the generated classes in coreplot
//
// Author:
//   Miguel de Icaza
//
using System;
using System.Runtime.InteropServices;

namespace MonoMac.CorePlot {

	// Need to flag these as abstract, to avoid an error reported since we are models that inherit from a model
	public abstract partial class CPTScatterPlotDataSource {
	}

	public abstract partial class CPBarPlotDataSource {
	}

	public abstract partial class CPPieChartDataSource {
	}
}