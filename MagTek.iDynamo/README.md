MagTek.iDynamo
==============

These are bindings to MagTek's native iDynamo SDK for iOS from
http://www.magtek.com/support/software/programming_tools/

Using
=====

Copy the MagTek.iDynamo.dll project in the binding directory to your
project, and add it as a reference in your project.

Building
========

Run `make' in the binding directory to build MagTek.iDynamo.dll.

Sample
======

The sample program in sample/ is a partial port of MagTek's sample iDynamo
program, it covers about half of the features in it.

ARMv7 support
=============

The downloaded static library contains duplicate symbols for ARMv7 that
results in an error when linking ARMv7 projects (e.g. for an iPad app).
The fix requires some minor surgery on the static library:
	* split the .a into both an armv6 and armv7 .a (lipo -thin) 
	* decompress the armv7.a (ar -x)
	* the duplicate will overwrite themselves, no work required
	* recompress the armv7.a library (libtool -static)
	* merge the (old) armv6 and the new armv7 libraries (lip -create)
	* rebuild the bindings

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
