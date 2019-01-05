using UnityEngine;

namespace Assets.Script
{
    public class ControleDificuldade : MonoBehaviour
    {
        public float TempoParaDificuladeMaxima;

        private float _tempoPassado;

        public float Dificulade { get; private set; }

        public void Update()
        {
            _tempoPassado += Time.deltaTime;
            Dificulade = Mathf.Min(1, _tempoPassado / TempoParaDificuladeMaxima);
        }
    }
}