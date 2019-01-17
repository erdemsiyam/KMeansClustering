using K_Means;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kmeans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*ÖN BİLGİ
            Chart içeriği (içendiki seriesler)

                Dugum   = yeni eklenen düğümler bu series'e eklenir. Eğer K-Means uygulanırsa içinde düğüm kalmayacağından silinir. Ama Tekrar Düğüm Eklenirse, Bunu tekrar oluşturup içine düğümleri ekleriz
                Küme {KumeSiraNumarasi} =   Kümenin merkezini tutan series
                Küme {KumeSiraNumarasi} Düğümleri  =   o kümenin düğümlerini tutan series.

        */

        // EKLEMELER SİLMELER
        private void btnDugumEkle_Click(object sender, EventArgs e)
        {
            // X ve Y Verisi Alma
            double x, y;    //  x,y kordinatları için değişkenler
            try
            {   //x ve y değerlerini TextBox'tan okurken hata alırsak diye trycatch açtık
                if (txtDugumX.Text.Contains(".") || txtDugumY.Text.Contains(".")) // değer alacağımız textbox'lar "." noktayı içeriyorsa(double için nokta değil virgül yazmamız gerekir ondalık kısmını) hata verdittiririz.
                    throw new Exception();//"." içeriyorsa hata verdittiriyoruz.
                x = Convert.ToDouble(txtDugumX.Text); // x ve y verisi TextBox'tan okunur
                y = Convert.ToDouble(txtDugumY.Text);
            }
            catch (Exception) // hata varsa
            {
                MessageBox.Show("Uygun Değerler Giriniz."); // mesaj döndürüp
                return;     //  işlem yapmadan geri göndeririz.
            }

            // Aynı Koordinatta Başka Düğüm Varsa Geri Dön
            if (KMeans.noktalar.Where(t => t.x == x && t.y == y).Count() > 0)
            {
                MessageBox.Show("Aynı koordinatta düğüm var.");
                return;
            }

            // Yukardaki Sorunlar Olmadıysa YENİ DÜĞÜM Arka Planda EKLENİR.
            KMeans.noktalar.Add(new Düğüm(x, y));
            // Yeni Düğüm Eklenirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
            KMeans.iterasyon = 1;

            // Yeni Düğümü Ön Planda Göstermek için :
            if (chart1.Series.FirstOrDefault(t => t.Name.Contains("Dugum")) == null)
            {   // önceden kmeans yapılmış ve ,Dugum slaytı silinmişse
                //(Bunu nasıl anladık, kmeans yaptığımızda "Dugum" series'i siliyorduk o yoksa kmeans uyguladık demektir)
                // tekrar Düğüm slaytı oluşturup global (Kümelere Atanmamış) Düğümler Oluşturulup Chart'a bastırırız
                Series s = new Series();
                s.Name = "Dugum";
                s.Enabled = true;
                s.ChartType = SeriesChartType.Point;    //  düğümlerin tipi nokta olacak
                s.XValueType = ChartValueType.Double;   //  düğümlerin x verisi double
                s.YValueType = ChartValueType.Double;   //  düğümlerin y verisi double
                s.MarkerColor = Color.Blue;             //  Global düğümlerin standart rengi MAVİ'dir.
                s.MarkerSize = 10;                      //  düğümlerin büyüklüğü 10
                s.MarkerStyle = MarkerStyle.Circle;     //  düğümler yuvarlak olacak
                s.IsVisibleInLegend = false;            //  yanda liste yazısına eklenmesinler
                if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                    s.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) }); //  düğüm eklenir.
                else
                    s.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } }); //  düğüm eklenir.
                chart1.Series.Add(s);                   //  Series, Chart'a Kaydolur
            }
            else
            {
                // daha k-means a başlamadıysak, "Düğüm" slaytı var demektir. 
                // o halde bu global düğümlerin(Kümelere verilmemiş düğümler) Series'ine yeni düğümümüz eklenir.
                if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                    chart1.Series["Dugum"].Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) });
                else
                    chart1.Series["Dugum"].Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } });
            }

        }
        private void btnDugumSil_Click(object sender, EventArgs e)
        {
            // Son Düğümü elimize alırız
            Düğüm düğüm = KMeans.noktalar.LastOrDefault();

            // eğer null ise başka düğüm kalmadı demektir. geri döneriz
            if (düğüm == null)
            {
                MessageBox.Show("Zaten Düğüm Kalmadı.");
                return;
            }

            // Son Düğümü sileriz
            KMeans.noktalar.Remove(düğüm);
            // Düğüm Silinirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
            KMeans.iterasyon = 1;


            // Görünümden de silmek için
            List<Series> series = chart1.Series.Where(x => x.Name.Contains("Dugum") || x.Name.Contains("Düğümleri")).ToList(); // Dugum ve Küme Düğümlerini Tutan adının sonunda "Düğümleri" yazısını barındıran serieslerin hepsini getir
            foreach (Series slayt in series) // gelen o serieslerin içinde dön
            {
                DataPoint dp = slayt.Points.FirstOrDefault(x => x.XValue == düğüm.x && x.YValues[0] == düğüm.y); // silmek istediğimiz düğümün koordinatıyla aynı değerde olan işaretçiyi bul
                slayt.Points.Remove(dp); // o işaretçiyi o slayttan (series'den) sil.
            }
        }
        private void btnDugumRastgele_Click(object sender, EventArgs e)
        {
            // Kaçtane düğüm istiyorsa bu değişkende tutacağız
            int kacTane = 0;
            try
            {   // Kaç Tane istiyor Sayısını TextBox'tan Alıyoruz.
                kacTane = Convert.ToInt16(txtDugumRastgele.Text);
            }
            catch (Exception) // Eğer sayıyı alırken hata çıkarsa, geri dön.
            {
                MessageBox.Show("Uygun Sayı Giriniz.");
                return;
            }

            Random rastgele = new Random(); //  rastgele koordinatlar için rastgelenesnesi
            for (int i = 0; i < kacTane; i++) // Kaçtane İstiyorsa okadar dön ve düğüm oluştur
            {
                double x, y;    //  Sıradaki Düğüm için x,y değişkenleri oluşturduk
                x = rastgele.NextDouble() * 10; //  rastgele x çektik
                y = rastgele.NextDouble() * 10; //  rastgele y çektik
                if (KMeans.noktalar.Where(t => t.x == x && t.y == y).Count() > 0)
                {   // eğer aynı koordinatta başka düğüm varsa, döngü sayacını eksilt tekrar döndür. Aynı Koordinatta Birden fazla düğüm istemiyoruz
                    i--;
                    continue;
                }

                // Sorunsuz Geldiysek Arka Planda Düğüm Oluşturulur Kayıta Eklenir.
                KMeans.noktalar.Add(new Düğüm(x, y));
                // Yeni Düğüm Eklenirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
                KMeans.iterasyon = 1;

                // Sıra geldi Bu Düğümü Chart'a Eklemeye
                if (chart1.Series.FirstOrDefault(t => t.Name.Contains("Dugum")) == null)
                {
                    // önceden kmeans yapılmış ve ,Dugum slaytı silinmişse
                    //(Bunu nasıl anladık, kmeans yaptığımızda "Dugum" series'i siliyorduk o yoksa kmeans uyguladık demektir)
                    // tekrar Düğüm slaytı oluşturup global (Kümelere Atanmamış) Düğümler Oluşturulup Chart'a bastırırız
                    Series s = new Series();
                    s.Name = "Dugum";
                    s.Enabled = true;
                    s.ChartType = SeriesChartType.Point;    //  düğümlerin tipi nokta olacak
                    s.XValueType = ChartValueType.Double;   //  düğümlerin x verisi double
                    s.YValueType = ChartValueType.Double;   //  düğümlerin y verisi double
                    s.MarkerColor = Color.Blue;             //  Global düğümlerin standart rengi MAVİ'dir.
                    s.MarkerSize = 10;                      //  düğümlerin büyüklüğü 10
                    s.MarkerStyle = MarkerStyle.Circle;     //  düğümler yuvarlak olacak
                    s.IsVisibleInLegend = false;            //  yanda liste yazısına eklenmesinler
                    if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                        s.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) });
                    else
                        s.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } });

                    chart1.Series.Add(s);                   //  Series, Chart'a Kaydolur
                }
                else
                {
                    // daha k-means a başlamadıysak, "Düğüm" slaytı var demektir. 
                    // o halde bu global düğümlerin(Kümelere verilmemiş düğümler) Series'ine yeni düğümümüz eklenir.
                    if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                        chart1.Series["Dugum"].Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) });
                    else
                        chart1.Series["Dugum"].Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } });
                }
            }

        }

        private void btnKumeyeRenkSec_Click(object sender, EventArgs e)
        {
            // Yeni Eklenecek Kümeye Renk Vermek için renk seçme işlemini bu buton fonksiyonu ile yapılır
            ColorDialog cd = new ColorDialog();     // Renk seçme dialog'u oluşturulup
            cd.ShowDialog();                        // kullanıcıya gösterilir
            btnKumeyeRenkSec.BackColor = cd.Color;  // kullanıcının seçtiği renk, bu butonun arkaplanı yapılır, ilerde de Kümeyi eklerken, bu butonun arkaplanından bu renk alınacak.
        }
        private void btnKumeEkle_Click(object sender, EventArgs e)
        {
            // Yeni Küme için Renk seçilmemişse mesaj döndür ... Nasıl anlarız : butonun rengi control renginde ise (255,240,240)
            if (btnKumeyeRenkSec.BackColor.A == 255 && btnKumeyeRenkSec.BackColor.B == 240 && btnKumeyeRenkSec.BackColor.G == 240)
            {
                MessageBox.Show("Lütfen Bir Renk Seçiniz.");
                return;
            }

            // Yeni Küme için  X,Y değişkenleri açılır
            double x, y;
            try
            {   //x ve y değerlerini TextBox'tan okurken hata alırsak diye trycatch açtık
                if (txtKumeX.Text.Contains(".") || txtKumeY.Text.Contains(".")) // değer alacağımız textbox'lar "." noktayı içeriyorsa(double için nokta değil virgül yazmamız gerekir ondalık kısmını) hata verdittiririz.
                    throw new Exception();//"." içeriyorsa hata verdittiriyoruz.
                x = Convert.ToDouble(txtKumeX.Text);
                y = Convert.ToDouble(txtKumeY.Text);
            }
            catch (Exception)
            {   // hata varsa
                MessageBox.Show("Uygun Değerler Giriniz.");
                return; //  işlem yapmadan geri göndeririz.
            }

            // Aynı Koordinatta Başka Küme Varsa Geri Dön
            if (KMeans.kümeler.Where(t => t.x == x && t.y == y).Count() > 0)
            {
                MessageBox.Show("Aynı koordinatta küme var.");
                return;
            }

            // Aynı Renkte Başka Küme Varsa Geri Dön
            if (KMeans.kümeler.Where(t => t.renk == btnKumeyeRenkSec.BackColor).Count() > 0)
            {
                MessageBox.Show("Aynı renkte küme var.");
                return;
            }

            // Sorun Yoksa KÜME ARKA PLANDA EKLENİR
            KMeans.kümeler.Add(new Küme(x, y, btnKumeyeRenkSec.BackColor));
            // Yeni Küme Eklenirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
            KMeans.iterasyon = 1;

            // Sıra Geldi Eklenen Kümeyi Ön Planda Göstermeye.
            Series s2 = new Series();                   // Bu Küme İçin Chart'a eklenecek Yeni Series Oluşturulur.
            s2.Name = "Küme " + KMeans.kümeler.Count;    // Series adı "Küme {KümeSayısı}"
            s2.Enabled = true;                          // Bu Series Chart'ta görünecek.
            s2.ChartType = SeriesChartType.Point;       // kümenin tipi nokta olacak
            s2.XValueType = ChartValueType.Double;      // kümenin x verisi double
            s2.YValueType = ChartValueType.Double;      // kümenin y verisi double
            s2.MarkerBorderColor = btnKumeyeRenkSec.BackColor; // işaretçinin Rengi, Biraz Önce Renk Seçimi Yaptığımız butonun arka planına kaydettiğimiz rengi olacak.
            s2.MarkerBorderWidth = 2;                   // işaretçinin sınır kalınlığı 2
            s2.MarkerColor = Color.Transparent;         // küme işaretçisinin içi boş renk olacak (Halka(Simit) Görünümü İçin)
            s2.MarkerSize = 26;                         // işaretçinin tam çapı 26
            s2.MarkerStyle = MarkerStyle.Circle;        // işaretçinin stili yuvarlak. (istediğimiz simit görünümüne sahip olduk)
            if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                s2.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) }); // bu küme için oluşturduğumuz series'e bir adet işaretçi eklenir o da tabii kümenin merkez koordinatını.
            else
                s2.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } }); // bu küme için oluşturduğumuz series'e bir adet işaretçi eklenir o da tabii kümenin merkez koordinatını.
            chart1.Series.Add(s2);                      // bu Series'i görünmesi için Chart'a Ekleriz.
        }
        private void btnKumeSil_Click(object sender, EventArgs e)
        {
            //Son Kümeyi elimize Alırız.
            Küme küme = KMeans.kümeler.LastOrDefault();


            // eğer null ise başka küme kalmadı demektir. geri döneriz
            if (küme == null)
            {
                MessageBox.Show("Zaten Küme Kalmadı.");
                return;
            }

            // Son Kümeyi sileriz
            KMeans.kümeler.Remove(küme);
            // Küme Silinirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
            KMeans.iterasyon = 1;

            // Görünümden de silmek için (SADECE KÜMEYİ onun düğümlerini Değil ! ) 
            chart1.Series.Remove(chart1.Series.Where(x => x.Name.Contains("Küme") && !x.Name.Contains("Düğümleri")).LastOrDefault());
            // chart'ın içinde son "Küme" isimli olup "Düğümleri" ismini içermeyen series silinir.

        }
        private void btnKumeRastgele_Click(object sender, EventArgs e)
        {

            // Kaçtane küme istiyorsa bu değişkende tutacağız
            int kacTane = 0;
            try
            {
                // Kaç Tane istiyor Sayısını TextBox'tan Alıyoruz.
                kacTane = Convert.ToInt16(txtKumeRastgele.Text);
            }
            catch (Exception)
            {
                // Eğer sayıyı alırken hata çıkarsa, geri dön.
                MessageBox.Show("Uygun Sayı Giriniz.");
                return;
            }
            Random rastgele = new Random(); //  rastgele koordinatlar için rastgelenesnesi
            for (int i = 0; i < kacTane; i++)   // Kaçtane İstiyorsa okadar dön ve küme oluştur
            {
                // Renk Atama
                Color rastgeleRenk;
                while (true)// Aynı Renkte Küme Varsa diye yine Rastgele Renk almak için while hep true, eğer farklı bulunursa break ile çıkılır
                {
                    rastgeleRenk = Color.FromArgb(rastgele.Next(256), rastgele.Next(256), rastgele.Next(256));// Rastgele Renk 
                    if (KMeans.kümeler.Where(t => t.renk == rastgeleRenk).Count() <= 0)
                        break; // Aynı Renkte Küme Yoksa While'ı bitir. Aynı Renkte Küme varsa yeni renk almak için tekrar while dön.
                }

                // Sıradaki Düğüm için x,y değişkenleri oluşturduk
                double x, y;

                // Koordinat Atama
                while (true) // Aynı Koordinatta Küme Varsa diye Tekrar Rastgele X,Y alması içi while hep true, eğer farklı bulunursa break ile çıkılır
                {
                    x = rastgele.NextDouble() * 10;
                    y = rastgele.NextDouble() * 10;
                    if (KMeans.kümeler.Where(t => t.x == x && t.y == y).Count() <= 0)
                        break; // Aynı Koordinatta Küme yoksa While'dan çık , Eğer varsa while tekrar girsin tekrar rastgele x,y alsın
                }

                // Küme Arka Planda Eklenir
                KMeans.kümeler.Add(new Küme(x, y, rastgeleRenk));
                // Yeni Küme Eklenirse, İterasyonu Sıfırlarız : Yeni Örnek olur çünkü
                KMeans.iterasyon = 1;

                // Kümeyi Ön Planda Göstermek için Chart'a Series Ekleyeceğiz.
                Series s2 = new Series();                   // Bu Küme İçin Chart'a eklenecek Yeni Series Oluşturulur.
                s2.Name = "Küme " + KMeans.kümeler.Count;   // Series adı "Küme {KümeSayısı}"
                s2.Enabled = true;                          // Bu Series Chart'ta görünecek.
                s2.ChartType = SeriesChartType.Point;       // kümenin tipi nokta olacak
                s2.XValueType = ChartValueType.Double;      // kümenin x verisi double
                s2.YValueType = ChartValueType.Double;      // kümenin y verisi double
                s2.MarkerBorderColor = rastgeleRenk;        // işaretçinin Rengi
                s2.MarkerBorderWidth = 2;                   // işaretçinin sınır kalınlığı 2
                s2.MarkerColor = Color.Transparent;         // küme işaretçisinin içi boş renk olacak (Halka(Simit) Görünümü İçin)
                s2.MarkerSize = 26;                         // işaretçinin tam çapı 26
                s2.MarkerStyle = MarkerStyle.Circle;        // işaretçinin stili yuvarlak. (istediğimiz simit görünümüne sahip olduk)
                if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                    s2.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y }, Label = $"({kırp(x)} , {kırp(y)})", Font = new Font("Arial", 9.0f) }); // bu küme için oluşturduğumuz series'e bir adet işaretçi eklenir o da tabii kümenin merkez koordinatını.
                else
                    s2.Points.Add(new DataPoint() { XValue = x, YValues = new double[] { y } }); // bu küme için oluşturduğumuz series'e bir adet işaretçi eklenir o da tabii kümenin merkez koordinatını.


                chart1.Series.Add(s2);                      // bu Series'i görünmesi için Chart'a Ekleriz.
            }

        }


        // K-MEANS İŞLEMİ VE SONUÇ ÇİZİMİ 
        private void btnUygula_Click(object sender, EventArgs e)
        {
            // K-Means öncesi veri kontrolü
            if (KMeans.noktalar.Count() < 1)
            {
                MessageBox.Show("En Az 1 Düğüm Olmalı");
                return;
            }
            if (KMeans.kümeler.Count() < 1)
            {
                MessageBox.Show("En Az 1 Küme Olmalı");
                return;
            }

            // Örnek Sonucu Yada İterasyon Sonucunu ilerde bastırmak üzere şimdiden mesaj için sonuc isimli string açılır.
            string sonuc = "";

            // Biten İterasyon Var Mı Kontrol
            if (KMeans.iterasyon == 0) // iterasyon 0 sa yani bitmişse Sonuç Göstertilecektir (EN AŞAĞIDA, Chart Gösterimi Sonrası)
            {
                sonuc = "Iterasyon BİTTİ.\n\t Sonuç : ";
            }
            else // iterasyon 0 dan farklı yani bitmemişse. Hem K-Means Yapılır Hemde İterasyon Sonucu Hazırlanacak (EN AŞAĞIDA, Chart Gösterimi Sonrası)
            {

                sonuc = KMeans.iterasyon + ".Iterasyon.\n\t Sonuç : ";
                // K-Means İşlemi
                KMeans.uzakliklariHesapla();
                KMeans.kümelerinDüğümOrtalamasınıHesapla();

                //işlem yapıldıktan sonra bittiyse iterasyon. Örnek bittiyse sonuç mesajını güncelleriz.
                if (KMeans.iterasyon == 0)
                {

                    sonuc = "Iterasyon BİTTİ.\n\t Sonuç : ";
                }

            }


            //K-Means Sonrası Çizimler
            foreach (Series se in chart1.Series.ToList()) // chart'ın içindeki series'ler boşaltılır
            {
                chart1.Series.Remove(se);
            }

            int kumeAdSayac = 1;
            foreach (Küme küme in KMeans.kümeler) // Küme Ve Düğümleri bastırılır.
            {
                // Düğümleri Ekleme
                Series s = new Series();    //  her kümenin düğümlerini eklemek için series açılır
                s.Name = "Küme " + kumeAdSayac + " Düğümleri";   //  adı "Küme {KümeSayısı} Düğümleri"
                s.Enabled = true;           //  chart'ta aktif olacak, görünecek
                s.ChartType = SeriesChartType.Point;    //  düğümlerin tipi nokta olacak
                s.XValueType = ChartValueType.Double;   //  düğümlerin x verisi double
                s.YValueType = ChartValueType.Double;   //  düğümlerin y verisi double
                s.MarkerColor = küme.renk;              //  düğümlerin rengi kümenin rengi yapılır
                s.MarkerSize = 10;                      //  düğümlerin büyüklüğü 10
                s.MarkerStyle = MarkerStyle.Circle;     //  düğümler yuvarlak olacak
                s.IsVisibleInLegend = false;            //  Düğümler Yandaki liste yazısına eklenmesinler

                foreach (Düğüm düğüm in küme.noktaları) //  Kümeye Ait Tüm Noktalar Eklenir.
                {
                    if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                        s.Points.Add(new DataPoint() { XValue = düğüm.x, YValues = new double[] { düğüm.y }, Label = $"({kırp(düğüm.x)} , {kırp(düğüm.y)})", Font = new Font("Arial", 9.0f) });
                    else
                        s.Points.Add(new DataPoint() { XValue = düğüm.x, YValues = new double[] { düğüm.y } });

                }
                chart1.Series.Add(s);   //  Series, Chart'a Kaydolur

                //kümenin kendisi Eklenir
                Series s2 = new Series();   // her kümenin kendisini eklemek için series açılır
                s2.Name = "Küme " + kumeAdSayac++;     //   adı "Küme {KümeSayısı}"
                s2.Enabled = true;     //   chart'ta aktif olacak, görünecek
                s2.ChartType = SeriesChartType.Point;   //  kümenin tipi nokta olacak
                s2.XValueType = ChartValueType.Double;  //  kümenin x verisi double
                s2.YValueType = ChartValueType.Double;  //  kümenin y verisi double
                s2.MarkerBorderColor = küme.renk;       //  kümenin çevre(sınır) rengi kümeye verilen renk olacak
                s2.MarkerBorderWidth = 2;               //  kümenin çevre sınır büyüklüğü 2 olacak (HALKA(SİMİT) YAPISI İÇİN)
                s2.MarkerColor = Color.Transparent;     //  kümenin içi transparent yani boş olacak
                s2.MarkerSize = 26;                     //  kümenin tam çapı 26 uzunlukta olacak
                s2.MarkerStyle = MarkerStyle.Circle;    //  kümenin tipi yuvarlak olacak (TAM İSTEDİĞİMİZ HALKA(SİMİT) YAPISINA ULAŞTIK)
                if ((string)btnKoordinatlariAcKapa.Tag == "acik")
                    s2.Points.Add(new DataPoint() { XValue = küme.x, YValues = new double[] { küme.y }, Label = $"({kırp(küme.x)} , {kırp(küme.y)})", Font = new Font("Arial", 9.0f) }); //  kümenin merkez noktaları verilir.
                else
                    s2.Points.Add(new DataPoint() { XValue = küme.x, YValues = new double[] { küme.y } }); //  kümenin merkez noktaları verilir.                    
                chart1.Series.Add(s2);                  //  series gösterime girer.
            }

            // Örnek Sonucu Yada İterasyon Sonucunu Göstermek için Tüm Kümelerin Koordinatları Yazdırılır.
            int kumeSayac = 1;
            foreach (Küme küme in KMeans.kümeler)
            {
                sonuc += $"\n Küme " + kumeSayac++ + " ( " + kırp(küme.x) + " , " + kırp(küme.y) + " )";
            }
            MessageBox.Show(sonuc);

        }


        //Diğerleri
        public static double kırp(double gelen)
        {
            string sayi = gelen.ToString();
            string[] parse = sayi.Split(',');
            if (parse.Length > 1 && parse[1].Count() > 2)
            {
                sayi = parse[0] + "," + parse[1].Substring(0, 2);
            }

            return Convert.ToDouble(sayi);

        }
        private void btnKoordinatlariAcKapa_Click(object sender, EventArgs e)
        {
            string acikMi = btnKoordinatlariAcKapa.Tag.ToString();


            if (acikMi == "acik")
            {
                foreach (Series serie in chart1.Series.ToList())
                {
                    foreach (DataPoint item in serie.Points.ToList())
                    {
                        item.Label = String.Empty;
                    }
                }

                btnKoordinatlariAcKapa.Tag = "kapali";
            }
            else
            {
                foreach (Series serie in chart1.Series.ToList())
                {
                    foreach (DataPoint item in serie.Points.ToList())
                    {
                        item.Label = $"({kırp(item.XValue)} , {kırp(item.YValues[0])})";
                    }
                }
                btnKoordinatlariAcKapa.Tag = "acik";
            }
        }
    }
}
