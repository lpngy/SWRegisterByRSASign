using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecCommonTypes
{
    [Serializable]
    public class DetailInfoItem
    {

        int mechineIndex;

        public int MechineIndex
        {
            get { return mechineIndex; }
            set { mechineIndex = value; }
        }

        /// <summary>
        /// 机器码
        /// </summary>
        string userMachineCode;

        public string UserMachineCode
        {
            get { return userMachineCode; }
            set { userMachineCode = value; }
        }

        /// <summary>
        /// 机器码对应的regcode
        /// </summary>
        string userDetailContent;

        public string UserDetailContent
        {
            get { return userDetailContent; }
            set { userDetailContent = value; }
        }
    }
}
