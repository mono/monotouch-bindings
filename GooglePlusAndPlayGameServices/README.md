Google Plus and Google Play GameServices
========================================

These are bindings to the native GooglePlus SDK and Google Play GameServices SDK for iOS 

Using
=====

Copy the Google.Plus.dll project in the binding directory to your
project, and add it as a reference in your project.

Building
========

Run `make' in the binding directory to build Google.Plus.dll.

Original Readme of both Projects
================================

This Google+ iOS SDK allows users to sign in and share with Google+ from
third-party apps.  The SDK also provides Google+ APIs for the app to access
the list of people in user-selected circles and to read and write user's app
activities.  The SDK contains the following files:

README  -- This file.

Changelog  -- The versions and changes of the SDK.

GooglePlus.framework/  -- The Google+ SDK framework.

GooglePlus.bundle/  -- Resources that can be used in your app.
                       Required if |GPPSignInButton| is used.

GoogleOpenSource.framework/ -- A framework containing all the open source files
                               used by the SDK.
                               Either add this framework or add individual
                               files in OpenSource/ directory into your project.

OpenSource/  -- Google open source files used by the SDK.
                This contains the same code as in GoogleOpenSource.framework.
                If you're not adding GoogleOpenSource.framework, add the files
                you need from this directory into your project.

SampleCode/  -- Sample code for your reference only.
                Do not include this in your project.
   GooglePlusSample.xcodeproj/  -- The Xcode project.


# Game Services SDK for iOS #

The Google Play game services SDK for iOS allows players to earn achievements, submit scores to
leaderboards, and save game state to the cloud.

## Documentation ##

For more information on Google Play game services, visit
<https://developers.google.com/games/services/>

To get started building games on iOS with the SDK, please visit
<https://developers.google.com/games/services/ios/quickstart>, and be sure to browse our
API reference documentation at <https://developers.google.com/games/services/ios/api/annotated>

## Third Party Code Notices ##

This software includes the following third party code:

+ Nimbus Framework, which is licensed under the Apache 2 license
<http://www.apache.org/licenses/LICENSE-2.0.html>

+ `Reachability.m`, which is licensed under the following license:

        Disclaimer: IMPORTANT:  This Apple software is supplied to you by Apple Inc.
        ("Apple") in consideration of your agreement to the following terms, and your
        use, installation, modification or redistribution of this Apple software
        constitutes acceptance of these terms.  If you do not agree with these terms,
        please do not use, install, modify or redistribute this Apple software.

        In consideration of your agreement to abide by the following terms, and subject
        to these terms, Apple grants you a personal, non-exclusive license, under
        Apple's copyrights in this original Apple software (the "Apple Software"), to
        use, reproduce, modify and redistribute the Apple Software, with or without
        modifications, in source and/or binary forms; provided that if you redistribute
        the Apple Software in its entirety and without modifications, you must retain
        this notice and the following text and disclaimers in all such redistributions
        of the Apple Software.
        Neither the name, trademarks, service marks or logos of Apple Inc. may be used
        to endorse or promote products derived from the Apple Software without specific
        prior written permission from Apple.  Except as expressly stated in this notice,
        no other rights or licenses, express or implied, are granted by Apple herein,
        including but not limited to any patent rights that may be infringed by your
        derivative works or by other works in which the Apple Software may be
        incorporated.

        The Apple Software is provided by Apple on an "AS IS" basis.  APPLE MAKES NO
        WARRANTIES, EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION THE IMPLIED
        WARRANTIES OF NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR A PARTICULAR
        PURPOSE, REGARDING THE APPLE SOFTWARE OR ITS USE AND OPERATION ALONE OR IN
        COMBINATION WITH YOUR PRODUCTS.

        IN NO EVENT SHALL APPLE BE LIABLE FOR ANY SPECIAL, INDIRECT, INCIDENTAL OR
        CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE
        GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
        ARISING IN ANY WAY OUT OF THE USE, REPRODUCTION, MODIFICATION AND/OR
        DISTRIBUTION OF THE APPLE SOFTWARE, HOWEVER CAUSED AND WHETHER UNDER THEORY OF
        CONTRACT, TORT (INCLUDING NEGLIGENCE), STRICT LIABILITY OR OTHERWISE, EVEN IF
        APPLE HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

        Copyright (C) 2010 Apple Inc. All Rights Reserved.

+ `json-framework`, which is licensed under the following license:

        Copyright (C) 2008 Stig Brautaset. All rights reserved.

        Redistribution and use in source and binary forms, with or without
        modification, are permitted provided that the following conditions are met:

          Redistributions of source code must retain the above copyright notice, this
          list of conditions and the following disclaimer.

          Redistributions in binary form must reproduce the above copyright notice,
          this list of conditions and the following disclaimer in the documentation
          and/or other materials provided with the distribution.

          Neither the name of the author nor the names of its contributors may be used
          to endorse or promote products derived from this software without specific
          prior written permission.

        THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
        AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
        IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
        DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
        FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
        DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
        SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
        CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
        OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
        OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

+ `Protocol Buffers in Objective-C`, which is licensed under the following license:

        Copyright 2008, Google Inc.
        All rights reserved.

        Redistribution and use in source and binary forms, with or without
        modification, are permitted provided that the following conditions are
        met:

            * Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.
            * Redistributions in binary form must reproduce the above
        copyright notice, this list of conditions and the following disclaimer
        in the documentation and/or other materials provided with the
        distribution.
            * Neither the name of Google Inc. nor the names of its
        contributors may be used to endorse or promote products derived from
        this software without specific prior written permission.

        THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
        "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
        LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
        A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
        OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
        SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
        LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
        DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
        THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
        (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
        OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

        Code generated by the Protocol Buffer compiler is owned by the owner
        of the input file used when generating it.  This code is not
        standalone and requires a support library to be linked with it.  This
        support library is itself covered by the above license.

+ `Cocoa Lumberjack`, which is licensed under the New BSD License.
<http://opensource.org/licenses/BSD-3-Clause>
