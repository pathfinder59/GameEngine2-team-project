using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    public class Shield : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ItemManger.Instance.AddItem("Shield");
                gameObject.SetActive(false);
            }
        }
    }
}
