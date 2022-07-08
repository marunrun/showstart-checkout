using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{
    public class UserIdInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string documentNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int documentType { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string documentTypeStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isSelf { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showDocumentNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int updateAuditStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
    }
}
