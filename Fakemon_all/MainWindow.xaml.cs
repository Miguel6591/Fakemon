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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Speech.Recognition;
using System.Data.OleDb;
using System.Data;

namespace Fakemon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int minutos = 0;
        int segundos = 0;
        double intervalo_1 = 10000.0;  // 10 segundos
        double intervalo_2 = 10000.0;  // 10 segundos

        DispatcherTimer time1;
        DispatcherTimer time2;

        Avatar avatar = new Avatar(100, 100, 100);

        Storyboard moverOjos, dormir, comer, jugar, enamorao, cansado,
            hambriento, aburrio, malo, morir;

        Boolean reconocerVoz = false;

        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ES-ES"));
        OleDbConnection myconect;
        OleDbCommand mycommand;

        public MainWindow()
        {
            time1 = new DispatcherTimer();
            time1.Interval = TimeSpan.FromMilliseconds(intervalo_1);
            time1.Tick += new EventHandler(temporizador);
            time1.Start();

            time2 = new DispatcherTimer();
            time2.Interval = TimeSpan.FromMilliseconds(intervalo_2);
            time2.Tick += new EventHandler(morirTimeMinutos);
            time2.Start();

            iniciarReconocimientoVoz();

            InitializeComponent();
            moverOjos = (Storyboard)this.Resources["moverOjos"];
            moverOjos.Begin();
            dormir = (Storyboard)this.Resources["dormir"];
            comer = (Storyboard)this.Resources["comer"];
            jugar = (Storyboard)this.Resources["jugar"];
            enamorao = (Storyboard)this.Resources["enamorado"];
            malo = (Storyboard)this.Resources["Malo"];
            cansado = (Storyboard)this.Resources["Cansado"];
            aburrio = (Storyboard)this.Resources["aburrido"];
            hambriento = (Storyboard)this.Resources["Hambriento"];
            morir = (Storyboard)this.Resources["morir"];

            // BBDD Access

            myconect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Persistencia.accdb");
            mycommand = myconect.CreateCommand();
            mycommand.CommandText = "SELECT * FROM Persistencia WHERE Id=1";
            mycommand.CommandType = CommandType.Text;
            myconect.Open();
            OleDbDataReader DBreader = mycommand.ExecuteReader();
            if (DBreader.Read())
            {
                pbEnergia.Value = Convert.ToDouble(DBreader["Energía"].ToString());
                pbHambre.Value = Convert.ToDouble(DBreader["Comida"].ToString());
                pbDiversion.Value = Convert.ToDouble(DBreader["Diversión"].ToString());

            }
        }

        private int temp(int max)
        {
            Random mitemp = new Random();
            return 1 + mitemp.Next(max);
        }


        private void temporizador(object sender, EventArgs e)
        {
            int tempoEnergia = temp(10);
            int tempoHambre = temp(5);
            int tempoDiversion = temp(15);

            pbEnergia.Value -= tempoEnergia;
            avatar.Energia -= tempoEnergia;
            pbHambre.Value -= tempoHambre;
            avatar.Apetito -= tempoHambre;
            pbDiversion.Value -= tempoDiversion;
            avatar.Diversion -= tempoDiversion;

            estados();
        }

        private void btnDormir_Click(object sender, RoutedEventArgs e)
        {
            Dormir();
        }

        private void btnComer_Click(object sender, RoutedEventArgs e)
        {
            Comer();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            Jugar();
        }


        private void btnJuego_Click(object sender, RoutedEventArgs e)
        {
            Juego_SimonDice();
        }

    #region acciones

        private void Dormir()
        {
            moverOjos.Stop();
            pbEnergia.Value += temp(60);
            dormir.Begin();
            comer.Stop();
            jugar.Stop();
            enamorao.Stop();
            malo.Stop();
            aburrio.Stop();
            hambriento.Stop();
            cansado.Stop();

            String sentenciaDormir = "UPDATE Persistencia SET Energía= " +
                Convert.ToInt32(pbEnergia.Value) + ", Comida= " + Convert.ToInt32(pbHambre.Value) +
                ", Diversión= " + Convert.ToInt32(pbDiversion.Value) + " WHERE Id=1";
            OleDbCommand com = new OleDbCommand(sentenciaDormir, myconect);

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Comer()
        {
           
            pbHambre.Value+= temp(60);
            comer.Begin();
            jugar.Stop();
            dormir.Stop();
            enamorao.Stop();
            malo.Stop();
            aburrio.Stop();
            hambriento.Stop();
            cansado.Stop();

            String sentenciaComer = "UPDATE Persistencia SET Energía= " +
                Convert.ToInt32(pbEnergia.Value) + ", Comida= " + Convert.ToInt32(pbHambre.Value) +
                ", Diversión= " + Convert.ToInt32(pbDiversion.Value) + " WHERE Id=1";
            OleDbCommand com = new OleDbCommand(sentenciaComer, myconect);

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Jugar()
        {
            pbDiversion.Value += temp(60); 
            jugar.Begin();
            dormir.Stop();
            comer.Stop();
            malo.Stop();
            aburrio.Stop();
            hambriento.Stop();
            cansado.Stop();

            String sentenciaJugar = "UPDATE Persistencia SET Energía= " +
                Convert.ToInt32(pbEnergia.Value) + ", Comida= " + Convert.ToInt32(pbHambre.Value) +
                ", Diversión= " + Convert.ToInt32(pbDiversion.Value) + " WHERE Id=1";
            OleDbCommand com = new OleDbCommand(sentenciaJugar, myconect);

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Enamorar()
        {
            enamorao.Begin();
            moverOjos.Stop();
            jugar.Stop();
            dormir.Stop();
            comer.Stop();
            malo.Stop();
            aburrio.Stop();
            hambriento.Stop();
            cansado.Stop();
        }


        private void estados()
        {
            if (pbEnergia.Value <= 50)
            {
                cansado.Begin();
            }
            if (pbHambre.Value <= 50)
            {              
                hambriento.Begin();
            }

            if (pbDiversion.Value <= 50)
            {
                aburrio.Begin();
            }


            if (pbEnergia.Value <= 25 && pbHambre.Value <= 25 && pbDiversion.Value <= 25)
            {
                malo.Begin();
                moverOjos.Begin();
                aburrio.Stop();
                hambriento.Stop();
                cansado.Stop();
            }
        }

        private void MorirLentamente(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            if (pbEnergia.Value <= 0 && pbHambre.Value <= 0 && pbDiversion.Value <= 0)
            {
                
                moverOjos.Stop();
                malo.Stop();
                morir.Begin();
                btnComer.IsEnabled = false;
                btnDormir.IsEnabled = false;
                btnJugar.IsEnabled = false;
                btnJugar.IsEnabled = false;
                btnJugar.IsEnabled = false;
                CanvasVoz.IsEnabled = false;

                recognizer.RecognizeAsyncStop();
               
                labelTiempoMuerte.Content = "YOU LOSE.\nHas jugado\ndurante\n" + minutos + ":" + segundos + " minutos." + "\n\n¡Pruebe otra vez!";
            }
        }

        private void morirTimeMinutos(object sender, EventArgs e)
        {

            segundos += 1;

            if (segundos == 60)
            {
                minutos += 1;
                segundos = 0;
            }
        }

        #endregion acciones

        #region voz

        private void iniciarReconocimientoVoz()
        {
            Choices acciones = new Choices();
            acciones.Add(new string[] {"Duerme", "Come ", "Juega", "Guapo" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(acciones);

            Grammar g = new Grammar(gb);

            recognizer.LoadGrammar(g);

            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(eventosVoz);
            recognizer.SetInputToDefaultAudioDevice();

        }

        private void eventosVoz(object sender, SpeechRecognizedEventArgs e)
        {

            switch (e.Result.Text)
            {
                case "Duerme":
                    Dormir();
                    moverOjos.Begin();
                    break;
                case "Come":
                    Comer();
                    break;
                case "Juega":
                    Jugar();
                    break;
                case "Guapo":
                    Enamorar();
                    break;
            }
        }


        private void reconocimientodeVoz(object sender, MouseButtonEventArgs e)
        {
            if (reconocerVoz == false)
            {
                reconocerVoz = true;

                RectVoz.Fill = new SolidColorBrush(Color.FromRgb(50, 150, 5));

                CnVozApagado.Visibility = Visibility.Hidden;
                CnVozEncendido.Visibility = Visibility.Visible;

                recognizer.RecognizeAsync(RecognizeMode.Multiple);

            }
            else
            {
                reconocerVoz = false;

                RectVoz.Fill = new SolidColorBrush(Color.FromRgb(135, 0, 0));

                CnVozApagado.Visibility = Visibility.Visible;
                CnVozEncendido.Visibility = Visibility.Hidden;

                recognizer.RecognizeAsyncStop();
            }
        }


        #endregion voz

        private void reinicio(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);

            Application.Current.Shutdown();
        }

        private void Juego_SimonDice()
        {
            pbDiversion.Value = 100;
            Juego simond = new Juego();
            simond.Show();
        }
    }

}
