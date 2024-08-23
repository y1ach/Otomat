using System;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ürünler = { "Eti Cin", "su", "sandviç", "soda", "gazoz" };
            int[] ürünfiyatları = { 30, 10, 50, 10, 15 };
            string[] ürünnumarası = { "1", "2", "3", "4", "5" };

            Console.WriteLine("Ürün satın alacaksanız 1'i tuşlayınız, eğer almayacaksanız güvenlik kodunu giriniz:");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Clear();
                Console.WriteLine("Para giriniz:");
                int bakiye = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ürünler: Eti Cin[1], su[2], sandviç[3], soda[4], gazoz[5]");

                while (true)
                {
                    Console.WriteLine("Almak istediğiniz ürünün numarasını giriniz:");
                    string ürünNo = Console.ReadLine();

                    int index = Array.IndexOf(ürünnumarası, ürünNo);

                    if (index >= 0 && index < ürünler.Length)
                    {
                        if (bakiye >= ürünfiyatları[index])
                        {
                            bakiye -= ürünfiyatları[index];
                            Console.WriteLine($"{ürünler[index]} satın alındı. Kalan bakiye: {bakiye} TL");

                            Console.WriteLine("Başka bir ürün almak istiyor musunuz? (E/H)");
                            string devamMi = Console.ReadLine().ToUpper();

                            if (devamMi != "E")
                            {
                                Console.WriteLine("Alışverişiniz sona erdi. Güle güle!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz bakiye! Lütfen tekrar para giriniz ya da alışverişi sonlandırmak için 'H' tuşlayınız.");
                            string yenidenParaGir = Console.ReadLine().ToUpper();
                            if (yenidenParaGir == "H")
                            {
                                Console.WriteLine("Alışveriş sona erdi.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ürün numarası. Lütfen tekrar deneyiniz.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Güvenlik kodu girildi.");
                Console.WriteLine("1 girerek ürün silme işlemi, 2 girerek ürün ekleme işlemi ve 3 girerek fiyat güncelleme işlemini yapabilirsiniz");

                string adminSecim = Console.ReadLine();

                switch (adminSecim)
                {
                    case "1":
                        Console.WriteLine("Silmek istediğiniz ürünün numarasını giriniz:");
                        int silinecekUrunNo = Convert.ToInt32(Console.ReadLine());

                        if (silinecekUrunNo > 0 && silinecekUrunNo <= ürünler.Length)
                        {
                            ürünler[silinecekUrunNo - 1] = null;
                            ürünnumarası[silinecekUrunNo - 1] = null;
                            ürünfiyatları[silinecekUrunNo - 1] = 0;

                            Console.WriteLine("Ürün başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz ürün numarası.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Eklemek istediğiniz ürünün adını giriniz:");
                        string yeniUrun = Console.ReadLine();
                        Console.WriteLine("Eklemek istediğiniz ürünün fiyatını giriniz:");
                        int yeniFiyat = Convert.ToInt32(Console.ReadLine());
                        string yeniUrunNo = (ürünnumarası.Length + 1).ToString();

                        Array.Resize(ref ürünler, ürünler.Length + 1);
                        ürünler[ürünler.Length - 1] = yeniUrun;

                        Array.Resize(ref ürünfiyatları, ürünfiyatları.Length + 1);
                        ürünfiyatları[ürünfiyatları.Length - 1] = yeniFiyat;

                        Array.Resize(ref ürünnumarası, ürünnumarası.Length + 1);
                        ürünnumarası[ürünnumarası.Length - 1] = yeniUrunNo;

                        Console.WriteLine("Ürün başarıyla eklendi.");
                        break;

                    case "3":
                        Console.WriteLine("Fiyatını güncellemek istediğiniz ürünün numarasını giriniz:");
                        int guncellenecekUrunNo = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (guncellenecekUrunNo >= 0 && guncellenecekUrunNo < ürünler.Length)
                        {
                            Console.WriteLine($"{ürünler[guncellenecekUrunNo]} için yeni fiyatı giriniz:");
                            int yenifiyat = Convert.ToInt32(Console.ReadLine());
                            ürünfiyatları[guncellenecekUrunNo] = yenifiyat;
                            Console.WriteLine("Ürün fiyatı başarıyla güncellendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz ürün numarası.");
                        }
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }

                // Güncellenmiş listeyi yazdır
                Console.WriteLine("\nGüncellenmiş Ürün Listesi:");
                for (int i = 0; i < ürünler.Length; i++)
                {
                    // Ürünlerin null olup olmadığını kontrol etmeden yazdır
                    Console.WriteLine($"Ürün: {(ürünler[i] ?? "Silinmiş Ürün")}, Fiyat: {ürünfiyatları[i]} TL, Numarası: {(ürünnumarası[i] ?? "N/A")}");
                }
            }
            Console.ReadLine();
        }
    }
}
