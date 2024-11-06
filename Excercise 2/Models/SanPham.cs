class  SanPham {
  public static int id = 1;

  public string MaSanPham {get; set;}

  public string TenSanPham {get; set;}

  public double GiaBan {get; set;}

  public double SoLuongTonKho {get; set;}

  public SanPham(){

  }
  
  public void NhapThongTin(){
    Console.WriteLine("Nhap ma san pham: ");
    MaSanPham = Console.ReadLine();
    Console.WriteLine("Nhap ten san pham: ");
    TenSanPham = Console.ReadLine();
    Console.WriteLine("Nhap gia ban: ");
    GiaBan = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Nhap so luong ton kho: ");
    SoLuongTonKho = Convert.ToDouble(Console.ReadLine());
    id++;
  }

  public string LayChuCuoiTrongTenSanPham(){
    string chuCuoi = "";
    string[] words = TenSanPham.Split(' ');
    chuCuoi= words[words.Length - 1];
    return chuCuoi;
  }

  public void XuatThongTin(){
    Console.WriteLine(@$"
      Ma san pham: {MaSanPham}
      Ten san pham: {TenSanPham}
      Gia ban: {GiaBan}
      So luong ton kho: {SoLuongTonKho}
    ");
  }

}
