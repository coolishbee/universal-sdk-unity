//
//  SDKApplicationDelegate.h
//  UniversalSDK
//
//  Created by james on 2021/03/07.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "UserProfile.h"

NS_ASSUME_NONNULL_BEGIN

@protocol SDKLoginDelegate <NSObject>
- (void)onSDKLoginSuccess:(UserProfile* _Nullable)userProfile;
- (void)onSDKLoginFailure:(NSError* _Nullable)error;
@end

@interface SDKApplicationDelegate : NSObject

- (instancetype)init NS_UNAVAILABLE;
+ (instancetype)new NS_UNAVAILABLE;

@property (class, nonatomic, readonly, strong) SDKApplicationDelegate *sharedInstance;
@property (nonatomic, weak) id<SDKLoginDelegate> loginDelegate;

- (BOOL)application:(UIApplication *)application
didFinishLaunchingWithOptions:(nullable NSDictionary<UIApplicationLaunchOptionsKey, id> *)launchOptions;

- (void)googleAuth:(UIViewController*)uiview;
- (void)facebookAuth:(UIViewController*)uiview;
- (void)appleAuth:(UIViewController*)uiview;

@end

NS_ASSUME_NONNULL_END
