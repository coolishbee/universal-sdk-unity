//
//  UserProfile.h
//  UniversalSDK
//
//  Created by james on 2021/03/07.
//

#import <Foundation/Foundation.h>
#import "UniversalEnumType.h"

NS_ASSUME_NONNULL_BEGIN

@interface UserProfile : NSObject
//@property (nonatomic) LoginType loginType;
@property (nonatomic) NSString* userID;
@property (nonatomic) NSString* idToken;
//@property (nonatomic) NSString* accessToken;
@property (nonatomic) NSString* displayName;
@property (nonatomic) NSString* email;
@property (nonatomic) NSString* photoURL;
@property (nonatomic) NSString* pushToken;
@end

NS_ASSUME_NONNULL_END
