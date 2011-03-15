using System;
using MonoTouch.UIKit;
using MonoTouch.CorePlot;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace iOSsample
{
	// A convenience class to show samples
	public class PlotViewController : UIViewController {
		CPGraphHostingView host;
		protected CPGraph Graph;
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// Host the graph
			host = new CPGraphHostingView (new RectangleF (10, 40, 300, 300)) {
				HostedGraph = Graph
			};
			View.AddSubview (host);
		}
	
	}
	
	public class ScatterPlot : PlotViewController { 
		CPXYGraph graph;

		public ScatterPlot ()
		{
			SetupGraph ();
			SetupAxes ();
			SetupScatterPlots ();
			Graph = graph;
		}
		
		void SetupGraph ()
		{
			var theme = CPTheme.ThemeNamed ("Plain Black");
			
			graph = new CPXYGraph (new RectangleF (0, 0, 300, 300), CPScaleType.Linear, CPScaleType.Linear){
				PaddingLeft = 10,
				PaddingRight = 10,
				PaddingTop = 10,
				PaddingBottom = 10,
				Title = "My graph",
				
				TitleTextStyle = new CPTextStyle () {
					FontSize = 18,
					FontName = "Helvetica",
					Color = CPColor.GrayColor
				},
			};
			graph.ApplyTheme (theme);
		}
		
		void SetupAxes ()
		{
			var plotspace = graph.DefaultPlotSpace;
			plotspace.AllowsUserInteraction = true;
			
			var major = new CPLineStyle () {
				LineWidth = .75f,
				LineColor = CPColor.FromGenericGray (0.2f).ColorWithAlphaComponent (.75f)
			};
			
			var minor = new CPLineStyle () {
				LineWidth = .25f,
				LineColor = CPColor.WhiteColor.ColorWithAlphaComponent (0.1f)
			};
			
			var axisSet = (CPXYAxisSet) graph.AxisSet;
			
			// Label x with a fixed interval policy
			var x = axisSet.XAxis;
			x.LabelingPolicy = CPAxisLabelingPolicy.PolicyAutomatic;
			x.MinorTicksPerInterval = 4;
			x.PreferredNumberOfMajorTicks = 8;
			x.MajorGridLineStyle = major;
			x.MinorGridLineStyle = minor;
			x.Title = "X Axis";
			x.TitleOffset = -30;

			// Label y with an automatic label policy. 
    		var y = axisSet.YAxis;
		    y.LabelingPolicy = CPAxisLabelingPolicy.PolicyAutomatic;
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
        	var dataSourceLinePlot = new CPScatterPlot () {
				CachePrecision = CPPlotCachePrecision.Double,
				DataLineStyle = new CPLineStyle () {
					LineWidth = 2,
					LineColor = CPColor.GreenColor
				},
				// For Kang, check this out:
				DataSource = new RandomSamplesSource (),
				PlotSymbolMarginForHitDetection = 5,
			};
			graph.AddPlot (dataSourceLinePlot);
			
			// Create a plot for the selection marker
			var selectionPlot = new CPScatterPlot () {
				CachePrecision = CPPlotCachePrecision.Double,
				DataLineStyle = new CPLineStyle () {
					LineWidth = 3,
					LineColor = CPColor.RedColor
				},
				//DataSource = new SelectionSource (graph)
			};
			graph.AddPlot (selectionPlot);	
			
			var space = graph.DefaultPlotSpace as CPXYPlotSpace;
			space.ScaleToFitPlots (new CPPlot [] { dataSourceLinePlot });
			
			// Setting these will lock the scrolling on each direction:
			//space.GlobalXRange = new CPPlotRange (NSNumber.FromDouble (-1).NSDecimalValue, NSNumber.FromDouble (10).NSDecimalValue);
			//space.GlobalYRange = new CPPlotRange (NSNumber.FromDouble (-5).NSDecimalValue, NSNumber.FromDouble (10).NSDecimalValue);
		}
	}
	public class RandomSamplesSource : CPScatterPlotDataSource {
		public List<PointF> Data;
		
		public RandomSamplesSource ()
		{
			Random r = new Random ();
			
			Data = new List<PointF> ();
			for (int i = 0; i < 100; i++){
				var y = i;
				Data.Add (new PointF (i * 0.5f, (float) y));
			}
		}
	
		public override int NumberOfRecordsForPlot (CPPlot plot)
		{
			return Data.Count;
		}
		
		public override NSNumber NumberForPlot (CPPlot plot, CPPlotField forFieldEnum, int index)
		{
			if (forFieldEnum == CPPlotField.ScatterPlotFieldX)
				return Data [index].X;
			else
				return Data [index].Y;
		}
		
		public override CPPlotSymbol GetSymbol (CPScatterPlot plot, int recordIndex)
		{
			return CPPlotSymbol.DiamondPlotSymbol;	
		}
	}
	
	public class SelectionSource : CPScatterPlotDataSource {
		CPGraph graph;
		
		public SelectionSource (CPGraph graph)
		{
			this.graph = graph;
		}
		
		public override int NumberOfRecordsForPlot (CPPlot plot)
		{
			return 5;
		}
		
		public override NSNumber NumberForPlot (CPPlot plot, CPPlotField forFieldEnum, int index)
		{
			var space = graph.DefaultPlotSpace as CPXYPlotSpace;
			
			switch (forFieldEnum){
			case CPPlotField.ScatterPlotFieldX:
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
				
			case CPPlotField.ScatterPlotFieldY:
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

