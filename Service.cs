using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Service
    {
        List<SinhVien> sinhViens;
        SinhVien sinhVien = new SinhVien();

        internal List<SinhVien> SinhViens { get => sinhViens; set => sinhViens = value; }

        public Service() 
        {
            SinhViens = new List<SinhVien>
            {
                new SinhVien("SV1", "Nguyen Van A", "0897561239", "PH1" ,"abcxyz@gmail.com", 9.5),
                new SinhVien("SV2", "Nguyen Van B", "0897561249", "PH2" ,"abcxyz@gmail.com", 9.5),
                new SinhVien("SV3", "Nguyen Van C", "0897561259", "PH3" ,"abcxyz@gmail.com", 9.5)
            };
        }

        public void AddSV()
        {
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Nhap ID: ");
                sinhVien.ID1 = Console.ReadLine();
                Console.WriteLine("Nhap ten: ");
                sinhVien.Name1= Console.ReadLine();
                Console.WriteLine("Nhap SDT: ");
                sinhVien.SDT1 = Console.ReadLine();
                Console.WriteLine("Nhap ma sinh vien: ");
                sinhVien.MaSV1= Console.ReadLine();
                Console.WriteLine("Nhap Email:");
                sinhVien.Email1 = Console.ReadLine();
                Console.WriteLine("Nhap diem: ");
                sinhVien.Diem1 = Convert.ToDouble(Console.ReadLine());

                SinhViens.Add(sinhVien);

                string check;
                Console.WriteLine("Co nhap tiep ko ? Y/N ");
                check = Console.ReadLine();
                if(check == "Y" || check == "y")
                {
                    Console.WriteLine("Tiep tuc nhap");
                    continue;
                }
                else if(check == "N" || check == "n")
                {
                    Console.WriteLine("Dung nhap");
                    break;
                }
                else
                {
                    Console.WriteLine("Gia tri khong hop le, dung nhap de tranh loi");
                    break;
                }
            }
        }

        //Update SV
        public void UpdateSV()
        {
            for (int i = 0; i < SinhViens.Count; i++)
            {
                int fix_choice;
                Console.WriteLine("Chon thong tin can sua");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Ten");
                Console.WriteLine("3. SDT");
                Console.WriteLine("4. Ma sinh vien");
                Console.WriteLine("5. Email");
                Console.WriteLine("6. Diem");

                fix_choice = Convert.ToInt32(Console.ReadLine());

                switch (fix_choice)
                {
                    case 1:
                        Console.WriteLine("Nhap ID moi:");
                        SinhViens[i].ID1 = Console.ReadLine();
                    break;
                    case 2:
                        Console.WriteLine("Nhap Ten moi:");
                        SinhViens[i].Name1 = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Nhap SDT moi:");
                        SinhViens[i].SDT1 = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Nhap Ma sinh vien moi:");
                        SinhViens[i].MaSV1 = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Nhap Email moi:");
                        SinhViens[i].Email1 = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Nhap Diem moi:");
                        SinhViens[i].Diem1 = Convert.ToDouble(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Sai input");
                        break;
                }

            }        
        }

        public void XoaSV()
        {
            string inpID;
            Console.WriteLine("Nhap id sinh vien can xoa: ");
            inpID = Console.ReadLine();
            //for (int i = 0; i < SinhViens.Count; i++)
            //{
            //    if (inpID == SinhViens[i].ID1)
            //    {
            //        SinhViens.RemoveAt(i);
            //    }
            //}

            var findDel = sinhViens.FirstOrDefault(p => p.ID1 == inpID);
            sinhViens.Remove(findDel);
            Console.WriteLine("Xoa thanh cong");
        }

        public void HienThiSV()
        {
            foreach (var item in sinhViens)
            {
                item.Show();
            }
        }

        public void TimSV()
        {
            string inpID;
            Console.WriteLine("Nhap ID sinh vien: ");
            inpID = Console.ReadLine();
            //for (int i = 0; i < SinhViens.Count; i++)
            //{
            //    if (inpID == SinhViens[i].ID1)
            //    {
            //        Console.WriteLine("Da tim thay sinh vien");
            //        SinhViens[i].Show();
            //    }

            //}

            var find = sinhViens.FirstOrDefault(p => p.ID1 == inpID);
            find.Show();
        }
        public void GenMail()
        {
            string MA;
            string ten;
            for (int i = 0; i < SinhViens.Count; i++)
            {
                ten = SinhViens[i].Name1;
                MA = SinhViens[i].MaSV1;

                string[] hovaten = ten.Split(' '); // Cat ten theo ky tu cach
                string result = hovaten[hovaten.Length - 1]; // Lay ten

                for (int j = 0; j < hovaten.Length-1; j++)
                {
                    result += hovaten[j][0]; //Lay chu cai dau
                }
                result += (MA + "@poly.edu.vn");
                Console.WriteLine($"Email cua ban la: {result}");

            }       
        }

        public void GhiVaoText(string path, List<SinhVien> sv)
        {
            if (File.Exists(path))
            {
                foreach (var item in sv)
                {
                    string line = item.OBJ_ToString(); //Tao ra thong tin cho 1 dong bat ky de ghi vao file
                    File.AppendAllText(path, line);
                }
            }
            else
            {
                Console.WriteLine("File khong ton tai"); //Hoac go code tao ra
                File.Create("SinhVien.txt");
            }
        }

        public List<SinhVien> DocFileText(string path)
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            string[] lines = File.ReadAllLines(path);  // Đọc tất cả các dòng từ file txt vào 1 mảng
            foreach (var line in lines)
            {
                if (line.Trim().Length == 0) continue;
                else
                {
                    string[] properties = line.Split(',', '\n');// Mỗi dòng thu được ta cắt theo dấu ','
                    SinhVien sv = new SinhVien();
                    sv.ID1 = properties[0].Split(':')[1];
                    sv.Name1 = properties[1].Split(':')[1];
                    sv.SDT1 = properties[2].Split(':')[1];
                    sv.MaSV1 = properties[3].Split(':')[1];
                    sv.Email1 = properties[4].Split(':')[1];
                    sv.Diem1 = double.Parse(properties[5].Split(':')[1]);
                    sinhViens.Add(sv);
                }
            }
            return sinhViens;
        }


    }
}
