using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecCommonTypes
{
    /// <summary>
    /// 用于记录app基本信息的类，包含app显示名称和app注册用的ID两个属性
    /// </summary>
    /// 
    [Serializable]
    public class AppInfos
    {
        /// <summary>
        /// app显示名称
        /// </summary>
        private string appdisplayname;

        public string Appdisplayname
        {
            get { return appdisplayname; }
            set { appdisplayname = value; }
        }

        /// <summary>
        /// app注册用的id
        /// </summary>
        private string appID;

        public string AppID
        {
            get { return appID; }
            set { appID = value; }
        }


    }
}
