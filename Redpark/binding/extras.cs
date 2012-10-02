//
// extras.cs: Extensions to the generated classes in coreplot
//
// Author:
//   Miguel de Icaza
//
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Redpark {

	// Need to flag these as abstract, to avoid an error reported since we are models that inherit from a model
	public partial class RscMgr{
		public int Read( [In] [Out] byte[] buffer, int offset, int count)
		{
			IntPtr unmanagedPointer = Marshal.AllocHGlobal(buffer.Length);
			Marshal.Copy(buffer,offset, unmanagedPointer,count);
			var read = this.Read(unmanagedPointer,(uint)count);
			
			Marshal.Copy(unmanagedPointer, buffer,0, buffer.Length);
			// Call unmanaged code
			Marshal.FreeHGlobal(unmanagedPointer);

			return read;

		}
		public void Write (byte[] buffer, int offset, int count)
		{
			IntPtr unmanagedPointer = Marshal.AllocHGlobal(count);
			Marshal.Copy(buffer,offset, unmanagedPointer,count);
			this.Write(unmanagedPointer,(uint)count);
			
			Marshal.FreeHGlobal(unmanagedPointer);
		}
	}
	
	public class RedparkStream : Stream
	{
		public class BytesAvailableArgs : EventArgs{
			public int Length {get;set;}
		}
		public readonly RscMgr RscMgr;
		public RedparkStream(RscMgr rscmgr)
		{
			RscMgr = rscmgr;
		}
		public RedparkStream (int baud, ParityType parity,StopBitsType stopbits)
		{
			RscMgr = new RscMgr();
			RscMgr.Baud = baud;
			RscMgr.SetParity(parity);
			RscMgr.SetStopBits(stopbits);
		}
		#region implemented abstract members of Stream

		public override void Flush ()
		{

		}

		public override int Read (byte[] buffer, int offset, int count)
		{
			return RscMgr.Read(buffer,offset,count);
		}

		public override long Seek (long offset, SeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public override void SetLength (long value)
		{
			throw new NotImplementedException ();
		}

		public override void Write (byte[] buffer, int offset, int count)
		{
			RscMgr.Write(buffer,offset,count);
		}

		public override bool CanRead {
			get {
				return true;
			}
		}

		public override bool CanSeek {
			get {
				return false;
			}
		}

		public override bool CanWrite {
			get {
				return true;
			}
		}

		public override long Length {
			get {
				return  0;
			}
		}

		public override long Position {
			get {
				return 0;
			}
			set {
			}
		}

#endregion
	}
}
