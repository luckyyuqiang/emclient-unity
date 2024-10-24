﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ChatSDK
{
    public class ContactManager_Mac : IContactManager
    {
        private IntPtr client;
        private ContactManagerHub contactManagerHub;

        internal ContactManager_Mac(IClient _client)
        {
            if(_client is Client_Mac clientMac)
            {
                client = clientMac.client;
            }
            //register listeners
            contactManagerHub = new ContactManagerHub();
            ChatAPINative.ContactManager_AddListener(client, contactManagerHub.OnContactAdd,contactManagerHub.OnContactDeleted,
                contactManagerHub.OnContactInvited, contactManagerHub.OnFriendRequestAccepted,contactManagerHub.OnFriendRequestDeclined);
        }

        public override void AcceptInvitation(string username, CallBack handle = null)
        {
            ChatAPINative.ContactManager_AcceptInvitation(client, username,
                 () => handle?.Success(),
                 (int code, string desc) => handle?.Error(code, desc));
        }

        public override void AddContact(string username, string reason = null, CallBack handle = null)
        {
            ChatAPINative.ContactManager_AddContact(client, username, reason ?? "",
                () => handle?.Success(),
                (int code, string desc) => handle?.Error(code, desc));
        }

        public override void AddUserToBlockList(string username, CallBack handle = null)
        {
            ChatAPINative.ContactManager_AddToBlackList(client, username, true,
                () => handle?.Success(),
                (int code, string desc) => handle?.Error(code, desc));
        }

        public override void DeclineInvitation(string username, CallBack handle = null)
        {
            ChatAPINative.ContactManager_DeclineInvitation(client, username,
                 () => handle?.Success(),
                 (int code, string desc) => handle?.Error(code, desc));
        }

        public override void DeleteContact(string username, bool keepConversation = false, CallBack handle = null)
        {
            ChatAPINative.ContactManager_DeleteContact(client, username, false,
                () => handle?.Success(),
                (int code, string desc) => handle?.Error(code, desc));
        }

        public override List<string> GetAllContactsFromDB()
        {
            //make a array of IntPtr(point to TOArray)
            TOArray toArray = new TOArray();
            IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(toArray));
            Marshal.StructureToPtr(toArray, intPtr, false);
            var array = new IntPtr[1];
            array[0] = intPtr;

            ChatAPINative.ContactManager_GetContactsFromDB(client, array, 1);

            //get data from IntPtr
            var returnTOArray = Marshal.PtrToStructure<TOArray>(array[0]);
            var stringList = new List<string>();

            //cannot get any message
            if (returnTOArray.Size <= 0)
            {
                Debug.Log($"Cannot find any contacts.");
                Marshal.FreeCoTaskMem(intPtr);
                return stringList;
            }

            
            for (int i=0; i< returnTOArray.Size; i++)
            {
                stringList.Add(Marshal.PtrToStringAnsi(returnTOArray.Data[i]));
            }
            ChatAPINative.ContactManager_ReleaseStringList(array, 1);
            Marshal.FreeCoTaskMem(intPtr);
            return stringList;
        }

        public override void GetAllContactsFromServer(ValueCallBack<List<string>> handle = null)
        {
            ChatAPINative.ContactManager_GetContactsFromServer(client,
                (IntPtr[] contactsResult, DataType dType, int size) =>
                {
                    Debug.Log($"GetAllContactsFromServer callback with dType={dType}, size={size}");
                    //Verify parameter
                    if (dType == DataType.ListOfString && size == 1)
                    {
                        var contactTOArray = Marshal.PtrToStructure<TOArray>(contactsResult[0]);
                        var result = new List<string>();
                        int toSize = contactTOArray.Size;
                        for (int i = 0; i < toSize; i++)
                        {
                            result.Add(Marshal.PtrToStringAnsi(contactTOArray.Data[i]));
                        }
                        handle?.OnSuccessValue(result);
                    }
                    else
                    {
                        Debug.LogError("Incorrect delegate parameters returned.");
                    }
                },

                (int code, string desc) => handle?.Error(code, desc));
        }

        public override void GetBlockListFromServer(ValueCallBack<List<string>> handle = null)
        {
            ChatAPINative.ContactManager_GetBlackListFromServer(client,
                (IntPtr[] blackListResult, DataType dType, int size) =>
                {
                    Debug.Log($"GetBlockListFromServer callback with dType={dType}, size={size}");
                    //Verify parameter
                    if (dType == DataType.ListOfString && size == 1)
                    {
                        var blackListTOArray = Marshal.PtrToStructure<TOArray>(blackListResult[0]);
                        var result = new List<string>();
                        int toSize = blackListTOArray.Size;
                        for (int i = 0; i < toSize; i++)
                        {
                            result.Add(Marshal.PtrToStringAnsi(blackListTOArray.Data[i]));
                        }
                        handle?.OnSuccessValue(result);
                    }
                    else
                    {
                        Debug.LogError("Incorrect delegate parameters returned.");
                    }
                },

                (int code, string desc) => handle?.Error(code, desc));
        }

        public override void GetSelfIdsOnOtherPlatform(ValueCallBack<List<string>> handle = null)
        {
            ChatAPINative.ContactManager_GetSelfIdsOnOtherPlatform(client,
                (IntPtr[] selfIdListResult, DataType dType, int size) =>
                {
                    Debug.Log($"GetSelfIdsOnOtherPlatform callback with dType={dType}, size={size}");
                    //Verify parameter
                    if (dType == DataType.ListOfString && size == 1)
                    {
                        var selfIdListTOArray = Marshal.PtrToStructure<TOArray>(selfIdListResult[0]);
                        var result = new List<string>();
                        int toSize = selfIdListTOArray.Size;
                        for (int i = 0; i < toSize; i++)
                        {
                            result.Add(Marshal.PtrToStringAnsi(selfIdListTOArray.Data[i]));
                        }
                        handle?.OnSuccessValue(result);
                    }
                    else
                    {
                        Debug.LogError("Incorrect delegate parameters returned.");
                    }
                },

                (int code, string desc) => handle?.Error(code, desc));
        }

        public override void RemoveUserFromBlockList(string username, CallBack handle = null)
        {
            ChatAPINative.ContactManager_RemoveFromBlackList(client, username,
                () => handle?.Success(),
                (int code, string desc) => handle?.Error(code, desc));
        }
    }
}