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
         * 置顶操作者ID。
         * 如果没有置顶信息，则该值为空串。
         *
         * \~english
         * The user ID who pinned the message.
         * If not pinned, then this value should be empty string.
         * 
         */
        public string PinnedBy;

        /**
         * \~chinese
         * 置顶时间。
         * 如果没有置顶信息，则该值为0。
         *
         * \~english
         * The time stamp where the message is pinned.
         * If not pinned, then this value should be zero.
         */
        public long PinnedAt;

        [Preserve]
        internal PinnedInfo() { }

        [Preserve]
        internal PinnedInfo(string jsonString) : base(jsonString) { }

        [Preserve]
        internal PinnedInfo(JSONObject jsonObject) : base(jsonObject) { }

        internal override void FromJsonObject(JSONObject jsonObject)
        {
            //IsPinned = jsonObject["isPinned"];
            PinnedBy = jsonObject["pinnedBy"];
            PinnedAt = (long)jsonObject["pinnedAt"].AsDouble;
        }

        internal override JSONObject ToJsonObject()
        {
            JSONObject jo = new JSONObject();
            //jo.AddWithoutNull("isPinned", IsPinned);
            jo.AddWithoutNull("pinnedBy", PinnedBy);
            jo.AddWithoutNull("pinnedAt", PinnedAt);
            return jo;
        }
    }
}