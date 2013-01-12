Route-Me
========

These are bindings to the native Route-Me control, a MapKit alternative. The bindings were developed and tested against the Alpstein fork of the Route-Me control. They don't cover 100% of the API but a good core chunk is covered (Jan2013). They should work on other Route-Me forks, as well as MapBox which is based on Route-Me. There was some limited testing done with MapBox.


These bindings were created using the bindings project template described here: http://docs.xamarin.com/ios/Guides/Advanced_Topics/Binding_Objective-C_Libraries

The raw binding source itself was generated using the utility posted by Kevin McMahon here: http://www.kevfoo.com/2011/09/monotouch_bindings/. This was then manually edited for cleanliness and to just get it working. However, the API has not been ".Net-ified". There's been no attempt to adapt the API to a more typical .Net framework experience like has been done with the MonoTouch libraries themselves.

Using
=====

Copy the contents of the binding folder to a suitable location and add the csproj as an existing project to your solution. Then add a project reference to it. To get Intellisense working you might also need to add a direct dll reference to the output of the binding project.

The livMapView.a file in the binding folder was created from the Alpstein fork of the Route-Me library (https://github.com/Alpstein/route-me). "lipo" was used to combing the i386 and Arm7 dll's into a universal binary file. If you want to run against MapBox or a different Route-Me fork, build the desired project in a consistent way to libMapView.a as described by the process here: http://docs.xamarin.com/ios/Guides/Advanced_Topics/Native_Interop.

Sample
======

A sample solution is in the sample folder. It simply loads a map control and connects it to the OpenStreetMap web source.

License
=======

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.


Authors
=======

Dennis Welu