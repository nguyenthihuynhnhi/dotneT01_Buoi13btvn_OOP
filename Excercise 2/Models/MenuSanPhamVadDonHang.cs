using System.Text.Json;

class MenuSanPhamVaDonHang
{
  public int Chon { get; set; }

  public List<SanPham>? DanhSachSanPham = new List<SanPham>();
  public List<DonHang> DanhSachDonHang = new List<DonHang>();

  public void HienThiChucNang()
  {
    Console.WriteLine(@$"
     -----------------------------------------
    1. Thêm sản phẩm
    2. Tìm Kiếm sản phẩm theo tên
    3. Cập nhật giá bán hoặc số lượng tồn kho 
    4. Tính tổng giá trị kho hàng
    5. Xóa sản phẩm khỏi danh sách
    6. Hiển thị danh sách sản phẩm cùng tổng giá trị kho hàng
    7. Hiển thị sản phẩm theo giá bán tăng dần
    8. sắp xếp và hiển thị danh sách sản phẩm theo giá bán từ thấp đến cao
    9. Sắp xếp và hiển thị danh sách sản phẩm theo tên
    10. Lưu lại dữ liệu
    11. Đọc dữ liệu cũ
    12.Thoát
    13. Thêm đơn hàng
    14. Hiển thị danh sách đơn hàng
    15. Cập nhật trạng thái giao hàng
    16. Xóa đơn hàng
   ");
  }


  //1
  public void ThemSanPham()
  {
    SanPham sanPham = new SanPham();
    sanPham.NhapThongTin();
    DanhSachSanPham.Add(sanPham);
  }

  //2
  public void TimKiemSanPhanTheo()
  {
    Console.Write("Nhập tên sản phẩm cần tìm: ");
    // string tenSanPham = Console.ReadLine();
    // foreach(SanPham sp in DanhSachSanPham){
    //   if(sp.TenSanPham.Contains(tenSanPham)){
    //     sp.XuatThongTin();
    //   }
    // }
    string tenSanPham = Console.ReadLine();
    List<SanPham> sanPhams = DanhSachSanPham.Where(sp => sp.TenSanPham.ToLower().Contains(tenSanPham.ToLower())).ToList();
    if (sanPhams.Count == 0)
    {
      Console.Write("Không tìm thấy sản phẩm");
    }
    else
    {
      foreach (SanPham sp in sanPhams)
      {
        sp.XuatThongTin();
      }
    }
  }

  //4
  public void TinhTongGiaTriKhoHang()
  {
    Console.Write($"Tổng giá trị kho hàng là: {TinhTongGiaTriTonKho()}");
  }


  //3
  public void CapNhatGiaBanHoacSoLuongTonKho(){
    Console.Write("Nhập vào mã sản phẩm:");
    string maSanPham = Console.ReadLine();
    SanPham sp = DanhSachSanPham.Find(sp => sp.MaSanPham == maSanPham);
    if(sp != null){
      Console.Write("Nhập vào giá bán mới:");
      double giaBan = Convert.ToDouble(Console.ReadLine());
      Console.Write("Nhập vào số lượng tồn kho mới:");
      double soLuongTonKho = Convert.ToDouble(Console.ReadLine());
      sp.GiaBan = giaBan;
      sp.SoLuongTonKho = soLuongTonKho;
      Console.Write("Cập nhật sản phẩm thành công");
    }else{
      Console.Write("Không tìm thấy sản phẩm");
    }
  }

  //5.
  public void XoaSanPham() {
    Console.Write("Nhập vào mã sản phẩm:");
    string maSanPham = Console.ReadLine();
    SanPham sp = DanhSachSanPham.Find(sp => sp.MaSanPham  == maSanPham);
    if(sp != null){
      DanhSachSanPham.Remove(sp);
      Console.Write("Xóa sản phẩm thành công");
    }else{
      Console.Write("Không tìm thấy sản phẩm");
    }
  }


  //6.
  public void HienThiDanhSachSanPham()
  {
    foreach (SanPham sp in DanhSachSanPham)
    {
      sp.XuatThongTin();
    }
    Console.Write($"Tổng giá trị kho hàng là: {TinhTongGiaTriTonKho()}");
  }

  //7
  public void HienThiGiaBanTangDan(){
    List<SanPham> sanPhams = DanhSachSanPham.OrderBy(sp => sp.GiaBan).ToList();
    foreach(SanPham sp in sanPhams){
      sp.XuatThongTin();
    }
  }

  //4
  public double TinhTongGiaTriTonKho()
  {
    double result = 0;
    foreach (SanPham sanpham in DanhSachSanPham)
    {
      result += sanpham.GiaBan * sanpham.SoLuongTonKho;
    }

    return result;
  }

  //9
  public void HienThiGiaBanTheoTen(){
    List<SanPham> sanPhams = DanhSachSanPham.OrderBy(sp =>sp.LayChuCuoiTrongTenSanPham()).ToList();
    foreach(SanPham sp in sanPhams){
      sp.XuatThongTin();
    }
  }


  //10. Lưu lại dữ liệu
  public async void LuuDuLieu()
  {
    string data = JsonSerializer.Serialize(DanhSachSanPham);

    await File.WriteAllTextAsync("sanpham.json", data);
  }


  //11. Đọc dữ liệu cũ

  public async void DocDuLieuCu()
  {
    string data = await File.ReadAllTextAsync("sanpham.json");
    DanhSachSanPham = JsonSerializer.Deserialize<List<SanPham>>(data);
  }

  //12
  public void Thoat()
  {
    Chon = 12;
  }

  //13.
  public void ThemDonHang(){
    DonHang donHang = new DonHang();
    donHang.NhapThongTin();
    DanhSachDonHang.Add(donHang);
  }


  //14
  public void HienThiDanhSachDonHang(){
    foreach(DonHang dh in DanhSachDonHang){
      dh.XuatThongTin();
    }
  }

  //15.
  public void CapNhatTrangThaiGiaoHang(){
    Console.Write("Nhập vào mã đơn hàng:");
    string maDonHang = Console.ReadLine();
    DonHang donHang = DanhSachDonHang.Find(dh => dh.MaDonHang == maDonHang);
    if(donHang != null){
      Console.Write("Nhập trạng thái giao hàng(true/false):");
      bool daGiao = Convert.ToBoolean(Console.ReadLine());
      donHang.DaGiao = daGiao;
      if(daGiao){
        SanPham sp = DanhSachSanPham.Find(sp => sp.MaSanPham == donHang.MaSanPham);
        if(sp != null){
          sp.SoLuongTonKho -= donHang.SoLuongBan;
          Console.Write("Cập nhật trạng thái giao hàng và số lượng tồn kho thành công");
        }else{
          Console.Write("Không tìm thấy sản phẩm");
        }
      }
    } else{
      Console.Write("Không tìm thấy đơn hàng");
    }   
  }

  //16.
  public void XoaDonHang(){
    Console.Write("Nhập vào mã đơn hàng:");
    string maDonHang = Console.ReadLine();
    DonHang donHang = DanhSachDonHang.Find(dh => dh.MaDonHang == maDonHang);
    if(donHang != null){
      DanhSachDonHang.Remove(donHang);
      Console.Write("Xóa đơn hàng thành công");
    } else{
      Console.Write("Không tìm thấy đơn hàng");
    }
  }
}