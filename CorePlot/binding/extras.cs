//
// extras.cs: Extensions to the generated classes in coreplot
//
// Author:
//   Miguel de Icaza
//   Alex Soto
//

using System;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using System.Runtime.InteropServices;

namespace CorePlot
{
	public static class CPTNumericDataTypeUtils
	{
		[DllImportAttribute("__Internal", EntryPoint = "CPTDataTypeWithDataTypeString")]
		private static extern IntPtr _DataTypeWithDataTypeString (IntPtr dataTypeString);

		public static CPTNumericDataType DataTypeFromString (string dataType)
		{
			var dataTypeString = new NSString (dataType);

			var resultPtr = _DataTypeWithDataTypeString (dataTypeString.Handle);
			var result = (CPTNumericDataType)Marshal.PtrToStructure (resultPtr, typeof(CPTNumericDataType));

			return result;
		}

		[DllImportAttribute("__Internal", EntryPoint = "CPTDataTypeIsSupported")]
		[return: MarshalAsAttribute (UnmanagedType.Bool)]
		private static extern bool _DataTypeIsSupported (IntPtr dataType);

		public static bool DataTypeIsSupported (CPTNumericDataType format)
		{
			IntPtr formatPtr = Marshal.AllocHGlobal (Marshal.SizeOf ( typeof (CPTNumericDataType)));
			bool result;

			try {
				Marshal.StructureToPtr ((object)format, formatPtr, true);

				result = _DataTypeIsSupported (formatPtr);
			}
			finally {
				Marshal.FreeHGlobal (formatPtr);
			}
			return result;
		}

		[DllImportAttribute("__Internal", EntryPoint = "CPTDataTypeEqualToDataType")]
		[return: MarshalAsAttribute (UnmanagedType.Bool)]
		private static extern bool _DataTypeEqualToDataType (IntPtr dataType1, IntPtr dataType2);

		public static bool DataTypeEqualToDataType (CPTNumericDataType dataType1, CPTNumericDataType dataType2)
		{
			IntPtr dataType1Ptr = Marshal.AllocHGlobal (Marshal.SizeOf (typeof (CPTNumericDataType)));
			IntPtr dataType2Ptr = Marshal.AllocHGlobal (Marshal.SizeOf (typeof (CPTNumericDataType)));
			bool result;

			try {
				Marshal.StructureToPtr ((object)dataType1, dataType1Ptr, true);
				Marshal.StructureToPtr ((object)dataType2, dataType2Ptr, true);

				result = _DataTypeEqualToDataType (dataType1Ptr, dataType2Ptr);
			}
			finally {
				Marshal.FreeHGlobal (dataType1Ptr);
				Marshal.FreeHGlobal (dataType2Ptr);
			}
			return result;
		}
	}
}

