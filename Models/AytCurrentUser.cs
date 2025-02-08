using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class AytCurrentUser
    {


        // 调试用
        /// <summary>
        /// 登录账户
        /// </summary>
        public string UserName { get; set; } = "测试环境";
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; } = "";
        public string AppSN { get; set; } = "WFC07E9E6A4307";
       // public ClientType ClientType { get; set; } = ClientType.技师APP;


        /// <summary>
        /// 当前门店
        /// </summary>
        public MerchantDto Merchant { get; set; }
        /// <summary>
        /// 当前商户
        /// </summary>
        public StoreDto CurrentStore { get; set; }
        public List<StoreDto> Stores { get; set; }
    }

    public class StoreDto
    { /// Desc:自增id
      /// Default:
      /// Nullable:False
      /// </summary>           

        public int Id { get; set; }


        /// <summary>
        /// Desc:店铺名称
        /// Default:
        /// Nullable:False
        /// </summary>           

        public string? Name { get; set; }

        /// <summary>
        /// Desc:店铺logo
        /// Default:
        /// Nullable:True
        /// </summary>           

        public string? Logo { get; set; }

        /// <summary>
        /// Desc:是否默认
        /// Default:'n'
        /// Nullable:False
        /// </summary>           

        public bool? IsDefault { get; set; }

        public string TenantId { get; set; }
    }

    public class MerchantDto
    {
        /// <summary>
        /// Desc:自增id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// Desc:类型 1 连琐 2 直营
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int Type { get; set; }

        /// <summary>
        /// Desc:logo
        /// Default:
        /// Nullable:True
        /// </summary>           

        public string Logo { get; set; }



        /// <summary>
        /// Desc:商户名称
        /// Default:
        /// Nullable:False
        /// </summary>           

        public string Name { get; set; }
    }
}
