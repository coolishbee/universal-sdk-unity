//
//  UniversalEnumType.h
//  UniversalSDK
//
//  Created by james on 2021/03/07.
//

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, LoginType)
{
    NONE,
    GOOGLE,
    FACEBOOK,
    APPLE,
};

typedef NS_ENUM(NSInteger, UniversalErrorCode)
{
    UniversalSuccess = 1000,
    UniversalCancel = 1001,
    UniversalNetworkError = 1002,
    UniversalServerError = 1003,
    UniversalAuthenticationAgentError = 1004,
    UniversalInternalError = 1007,
    UniversalPurchaseError = 1008,
};

NS_ASSUME_NONNULL_BEGIN

@interface UniversalEnumType : NSObject
+ (NSString*) loginTypeStringFromEnum:(LoginType)type;
@end

NS_ASSUME_NONNULL_END
