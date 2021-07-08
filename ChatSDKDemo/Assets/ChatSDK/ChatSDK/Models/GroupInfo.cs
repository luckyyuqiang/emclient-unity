﻿using System;
using SimpleJSON;

namespace ChatSDK {
    public class GroupInfo
    {

        public string GroupId { get; internal set; }
        public string GroupName { get; internal set; }

        internal GroupInfo(JSONNode jn) {
            if (!jn.IsNull && jn.IsObject) {
                JSONObject jo = jn.AsObject;
                GroupId = jo["gruopId"].Value;
                GroupName = jo["groupName"].Value;
            }
        }
    }

}

