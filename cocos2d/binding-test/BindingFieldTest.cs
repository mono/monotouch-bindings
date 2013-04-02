//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Reflection;

using NUnit.Framework;
using TouchUnit.Bindings;

#if MONOMAC
using MonoMac.Cocos2D;
#else
using MonoTouch.Cocos2D;
using MonoTouch.Foundation;
#endif

namespace Cocos2D.Bindings {
	
	[TestFixture]
	public class BindingFieldTest : ApiFieldTest {
		
		public BindingFieldTest ()
		{
			// Useful to know what was being tried if things crash
			LogProgress = true;

			// Useful for fixing several errors before rebuilding the bindings
			ContinueOnFailure = true;
		}
		
		protected override Assembly Assembly {
			get { 
				var assembly = typeof (CCAccelAmplitude).Assembly;
#if MONOMAC
				MonoMac.ObjCRuntime.Runtime.RegisterAssembly (assembly);
#endif
				
				return assembly; 
			}
		}
	}
}