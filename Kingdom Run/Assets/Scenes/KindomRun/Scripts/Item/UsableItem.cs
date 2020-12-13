using KPU.Manager;
using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    [CreateAssetMenu(fileName = "item",menuName = "KPU/아이템만들기")]
    public class UsableItem : Item
    {
        public string eventName;

        public void Use()
        {
            EventManager.Emit(eventName);
        }
    }
}
