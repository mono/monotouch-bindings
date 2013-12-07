using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAnalyticsServices.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreData SystemConfiguration AdSupport", SmartLink = true, ForceLoad = true, LinkerFlags = "-lz -lsqlite3.0 " +
	"-Xlinker -alias -Xlinker _kGAIProduct -Xlinker _GAIProduct " +
	"-Xlinker -alias -Xlinker _kGAIVersion -Xlinker _GAIVersion " +
	"-Xlinker -alias -Xlinker _kGAIErrorDomain -Xlinker _GAIErrorDomain " +
	"-Xlinker -alias -Xlinker _kGAITitle -Xlinker _GAITitle " +
	"-Xlinker -alias -Xlinker _kGAIAppName -Xlinker _GAIAppName " +
	"-Xlinker -alias -Xlinker _kGAIAppVersion -Xlinker _GAIAppVersion " +
	"-Xlinker -alias -Xlinker _kGAIAppId -Xlinker _GAIAppId " +
	"-Xlinker -alias -Xlinker _kGAIAppInstallerId -Xlinker _GAIAppInstallerId " +
	"-Xlinker -alias -Xlinker _kGAIEventCategory -Xlinker _GAIEventCategory " +
	"-Xlinker -alias -Xlinker _kGAIEventAction -Xlinker _GAIEventAction " +
	"-Xlinker -alias -Xlinker _kGAIEventLabel -Xlinker _GAIEventLabel " +
	"-Xlinker -alias -Xlinker _kGAIEventValue -Xlinker _GAIEventValue " +
	"-Xlinker -alias -Xlinker _kGAISocialNetwork -Xlinker _GAISocialNetwork " +
	"-Xlinker -alias -Xlinker _kGAISocialAction -Xlinker _GAISocialAction " +
	"-Xlinker -alias -Xlinker _kGAISocialTarget -Xlinker _GAISocialTarget " +
	"-Xlinker -alias -Xlinker _kGAITransactionId -Xlinker _GAITransactionId " +
	"-Xlinker -alias -Xlinker _kGAITransactionAffiliation -Xlinker _GAITransactionAffiliation " +
	"-Xlinker -alias -Xlinker _kGAITransactionRevenue -Xlinker _GAITransactionRevenue " +
	"-Xlinker -alias -Xlinker _kGAITransactionShipping -Xlinker _GAITransactionShipping " +
	"-Xlinker -alias -Xlinker _kGAITransactionTax -Xlinker _GAITransactionTax " +
	"-Xlinker -alias -Xlinker _kGAICurrencyCode -Xlinker _GAICurrencyCode " +
	"-Xlinker -alias -Xlinker _kGAIItemPrice -Xlinker _GAIItemPrice " +
	"-Xlinker -alias -Xlinker _kGAIItemQuantity -Xlinker _GAIItemQuantity " +
	"-Xlinker -alias -Xlinker _kGAIItemSku -Xlinker _GAIItemSku " +
	"-Xlinker -alias -Xlinker _kGAIItemName -Xlinker _GAIItemName " +
	"-Xlinker -alias -Xlinker _kGAIItemCategory -Xlinker _GAIItemCategory " +
	"-Xlinker -alias -Xlinker _kGAICampaignSource -Xlinker _GAICampaignSource " +
	"-Xlinker -alias -Xlinker _kGAICampaignMedium -Xlinker _GAICampaignMedium " +
	"-Xlinker -alias -Xlinker _kGAICampaignName -Xlinker _GAICampaignName " +
	"-Xlinker -alias -Xlinker _kGAICampaignKeyword -Xlinker _GAICampaignKeyword " +
	"-Xlinker -alias -Xlinker _kGAICampaignContent -Xlinker _GAICampaignContent " +
	"-Xlinker -alias -Xlinker _kGAICampaignId -Xlinker _GAICampaignId " +
	"-Xlinker -alias -Xlinker _kGAITimingCategory -Xlinker _GAITimingCategory " +
	"-Xlinker -alias -Xlinker _kGAITimingVar -Xlinker _GAITimingVar " +
	"-Xlinker -alias -Xlinker _kGAITimingValue -Xlinker _GAITimingValue " +
	"-Xlinker -alias -Xlinker _kGAITimingLabel -Xlinker _GAITimingLabel " +
	"-Xlinker -alias -Xlinker _kGAIExDescription -Xlinker _GAIExDescription " +
	"-Xlinker -alias -Xlinker _kGAIExFatal -Xlinker _GAIExFatal " +
	"-Xlinker -alias -Xlinker _kGAISampleRate -Xlinker _GAISampleRate " +
	"-Xlinker -alias -Xlinker _kGAIAppView -Xlinker _GAIAppView " +
	"-Xlinker -alias -Xlinker _kGAIEvent -Xlinker _GAIEvent " +
	"-Xlinker -alias -Xlinker _kGAISocial -Xlinker _GAISocial " +
	"-Xlinker -alias -Xlinker _kGAITransaction -Xlinker _GAITransaction " +
	"-Xlinker -alias -Xlinker _kGAIItem -Xlinker _GAIItem " +
	"-Xlinker -alias -Xlinker _kGAIException -Xlinker _GAIException " +
	"-Xlinker -alias -Xlinker _kGAITiming -Xlinker _GAITiming")]
