using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class NotificationMessageOutput
    {
        public string? Title { get; set; }


        public string? Body { get; set; }


        /// <summary>
        ///     消息类型 
        /// 1.派工消息  派工取消 拍工提醒 派工超时提醒 下钟提醒
        /// 2.考勤消息  上班消息  下班消息  
        /// 3.预约提醒  预约即将到期提醒  预约取消消息
        /// 
        /// </summary>

        public NotificationMessageContentType ContentType { get; set; }
        /// <summary>
        /// 登陆Id
        /// </summary>

        public Guid UserId { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>

        public long? ArtificerId { get; set; }

        public DateTime? CreateTime { get; set; }
    }

    /// <summary>
    ///     消息类型 
    /// 1.派工消息  派工取消 排工提醒 派工超时提醒 下钟提醒
    /// 2.考勤消息  上班消息  下班消息  
    /// 3.预约提醒  预约即将到期提醒  预约取消消息
    /// 
    /// </summary>
    public enum NotificationMessageContentType
    {
        派工提醒 = 11,
        派工取消提醒 = 12,
        派工超时提醒 = 13,
        项目将到期提醒 = 14,
        服务超时提醒 = 15,
        迟到上班提醒 = 21,
        下班提醒 = 22,
        预约提醒 = 31,
        预约即将到期提醒 = 32,
        预约取消提醒 = 33,
    }
}
