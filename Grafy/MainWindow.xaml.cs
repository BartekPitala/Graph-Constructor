using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Grafy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Canvas mainCanvas;
        private Graf nasz_graf = null;
        public int ilosc_wierzcholkow { get; set; }
        public int aktualny_wierzcholek { get; set; }//ZMIENNA POTRZEBNA DO WYPISYWANIA NA WKRAN INFO, KTOREMU WIERZCHOLKOWI WPISUJEMY
                                                     //SĄSIADÓW


        public bool zatwierdzono_sasiada { get; set; }//ZMIENNA POTRZEBNA DO REALIZACJI WPISYWANIA SĄSIADÓW (PATRZ NIŻEJ)
        public bool kolejny_wierzcholek { get; set; } //ZMIENNA POTRZEBNA DO REALIZACJI WPISYWANIA SĄSIADÓW (PATRZ NIŻEJ)

        public MainWindow()
        {
            InitializeComponent();
            aktualny_wierzcholek = 1;
            zatwierdzono_sasiada = false;
            kolejny_wierzcholek = false;
            draw_connections_button.IsEnabled = false;
            confirm_button_2.IsEnabled = false;
            kolejny_wierzcholek_button.IsEnabled = false;


        }

        private void Generuj_kolo()
        {
       

            mainCanvas = new Canvas();

            mainCanvas.Width = 512;
            mainCanvas.Height = 768;
            mainCanvas.Background = Brushes.Green;

            mainCanvas.Margin = new Thickness(512, 0, 0, 0);

            Najlepszy_grid.Children.Add(mainCanvas);






            Ellipse kolo = new Ellipse();
            kolo.Width = 400;
            kolo.Height = 400;
            kolo.StrokeThickness = 5;
            
            kolo.Stroke = Brushes.Black;
            Canvas.SetBottom(kolo, 212);
            Canvas.SetLeft(kolo, 56);
           
            
  

        }



        void UstawWspolrzedne(Graf nowy_graf)
        {
            double kat = 2*Math.PI / nowy_graf.ilosc;

            for(int i=0;i<nowy_graf.ilosc;++i)
            {
                
                nowy_graf.x[i] = Math.Cos(i * kat) * nowy_graf.promien + 255;
                nowy_graf.y[i] = Math.Sin(i * kat) * nowy_graf.promien + 408;
               
            }

        }






        private void illosc_wierzcholkow_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (illosc_wierzcholkow.Text == "")
                return;

            ilosc_wierzcholkow = Int32.Parse(illosc_wierzcholkow.Text);
  

        }

        private void restart_button_Click(object sender, RoutedEventArgs e)//RESTARTUJE APKE, CZYLI ROBIMY GRAF OD NOWA
        {
            if (nasz_graf != null)
            {
                illosc_wierzcholkow.Text = "";
                illosc_wierzcholkow.IsEnabled = true;
                nasz_graf.usunGraf();
                aktualny_wierzcholek = 1;
                zatwierdzono_sasiada = false;
                kolejny_wierzcholek = false;
                draw_connections_button.IsEnabled = false;
                sasiedzi_wierzcholka.Text = "Poniżej wpisz sąsiadów wierzchołka nr ";
                confirm_button.IsEnabled = true;
                sasiedzi.Text = "";
                confirm_button_2.IsEnabled = false;
                kolejny_wierzcholek_button.IsEnabled = false;
                Info_o_liczbie.Text = "Poniżej wpisz liczbę wierzchołków";
            }
            }



        private void confirm_button_Click(object sender, RoutedEventArgs e)//ZATWIERDZA ILOSC WIERZCHOLKOW
        {
            if (illosc_wierzcholkow.Text == "")
            {
                Info_o_liczbie.Text = "Wprowadź prawidłową liczbę wierzchołków!";
            }
            else
            {
                confirm_button.IsEnabled = false;
                illosc_wierzcholkow.IsEnabled = false;
                Generuj_kolo();
                nasz_graf = new Graf(ilosc_wierzcholkow, this);
                UstawWspolrzedne(nasz_graf);
                nasz_graf.rysujWierzcholki();
                sasiedzi_wierzcholka.Text += aktualny_wierzcholek.ToString();
                confirm_button_2.IsEnabled = true;
                kolejny_wierzcholek_button.IsEnabled = true;
            }
        }
        
        private void sasiedzi_TextChanged(object sender, TextChangedEventArgs e)//TU WPISUJEMY SASIADOW KONKRETNYCH  WIERZCHOŁKÓW
        {
                       

        }




        private void confirm_button_2_Click(object sender, RoutedEventArgs e)//ZATWIERDZA SĄSIADA DLA WIERZCHOŁKA
        {
            zatwierdzono_sasiada = true;
            int z = 0;
            if (aktualny_wierzcholek <= ilosc_wierzcholkow)
            {
                Int32.TryParse(sasiedzi.Text, out z);
                if (z >= 0 && z <= ilosc_wierzcholkow)
                {
                    sasiedzi_wierzcholka.Text = "Poniżej wpisz sąsiadów wierzchołka nr " + aktualny_wierzcholek.ToString() + "\nWierzcholek nr " + z.ToString() + " jest sasiadem wierzcholka nr " + aktualny_wierzcholek.ToString();
                    nasz_graf.sasiedztwo[aktualny_wierzcholek - 1, z - 1] = 1;
                    nasz_graf.sasiedztwo[z - 1, aktualny_wierzcholek - 1] = 1;
                }
                else
                {
                    sasiedzi_wierzcholka.Text = "Sąsiad spoza zakresu wierzchołków! Wpisz poprawnego sąsiada wierzchołka nr " + aktualny_wierzcholek.ToString();
                }
            }

    }

        private void kolejny_wierzcholek_button_Click(object sender, RoutedEventArgs e)//PRZECHODZI DO WPISYWANIA SASIADOW KOLEJNEGO WIERZCHOLKA
        {
            kolejny_wierzcholek = true;
            if (aktualny_wierzcholek < ilosc_wierzcholkow)
            {
                aktualny_wierzcholek++;
                sasiedzi_wierzcholka.Text = "Poniżej wpisz sąsiadów wierzchołka nr " + aktualny_wierzcholek.ToString();
            }
            else
            {
                sasiedzi_wierzcholka.Text = "Wpisano sąsiadów wszystkich wierzchołkow!";
                confirm_button_2.IsEnabled = false;
                kolejny_wierzcholek_button.IsEnabled = false;
                draw_connections_button.IsEnabled = true;
            }
        }


        private void draw_connections_button_Click(object sender, RoutedEventArgs e)
        {
            nasz_graf.rysujPolaczenie();
        }





        private void wczytywanie_Click(object sender, RoutedEventArgs e)
        {

            string[] polaczenia = System.IO.File.ReadAllLines(@"../../dane/macierz_sasiedztwa.txt");

            int ilosc_wierzcholkow = System.IO.File.ReadAllLines(@"../../dane/macierz_sasiedztwa.txt").Count();

            Generuj_kolo();

            nasz_graf = new Graf(ilosc_wierzcholkow, this);
            UstawWspolrzedne(nasz_graf);
            nasz_graf.rysujWierzcholki();




            int i = 0;

              foreach(string linia in polaczenia)
              {

                for (int j = 0; j < ilosc_wierzcholkow; j++)
                    nasz_graf.sasiedztwo[i, j] = Convert.ToInt32(linia[j]) - 48;
                i++;

              }

                nasz_graf.rysujPolaczenie();



        }
    }

    



}
