using System;
using MonoTouch.Foundation;
using System.Runtime.InteropServices;

namespace Amazon.LogIn
{
	public partial class ApiResult, IDisposable
	{
		public NSObject this [string key]
		{
			get{ return this.Result.ValueForKey (new NSString (key)); }
		}
	}
	
	public partial class ApiError, IDisposable
	{
	}

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
				var code = value;
				
				if (code == AIErrorCode.NoError)
					Code_ = AIErrorCons.NoError.ToUint ();
				else if (code == AIErrorCode.ApplicationNotAuthorized)
					Code_ = AIErrorCons.ApplicationNotAuthorized.ToUint ();
				else if (code == AIErrorCode.ServerError)
					Code_ = AIErrorCons.ServerError.ToUint ();
				else if (code == AIErrorCode.ErrorUserInterrupted)
					Code_ = AIErrorCons.ErrorUserInterrupted.ToUint ();
				else if (code == AIErrorCode.AccessDenied)
					Code_ = AIErrorCons.AccessDenied.ToUint ();
				else if (code == AIErrorCode.DeviceError)
					Code_ = AIErrorCons.DeviceError.ToUint ();
				else if (code == AIErrorCode.InvalidInput)
					Code_ = AIErrorCons.InvalidInput.ToUint ();
				else if (code == AIErrorCode.NetworkError)
					Code_ = AIErrorCons.NetworkError.ToUint ();
				else if (code == AIErrorCode.UnauthorizedClient)
					Code_ = AIErrorCons.UnauthorizedClient.ToUint ();
				else if (code == AIErrorCode.InternalError)
					Code_ = AIErrorCons.InternalError.ToUint ();
				else
					Code_ = (uint)AIErrorCode.UnknownError;
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

