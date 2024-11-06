using System.Text;

Console.OutputEncoding = Encoding.UTF8;

MenuHocVien menu = new MenuHocVien();



 menu.DocDuLieuTuFile();
if(menu.DanhSachHocVien.Count != 0){
  HocVien.id = menu.DanhSachHocVien.Count + 1;
}



while (true)
{
  menu.HienThiChucNang();
  Console.Write("Hãy chọn chức năng:");
  menu.Chon = Convert.ToInt32(Console.ReadLine());

  switch (menu.Chon)
  {
    case 1:
      {
        menu.ThemHocSinh();
      }; break;
    case 2:
      {

      }; break;
    case 3:
      {
        menu.CapNhatDiemSoHocSinh();
      }; break;
    case 4:
      {
        menu.XoaHocSinh();
      }; break;
    case 5:
      {
        menu.HienThiThongTinhocSinh();
      }; break;
    case 6:
      {
        menu.HienThiHocSinhTheoDiemTrungBinhTangDan();
      }
      break;
    case 7:
      {
        menu.HienThiHoSinhTheoTen();
      }
      break;
    case 8:
      {
        menu.GhiDuLieuVaoFile();
      }
      break;
    case 9:
      {
        menu.DocDuLieuTuFile();      
      }
      break;
    case 10:
      {
        menu.Thoat();
      }
      break;

  }

  if (menu.Chon == 10)
  {
    break;
  }
}