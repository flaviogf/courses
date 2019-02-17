using UnityEngine;

namespace Assets.Script
{
    public class ObstaculoPontuacao : MonoBehaviour
    {
        private Pontuacao _pontuacao;

        public void Awake()
        {
            _pontuacao = FindObjectOfType<Pontuacao>();
        }

        public void OnTriggerEnter2D(Collider2D outro)
        {
            if (outro.CompareTag("Aviao"))
            {
                _pontuacao.AdicionarPonto();
            }
        }
    }
}