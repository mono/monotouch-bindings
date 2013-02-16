LAAnimatedGrid
==========

[Luis Ascorbe](http://about.me/lascorbe)

Tweet me [@LuisEAM](http://twitter.com/luiseam)

`LAAnimatedGrid` automatically make a grid like the [flayvr app](http://www.flayvr.com/).

Of course, I'll love to hear your using my control in your app, you can contact me (<devlascorbe@gmail.com>) anytime

![Screenshot of LAAnimatedGrid](https://raw.github.com/Lascorbe/LAAnimatedGrid/master/captura.png  "LAAnimatedGrid Screenshot")

Example
==========
Build and run the `LAAnimatedGridExample` project in Xcode to see `LAAnimatedGrid` in action.


Requeriments
==========

`LAAnimatedGrid` can be used in iOS5 and iOS6. Work with ARC and non-ARC projects.

· Xcode 4.5 or higher

· Apple LLVM compiler

· iOS 5.0 or higher


Instructions
==========

Just drag and drop the project files to your project, then add the following libraries:

AFNetworking:
- SystemConfiguration.framework 
- MobileCoreServices.framework 
- QuartzCore.framework 

Note: If you are not using ARC in your project, add `-fobjc-arc` as a compiler flag for the `AFNetworking` classes.


Usage
==========

* Init and pass the array of images

``` objective-c
    laag = [[LAAnimatedGrid alloc] initWithFrame:CGRectMake(10, 10, 300, 200)];
    [laag setArrImages:arrImages];
    [self.view addSubview:laag];
```

* Other properties you could customize

``` objective-c
    [laag setLaagOrientation:LAAGOrientationVertical];
    [laag setLaagBorderColor:[UIColor blackColor]];
    [laag setLaagBackGroundColor:[UIColor whiteColor]];
```

NOTE: `LAAnimatedGrid` support rotations and the array could be UIImages or NSURLs (to web images).


Credits
==========

Mattt Thompson and Scott Raymond creators of [AFNetworking](https://github.com/AFNetworking/AFNetworking)


License
=======

`LAAnimatedGrid` is distributed under the terms and conditions of the MIT license. 

Copyright (c) 2012 Luis Ascorbe

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
