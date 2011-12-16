//
//  BasicExampleAppDelegate.m
//  Google Analytics iOS SDK.
//
//  Copyright 2009 Google Inc. All rights reserved.
//

#import "BasicExampleAppDelegate.h"

#import "GANTracker.h"

// Dispatch period in seconds
static const NSInteger kGANDispatchPeriodSec = 10;
// **************************************************************************
// PLEASE REPLACE WITH YOUR ACCOUNT DETAILS.
// **************************************************************************
static NSString* const kAnalyticsAccountId = @"UA-00000000-1";

@implementation BasicExampleAppDelegate

@synthesize window = window_;

- (void)applicationDidFinishLaunching:(UIApplication *)application {
  [[GANTracker sharedTracker] startTrackerWithAccountID:kAnalyticsAccountId
                                         dispatchPeriod:kGANDispatchPeriodSec
                                               delegate:nil];
  NSError *error;

  if (![[GANTracker sharedTracker] setCustomVariableAtIndex:1
                                                       name:@"iOS1"
                                                      value:@"iv1"
                                                  withError:&error]) {
    NSLog(@"error in setCustomVariableAtIndex");
  }

  if (![[GANTracker sharedTracker] trackEvent:@"Application iOS"
                                       action:@"Launch iOS"
                                        label:@"Example iOS"
                                        value:99
                                    withError:&error]) {
    NSLog(@"error in trackEvent");
  }

  if (![[GANTracker sharedTracker] trackPageview:@"/app_entry_point"
                                       withError:&error]) {
    NSLog(@"error in trackPageview");
  }
  [window_ makeKeyAndVisible];
}

- (void)dealloc {
  [[GANTracker sharedTracker] stopTracker];
  [window_ release];
  [super dealloc];
}

@end
