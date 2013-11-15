/*
 * C# sample for PiePlot
 *
 * Author:
 * Berndt Hamboeck
 */
using System;
using System.Collections.Generic;

using MonoTouch.Foundation;

using CorePlot;

namespace CorePlotiOSSample
{
	public class PiePlot : PlotViewController
	{
		CPTXYGraph graph;

		public PiePlot ()
		{
			SetupGraph ();
			SetupAxes ();
			SetupPiePlots ();
			Graph = graph;
		}

		void SetupGraph ()
		{
			/*
				Dark Gradients => Dark gradient theme.
				Plain White    => Plain white theme.
				Plain Black    => Plain black theme.
				Slate          => Slate theme.
				Stocks         => Stocks theme.
			*/

			var theme = CPTTheme.ThemeNamed (CPTTheme.DarkGradientTheme);

			graph = new CPTXYGraph {
				PaddingLeft = 0,
				PaddingRight = 0,
				PaddingTop = 0,
				PaddingBottom = 0
			};
			graph.ApplyTheme (theme);
		}

		void SetupAxes ()
		{
			graph.PlotAreaFrame.MasksToBorder = false;

			var axisSet = (CPTXYAxisSet)graph.AxisSet;
			var x = axisSet.XAxis;
			x.LabelingPolicy = CPTAxisLabelingPolicy.None;

			var y = axisSet.YAxis;
			y.LabelingPolicy = CPTAxisLabelingPolicy.None;
		}

		void SetupPiePlots ()
		{
			 // Prepare a radial overlay gradient for shading/gloss
			var color = new CPTColor (new MonoTouch.CoreGraphics.CGColor (1f,1f,0f));

			var overlayGradient = new CPTGradient { GradientType = CPTGradientType.Radial };

			overlayGradient.AddColorStop (color.ColorWithAlphaComponent (0.7f), 1.0f);

			// Create a plot that uses the data source method
			var piePlot = new CPTPieChart {
				PieRadius = 130.0f,
				Identifier = (NSString) "Pie Chart 1",
				StartAngle = (float) Math.PI / 4f, // 0.785398163397448309616f; //M_PI_4;
				SliceDirection = CPTPieDirection.CounterClockwise,
				BorderLineStyle = CPTLineStyle.LineStyle
			};

			var inputData = new List<float> { 60, 20,40 };
			piePlot.DataSource = new PieSourceData (inputData);

			graph.AddPlot (piePlot);
		}
	}

	public class PieSourceData : CPTPieChartDataSource
	{
		List<CPTColor> colors = new List<CPTColor> { CPTColor.RedColor, CPTColor.BlueColor, CPTColor.GreenColor };
		static CPTMutableTextStyle whiteText;
		List<float> data;

		public PieSourceData (List<float> yValues)
		{
			if (whiteText == null) {
				whiteText = new CPTMutableTextStyle ();
				whiteText.Color = CPTColor.WhiteColor;
			}

			data = yValues;
		}

		public override int NumberOfRecordsForPlot (CPTPlot plot)
		{
			return data.Count;
		}

		public override NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, uint index)
		{
			if (forFieldEnum == CPTPlotField.PieChartWidth)
				return data [(int)index];
			return index;
		}

		public override CPTLayer DataLabelForPlot (CPTPlot plot, uint recordIndex)
		{
			string text = "Pie" + recordIndex;
			return new CPTTextLayer (text, whiteText);
		}

		public override CPTFill GetSliceFill (CPTPieChart pieChart, uint recordIndex)
		{
			return new CPTFill (colors[(int)recordIndex]);
		}
	}
}
