class HocVien{

 public static int id {get; set;} = 1;
  public string? MaHocVien {get; set; } 
  public string? TenHocVien {get; set;}

  public double diemToan {get; set;}

  public double diemVan{get; set;}

  public double diemAnh {get; set;}

  public HocVien(){

  }
  public void NhapThongTin(){
    Console.Write("Nhập mã học viên:");
    MaHocVien = Console.ReadLine();
    Console.Write("Nhập tên học viên:");
    TenHocVien = Console.ReadLine();
    Console.Write("Nhập điểm toán:");
    diemToan = Convert.ToDouble(Console.ReadLine());
    Console.Write("Nhập điểm văn:");
    diemVan = Convert.ToDouble(Console.ReadLine());
    Console.Write("Nhập điểm anh:");
    diemAnh = Convert.ToDouble(Console.ReadLine());
    HocVien.id++;
  }

  public void XuatThongTin(){
    Console.WriteLine(@$"
    ----------------------------------------------------------------
      Mã học viên: {MaHocVien}
      Tên học viên: {TenHocVien}
      Điểm toán: {diemToan} -    Điểm anh: {diemAnh} -       Điểm văn: {diemVan}
      Điểm trung bình: {TinhDiemTrungBinh()}  Xếp loại: {XepLoai()}
    ");
  }

  public double TinhDiemTrungBinh(){
    return (diemToan + diemVan + diemAnh) / 3;
  }

  public string GetLastName(){
    string[] arr = TenHocVien.Split(" ");
    return arr.Last();
  }

  public string XepLoai(){
    double diemTB = TinhDiemTrungBinh();
    string result = "";

    if(diemTB < 5) {
      result = "Yếu";
    }else if(diemTB >= 5 && diemTB <= 6.5){
      result = "Trung Bình";
    }else if(diemTB >= 6.5 && diemTB < 8){
      result = "Khá";
    }else{
      result = "Giỏi";
    }
    return result;
  }

}