//
// extras.cs: Extensions to the generated classes in coreplot
//
// Author:
//   Miguel de Icaza
//
using System;
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
}
