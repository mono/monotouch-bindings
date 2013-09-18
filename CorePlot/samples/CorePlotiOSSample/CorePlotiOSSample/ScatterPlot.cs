using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CorePlot;

namespace CorePlotiOSSample
{
	// A convenience class to show samples
	public class PlotViewController : UIViewController {
		CPTGraphHostingView host;
		protected CPTGraph Graph;
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0))
				EdgesForExtendedLayout = UIRectEdge.None;
			
			// Host the graph
			host = new CPTGraphHostingView (new RectangleF (10, 40, 300, 300)) {
				HostedGraph = Graph
			};
			View.AddSubview (host);
		}
	}
	
	public class ScatterPlot : PlotViewController { 
		CPTXYGraph graph;

		public ScatterPlot ()
		{
			SetupGraph ();
			SetupAxes ();
			SetupScatterPlots ();
			Graph = graph;
		}
		
		void SetupGraph ()
		{
			var theme = CPTTheme.ThemeNamed ("Plain Black");
			
			graph = new CPTXYGraph (new RectangleF (0, 0, 300, 300), CPTScaleType.Linear, CPTScaleType.Linear){
				PaddingLeft = 10,
				PaddingRight = 10,
				PaddingTop = 10,
				PaddingBottom = 10,
				Title = "My graph",
				
				TitleTextStyle = new CPTMutableTextStyle {
					FontSize = 18,
					FontName = "Helvetica",
					Color = CPTColor.GrayColor
				}
			};
			graph.ApplyTheme (theme);
		}
		
		void SetupAxes ()
		{
			var plotspace = graph.DefaultPlotSpace;
			plotspace.AllowsUserInteraction = true;
			
			var major = new CPTLineStyle {
				LineWidth = .75f,
				LineColor = CPTColor.FromGenericGray (0.2f).ColorWithAlphaComponent (.75f)
			};
			
			var minor = new CPTLineStyle {
				LineWidth = .25f,
				LineColor = CPTColor.WhiteColor.ColorWithAlphaComponent (0.1f)
			};
			
			var axisSet = (CPTXYAxisSet) graph.AxisSet;
			
			// Label x with a fixed interval policy
			var x = axisSet.XAxis;
			x.LabelingPolicy = CPTAxisLabelingPolicy.Automatic;
			x.MinorTicksPerInterval = 4;
			x.PreferredNumberOfMajorTicks = 8;
			x.MajorGridLineStyle = major;
			x.MinorGridLineStyle = minor;
			x.Title = "X Axis";
			x.TitleOffset = -30;

			// Label y with an automatic label policy. 
			var y = axisSet.YAxis;
			y.LabelingPolicy = CPTAxisLabelingPolicy.Automatic;
			y.MinorTicksPerInterval = 4;
			y.PreferredNumberOfMajorTicks = 8;
			y.MajorGridLineStyle = major;
			y.MinorGridLineStyle = minor;
			y.LabelOffset = 20;
			y.Title = "Y Axis";
			y.TitleOffset = -30;
		}
		
		void SetupScatterPlots ()
		{
			// Create a plot that uses the data source method
			var dataSourceLinePlot = new CPTScatterPlot {
				CachePrecision = CPTPlotCachePrecision.Double,
				DataLineStyle = new CPTLineStyle {
					LineWidth = 2,
					LineColor = CPTColor.GreenColor
				},
				// For Kang, check this out:
				DataSource = new RandomSamplesSource (),
				PlotSymbolMarginForHitDetection = 5
			};
			graph.AddPlot (dataSourceLinePlot);
			
			// Create a plot for the selection marker
			var selectionPlot = new CPTScatterPlot {
				CachePrecision = CPTPlotCachePrecision.Double,
				DataLineStyle = new CPTLineStyle {
					LineWidth = 3,
					LineColor = CPTColor.RedColor
				},
			};
			graph.AddPlot (selectionPlot);	
			
			var space = graph.DefaultPlotSpace as CPTXYPlotSpace;
			space.ScaleToFitPlots (new CPTPlot [] { dataSourceLinePlot });
			
			// Setting these will lock the scrolling on each direction:
			//space.GlobalXRange = new CPPlotRange (NSNumber.FromDouble (-1).NSDecimalValue, NSNumber.FromDouble (10).NSDecimalValue);
			//space.GlobalYRange = new CPPlotRange (NSNumber.FromDouble (-5).NSDecimalValue, NSNumber.FromDouble (10).NSDecimalValue);
		}
	}
	
	public class RandomSamplesSource : CPTScatterPlotDataSource {
		public List<PointF> Data;
		
		public RandomSamplesSource ()
		{
			Data = new List<PointF> ();
			for (int i = 0; i < 100; i++){
				var y = i;
				Data.Add (new PointF (i * 0.5f, (float) y));
			}
		}
	
		public override int NumberOfRecordsForPlot (CPTPlot plot)
		{
			return Data.Count;
		}
		
		public override NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, int index)
		{
			if (forFieldEnum == CPTPlotField.ScatterPlotFieldX)
				return Data [index].X;
			return Data [index].Y;
		}
		
		public override CPTPlotSymbol GetSymbol (CPTScatterPlot plot, int recordIndex)
		{
			return CPTPlotSymbol.DiamondPlotSymbol;	
		}
	}
	
	public class SelectionSource : CPTScatterPlotDataSource {
		CPTGraph graph;
		
		public SelectionSource (CPTGraph graph)
		{
			this.graph = graph;
		}
		
		public override int NumberOfRecordsForPlot (CPTPlot plot)
		{
			return 5;
		}
		
		public override NSNumber NumberForPlot (CPTPlot plot, CPTPlotField forFieldEnum, int index)
		{
			var space = graph.DefaultPlotSpace as CPTXYPlotSpace;
			
			switch (forFieldEnum){
			case CPTPlotField.ScatterPlotFieldX:
				switch (index){
				case 0:
					return NSNumber.FromDouble (space.GlobalXRange.MinLimitDouble);
					
				case 1:
					return NSNumber.FromDouble (space.GlobalXRange.MaxLimitDouble);
					
				case 2:
				case 3:
				case 4:
					return 1;
				}
				break;
				
			case CPTPlotField.ScatterPlotFieldY:
				switch (index){
				case 0:
				case 1:
				case 2:
					return 1;
				case 3:
					return NSNumber.FromDouble (space.GlobalYRange.MinLimitDouble);
					
				case 4:
					return NSNumber.FromDouble (space.GlobalYRange.MaxLimitDouble);
				}
				break;
			}
			return NSNumber.FromDouble (2);
		}
	}

#if false			
 
    // Set plot delegate, to know when symbols have been touched
        // We will display an annotation when a symbol is touched
    dataSourceLinePlot.delegate = self; 
    dataSourceLinePlot.plotSymbolMarginForHitDetection = 5.0;
    
    // Create a plot for the selection marker
        CPScatterPlot *selectionPlot = [[[CPScatterPlot alloc] init] autorelease];
    selectionPlot.identifier = SELECTION_PLOT;
        selectionPlot.cachePrecision = CPPlotCachePrecisionDouble;
    
    lineStyle = [[dataSourceLinePlot.dataLineStyle mutableCopy] autorelease];
        lineStyle.lineWidth = 3.0;
    lineStyle.lineColor = [CPColor redColor];
    selectionPlot.dataLineStyle = lineStyle;
    
    selectionPlot.dataSource = self;
    [graph addPlot:selectionPlot];
    
    // Auto scale the plot space to fit the plot data
    // Compress ranges so we can scroll
    CPXYPlotSpace *plotSpace = (CPXYPlotSpace *)graph.defaultPlotSpace;
    [plotSpace scaleToFitPlots:[NSArray arrayWithObject:dataSourceLinePlot]];
    CPPlotRange *xRange = plotSpace.xRange;
    [xRange expandRangeByFactor:CPDecimalFromDouble(0.75)];
    plotSpace.xRange = xRange;
    CPPlotRange *yRange = plotSpace.yRange;
    [yRange expandRangeByFactor:CPDecimalFromDouble(0.75)];
    plotSpace.yRange = yRange;
    
    CPPlotRange *globalXRange = [CPPlotRange plotRangeWithLocation:CPDecimalFromDouble(-1.0) length:CPDecimalFromDouble(10.0)];
    plotSpace.globalXRange = globalXRange;
    CPPlotRange *globalYRange = [CPPlotRange plotRangeWithLocation:CPDecimalFromDouble(-5.0) length:CPDecimalFromDouble(10.0)];
    plotSpace.globalYRange = globalYRange;
		}
#endif
}

