using AgoraChat.SimpleJSON;
#if !_WIN32
using UnityEngine.Scripting;
#endif

namespace AgoraChat
{
    /**
     * \~chinese
     * 置顶信息信息类。
     *
     * \~english
     * The pinned information class.
     */
    [Preserve]
    public class PinnedInfo : BaseModel

    {
        /**
         * \~chinese
         * 是否置顶。
         *
         * \~english
         * Is pinned or not.
         * 
         */
        public bool IsPinned { get; private set; }

        /**
         * \~chinese
         * 置顶操作者ID。
         *
         * \~english
         * The user ID who pinned the message.
         * 
         */
        public string PinnedBy { get; private set; }

        /**
         * \~chinese
         * 置顶时间。
         *
         * \~english
         * The time stamp where the message is pinned.
         */
        public long PinnedAt { get; private set; }

        [Preserve]
        internal PinnedInfo() { }

        [Preserve]
        internal PinnedInfo(string jsonString) : base(jsonString) { }

        [Preserve]
        internal PinnedInfo(JSONObject jsonObject) : base(jsonObject) { }

        internal override void FromJsonObject(JSONObject jsonObject)
        {
            IsPinned = jsonObject["isPinned"];
            PinnedBy = jsonObject["pinnedBy"];
            PinnedAt = (long)jsonObject["pinnedAt"].AsDouble;
        }

        internal override JSONObject ToJsonObject()
        {
            JSONObject jo = new JSONObject();
            jo.AddWithoutNull("isPinned", IsPinned);
            jo.AddWithoutNull("pinnedBy", PinnedBy);
            jo.AddWithoutNull("pinnedAt", PinnedAt);
            return jo;
        }
    }
}