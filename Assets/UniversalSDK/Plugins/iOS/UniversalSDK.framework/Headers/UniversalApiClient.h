//
//  UniversalApiClient.h
//  UniversalSDK
//
//  Created by james on 2021/03/07.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "UniversalEnumType.h"
#import "LoginResult.h"

NS_ASSUME_NONNULL_BEGIN

typedef void (^LoginResultCallback)(LoginResult *_Nullable loginResult,
                                    NSError *_Nullable error);
typedef void (^ResultCallback)(NSString *_Nullable result,
                               NSError *_Nullable error);

@interface UniversalApiClient : NSObject

+ (instancetype)getInstance;

//@property (nonatomic) NSString *deviceToken;
@property (nonatomic, strong) LoginResultCallback loginCallback;
@property (nonatomic, strong) ResultCallback resultCallback;

- (void) setupSDK;

- (void) login:(LoginType)loginType
            vc:(UIViewController *)vc
    completion:(nullable LoginResultCallback)completion;

- (void) login:(LoginType)loginType
viewController:(UIViewController *)viewController
    completion:(nullable ResultCallback)completion;

- (void) logout:(nullable ResultCallback)completion;

- (void) initBilling:(NSString *)productList
          completion:(nullable ResultCallback)completion;

- (void) purchaseLaunch:(NSString *)pid
             completion:(nullable ResultCallback)completion;

- (void) openSafariView:(UIViewController*)viewController
                    url:(NSString *)url;

- (void) setDeviceToken:(NSString*)token;



@end

NS_ASSUME_NONNULL_END
