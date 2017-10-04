using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Grafy
{
    class Graf

    {


        public MainWindow okno;//ZMIENNA REPREZENTUJACA GLOWNE OKNO PROGRAMU
        public double[] x { get; set; }//WSPOLRZEDNE X-OWE WIERZCHOLKOW GRAFU
        public double[] y { get; set; }//WSPOLRZEDNE Y-OWE WIERZCHOLKOW GRAFU
        public int[,] sasiedztwo { get; set; }//MACIERZ POLACZEN W GRAFIE
        public int ilosc { get; set; }//LICZBA WIERZCHOLKOW
        public double promien { get; set; }//PROMIEN KOLA, NA KTORYM LEZA WIERZCHOLKI



        public Graf(int n, MainWindow _okno)
        {
            x = new double[n];
            y = new double[n];
            ilosc = n;         
            promien = 200;  
            okno = _okno;   
            sasiedztwo = new int[ilosc , ilosc];
            for (int i = 0; i < ilosc; ++i)
            {
                for(int j=0; j < ilosc; ++j)
                {
                    sasiedztwo[i, j] = 0;

                }
            }
        }

        public void rysujWierzcholki()//METODA REALIZUJACA RYSOWANIEWIERZCHOLKOW
        {
            for (int i = 0; i < ilosc; ++i)
            {
                Ellipse punkt = new Ellipse();
                punkt.Width = 10;
                punkt.Height = 10;
                punkt.StrokeThickness = 1;
                punkt.Stroke = Brushes.Black;
                punkt.Fill = Brushes.Black;
                Canvas.SetBottom(punkt, y[i]);
                Canvas.SetLeft(punkt, x[i]);
                okno.mainCanvas.Children.Add(punkt);
                
            }
        }

        public void polaczenie()//METODA REALIZUJACA WYPELNIANIE MACIERZY POLACZEN
        {
            Random los = new Random();
            int z;

            for (int i = 0; i < ilosc; ++i)
            {
                for (int j = 0; j < ilosc; ++j)
                {
                    sasiedztwo[i, j] = 0;
                    z = los.Next(0, 5);
                    if (z == 1)
                    {
                        sasiedztwo[i, j] = z;
                        sasiedztwo[j, i] = z;
                    }
                }
            }


        }
        
        
        public void rysujPolaczenie()//METODA REALIZUJACA RYSOWANIE POLACZEN WIERZCHOLKOW W GRAFIE
        {
            for (int i = 0; i < ilosc; ++i)
            {
                for (int j = 0; j < ilosc; ++j)
                {
                    if(sasiedztwo[i,j]==1)
                    {
                        Line krawedz = new Line();
                        krawedz.X1 = x[i] + 4;
                        krawedz.X2 = x[j] + 4;
                        krawedz.Y1 = y[i] - 53;
                        krawedz.Y2 = y[j] - 53;
                        krawedz.StrokeThickness = 1;
                        krawedz.Stroke = Brushes.Yellow;
                        krawedz.Visibility = System.Windows.Visibility.Visible;
                        okno.mainCanvas.Children.Add(krawedz);

                    }

                }
            }
        }

        public void usunGraf()//METODA USUWAJACA GRAF
        {
            okno.mainCanvas.Children.Clear();

        }

    }
}
