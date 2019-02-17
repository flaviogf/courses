using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class IniciaJogoController : MonoBehaviour
    {
        public void Start()
        {
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Jogo");
            }
        }
    }
}