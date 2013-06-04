using System;

namespace Google.Plus
{
	public partial class Share
	{
		ShareBuilder ShareDialog { get { return new ShareBuilder (ShareDialog_); } }
	}

	public static class PlusConstants
	{
		// Authorization scope
		public const string AuthScopePlusLogin = @"https://www.googleapis.com/auth/plus.login";
		public const string AuthScopePlusMe    = @"https://www.googleapis.com/auth/plus.me";

		// Collection
		public const string PlusCollectionPlusoners = @"plusoners";
		public const string PlusCollectionPublic    = @"public";
		public const string PlusCollectionResharers = @"resharers";
		public const string PlusCollectionVault     = @"vault";
		public const string PlusCollectionVisible   = @"visible";

		// OrderBy
		public const string PlusOrderByAlphabetical = @"alphabetical";
		public const string PlusOrderByBest         = @"best";
		public const string PlusOrderByRecent       = @"recent";

		// SortOrder
		public const string PlusSortOrderAscending  = @"ascending";
		public const string PlusSortOrderDescending = @"descending"; 
		
	}

}

