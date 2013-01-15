using System;

using MonoTouch.CoreLocation;

namespace RouteMe
{
	public enum RMUserTrackingMode
	{
		RMUserTrackingModeNone              = 0,
		RMUserTrackingModeFollow            = 1,
		RMUserTrackingModeFollowWithHeading = 2
	}
	
	public enum RMBoundingMask
	{
		RMMapNoMinBound		= 0,
		RMMapMinHeightBound	= 1,
		RMMapMinWidthBound	= 2
	}
	
	public enum RMMapDecelerationMode
	{
		RMMapDecelerationNormal = 0,
		RMMapDecelerationFast   = 1, // default
		RMMapDecelerationOff    = 2
	}
	
	public struct RMTile
	{
		public uint x;
		public uint y;
		public short zoom;
	}
	
	public struct RMTilePoint
	{
		public RMTile tile;
		public System.Drawing.PointF offset;
	}
	
	public struct RMTileRect
	{
		public RMTilePoint origin;
		public System.Drawing.SizeF size;
	}
	
	public struct RMSphericalTrapezium
	{
		public CLLocationCoordinate2D southWest;
		public CLLocationCoordinate2D northEast;
	}
	
	public struct RMProjectedPoint
	{
		public double x, y;
	}
	
	public struct RMProjectedSize
	{
		public double width, height;
	}
	
	public struct RMProjectedRect
	{
		public RMProjectedPoint origin;
		public RMProjectedSize size;
	}
	
	public enum  RMCachePurgeStrategy
	{
		RMCachePurgeStrategyLRU,
		RMCachePurgeStrategyFIFO,
	}
}
