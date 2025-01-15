using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.Enums
{
    public enum EOrderStatus
    {
        /// <summary>
        /// در حال بررسی
        /// </summary>
        Pending=1,

        /// <summary>
        /// درحال ساختن
        /// </summary>
        Working = 2,

        /// <summary>
        /// اتمام کار
        /// </summary>
        Done=3,

        /// <summary>
        /// کنسل شده
        /// </summary>
        Canceled=4
    }
}
