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

namespace Tapit
{
	public enum TapItAdType
	{
		Banner       = 0x01,
		Fullscreen   = 0x02,
		Video        = 0x04,
		OfferWall    = 0x08,
	};

	public enum TapItInterstitialControlType
	{
		None        = 0x00,
		Lightbox    = 0x01,
		ActionSheet = 0x02,
	};

	public enum TapItBannerHideDirection
	{
		None,
		Left,
		Right,
		Up,
		Down,
	};


}

