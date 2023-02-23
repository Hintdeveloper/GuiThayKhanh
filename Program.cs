using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            int choice;
            do
            {
                Console.WriteLine("\t\t\tMENU");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Sua sinh vien");
                Console.WriteLine("3. Xoa sinh vien");
                Console.WriteLine("4. Hien thong tin sinh vien");
                Console.WriteLine("5. Tim kiem sinh vien");
                Console.WriteLine("6. Kiem tra SDT");
                Console.WriteLine("7. Doc ghi file");
                Console.WriteLine("8. Tu sinh mail");

                Console.WriteLine("Nhap lua chon: ");
                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        service.AddSV();
                        break;
                    case 2:
                        service.UpdateSV();
                        break;
                    case 3:
                        service.XoaSV();
                        break;
                    case 4:
                        service.HienThiSV();
                        break;
                    case 5:
                        service.TimSV();
                        break;
                    case 6:
                        break;
                    case 7:
                        service.GhiVaoText("Sinhvien.txt", service.SinhViens);
                        service.DocFileText("Sinhvien.txt");
                        break;
                    case 8:
                        service.GenMail();
                        break;
                    default:
                        break;
                }

            } while (choice > 0 && choice <=8);        
        }
    }
}
