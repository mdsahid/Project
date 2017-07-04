using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    [Serializable]
    public class Types
    {
        #region Property
        public int ID { get; set; }
        public string TypeName { get; set; }


        #endregion


        #region Constructor
        public Types()
        {

        }

        public Types(string typeName)
        {

            this.TypeName = typeName;
        }
        #endregion


    }//cs
        #endregion
}//ns