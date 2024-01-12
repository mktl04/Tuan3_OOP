using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2_CuaHangBanLe
{
    class SanPham
    {

        private string _ten;
        private double _giaMua;

        public SanPham()
        {

        }
        public SanPham(string ten, double giamua)
        {
            _ten = ten;
            _giaMua = giamua;
        }
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public double GiaMua
        {
            get { return _giaMua; }
            set
            {
                if (value >= 0)
                    _giaMua = value;
            }
        }
        public virtual double TinhGiaBan()
        {
            return 0;
        }
        public virtual string InChiTiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ten cua san pham:");
            _ten = Console.ReadLine();
            Console.Write("Gia ban cua san pham:");
            _giaMua = double.Parse(Console.ReadLine());

        }
    }
    class Socola : SanPham
    {
        private double _loiNhuan;
        public Socola() : base()
        {

        }
        public Socola(string ten, double giamua) : base(ten, giamua)
        {
            _loiNhuan = giamua * 0.2;
        }
        public override double TinhGiaBan()
        {
            return GiaMua + _loiNhuan;
        }
        public override string InChiTiet()
        {
            return string.Format("Ten:{0} - Gia ban: {1:#,##0}", Ten, TinhGiaBan());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loiNhuan = GiaMua * 0.2;
        }

    }
    class NuocUong : SanPham
    {
        private double _loiNhuan;
        private double _chiPhiGiuLanh;

        public NuocUong() : base()
        {

        }
        public NuocUong(string ten, double giamua) : base(ten, giamua)
        {
            _loiNhuan = giamua * 0.15;
            _chiPhiGiuLanh = giamua * 0.1;
        }
        public override double TinhGiaBan()
        {
            return GiaMua + _loiNhuan + _chiPhiGiuLanh;
        }
        public override string InChiTiet()
        {
            return string.Format("Ten:{0} - Gia ban: {1:#,##0}", Ten, TinhGiaBan());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loiNhuan = GiaMua * 0.15;
            _chiPhiGiuLanh = GiaMua * 0.1;
        }
    }
    class QuanLiSP
    {
        private string _ten;
        private SanPham[] dssp;
        private int n;

        public QuanLiSP()
        {
            _ten = "Cua hang ban le";
            dssp = new SanPham[100];
            n = 0;
        }
        public QuanLiSP(int max)
        {
            _ten = "Cua hang ban le";
            dssp = new SanPham[max];
            n = 0;
        }
        public void Nhap()
        {
            int chon;
            SanPham sp;
            while (true)
            {
                Console.Write("Ban muon them sp gi (1.Socola)(2.Nuoc uong): ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        sp = new Socola();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                    case 2:
                        sp = new NuocUong();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                }
                Console.Write("Ban co muon tiep tuc khong? (Nhan phim 0 de thoat chuong trinh.)");
                chon = int.Parse(Console.ReadLine());
                if (chon == 0)
                    break;

            }
        }
        public void InDanhSach()
        {
            Console.WriteLine("-Ten cua hang: " + _ten);
            Console.WriteLine("----Danh sach cac san pham cua ban----");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(dssp[i].InChiTiet());
            }
        }
    }
}
