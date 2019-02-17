using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class Pontuacao : MonoBehaviour
    {
        private const string ChaveRecorde = "Recorde";

        public Text TextPontuacao;

        public Text TextRecorde;

        private AudioSource _somPontuacao;

        private int _pontuacao;

        public void Awake()
        {
            _somPontuacao = GetComponent<AudioSource>();
        }

        public void AdicionarPonto()
        {
            _pontuacao++;
            TextPontuacao.text = _pontuacao.ToString();
            _somPontuacao.Play();
        }

        public void Reiniciar()
        {
            _pontuacao = 0;
            TextPontuacao.text = _pontuacao.ToString();
        }

        public void SalvarRecorde()
        {
            var recorde = PlayerPrefs.GetInt("Recorde");
            if (_pontuacao > recorde)
            {
                PlayerPrefs.SetInt(ChaveRecorde, _pontuacao);
            }

            TextRecorde.text = PlayerPrefs.GetInt("Recorde").ToString();
        }
    }
}