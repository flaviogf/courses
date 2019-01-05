using UnityEngine;

namespace Assets.Scripts
{
    public class MoveOffsetController : MonoBehaviour
    {
        private Material _material;

        public float Velocidade;

        public void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        public void Update()
        {
            var offset = _material.mainTextureOffset.x + Velocidade * Time.deltaTime;
            _material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}