using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace InMobiSdk
{
	[BaseType (typeof (UIView))]
	public partial interface IMBanner {

		[Export ("initWithFrame:appId:adSize:")]
		IntPtr Constructor (RectangleF frame, string appId, IMAdSize adSize);

		[Export ("initWithFrame:slotId:")]
		IntPtr Constructor (RectangleF frame, long slotId);

		[Export ("adSize")]
		IMAdSize AdSize { get; set; }

		[Export ("appId", ArgumentSemantic.Copy)]
		string AppId { get; set; }

		[Export ("slotId")]
		long SlotId { get; set; }

		[Export ("loadBanner")]
		void LoadBanner ();

		[Export ("stopLoading")]
		void StopLoading ();

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		IIMBannerDelegate Delegate { get; set; }

		[Export ("refreshInterval")]
		int RefreshInterval { get; set; }

		[Export ("refreshAnimation")]
		UIViewAnimationTransition RefreshAnimation { get; set; }

		[Export ("additionaParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionaParameters { get; set; }

		[Export ("keywords", ArgumentSemantic.Copy)]
		string Keywords { get; set; }

		[Export ("refTagKey", ArgumentSemantic.Copy)]
		string RefTagKey { get; set; }

		[Export ("refTagValue", ArgumentSemantic.Copy)]
		string RefTagValue { get; set; }
	}

	public interface IIMBannerDelegate { }

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface IMBannerDelegate {

		[Export ("bannerDidReceiveAd:")]
		void DidReceiveAd (IMBanner banner);

		[Export ("banner:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (IMBanner banner, IMError error);

		[Export ("bannerDidInteract:withParams:")]
		void DidInteract (IMBanner banner, NSDictionary dictionary);

		[Export ("bannerWillPresentScreen:")]
		void WillPresentScreen (IMBanner banner);

		[Export ("bannerWillDismissScreen:")]
		void WillDismissScreen (IMBanner banner);

		[Export ("bannerDidDismissScreen:")]
		void DidDismissScreen (IMBanner banner);

		[Export ("bannerWillLeaveApplication:")]
		void WillLeaveApplication (IMBanner banner);
	}

	[BaseType (typeof (NSError))]
	public partial interface IMError {

	}

	[BaseType (typeof (NSObject))]
	public partial interface IMInterstitial {

		[Export ("initWithAppId:")]
		IntPtr Constructor (string appId);

		[Export ("initWithSlotId:")]
		IntPtr Constructor (long slotId);

		[Export ("appId", ArgumentSemantic.Copy)]
		string AppId { get; set; }

		[Export ("slotId")]
		long SlotId { get; set; }

		[Export ("loadInterstitial")]
		void LoadInterstitial ();

		[Export ("stopLoading")]
		void StopLoading ();

		[Export ("presentInterstitialAnimated:")]
		void PresentInterstitialAnimated (bool animated);

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		IIMInterstitialDelegate Delegate { get; set; }

		[Export ("state")]
		IMInterstitialState State { get; }

		[Export ("adMode")]
		IMAdMode AdMode { get; set; }

		[Export ("additionaParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionaParameters { get; set; }

		[Export ("keywords", ArgumentSemantic.Copy)]
		string Keywords { get; set; }
	}

	public interface IIMInterstitialDelegate {}

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface IMInterstitialDelegate {

		[Export ("interstitialDidReceiveAd:")]
		void DidReceiveAd (IMInterstitial ad);

		[Export ("interstitial:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (IMInterstitial ad, IMError error);

		[Export ("interstitialWillPresentScreen:")]
		void WillPresentScreen (IMInterstitial ad);

		[Export ("interstitialWillDismissScreen:")]
		void WillDismissScreen (IMInterstitial ad);

		[Export ("interstitialDidDismissScreen:")]
		void DidDismissScreen (IMInterstitial ad);

		[Export ("interstitialWillLeaveApplication:")]
		void WillLeaveApplication (IMInterstitial ad);

		[Export ("interstitialDidInteract:withParams:")]
		void DidInteract (IMInterstitial ad, NSDictionary dictionary);

		[Export ("interstitial:didFailToPresentScreenWithError:")]
		void DidFailToPresentScreen (IMInterstitial ad, IMError error);
	}

	[BaseType (typeof (NSObject))]
	public partial interface InMobi {

		[Static, Export ("initialize:")]
		void Initialize (string publisherAppId);

		[Static, Export ("logLevel")]
		IMLogLevel LogLevel { set; }

		[Static, Export ("deviceIdMask")]
		IMDeviceIdMask DeviceIdMask { set; }

		[Static, Export ("getVersion")]
		string GetVersion { get; }

		[Static, Export ("gender")]
		IMGender Gender { set; }

		[Static, Export ("education")]
		IMEducation Education { set; }

		[Static, Export ("ethnicity")]
		IMEthnicity Ethnicity { set; }

		[Static, Export ("dateOfBirth")]
		NSDate DateOfBirth { set; }

		[Static, Export ("setDateOfBirthWithMonth:day:year:")]
		void SetDateOfBirthWithMonth (uint month, uint day, uint year);

		[Static, Export ("income")]
		int Income { set; }

		[Static, Export ("age")]
		int Age { set; }

		[Static, Export ("maritalStatus")]
		IMMaritalStatus MaritalStatus { set; }

		[Static, Export ("hasChildren")]
		IMHasChildren HasChildren { set; }

		[Static, Export ("sexualOrientation")]
		IMSexualOrientation SexualOrientation { set; }

		[Static, Export ("language")]
		string Language { set; }

		[Static, Export ("postalCode")]
		string PostalCode { set; }

		[Static, Export ("areaCode")]
		string AreaCode { set; }

		[Static, Export ("interests")]
		string Interests { set; }

		[Static, Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocationWithLatitude (float latitude, float longitude, float accuracyInMeters);

		[Static, Export ("setLocationWithCity:state:country:")]
		void SetLocationWithCity (string city, string state, string country);

		[Static, Export ("addUserID:withValue:")]
		void AddUserID (IMUserId userId, string idValue);

		[Static, Export ("removeUserID:")]
		void RemoveUserID (IMUserId userId);
	}

	[BaseType (typeof (NSObject))]
	public partial interface InMobiAnalytics {

		[Static, Export ("startSessionManually")]
		void StartSessionManually ();

		[Static, Export ("endSessionManually")]
		void EndSessionManually ();

		[Static, Export ("beginSection:withParams:")]
		void BeginSection (string sectionName, NSDictionary additionalParams);

		[Static, Export ("beginSection:")]
		void BeginSection (string sectionName);

		[Static, Export ("endSection:withParams:")]
		void EndSection (string sectionName, NSDictionary additionalParams);

		[Static, Export ("endSection:")]
		void EndSection (string sectionName);

		[Static, Export ("tagEvent:withParams:")]
		void TagEvent (string eventName, NSDictionary additionalParams);

		[Static, Export ("tagEvent:")]
		void TagEvent (string eventName);

		[Static, Export ("tagTransactionManually:")]
		void TagTransactionManually (NSObject skTransaction);

		[Static, Export ("reportCustomGoal:")]
		void ReportCustomGoal (string goalName);
	}

	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
}

