using System;
using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
using System.Threading.Tasks;

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

        // Método assíncrono para inicializar o player de áudio
        private async void InicializarPlayer()
        {
            var audioManager = AudioManager.Current;
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("click.mp3"));
        }

        // Evento de clique do botão
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            player.Play(); // Tocar som ao clicar no botão
            btn.IsEnabled = false;
            btn.Text = vez;
            vez = vez == "X" ? "O" : "X"; // Alternar vez
            jogadas++; // Incrementar contador de jogadas

            // Verificar se há um vencedor ou empate
            if (VerificarVencedor("X") || VerificarVencedor("O") || jogadas == 9)
            {
                string mensagem = jogadas == 9 ? "Empate, ninguém ganhou!" : $"Parabéns, o {btn.Text} ganhou!";
                DisplayAlert("Resultado", mensagem, "OK");
                Zerar();
            }
        }

        // Método para verificar se há um vencedor
        private bool VerificarVencedor(string jogador)
        {
            return (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador ||
                    btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador ||
                    btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador ||
                    btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador ||
                    btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador ||
                    btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador ||
                    btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador ||
                    btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador);
        }

        // Método para reiniciar o jogo
        private void Zerar()
        {
            foreach (var btn in new[] { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 })
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }
            vez = "X"; // Reiniciar a vez para X
            jogadas = 0; // Reiniciar o contador de jogadas
        }
    }
}
