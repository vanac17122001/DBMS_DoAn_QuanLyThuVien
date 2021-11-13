using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using DTO;
using System.Data;

namespace BLLayer
{
    public class BLL_TraSach
    {
        DAL_TraSach TraSach;

        public BLL_TraSach(string username, string pass)
        {
            TraSach = new DAL_TraSach(username, pass);
        }

        public DataSet getTraSach()
        {
            return TraSach.getTraSach();
        }
        public bool suaTraSach(string err, DTO_TraSach dtotra)
        {
            return TraSach.suaTraSach(err, dtotra);
        }
        public bool themTraSach(string err, DTO_TraSach dtotra)
        {
            return TraSach.themTraSach(err, dtotra);
        }
        public bool xoaTraSach(string err, int id)
        {
            return TraSach.xoaTraSach(err, id);
        }
        public DataSet timTraSach(int id)
        {
            return TraSach.timTraSach(id);
        }
    }
}
