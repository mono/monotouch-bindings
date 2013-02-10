 MBAlertView
===================

MBAlertView is a fun and simple block-based alert and HUD library for iOS, as seen in [Notestand.](https://itunes.apple.com/us/app/notestand-notes-discussions/id586976282?mt=8)

[![](http://i.imgur.com/3s3eJ.png)](http://i.imgur.com/3s3eJ.png)
[![](http://i.imgur.com/7CbbT.png)](http://i.imgur.com/7CbbT.png) 
[![](http://i.imgur.com/lq53u.png)](http://i.imgur.com/lq53u.png)
[![](http://i.imgur.com/Aqfnr.png)](http://i.imgur.com/Aqfnr.png)

### Features
<ul>
	<li>Nested alerts and HUDs</li>
	<li>Block based</li>
	<li>Images</li>
	<li>Nice animations</li>
	<li>Doesn't use any PNG files. Everything is drawn with code.</li>
</ul>

## Usage

Run `make` to generate the binding. You will find the generated dll inside binding folder.

There are two factory methods to get you started:

### Alerts

``` csharp
var alert = MBAlertView.AlertWithBody ("Are you sure you want to delete this note? You cannot undo this.", "Cancel", () => {
	// Cancel button Actions
	Console.WriteLine ("Tapped Cancel Button");
});

alert.AddButtonWithText ("Delete", MBAlertViewItemType.Destructive, () => {
// Delete button Actions
	Console.WriteLine ("Tapped Delete Button");
});

alert.AddToDisplayQueue ();
```

### HUDs
``` csharp
MBHUDView.HudWithBody("Wait.", MBAlertViewHUDType.ActivityIndicator, 4.0f, true);
```

You can see more in the easy to follow demo.

## License
MBAlertView is available under the MIT license.

## Original Objective-C version

[https://github.com/mobitar/MBAlertView](https://github.com/mobitar/MBAlertView)