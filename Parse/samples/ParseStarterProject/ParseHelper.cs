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
using ParseTouch;
using MonoTouch.Foundation;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;


namespace ParseStarterProject
{

	public static class ParseHelper
	{

		public static ParseObject ToPfObject(this object obj)
		{
			var type = obj.GetType();
			var pfObj = ParseObject.FromName(type.Name);
			var properties = type.GetProperties();
			foreach(var prop in properties)
			{
				if(Attribute.IsDefined(prop,typeof(IgnoreDataMemberAttribute)))
					continue;
				string keyName = Attribute.IsDefined(prop,typeof(DataMemberAttribute)) ? ((DataMemberAttribute)Attribute.GetCustomAttribute(prop,typeof(DataMemberAttribute))).Name : prop.Name;
				if(keyName == "UpdatedAt" || keyName == "CreatedAt" || keyName == "ObjectId")
					continue;
				var val = prop.GetValue(obj,null);
				NSString valString;
				if(val is DateTime)
					valString = new NSString(((DateTime)val).ToString("s"));
				else
					valString = new NSString(val.ToString());
				pfObj.SetObjectforKey(valString,keyName);
			}
			return pfObj;
		}

		public static T ToObject<T> (this ParseObject pfObj) where T : new ()
		{
			T obj = new T();
			var type = obj.GetType();

			var keys = pfObj.AllKeys;
			foreach(var prop in type.GetProperties())
			{
				string keyName = Attribute.IsDefined(prop,typeof(DataMemberAttribute)) ? ((DataMemberAttribute)Attribute.GetCustomAttribute(prop,typeof(DataMemberAttribute))).Name : prop.Name;
				if(!keys.Contains(keyName) && keyName != "UpdatedAt" && keyName != "CreatedAt" && keyName != "ObjectId")
					continue;
				if(keyName == "UpdatedAt")
				{
					prop.SetValue(obj,(DateTime)(pfObj.UpdatedAt ?? DateTime.MinValue),null);
					continue;
				}
				else if(keyName == "CreatedAt")
				{
					prop.SetValue(obj,(DateTime)(pfObj.CreatedAt ?? DateTime.MinValue),null);
					continue;
				}
				else if(keyName == "ObjectId")
				{
					prop.SetValue(obj,pfObj.ObjectId,null);
					continue;
				}
				if(prop.PropertyType == typeof(DateTime))
					prop.SetValue (obj,DateTime.ParseExact(pfObj.ObjectForKey(keyName).ToString(),"s",CultureInfo.InvariantCulture),null);
				else if (prop.PropertyType.IsEnum)
					prop.SetValue (obj,Enum.Parse(prop.PropertyType, pfObj.ObjectForKey(keyName).ToString()),null);
				else if(prop.PropertyType == typeof(String))					
					prop.SetValue (obj,pfObj.ObjectForKey(keyName).ToString(),null);
				else
					prop.SetValue (obj,Convert.ChangeType(pfObj.ObjectForKey(keyName).ToString(),prop.PropertyType),null);
			}

			return obj;
		}
	}
}

