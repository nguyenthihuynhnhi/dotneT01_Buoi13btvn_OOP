using System.Text.Json;

class  MenuHocVien{

  public int Chon {get; set;}
  public List<HocVien>? DanhSachHocVien  = new List<HocVien>();


  public MenuHocVien(){

  }
  public void HienThiChucNang(){
    Console.WriteLine(@$"
      ------------------Quản lý học viên------------------
      1.Thêm thông tin học sinh
      2.Tìm kiếm thông tin học sinh theo tên.
      3.Cập nhật điểm số học sinh
      4.Xóa học sinh ra khỏi danh sách
      5.Hiển thị danh sách học sinh kèm xếp loại học lực dựa trên điểm trung bình
      6.Hiển thị học sinh theo điểm trung bình tăng dần
      7.Hiển thị học sinh theo tên     
      8.Ghi dữ liệu vào file
      9.Đọc dữ liệu từ file 
      10.Thoát
    ");
  }


  //1.Thêm thông tin học sinh
  public void ThemHocSinh(){
    //1.Khỏi tạo 1 đối tượng học viên
    HocVien hocVien = new HocVien();
    //2.Cho nhập thông tin của học viên
    hocVien.NhapThongTin();
    //3.Thêm học viên vào danh sách
    DanhSachHocVien.Add(hocVien);
    this.GhiDuLieuVaoFile();
  }

  //2. Tìm Kiếm học sinh theo tên


  //3. Cập nhật điểm số học sinh
  public void CapNhatDiemSoHocSinh(){
    Console.Write("Nhập mã số sinh viên:");
    string MaSoNhanVienMoi = Console.ReadLine();
    Console.Write("Nhập điểm toán:");
    double diemToanMoi = Convert.ToDouble(Console.ReadLine());
    Console.Write("Nhập điểm văn:");
    double diemVanMoi = Convert.ToDouble(Console.ReadLine());
    Console.Write("Nhập điểm anh:");
    double diemAnhMoi = Convert.ToDouble(Console.ReadLine());
    HocVien hv = DanhSachHocVien.Find(hv => hv.MaHocVien == MaSoNhanVienMoi);
    if(hv != null){
      hv.diemVan = diemVanMoi;
      hv.diemAnh = diemAnhMoi;
      hv.diemToan = diemToanMoi;
      hv.XuatThongTin();
    }else{
      Console.Write("Không tìm thấy học viên");
    }
  }

  //  4.Xóa học sinh ra khỏi danh sách
  public void XoaHocSinh(){
    Console.Write("Nhập mã sinh viên:");
    string MaHocVien = Console.ReadLine();
    HocVien hv = DanhSachHocVien.Find(hv => hv.MaHocVien == MaHocVien);
    if(hv != null) {
      DanhSachHocVien.Remove(hv);
      Console.Write("Xóa học viên thành công");
    }else{
      Console.Write("Không tìm thấy học viên có mã sinh viên tương ứng");
    }
  }


  //5.Hiển thị danh sách học sinh kèm xếp loại học lực dựa trên điểm trung bình
  public void HienThiThongTinhocSinh(){
    foreach(HocVien hv in DanhSachHocVien){
      hv.XuatThongTin();
    }
  } 



  //6. Hiển thị học sinh theo điểm trung bình tăng dần
  public void HienThiHocSinhTheoDiemTrungBinhTangDan(){
    List<HocVien> newList = DanhSachHocVien.OrderBy(x => x.TinhDiemTrungBinh()).ToList();
    newList.ForEach(hv => hv.XuatThongTin());
  }

  //7. Hiển thị học sinh theo tên
  public void HienThiHoSinhTheoTen(){
    List<HocVien> newListSortedByLastName = DanhSachHocVien.OrderBy(x => x.GetLastName()).ToList();
    
    Console.Write("Danh sách học viên theo tên:");
    foreach(HocVien hv in newListSortedByLastName){
     Console.Write(@$"
      {hv.TenHocVien} 
     ");
    }
  }

  //8.Ghi dữ liệu vào file
  public async void GhiDuLieuVaoFile(){
    //conver data từ object -> sang
    string DSHV = JsonSerializer.Serialize(DanhSachHocVien);

    //Lưu dữ liệu vào file data.json
    await File.WriteAllTextAsync("data.json",DSHV);
  }

  //9. Đọc dữ liệu từ file
  public async void DocDuLieuTuFile(){
    //Đọc dữ liệu từ file data.json
    string dshv = await File.ReadAllTextAsync("./data.json");
    //Chuyển từ dạng string -> object
    this.DanhSachHocVien = JsonSerializer.Deserialize<List<HocVien>>(dshv);
  }


  //10.Thoát
  public void Thoat(){
    Chon = 10;
  }

}