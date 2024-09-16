namespace StoreApp.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }//kaç tane ürünün listelendiğinin bilgisi
        public int ItemsPerPage { get; set; }//sayfa başına düşen kayıt sayısı
        public int CurrenPage { get; set; }//mevcut sayfa bilgisi

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
        //dinamik olarak kaç adet çıktığını buluyoruz. toplam ürün sayısını
        //sayfa başına düşen ürün sayısına bölüyoruz
    }
}
