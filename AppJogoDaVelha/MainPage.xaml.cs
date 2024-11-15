using Plugin.Maui.Audio;

namespace AppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        int jogadas = 0;
        IAudioPlayer player;
        public MainPage()
        {
            InitializeComponent();
            InicializarPlayer();
        }

        private async void InicializarPlayer()
        {
            var audioManager = AudioManager.Current;
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("click.mp3"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // tocar o som ao tocar no botão
            player.Play();

            Button btn = (Button)sender;

            btn.IsEnabled = false;

            if (vez == "X")
            {

                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }

            jogadas++;// incrementa o contador de jogadas

            // Verifica se o X ganhou em uma das linhas
            if ((btn10.Text == "X" && btn11.Text == "X" && btn12.Text == "X" ||
                btn20.Text == "X" && btn21.Text == "X" && btn22.Text == "X" ||
                btn30.Text == "X" && btn31.Text == "X" && btn32.Text == "X"))
            {
                DisplayAlert("Parabéns", "O X ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica se o X ganhou em uma das colunas
            if (btn10.Text == "X" && btn20.Text == "X" && btn30.Text == "X" ||
                btn11.Text == "X" && btn21.Text == "X" && btn31.Text == "X" ||
                btn12.Text == "X" && btn22.Text == "X" && btn32.Text == "X")
            {
                DisplayAlert("Parabéns", "O X ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica se o X ganhou em uma das diagonais
            if (btn10.Text == "X" && btn21.Text == "X" && btn32.Text == "X" ||
                btn12.Text == "X" && btn21.Text == "X" && btn30.Text == "X")
            {
                DisplayAlert("Parabéns", "O X ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica se o 0 ganhou
            if (btn10.Text == "0" && btn11.Text == "0" && btn12.Text == "0" ||
                btn20.Text == "0" && btn21.Text == "0" && btn22.Text == "0" ||
                btn30.Text == "0" && btn31.Text == "0" && btn32.Text == "0" ||
                btn10.Text == "0" && btn20.Text == "0" && btn30.Text == "0" ||
                btn11.Text == "0" && btn21.Text == "0" && btn31.Text == "0" ||
                btn12.Text == "0" && btn22.Text == "0" && btn32.Text == "0" ||
                btn10.Text == "0" && btn21.Text == "0" && btn32.Text == "0" ||
                btn12.Text == "0" && btn21.Text == "0" && btn30.Text == "0")
            {
                DisplayAlert("Parabéns", "O 0 ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica se deu empate
            if (jogadas == 9)
            {
                DisplayAlert("Empate", "Ninguém ganhou!", "OK");
                Zerar();
            }

        }// fecha método

        void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";
            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;
            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;
            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            vez = "X"; // reincia a  vez para X.
            jogadas = 0;  // reinciar o contador de jogadas
        }

    } // fecha classe
} // fecha namespace
