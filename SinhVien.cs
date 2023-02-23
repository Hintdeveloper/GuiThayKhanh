using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SinhVien
    {
        string ID;
        string Name;
        string SDT;
        string MaSV;
        string Email;
        double Diem;

        public SinhVien()
        {

        }

        public SinhVien(string iD, string name, string sDT, string maSV, string email, double diem)
        {
            ID = iD;
            Name = name;
            SDT = sDT;
            MaSV = maSV;
            Email = email;
            Diem = diem;
        }

        public string ID1 { get => ID; set => ID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string MaSV1 { get => MaSV; set => MaSV = value; }
        public string Email1 { get => Email; set => Email = value; }
        public double Diem1 { get => Diem; set => Diem = value; }

        public void Show()
        {
            Console.WriteLine($"ID:  {ID1}");
            Console.WriteLine($"Ten: {Name1}");
            Console.WriteLine($"SDT: {SDT1}");
            Console.WriteLine($"Ma sinh vien: {MaSV1}");
            Console.WriteLine($"Email: {Email1}");
            Console.WriteLine($"Diem: {Diem1}");
        }

        public string OBJ_ToString()
        {
            return $"ID:{ID1}, Ten: {Name1}, SDT: {SDT1}, Ma sinh vien: {MaSV1}, Email: {Email1}, Diem: {Diem1}\n";
        }
    }
}
