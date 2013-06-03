# StatusBar
A minimal status bar for iOS. It covers the top status bar and appears like the message is embedded within. StatusBar is available in the [Xamarin Component Store](http://components.xamarin.com/) as a free component download.

![StatusBar Screenshot](KGStatusBar.png)

## Installation
### Binding
**Note**: This is not the recommended approach. Unless you are updating the binding manually and trying to test it out, I would recommend using the StatusBar component. It has a much more seamless integration into your application

1. Optional: Re-download KGStatusBar from Kevin Gibbons. Remove KGStatusBar.h/.m from the Static Library Xcode project and add the new versions. Build the static library and reference it in the binding project.
2. Build the binding.
3. Reference the .dll built in your project.

### Component
1. Open up the "Components" folder of the project you are wishing to add StatusBar to.
2. Browse for StatusBar in the Component Store.
3. Click "Add to App". The component will be downloaded and all references will be setup for you.

## Usage
There is a sample available with the component, though you can easily get the sample to work with the binding by referencing the .dll instead of adding the component.

Prior to Use: Add a using directive to the top of the class you are wishing to use StatusBar for.
    using KGStatusBar;

Usage:
    StatusBar.ShowWithStatus ("Status message!");
    StatusBar.ShowErrorWithStatus ("Error message!");
		StatusBar.ShowSuccessWithStatus ("Success message!");
    StatusBar.Dismiss ();

## Credits
StatusBar is the Xamarin.iOS-capable version of [KGStatusBar](https://github.com/kevingibbon/KGStatusBar) from Kevin Gibbon of [Attachments.me](https://attachments.me/). Kevin certainly deserves all the credit as all I have done is create the Xamarin.iOS binding for the library.

## License
Copyright (c) 2013 [Kevin Gibbon](http://www.kevingibbon.com/) [Pierce Boggan](http://pierceboggan.com/)

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
