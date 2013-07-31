##Dropbox Chooser for Xamarin.iOS


Xamarin.iOS bindings for Dropbox Chooser API `version 1.0`
https://www.dropbox.com/developers/dropins


###Setup instructions


1. Run `make` command inside `bindings` directory
2. Open `bindings` directory, extract dropbox-ios-chooser-sdk-1.0.zip and add `DBChooser.bundle` to your project under `Resources` directory.
3. Reference `DropboxChooser.iOS.dll` in your project.

###Creating a URL scheme

The Chooser communicates with the Dropbox app to allow users to select a file without having to authorise. In order to navigate back to our app, we need add a URL scheme that Dropbox app can call:

1. Double click on your project, under `Build`->`iOS Application` select Advanced tab. Under `URL Types` section press `Add URL Type` and select `Role` as `Editor`
2. In the `URL Schemes` enter db-APP_KEY (replacing APP_KEY with the key generated when you created your app)

More info - https://www.dropbox.com/developers/dropins/chooser/ios