namespace MonoTouch.FacebookConnect {

	public partial class Facebook {
	}

	public partial class FBSession {
		static public bool IsSessionOpenWithState(FBSessionState state) { return (0 != (state & FBSessionState.OPENBIT)); }
		static public bool IsSessionStateTerminal(FBSessionState state) { return (0 != (state & FBSessionState.TERMINALBIT)); }
	}
}
