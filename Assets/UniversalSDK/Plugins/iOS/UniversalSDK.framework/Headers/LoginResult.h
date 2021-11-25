//
//  LoginResult.h
//  UniversalSDK
//
//  Created by james on 2021/03/07.
//

#import <Foundation/Foundation.h>
#import "UserProfile.h"

NS_ASSUME_NONNULL_BEGIN

@interface LoginResult : NSObject

@property (nonatomic) NSInteger responseCode;
@property (nonatomic, nullable) UserProfile *userProfile;

@end

NS_ASSUME_NONNULL_END
