using System.Text;

Console.OutputEncoding = Encoding.UTF8;

MenuSanPhamVaDonHang menuSanPhamVaDonHang = new MenuSanPhamVaDonHang();

menuSanPhamVaDonHang.DocDuLieuCu();

if (menuSanPhamVaDonHang.DanhSachSanPham.Count != 0)
{
  SanPham.id = menuSanPhamVaDonHang.DanhSachSanPham.Count + 1;
}

while (true)
{
  menuSanPhamVaDonHang.HienThiChucNang();

  Console.Write("Chọn chức năng: ");
  menuSanPhamVaDonHang.Chon = Convert.ToInt32(Console.ReadLine());
  switch (menuSanPhamVaDonHang.Chon)
  {
    case 1:
      menuSanPhamVaDonHang.ThemSanPham();
      break;
    case 2:
      menuSanPhamVaDonHang.TimKiemSanPhanTheo();
      break;
    case 3:
      menuSanPhamVaDonHang.CapNhatGiaBanHoacSoLuongTonKho();
      break;
    case 4:
      menuSanPhamVaDonHang.TinhTongGiaTriKhoHang();
      break;
    case 5:
      menuSanPhamVaDonHang.XoaSanPham();
      break;
    case 6:
      menuSanPhamVaDonHang.HienThiDanhSachSanPham();
      break;
    case 7:
      menuSanPhamVaDonHang.HienThiGiaBanTangDan();
      break;
    case 8:
      menuSanPhamVaDonHang.HienThiGiaBanTangDan();
      break;
    case 9:
      menuSanPhamVaDonHang.HienThiGiaBanTheoTen();
      break;
    case 10:
      menuSanPhamVaDonHang.LuuDuLieu();
      break;
    case 11:
      menuSanPhamVaDonHang.DocDuLieuCu();
      break;
    case 12:
      menuSanPhamVaDonHang.Thoat();
      break;
    case 13:
      menuSanPhamVaDonHang.ThemDonHang();
      break;
    case 14:
      menuSanPhamVaDonHang.HienThiDanhSachDonHang();
      break;
    case 15:
      menuSanPhamVaDonHang.CapNhatTrangThaiGiaoHang();
      break;
    case 16:
      menuSanPhamVaDonHang.XoaDonHang();
      break;
    default:
      Console.WriteLine("Lựa chọn không hợp lệ");
      break;
  }
  if (menuSanPhamVaDonHang.Chon == 12) break;
}
