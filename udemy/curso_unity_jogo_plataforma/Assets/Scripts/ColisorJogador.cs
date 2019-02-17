using UnityEngine;

namespace Assets.Scripts
{
    public class ColisorJogador : MonoBehaviour
    {
        public Jogador _scripJogador;

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Inimigo"))
            {
                _scripJogador.SofreDano();
            }
        }
    }
}
