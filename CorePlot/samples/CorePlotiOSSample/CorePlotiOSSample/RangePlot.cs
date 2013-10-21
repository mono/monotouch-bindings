/*
 * C# sample for RangePlot
 *
 * Author:
 * Berndt Hamboeck
 */
using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;

using CorePlot;

namespace CorePlotiOSSample
{
	public class RangePlot : PlotViewController
	{
		CPTXYGraph graph;
		CPTLineStyle barLineStyle, barLineStyleDefault;
		CPTFill areaFill, areaFillDefault;

		public RangePlot ()
		{
			SetupGraph ();
			SetupAxes ();
			SetupPlots ();
			Graph = graph;
		}

		void SetupGraph ()
		{
			var theme = CPTTheme.ThemeNamed (CPTTheme.PlainBlackTheme);

			graph = new CPTXYGraph {
				PaddingLeft = 10,
				PaddingRight = 10,
				PaddingTop = 10,
				PaddingBottom = 10,
				Title = "Click to Toggle Range Plot Style",

				TitleTextStyle = new CPTMutableTextStyle {
					FontSize = 18,
					FontName = "Helvetica",
					Color = CPTColor.GrayColor
				},

				TitleDisplacement = new PointF (0, -20f)
			};
			graph.ApplyTheme (theme);

			// Store area fill for use later
			var transparentGreen = CPTColor.GreenColor;
			areaFill = new CPTFill (transparentGreen.ColorWithAlphaComponent(0.2f));

			graph.DefaultPlotSpace.ShouldHandlePointingDeviceUp = delegate {
				var rangePlot = (CPTRangePlot) graph.PlotWithIdentifier((NSString)"Date Plot");
				// TODO: instead of areaFillDefault -> null (see code below in comment
				rangePlot.AreaFill = (rangePlot.AreaFill == areaFill ? areaFillDefault : areaFill);
				rangePlot.BarLineStyle = (rangePlot.BarLineStyle == barLineStyleDefault ? barLineStyle: barLineStyleDefault);
				return false;
			};
		}

		void SetupAxes ()
		{
			int oneDay = 24 * 60 * 60;

			var plotspace = graph.DefaultPlotSpace;
			plotspace.AllowsUserInteraction = true;

			// Setup scatter plot space
			var plotSpace = (CPTXYPlotSpace) graph.DefaultPlotSpace;
			decimal xLow = oneDay * 0.5m;

			var plotRangeX = new CPTPlotRange ((NSDecimal)xLow, (NSDecimal)(oneDay * 5m));

			plotSpace.XRange = plotRangeX;

			var plotRangeY = new CPTPlotRange ((NSDecimal) 1, (NSDecimal) 3);


			plotSpace.YRange = plotRangeY;
			// Axes
			var axisSet = (CPTXYAxisSet) graph.AxisSet;
			CPTXYAxis x = axisSet.XAxis;
			x.MajorIntervalLength = oneDay;
			x.OrthogonalCoordinateDecimal = 2;
			x.MinorTicksPerInterval = 0;

			CPTXYAxis y = axisSet.YAxis;
			y.MajorIntervalLength = (NSDecimal)0.5;
			y.MinorTicksPerInterval = 5;
			y.OrthogonalCoordinateDecimal = oneDay;
		}

		void SetupPlots ()
		{
			// Create a plot that uses the data source method
			var dataSourceLinePlot = new CPTRangePlot ();
			dataSourceLinePlot.Identifier = (NSString)"Date Plot";

			// Add line style
			barLineStyle = new CPTLineStyle();
			barLineStyle.LineWidth = 3f;
			barLineStyle.LineColor = CPTColor.GreenColor;
			dataSourceLinePlot.BarLineStyle = barLineStyle;

			// Bar properties
			dataSourceLinePlot.BarWidth = 10.0f;
			dataSourceLinePlot.GapWidth = 20.0f;
			dataSourceLinePlot.GapHeight = 20.0f;
			dataSourceLinePlot.DataSource = new RangeSource();

			// Add plot
			graph.AddPlot(dataSourceLinePlot);

			areaFillDefault = CPTFill.FromColor(CPTColor.ClearColor);
			barLineStyleDefault = dataSourceLinePlot.BarLineStyle;

			var space = graph.DefaultPlotSpace as CPTXYPlotSpace;
			space.ScaleToFitPlots (new CPTPlot [] { dataSourceLinePlot });
		}
	}

	public class RangeSource : CPTRangePlotDataSource
	{
		Dictionary<int, Dictionary<int, float>> data;

		public RangeSource ()
		{
			var r = new Random ();
			int oneDay = 24 * 60 * 60;
			data = new Dictionary<int, Dictionary<int, float>>();

			// Add some data
			for ( int i = 0; i < 5; i++ ) {
				var dataVal = new Dictionary<int, float> ();
				float x = i + oneDay*(i+1.0f);
				float y = 3.0f*r.Next(10) + 1.2f;
				float rHigh = r.Next(10) * 0.5f + 0.25f;
				float rLow = r.Next(10) * 0.5f + 0.25f;
				float rLeft = (r.Next(10) * 0.125f + 0.125f) * oneDay;
				float rRight =(r.Next(10) * 0.125f + 0.125f)  * oneDay;

				dataVal.Add(0,x);
				dataVal.Add(1,y);
				dataVal.Add(2,rHigh);
				dataVal.Add(3,rLow);
				dataVal.Add(4,rLeft);
				dataVal.Add(5,rRight);
				data.Add(i, dataVal);
			}
		}

		public override int NumberOfRecordsForPlot (CPTPlot plot)
		{
			return data.Count;
		}

		public override NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, uint index)
		{
			int fieldNum = (int)forFieldEnum;
			Dictionary<int, float> dataVal = data[(int)index];
			Console.WriteLine (string.Format ("{0} {1}", fieldNum, dataVal [fieldNum]));
			return dataVal[fieldNum];
		}
	}
}
