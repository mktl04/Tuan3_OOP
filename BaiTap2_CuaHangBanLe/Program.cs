using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2_CuaHangBanLe
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLiSP quanli = new QuanLiSP();
            quanli.Nhap();
            quanli.InDanhSach();
            Console.ReadLine();
        }
    }
}
