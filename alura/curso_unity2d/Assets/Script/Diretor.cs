using UnityEngine;

namespace Assets.Script
{
    public class Diretor : MonoBehaviour
    {
        public GameObject PainelGameOver;

        public MaoPiscando MaoPiscando;

        public Pontuacao Pontuacao;

        public Jogador Jogador;

        public void FinalizaJogo()
        {
            PainelGameOver.SetActive(true);
            Time.timeScale = 0;
            Pontuacao.SalvarRecorde();
        }

        public void ReiniciarJogo()
        {
            PainelGameOver.SetActive(false);
            Time.timeScale = 1;
            MaoPiscando.Reiniciar();
            Pontuacao.Reiniciar();
            Jogador.Reiniciar();
            var obstaculos = FindObjectsOfType<Obstaculo>();
            foreach (var obstaculo in obstaculos)
            {
                obstaculo.Destruir();
            }
        }
    }
}