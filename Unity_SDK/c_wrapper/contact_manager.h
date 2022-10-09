#ifndef _CONTACT_MANAGER_H_
#define _CONTACT_MANAGER_H_

#pragma once
#include "common.h"
#include "models.h"
#include "callbacks.h"

#ifdef __cplusplus
extern "C"
{
#endif //__cplusplus
//ContactManager methods
HYPHENATE_API void AGORA_CALL ContactManager_AddListener(void *client,
                                        FUNC_OnContactAdded onContactAdded,
                                        FUNC_OnContactDeleted onContactDeleted,
                                        FUNC_OnContactInvited onContactInvited,
                                        FUNC_OnFriendRequestAccepted onFriendRequestAccepted,
                                        FUNC_OnFriendRequestDeclined OnFriendRequestDeclined
                                        );

HYPHENATE_API void AGORA_CALL ContactManager_AddContact(void *client, int callbackId, const char* username, const char* reason, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_DeleteContact(void *client, int callbackId, const char* username, bool keepConversation, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_GetContactsFromServer(void *client, int callbackId, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_GetContactsFromDB(void *client, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_AddToBlackList(void *client, int callbackId, const char* username, bool both, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_RemoveFromBlackList(void *client, int callbackId, const char* username,FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_GetBlackListFromServer(void *client, int callbackId, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_AcceptInvitation(void *client, int callbackId, const char* username,FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_DeclineInvitation(void *client, int callbackId, const char* username,FUNC_OnSuccess onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ContactManager_GetSelfIdsOnOtherPlatform(void *client, int callbackId, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
#ifdef __cplusplus
}
#endif //__cplusplus

void ContactManager_RemoveListener(void*client);

#endif //_CONTACT_MANAGER_H_

