using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
namespace Sİfre_güvenlik_testi_odev1
{
    static class Class2
    {
        public static int KücükHarf, BüyükHarf, Rakam, Sembol;
        public  enum SifreGücü //şifre gücü yazısını yazmak için enum fonksiyonu açılır.

        {
            [Description("Kabul Edilemez")] KabulEdilemez, //kabul edilemez için açıklama eklenir.
            [Description("Kabul Edilir")] KabulEdilir, Güçlü //kabul edilebilir ve güçlü için açıklama eklenir 

        }
        public static int KücükHarfSkor(string Sifre) //küçük harfler için private fonksiyonu açılır.
        {
            int Sayi = Sifre.Length - Regex.Replace(Sifre, "[a-z]", "").Length; //parolanın uzunluğu eşleşen küçük harflerin sayısı kadar azaltır. 
            KücükHarf = Sayi; //sayi değeri KücükHarf değişkenine atanır.
            return Math.Min(2, Sayi) * 10; //1 adet küçük harfe 10, üzeri küçük harf adedi için 20 değeri döndürülür.
        }
        public  static int BüyükHarfSkor(string Sifre) //büyük harfler için private fonksiyonu açılır.
        {
            int Sayi = Sifre.Length - Regex.Replace(Sifre, "[A-Z]", "").Length; //parolanın uzunluğu eşleşen büyük harflerin sayısı kadar azaltır.
            BüyükHarf = Sayi; //sayi değeri BüyükHarf değişkenine atanır.
            return Math.Min(2, Sayi) * 10; //1 adet büyük harfe 10, üzeri büyük harf adedi için 20 değeri döndürülür.
        }

        public static int RakamSkor(string Sifre) //rakamlar için private fonksiyonu açılır. 
        {
            int Sayi = Sifre.Length - Regex.Replace(Sifre, "[0-9]", "").Length; //parolanın uzunluğu eşleşen rakamların sayısı kadar azaltır. 
            Rakam = Sayi; //sayi değeri Rakam değişkenine atanır.
            return Math.Min(2, Sayi) * 10; //1 adet rakama 10, üzeri rakam adedi için 20 değeri döndürülür.
        }

        public static int SembolSkor(string Sifre) //semboller için private fonksiyonu açılır.
        {

            int Sayi = Regex.Matches(Sifre, "[-~!@#$%^&*()_+{}:\"<>/?.,;]").Count; //semboller sayıları kadar kullanılır.
            Sembol = Sayi;  //sembole sayi değişkeni atanır. 
            return Sayi * 10; //her bir sembole 10 puan döndürülür. 
        }
        public  static int SifreUzunlukSkor(string Sifre) //şifre uzunluğu için private fonksiyonu açılır. 
        { // Burada Kullanıcının girmiş oldugu şifrenin uzunlugunu ögreniyoruz.
            int Sayi = Sifre.Length; //şifrenin uzunluğu sayıya atanır.
            return Sayi; //sayı döndürülür. 
        }
        public static int SifreSkoruOlustur(string Sifre) //şifre skoru için public fonksiyonu açılır. 
        {
            if (Sifre == null) //eğer şifre boşsa 
            {
                return 0; //sıfır değeri döndürülür. 
            }
            int Uzunluk = SifreUzunlukSkor(Sifre); //Şifreuzunlukskor fonksiyon değeri Uzunluk değişkenine atanır. 
            int KücükH = KücükHarfSkor(Sifre); //Kücükharfskor fonksiyon değeri KücükH değişkenine atanır. 
            int BüyükH = BüyükHarfSkor(Sifre); //Büyükharfskorskor fonksiyon değeri BüyükH değişkenine atanır. 
            int RakamSayi = RakamSkor(Sifre); //Rakamskor fonksiyon değeri RakamsayiH değişkenine atanır. 
            int Ozel = SembolSkor(Sifre); //Sembolskor fonksiyon değeri Ozel değişkenine atanır. 
            if (KücükH != 0 && BüyükH != 0 && RakamSayi != 0 && Ozel != 0) //KücükH, BüyükH, RakamSayi, Ozel değerleri sıfıra eşit değilse.
            {
                if (Uzunluk == 9) //uzunluk 9 a eşitse
                {
                    Uzunluk = 10; //uzunluğa 10 değerini ata. 
                    return Uzunluk + Ozel + KücükH + BüyükH + RakamSayi; //Uzunluk, Ozel, KücükH, BüyükH, RakamSayi değerlerini toplayıp döndür. 
                }
                return Ozel + KücükH + BüyükH + RakamSayi;  //Ozel, KücükH, BüyükH, RakamSayi değerlerini toplayıp döndür. 
            }
            return 0; //sıfır döndürülür.
        }
        public static SifreGücü SifreGücüHesapla(int Skor) //şifre gücü yazmak için public fonksiyonu açılır. 
        {
            if (Skor < 70) //skor puanı 70 den küçük ise
            {
                Console.WriteLine(Skor); //skor puanını yazdır. 
                return SifreGücü.KabulEdilemez; //şifre gücünü ve şifre kabul edilemez yazdır. 
            }
            else if (Skor >= 70 && Skor < 90) //şifre 70 ve 90 arasındaysa 
            {
                Console.WriteLine(Skor); //skor puanını yaz
                return SifreGücü.KabulEdilir; //şifre gücünü ve şifre kabul edilir yazdır. 
            }
            else //şifre 90 ve üzeri ise
            {
                Skor = 100;
                Console.WriteLine(Skor); //skoru yazdır. 
                return SifreGücü.Güçlü; //şifre gücünü ve şifre güçlü yazdır. 
            }

        }
    }
}
