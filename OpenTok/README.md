The OpenTok binding requires users to download the latest version of the
OpenTok SDK.

Once you download the SDK, add the file Opentok.framework/OpenTok as a file
to your project.   Then select the file, and set Build Action to be
"ObjcBindingNativeLibrary".

The above is necessary, because OpenTok does not allow redistribution of their
binaries.

Once you have your resulting dll library, you can add that to a project.
