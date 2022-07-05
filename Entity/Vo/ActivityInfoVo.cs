using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{

    public class ActivityInfoList
    {
        public List<ActivityInfoVo> activityInfo { get; set; }
    }
    public class ActivityInfoVo
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [System.Text.Json.Serialization.JsonConverter(typeof(LongToStringJsonConverter))]
        public string activityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string activityPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int activityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string activityTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int beginTimeConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int canBringFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string friendRuleUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int groupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isShowCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isTour { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int leftDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> performerList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string performerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sellIdentity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sequence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long showStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string siteName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> styleIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> styles { get; set; }
        /// <summary>
        /// 4月10日 —4月11日 2021星巢秘境·楠溪江RockTown音乐嘉年华
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string week { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wishCount { get; set; }

        public string MyTitle
        {
            get
            {
                if (city != null)
                {
                    return title  + "\r\n";
                }
                else
                {
                    return title;
                }

            }
        }
    }
}
