/*
 * C# sample for BarPlot:
 *
 * Author:
 * Berndt Hamboeck
 */
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CorePlot;

namespace CorePlotiOSSample
{
	public class BarPlot : PlotViewController
	{ 
		CPTXYGraph graph;

		public BarPlot ()
		{
			SetupGraph ();
			SetupAxes ();
			SetupBarPlots ();
			Graph = graph;
		}
		
		void SetupGraph ()
		{
			var theme = CPTTheme.ThemeNamed ("Plain Black");
			
			graph = new CPTXYGraph (new RectangleF (0, 0, 300, 300), CPTScaleType.Linear, CPTScaleType.Linear){
				PaddingLeft = 0,
				PaddingRight = 0,
				PaddingTop = 0,
				PaddingBottom = 0,
				Title = "Bar Chart",
				
				TitleTextStyle = new CPTMutableTextStyle () {
					FontSize = 18,
					FontName = "Helvetica",
					Color = CPTColor.GrayColor
				},
				TitleDisplacement = new PointF(0, -20f)
			};
			graph.ApplyTheme (theme);
		}
		
		void SetupAxes ()
		{
			var plotspace = graph.DefaultPlotSpace;
			plotspace.AllowsUserInteraction = true;
			plotspace.Delegate = new MyBarDelegate ();
			
			var major = new CPTLineStyle () {
				LineWidth = .75f,
				LineColor = CPTColor.FromGenericGray (0.2f).ColorWithAlphaComponent (.75f)
			};
			
			var minor = new CPTLineStyle () {
				LineWidth = .25f,
				LineColor = CPTColor.WhiteColor.ColorWithAlphaComponent (0.1f)
			};
			
			var axisSet = (CPTXYAxisSet)graph.AxisSet;
			
			// Label x with a fixed interval policy
			var x = axisSet.XAxis;
			x.LabelingPolicy = CPTAxisLabelingPolicy.None;
			x.Title = "X Axis";
			x.TitleOffset = 0;

			// Label y with an automatic label policy. 
			var y = axisSet.YAxis;
			y.LabelingPolicy = CPTAxisLabelingPolicy.None;
			y.LabelOffset = 0;
			y.Title = "Y Axis";
			y.TitleOffset = 0;
		}
		
		void SetupBarPlots ()
		{
			// Create a plot that uses the data source method
			var inputSocket = new List<float> () { 30, 20, 10, 20, 10, 55 };

			var barPlot = new CPTBarPlot () {
				DataSource = new BarSourceData (inputSocket),
				BaseValue = 0,
				BarOffset = (NSDecimal)(-0.25),
				Identifier = (NSString) "Bar Plot 1"
			};
			graph.AddPlot (barPlot);	

			barPlot.Fill = new CPTFill (CPTColor.BrownColor);
			graph.AddPlot (barPlot, graph.DefaultPlotSpace);	
			
			var space = graph.DefaultPlotSpace as CPTXYPlotSpace;		
			space.ScaleToFitPlots (new CPTPlot [] { barPlot});
			
			decimal newYMax = (decimal)space.YRange.MaxLimit + (decimal)space.YRange.MaxLimit * 0.2m;
			space.YRange = new CPTPlotRange (-4, new NSDecimalNumber (newYMax.ToString ()).NSDecimalValue);
			
			decimal newXMax = (decimal)space.XRange.MaxLimit + 2;
			decimal newXMin = (decimal)space.XRange.MinLimit - 1;
			space.XRange = new CPTPlotRange (new NSDecimalNumber (newXMin.ToString ()).NSDecimalValue, 
							 new NSDecimalNumber (newXMax.ToString ()).NSDecimalValue);
		}
	}
	
	public class MyBarDelegate : CPTBarPlotDelegate {
		public override void BarSelected (CPTBarPlot plot, int recordIndex)
		{
			Console.WriteLine ("Selected at {0}", recordIndex);
		}
	}

	public class BarSourceData : CPTBarPlotDataSource {
		static CPTMutableTextStyle whiteText = null;
		List<PointF> data;
		float minVal;
		float maxVal;

		public BarSourceData (List<float> yValues)
		{
			if (whiteText == null) {
				whiteText = new CPTMutableTextStyle ();
				whiteText.Color = CPTColor.WhiteColor;
			}
			
			maxVal = yValues.Max();
			minVal = yValues.Min();
			
			data = new List<PointF> (); 
			float xPos = 1f;
			foreach (float yVal in yValues) {
				data.Add (new PointF (xPos * 0.5f, yVal));
				xPos++;
			}
		}
	
		public override int NumberOfRecordsForPlot (CPTPlot plot)
		{
			return data.Count;
		}
		
		public override NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, int index)
		{
			if (forFieldEnum == CPTPlotField.BarLocation)
				return data [index].X;
			else
				return data [index].Y;
		}
		
		public override CPTLayer DataLabelForPlot (CPTPlot plot, int recordIndex)
		{
			string text = "Bar" + recordIndex.ToString ();
			return new CPTTextLayer (text, whiteText);
		}
		
		public override CPTFill GetBarFill (CPTBarPlot barPlot, int recordIndex)
		{
			if (data[recordIndex].Y == minVal )
				return new CPTFill (CPTColor.RedColor);
			else if (data[recordIndex].Y == maxVal )
				return new CPTFill (CPTColor.GreenColor);
			
			return null;
		}
	}
}

