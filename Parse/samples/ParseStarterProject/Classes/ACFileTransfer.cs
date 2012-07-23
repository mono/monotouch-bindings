//
//  Copyright 2012  James Clancey, Xamarin Inc  (http://www.xamarin.com)
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;

namespace ParseStarterProject
{

	public class ACFileTransferDetails : NSObject
	{

		public string Peer {get;set;}
		public string Digest {get;set;}
		public string UUID {get;set;}
		public string filename {get;set;}
		public int Bytes {get;set;}
		public int Total {get;set;}
		public int Start {get;set;}
		public int Length {get;set;}
		public NSData Data {get;set;}
	}
}

