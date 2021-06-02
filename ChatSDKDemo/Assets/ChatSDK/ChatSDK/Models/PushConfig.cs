﻿using System;
using SimpleJSON;

namespace ChatSDK {
    public class PushConfig
    {

        public bool NoDisturb { get; internal set; }
        public int NoDisturbStartHour { get; internal set; }
        public int NoDisturbEndHour { get; internal set; }
        public PushStyle Style { get; internal set; }

        internal PushConfig(JSONNode jo)
        {
            if (jo != null)
            {
                NoDisturb = jo["noDisturb"].AsBool;
                NoDisturbStartHour = jo["noDisturbStartHour"].AsInt;
                NoDisturbEndHour = jo["noDisturbEndHour"].AsInt;
                NoDisturb = jo["noDisturb"].AsBool;
                if (jo["pushStyle"].AsInt == 0)
                {
                    Style = PushStyle.Simple;
                }
                else {
                    Style = PushStyle.Summary;
                }
            }
        }
    }

}
