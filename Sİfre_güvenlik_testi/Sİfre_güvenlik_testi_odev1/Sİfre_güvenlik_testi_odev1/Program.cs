/****
 **					SAKARYA ÜNİVERSİTESİ
 **				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
 **				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
 **				   NESNEYE DAYALI PROGRAMLAMA DERSİ
 **					2021-2022 BAHAR DÖNEMİ

 ****/

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sİfre_güvenlik_testi_odev1
{
    class Program //program sınıfı açılır.
    {
     
        static void Main(string[] args)
        {
            string Sifre; //sifre değeri sting değişkeni olarak tanımlanır. 
            int Skor; //skor değeri int değeri olarak tanımlanır.

            do
            {
                Console.Write("Şifre Giriniz:"); //kullanıcıdan şifre girmesini istiyoruz.
                Sifre = Console.ReadLine(); //kullanıcıdan şifre alıyoruz. 
                Skor = Class2.SifreSkoruOlustur(Sifre.Trim()); //şifrede boşluk olmaması için trim fonksiyonunu kullanıyoruz.
                if (Sifre.ToLower() == "cikis") return;

                else if (Sifre.Length >= 9) //şifre uzunluğu 9 karakter ve üzeri ise 
                {
                    if (Skor >= 100) //eğer skor puanı 100 ve üzeri ise 
                    {
                        Skor = 100;  //skoru 100 e eşitliyoruz.
                    }
                    if (Skor < 70) //skor puanı 70 in altındaysa
                    {

                        Console.WriteLine("\n Sifre {0} \n Büyük Harf={1}\n Küçük Harf={2}\n Rakam={3}\n Sembol={4}\n", Class2.SifreGücü.KabulEdilemez, Class2.BüyükHarf, Class2.KücükHarf, Class2.Rakam, Class2.Sembol);
                        Console.WriteLine("Toplam Skor={0}\n", Skor);
                        //Console.WriteLine("Şifreniz de en az 1 Küçük Harf, 1 Büyük Harf, 1 Rakam, 1 tane özel karakter kullanmalısınız");

                    }
                    else if (Skor >= 70 && Skor < 90) //skor puanı 70 ve 90 arasınsdaysa (70 dahil, 90 dahil değil)
                    {
                        Console.WriteLine("\nSifre {0} \n Büyük Harf={1}\n Küçük Harf={2}\n Rakam={3}\n Sembol={4}\n", Class2.SifreGücü.KabulEdilir, Class2.BüyükHarf, Class2.KücükHarf, Class2.Rakam, Class2.Sembol);
                        Console.WriteLine("Toplam Skor={0}", Skor);
                    }
                    else //skor 90 ve üzeri ise
                    {
                        Console.WriteLine("\nSifre {0} ve {1} \n Büyük Harf={2}\n Küçük Harf={3}\n Rakam={4}\n Sembol={5}\n", Class2.SifreGücü.KabulEdilir, Class2.SifreGücü.Güçlü, Class2.BüyükHarf, Class2.KücükHarf, Class2.Rakam, Class2.Sembol);
                        Console.WriteLine("Toplam Skor={0}\n", Skor);

                    }
                }
                else //şifre 9 karakterden az ise
                {
                    Console.WriteLine("\nŞifreniz en az 9 karakter olmalıdır.");

                }

            } while (Sifre.ToLower() != "cikis");
            Console.ReadKey();
        }
        
     

    }

}