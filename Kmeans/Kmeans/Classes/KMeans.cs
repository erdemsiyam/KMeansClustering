using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace K_Means
{
    static class KMeans
    {
        public static int iterasyon = 0;
        public static List<Küme> kümeler = new List<Küme>();
        public static List<Düğüm> noktalar = new List<Düğüm>();

        public static void uzakliklariHesapla()
        {
            //ilk önce tüm kümelerin nokta listeleri sıfırlanır
            foreach (Küme küme in kümeler) // sahip olduğu tüm noktaları silip , kendilerine en yakın noktalar tekrar hesaplanacak
            {
                küme.noktaları = new List<Düğüm>();
            }

            foreach (Düğüm düğüm in noktalar) // Her Düğüm kendisine En Yakın Kümeyi bulması üzerine işleme tabi tutulur.
            {
                Küme seçilenKüme = null; // seçili küme diye Küme alanı açtık
                double seciliKümeyeUzunluk = 0; // seçili kümenin bu düğüme uzunluğunu tutacak
                foreach (Küme küme in kümeler) // her küme için bu düğüme olan uzaklığı denemek için tüm kümeleri gezeriz
                {
                    double x_fark = Math.Abs(düğüm.x - küme.x); // x ve y farklarını bulduk mutlak değer yaptık
                    double y_fark = Math.Abs(düğüm.y - küme.y);
                    double hipotenus =Math.Pow(Math.Pow(x_fark, 2) + Math.Pow(y_fark, 2),0.5); // düğümün kümeye olan hipotenüs uzunluğu bulundu
                    if (seçilenKüme == null) // seçili küme boşsa (yani ilk defa bu fora girdiysek) ne olursa olsun ilk kümeyi alırız
                    {
                        seçilenKüme = küme; //  ne olursa olsun ilk kümeyi alırız
                        seciliKümeyeUzunluk = hipotenus; // ona olan uzunluğumuzu da alırız
                    }
                    else // önceden seçilmiş kümemiz varsa , aşağıda sıradaki kümeyle olan uzunluğu karşılaştırırız en yakın kümeyi alırız
                    {
                        if (hipotenus <= seciliKümeyeUzunluk) // yeni kümeye olan uzunluk seçili kümeye uzunluğumuzdan az ise
                        {
                            seçilenKüme = küme; // yeni seçili kümemiz bize daha yakın olanıdır diyerek alırız
                            seciliKümeyeUzunluk = hipotenus; // uzunluğu da güncelleriz.

                        } 
                    }
                }
                //en son bu düğüme en yakın kümeyi bulmuş oluruz ve onu o kümenin noktalarına ekleriz.
                seçilenKüme.noktaları.Add(düğüm);
            }
        }

        public static void kümelerinDüğümOrtalamasınıHesapla()
        {
            // uzakliklari hesaplayıp kümelere kendileine en yakın noktaları atadıktan sonra
            // kümelerin yeni merkez koordinatlarını hesaplamak için bu fonksiyonu çalıştırırız

            // eğer kümelerin yeni merkezleri eski merkezlerinden farklıysa değişim var demektir, bu sayede iterasyon artırırız. bu kararı tutması için bu bool oluşturulur
            bool degisenVarMi = false;

            // kümelerin yeni merkezleri için kümelerde gezeriz.
            foreach (Küme küme in kümeler)
            {
                // İstisna bir durum için aşağıdakiler yazılır
                // eğer hiç düğümü yoksa , koordinatları değişmeyecektir direkt onu pas geçeriz.
                if (küme.noktaları.Count <= 0)
                {
                    continue;
                }

                // Kümenin Sahip olduğu düğümleri gezilir ve  x ve y değerleri toplanır, en son ortalamasını alarak kümenin merkezi belirlenir.
                double toplam_x = 0,toplam_y = 0;
                foreach (Düğüm düğüm in küme.noktaları)
                {
                    toplam_x += düğüm.x;
                    toplam_y += düğüm.y;
                }

                //Kümenin yeni x ve y merkezleri ortalama ile bulunur.
                double yeniX = toplam_x / Convert.ToDouble(küme.noktaları.Count);
                double yeniY = toplam_y / Convert.ToDouble(küme.noktaları.Count);

                // Kümenin Yeni Merkezi Eski Merkezinden Farklıysa, değişen var demektir "true" yaparız, o yüzden aşağıda da iterasyon artar (ÖRNEK BİTİRİLMEZ)
                if (küme.x != yeniX || küme.y != yeniY) 
                {
                    degisenVarMi = true;
                }

                // Ardından Kümenin Yeni Merkezi Güncellenir.
                küme.x = yeniX;
                küme.y = yeniY;

            }
            //Kümelerin Yeni Merkezleri Hesaplandı.

            // Eğer bu kümelerden herhangi birinin merkezi değişmişse, örnekte değişim var demektir iterasyonu bir artırırız.
            if (degisenVarMi)
            {
                iterasyon++;
            }
            else // eğer hiçbir küme merkezi değişmemişse, iterasyon SIFIRLANIR. ÖRNEK BİTER.
            {
                iterasyon = 0;
            }
        }

    }
}
