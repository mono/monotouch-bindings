using System;
using MonoTouch.Foundation;
using System.Runtime.InteropServices;

namespace Amazon.LogIn
{
	public partial class AIError : NSObject
	{
		public AIErrorCode Code { 
			get {
				uint code = Code_;

				if (code == AIErrorCons.NoError.ToUint ())
					return AIErrorCode.NoError;
				else if (code == AIErrorCons.ApplicationNotAuthorized.ToUint ())
					return AIErrorCode.ApplicationNotAuthorized;
				else if (code == AIErrorCons.ServerError.ToUint ())
					return AIErrorCode.ServerError;
				else if (code == AIErrorCons.ErrorUserInterrupted.ToUint ())
					return AIErrorCode.ErrorUserInterrupted;
				else if (code == AIErrorCons.AccessDenied.ToUint ())
					return AIErrorCode.AccessDenied;
				else if (code == AIErrorCons.DeviceError.ToUint ())
					return AIErrorCode.DeviceError;
				else if (code == AIErrorCons.InvalidInput.ToUint ())
					return AIErrorCode.InvalidInput;
				else if (code == AIErrorCons.NetworkError.ToUint ())
					return AIErrorCode.NetworkError;
				else if (code == AIErrorCons.UnauthorizedClient.ToUint ())
					return AIErrorCode.UnauthorizedClient;
				else if (code == AIErrorCons.InternalError.ToUint ())
					return AIErrorCode.InternalError;
				else
					return AIErrorCode.UnknownError;
			}
			set {
				Code_ = (uint)value;
			}
		}
	}

	public static partial class AIErrorCons
	{
		public static uint ToUint (this IntPtr ptr)
		{
			return (uint)Marshal.PtrToStructure(ptr, typeof(uint));
		}
	}
}

