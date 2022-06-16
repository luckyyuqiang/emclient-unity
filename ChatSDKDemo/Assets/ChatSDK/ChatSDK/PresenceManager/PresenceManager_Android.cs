﻿using System;
using System.Collections.Generic;

namespace ChatSDK
{
	internal sealed class PresenceManager_Android : IPresenceManager
	{
		private IntPtr client;

		internal PresenceManager_Android(IClient _client)
		{
			if (_client is Client_Mac clientMac)
			{
				client = clientMac.client;
			}
		}

		public override void publishPresence(int presenceStatus, string ext = "", CallBack handle = null)
		{
			//TODO: Add code for PresenceManager_Android
		}
		public override void SubscribePresences(List<string> members, long expiry, ValueCallBack<List<Presence>> handle = null)
		{
			//TODO: Add code for PresenceManager_Android
		}
		public override void UnsubscribePresences(List<string> members, CallBack handle = null)
		{
			//TODO: Add code for PresenceManager_Android
		}
		public override void FetchSubscribedMembers(int pageNum, int pageSize, ValueCallBack<List<string>> handle = null)
		{
			//TODO: Add code for PresenceManager_Android
		}
		public override void FetchPresenceStatus(List<string> members, ValueCallBack<List<Presence>> handle = null)
		{
			//TODO: Add code for PresenceManager_Android
		}

	}
}