using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Fakemon
{
    /// <summary>
    /// Lógica de interacción para Juego.xaml
    /// </summary>
    /// 

    public partial class Juego : Window
    {

        Storyboard Pikachu, Rayquaza, Arceus, Deoxys, Jirachi, Hooh, Kyogre, Groudon, Raikou,
                Entei, Suicune, Mewtwo, Mew, Lugia, Celebi, Solgaleo;

        List<int> ListPokemon = new List<int>();
        int puntosObtenidos = 0;
        int c = 0;
        bool correcto = false;
        Random botonAlea = new Random();


        public Juego()
        {
            botonAlea = new Random();
            InitializeComponent();

            desactivarButtons();

            Pikachu = (Storyboard)this.Resources["pikachu"];
            Rayquaza = (Storyboard)this.Resources["rayquaza"];
            Arceus = (Storyboard)this.Resources["arceus"];
            Deoxys = (Storyboard)this.Resources["deoxys"];
            Jirachi = (Storyboard)this.Resources["jirachi"];
            Hooh = (Storyboard)this.Resources["hooh"];
            Kyogre = (Storyboard)this.Resources["kyogre"];
            Groudon = (Storyboard)this.Resources["groudon"];
            Raikou = (Storyboard)this.Resources["raikou"];
            Entei = (Storyboard)this.Resources["entei"];
            Suicune = (Storyboard)this.Resources["suicune"];
            Mewtwo = (Storyboard)this.Resources["mewtwo"];
            Mew = (Storyboard)this.Resources["mew"];
            Lugia = (Storyboard)this.Resources["lugia"];
            Celebi = (Storyboard)this.Resources["celebi"];
            Solgaleo = (Storyboard)this.Resources["solgaleo"];

        }

        public int PuntosObtenidos
        {
            get
            {
                return puntosObtenidos;
            }

            set
            {
                puntosObtenidos = value;
            }
        }

        public void botonPokemon(int valorPokemon)
        {
            if (ListPokemon[c] == valorPokemon)
            {
                c++;

            }
            else
            {

                CvTiempoJugado.Visibility = System.Windows.Visibility.Visible;
                PuntosObtenidos = ListPokemon.Count();
                labelTiempoJugado.Content = "Inténtelo de nuevo\n\nHas conseguido: " + PuntosObtenidos + " puntos\n";
                c = 0;
                ListPokemon = new List<int>();
                buttonJugar.IsEnabled = true;
                desactivarButtons();
                return;
            }

            if (c >= ListPokemon.Count)
            {
                c = 0;
                ListPokemon.Add(botonAlea.Next(0, 16));
                pulsarPokemon();
            }
            labelPuntosConseguidos.Content = ListPokemon.Count.ToString();
        }

        private void buttonJugar_Click(object sender, RoutedEventArgs e)
        {
            ListPokemon.Add(botonAlea.Next(0, 16));
            pulsarPokemon();
            buttonJugar.IsEnabled = false;
            CvTiempoJugado.Visibility = System.Windows.Visibility.Hidden;
            activarButtons();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(0);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(1);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(2);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(3);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(4);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(5);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(6);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(7);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(8);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(9);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(10);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(11);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(12);
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(13);
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(14);
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            botonPokemon(15);
        }


        public void pulsarPokemon()
        {
            correcto= true;
            
            foreach (int i in ListPokemon)
            {
                switch (i)
                {

                    case 0:
                        Pikachu.Begin();
                        break;
                    case 1:
                        Rayquaza.Begin();
                        break;
                    case 2:
                        Arceus.Begin();
                        break;
                    case 3:
                        Deoxys.Begin();
                        break;
                    case 4:
                        Jirachi.Begin();
                        break;
                    case 5:
                        Hooh.Begin();
                        break;
                    case 6:
                        Kyogre.Begin();
                        break;
                    case 7:
                        Entei.Begin();
                        break;
                    case 8:
                        Raikou.Begin();
                        break;
                    case 9:
                        Groudon.Begin();
                        break;
                    case 10:
                        Mewtwo.Begin();
                        break;
                    case 11:
                        Lugia.Begin();
                        break;
                    case 12:
                        Celebi.Begin();
                        break;
                    case 13:
                        Suicune.Begin();
                        break;
                    case 14:
                        Solgaleo.Begin();
                        break;
                    case 15:
                        Mew.Begin();
                        break;
                }
            }
            correcto = false;
        }

        private void activarButtons()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            button10.IsEnabled = true;
            button11.IsEnabled = true;
            button12.IsEnabled = true;
            button13.IsEnabled = true;
            button14.IsEnabled = true;
            button15.IsEnabled = true;
            button16.IsEnabled = true;
        }

        private void desactivarButtons()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
            button10.IsEnabled = false;
            button11.IsEnabled = false;
            button12.IsEnabled = false;
            button13.IsEnabled = false;
            button14.IsEnabled = false;
            button15.IsEnabled = false;
            button16.IsEnabled = false;
        }
    }
    
}
