#ifndef _PUSH_MANAGER_H_
#define _PUSH_MANAGER_H_

#pragma once
#include "common.h"
#include "models.h"
#include "callbacks.h"

#ifdef __cplusplus
extern "C"
{
#endif //__cplusplus
//PushManager methods
HYPHENATE_API void AGORA_CALL PushManager_GetIgnoredGroupIds(void *client, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API void AGORA_CALL PushManager_GetPushConfig(void *client, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API void AGORA_CALL PushManager_GetUserConfigsFromServer(void *client, int callbackId, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_IgnoreGroupPush(void *client, int callbackId, const char * groupId, bool noDisturb, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_UpdatePushNoDisturbing(void *client, int callbackId, bool noDisturb, int startTime, int endTime, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_UpdatePushDisplayStyle(void *client, int callbackId, EMPushConfigs::EMPushDisplayStyle style, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_UpdateFCMPushToken(void *client, int callbackId, const char * token, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_UpdateHMSPushToken(void *client, int callbackId, const char * token, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_UpdatePushNickName(void *client, int callbackId, const char * nickname, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_ReportPushAction(void *client, int callbackId, const char * parameters, FUNC_OnSuccess onSuccess, FUNC_OnError onError);

HYPHENATE_API void AGORA_CALL PushManager_SetSilentModeForAll(void* client, int callbackId, const char* param, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_GetSilentModeForAll(void* client, int callbackId, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_SetSilentModeForConversation(void* client, int callbackId, const char* convId, EMConversation::EMConversationType type, const char* param, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_GetSilentModeForConversation(void* client, int callbackId, const char* convId, EMConversation::EMConversationType type, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_GetSilentModeForConversations(void* client, int callbackId, const char* param, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_SetPreferredNotificationLanguage(void* client, int callbackId, const char* laguangeCode, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL PushManager_GetPreferredNotificationLanguage(void* client, int callbackId, FUNC_OnSuccess_With_Result onSuccessResult, FUNC_OnError onError);

#ifdef __cplusplus
}
#endif //__cplusplus

#endif //_PUSH_MANAGER_H_

