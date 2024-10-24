#ifndef _CHAT_MANAGER_H_
#define _CHAT_MANAGER_H_

#pragma once
#include "common.h"
#include "models.h"
#include "callbacks.h"

#ifdef __cplusplus
extern "C"
{
#endif //__cplusplus
//ChatManager methods
AGORA_API void ChatManager_SendMessage(void *client, FUNC_OnSuccess onSuccess, FUNC_OnError onError, void *mto, EMMessageBody::EMMessageBodyType type);
AGORA_API void ChatManager_FetchHistoryMessages(void *client, const char * conversationId, EMConversation::EMConversationType type, const char * startMessageId, int count, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_GetConversationsFromServer(void *client, FUNC_OnSuccess_With_Result onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_AddListener(void *client,
                                       FUNC_OnMessagesReceived onMessagesReceived,
                                       FUNC_OnCmdMessagesReceived onCmdMessagesReceived,
                                       FUNC_OnMessagesRead onMessagesRead,
                                       FUNC_OnMessagesDelivered onMessagesDelivered,
                                       FUNC_OnMessagesRecalled onMessagesRecalled,
                                       FUNC_OnReadAckForGroupMessageUpdated onReadAckForGroupMessageUpdated,
                                       FUNC_OnGroupMessageRead onGroupMessageRead,
                                       FUNC_OnConversationsUpdate onConversationsUpdate,
                                       FUNC_OnConversationRead onConversationRead
                                       );

AGORA_API void ChatManager_RemoveConversation(void *client, const char * conversationId, bool isRemoveMessages);
AGORA_API void ChatManager_DownloadMessageAttachments(void *client, const char * messageId, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_DownloadMessageThumbnail(void *client, const char * messageId, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API bool ChatManager_ConversationWithType(void *client, const char * conversationId, EMConversation::EMConversationType type, bool createIfNotExist);
AGORA_API int  ChatManager_GetUnreadMessageCount(void *client);
AGORA_API bool ChatManager_InsertMessages(void *client, void * messageList[], EMMessageBody::EMMessageBodyType typeList[], int size);
AGORA_API void ChatManager_LoadAllConversationsFromDB(void *client, void * conversationArray[], int size);
AGORA_API void ChatManager_GetMessage(void *client, const char * messageId, void * messageArray[], int size);
AGORA_API bool ChatManager_MarkAllConversationsAsRead(void *client);
AGORA_API void ChatManager_RecallMessage(void *client, const char * messageId, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_ResendMessage(void *client, const char * messageId, void * messageArray[], int size, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_LoadMoreMessages(void *client, void * messageArray[], int size, const char * keywords, long timestamp, int maxcount, const char * from, EMConversation::EMMessageSearchDirection direction);
AGORA_API void ChatManager_SendReadAckForConversation(void *client, const char * conversationId, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API void ChatManager_SendReadAckForMessage(void *client, const char * messageId, FUNC_OnSuccess onSuccess, FUNC_OnError onError);
AGORA_API bool ChatManager_UpdateMessage(void *client, void *mto, EMMessageBody::EMMessageBodyType type);

AGORA_API void ChatManager_ReleaseConversationList(void * conversationArray[], int size);
AGORA_API void ChatManager_ReleaseMessageList(void * messageArray[], int size);
#ifdef __cplusplus
}
#endif //__cplusplus

#endif //_CHAT_MANAGER_H_

