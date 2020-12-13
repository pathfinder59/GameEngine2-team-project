using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    public class Heal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ItemManger.Instance.AddItem("Heal");
                gameObject.SetActive(false);
            }
        }
    }
}
