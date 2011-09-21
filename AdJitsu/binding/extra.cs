using MonoTouch.ObjCRuntime;

[assembly:LinkWith ("libAdjitsuSDK.a", LinkerFlags="-framework QuartzCore -framework CoreGraphics -framework AVFoundation -framework CoreLocation -framework CoreMedia -framework CoreMotion -framework CoreText -framework MediaPlayer -framework MobileCoreServices -framework OpenGLES -framework QuartzCore -lxml2 -lsqlite3", NeedsCpp=true)]
