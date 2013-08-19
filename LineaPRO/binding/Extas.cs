using System;
using MonoTouch.Foundation;
using System.Runtime.InteropServices;

namespace LineaProSdk
{
	public partial class Linea
	{
		public bool PlaySound (int volume, int[] tones, out NSError error)
		{
			if ((tones.Length % 2) != 0 || tones.Length == 0)
				throw new ArgumentException ("Must be an even-length array of integers, where the odd elements are frequencies and the even elements are durations.", "tones");

			// Length is byte-based
			int Length = tones.Length*4;

			//Creating an IntPtr, pointing to a new array, to send to the device.
			IntPtr Ptr = Marshal.AllocHGlobal(Length);

			//Copying the tone data to the new array.
			for (int i = 0; i < tones.Length; i ++) Marshal.WriteInt32(Ptr, i*4, tones[i]);

			//Attempts to play the sound, providing the volume, the pointer to tone array, the byte length of the array, and an output error.
			bool Success = PlaySound_ (volume, Ptr, Length, out error);

			// Free memory before writing any errors
			Marshal.FreeHGlobal(Ptr);

			return Success;
		}

		public bool SetScanBeep (bool enabled, int volume, int[] tones, out NSError error)
		{
			if ((tones.Length % 2) != 0 || tones.Length == 0)
				throw new ArgumentException ("Must be an even-length array of integers, where the odd elements are frequencies and the even elements are durations.", "tones");

			// Length is byte-based
			int Length = tones.Length*4;

			//Creating an IntPtr, pointing to a new array, to send to the device.
			IntPtr Ptr = Marshal.AllocHGlobal(Length);

			//Copying the tone data to the new array.
			for (int i = 0; i < tones.Length; i ++) Marshal.WriteInt32(Ptr, i*4, tones[i]);

			//Attempts to play the sound, providing the volume, the pointer to tone array, the byte length of the array, and an output error.
			bool Success = BarcodeSetScanBeep_ (enabled, volume, Ptr, Length, out error);

			// Free memory before writing any errors
			Marshal.FreeHGlobal(Ptr);

			return Success;
		}

		public bool BtWrite (byte[] data, out NSError error) 
		{
			IntPtr ptr = Marshal.AllocHGlobal (data.Length);
			Marshal.Copy(data, 0, ptr, data.Length);
			bool success = BtWrite_ (ptr, data.Length, out error);
			Marshal.FreeHGlobal(ptr);

			return success;
		}

		public int BtRead (ref byte[] data, double timeout, out NSError error)
		{
			IntPtr ptr = Marshal.AllocHGlobal (data.Length);
			int result = BtRead_ (ref ptr, data.Length, timeout, out error);
			Marshal.Copy (ptr, data, 0, data.Length);
			Marshal.FreeHGlobal(ptr);

			return result;
		}
	}
}

