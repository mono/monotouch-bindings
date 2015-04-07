Linea PRO SDK for Xamarin.iOS
=============================

This Xamarin.iOS project binds `DTDevices-iOS_2015-02-v1` library AKA (Version 1.96).

## Prerequisites

In order to compile the `LineaProSdk.dll` you need to obtain and include `libdtdev.a` file inside the `binding` directory

Steps to obtain and include `libdtdev.a`:

1. Go to [http://ipcprint.com/developer/](http://ipcprint.com/developer/).
2. Register an Account or log in using your credentials.
3. Download and unzip **DTDevices-iOS_2015-02-v1.Universal_XCode6.zip**
4. Copy `DTDevices-iOS_2015-02-27_v1.96_Universal_XCode6/Library/libdtdev.a` inside `binding` folder.

## Building LineaProSdk.dll

In order to build `LineaProSdk.dll` you have two options:

**Via Xamarin Studio**

1. Open Xamarin Studio
2. Click on **File > Open…** and locate `/Path/to/monotouch-bindings/LineaPro/binding/LineaProSdk.csproj`
3. Build the project.
4. You will find `LineaProSdk.dll` inside `/Path/to/monotouch-bindings/LineaPro/binding/bin/`

**Via Command-line**

1. Open `Terminal.app` and **cd** into `/Path/to/monotouch-bindings/LineaPRO/`
2. Run the `make` command.
3. The `LineaProSdk.dll` will be generated inside `binding` directory.

## Code Code Code...

Once you have your freshly baked `LineaProSdk.dll` you can run the included sample in your device and start developing awesome apps!

__Just one note:__ Whenever you create a new Xamarin.iOS project that will be using Linea PRO SDK don't forget to add the following keys inside your __info.plist__ file:

```xml
	<key>UISupportedExternalAccessoryProtocols</key>
	<array>
		<string>com.datecs.linea.pro.msr</string>
		<string>com.datecs.linea.pro.bar</string>
	</array>
```

## License

Copyright (c) 2013 Xamarin, Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Authors

Alex Soto 
