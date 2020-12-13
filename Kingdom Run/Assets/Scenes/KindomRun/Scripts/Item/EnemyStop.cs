using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    public class EnemyStop : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ItemManger.Instance.AddItem("EnemyStop");
                gameObject.SetActive(false);
            }
        }
    }
}
