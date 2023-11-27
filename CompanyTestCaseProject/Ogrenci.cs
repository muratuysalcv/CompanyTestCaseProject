namespace CompanyTestCaseProject
{
    public class Ogrenci
    {
        public Ogrenci(int no, string ad, int vizeNotu, int finalNotu)
        {
            this.No = no;
            this.Ad = ad;
            this.FinalNotu = finalNotu;
            this.VizeNotu = vizeNotu;
        }
        private int No { get; set; }
        private string Ad { get; set; }
        private int VizeNotu { get; set; }
        private int FinalNotu { get; set; }

        private double NotHesapla()
        {
            return (this.VizeNotu * 0.4 + this.FinalNotu * 0.6);
        }

        public string OgrenciYazdir()
        {
            return "Ogrenci bilgileri:" + this.Ad + " adında " + this.No + " numarasinda not ortalamasi da "+this.NotHesapla().ToString("n1") ;
        }
    }
}
