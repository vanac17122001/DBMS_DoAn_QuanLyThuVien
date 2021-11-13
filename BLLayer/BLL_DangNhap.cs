using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using DTO;

namespace BLLayer
{
    public class BLL_DangNhap
    {
        DAL_DangNhap dn;

        public BLL_DangNhap(string username, string pass)
        {
            dn = new DAL_DangNhap(username, pass);
        }
        public string dangNhap(user a)
        {
            return dn.DangNhap(a);
        }
    }
}
