class DonHang{
  public string MaDonHang{get; set;}
  public string MaSanPham{get; set;}
  public double SoLuongBan{get; set;}
  
  public string TenNguoiDat{get; set;}
  public bool DaGiao{get; set;}

  public DonHang(){
    DaGiao = false;
  }

  public void NhapThongTin(){
    Console.WriteLine("Nhap ma don hang: ");
    MaDonHang = Console.ReadLine();
    Console.WriteLine("Nhap ma san pham: ");
    MaSanPham = Console.ReadLine();
    Console.WriteLine("Nhap so luong ban: ");
    SoLuongBan = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Nhap ten nguoi dat: ");
    TenNguoiDat = Console.ReadLine();
  }

  public void XuatThongTin(){
    Console.WriteLine(@$"
      Ma don hang: {MaDonHang}
      Ma san pham: {MaSanPham}
      So luong ban: {SoLuongBan}
      Ten nguoi dat: {TenNguoiDat}
      Da giao: {DaGiao}
    ");
  }
}