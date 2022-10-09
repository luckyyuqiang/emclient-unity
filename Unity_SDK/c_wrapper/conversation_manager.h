#ifndef _CONVERSATION_MANAGER_H_
#define _CONVERSATION_MANAGER_H_

#pragma once
#include "common.h"
#include "models.h"
#include "callbacks.h"

#ifdef __cplusplus
extern "C"
{
#endif //__cplusplus

//ConversationManager methods
HYPHENATE_API bool AGORA_CALL ConversationManager_AppendMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, void *mto, EMMessageBody::EMMessageBodyType type);
HYPHENATE_API bool AGORA_CALL ConversationManager_ClearAllMessages(void *client, const char * conversationId, EMConversation::EMConversationType conversationType);
HYPHENATE_API bool AGORA_CALL ConversationManager_RemoveMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, const char * messageId);
HYPHENATE_API void AGORA_CALL ConversationManager_ExtField(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API bool AGORA_CALL ConversationManager_InsertMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, void *mto, EMMessageBody::EMMessageBodyType type);
HYPHENATE_API void AGORA_CALL ConversationManager_LatestMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API void AGORA_CALL ConversationManager_LatestMessageFromOthers(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API void AGORA_CALL ConversationManager_LoadMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, const char * messageId, FUNC_OnSuccess_With_Result onSuccess);
HYPHENATE_API void AGORA_CALL ConversationManager_LoadMessages(void *client, int callbackId, const char * conversationId, EMConversation::EMConversationType conversationType, const char * startMessageId, int count, EMConversation::EMMessageSearchDirection direction, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ConversationManager_LoadMessagesWithKeyword(void *client, int callbackId, const char * conversationId, EMConversation::EMConversationType conversationType, const char * keywords, const char * sender, int64_t timestamp, int count, EMConversation::EMMessageSearchDirection direction, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ConversationManager_LoadMessagesWithMsgType(void *client, int callbackId, const char * conversationId, EMConversation::EMConversationType conversationType, EMMessageBody::EMMessageBodyType type, int64_t timestamp, int count, const char * sender, EMConversation::EMMessageSearchDirection direction, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ConversationManager_LoadMessagesWithTime(void *client, int callbackId, const char * conversationId, EMConversation::EMConversationType conversationType, int64_t startTimeStamp, int64_t endTimeStamp, int count, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
HYPHENATE_API void AGORA_CALL ConversationManager_MarkAllMessagesAsRead(void *client, const char * conversationId, EMConversation::EMConversationType conversationType);
HYPHENATE_API void AGORA_CALL ConversationManager_MarkMessageAsRead(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, const char * messageId);
HYPHENATE_API void AGORA_CALL ConversationManager_SetExtField(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, const char * ext);
HYPHENATE_API int AGORA_CALL  ConversationManager_UnreadMessagesCount(void *client, const char * conversationId, EMConversation::EMConversationType conversationType);
HYPHENATE_API int AGORA_CALL  ConversationManager_MessagesCount(void *client, const char * conversationId, EMConversation::EMConversationType conversationType);
HYPHENATE_API bool AGORA_CALL ConversationManager_UpdateMessage(void *client, const char * conversationId, EMConversation::EMConversationType conversationType, void *mto, EMMessageBody::EMMessageBodyType type);
HYPHENATE_API bool AGORA_CALL ConversationManager_IsThread(void* client, const char* conversationId, EMConversation::EMConversationType conversationType);

#ifdef __cplusplus
}
#endif //__cplusplus

#endif //_CONVERSATION_MANAGER_H_

