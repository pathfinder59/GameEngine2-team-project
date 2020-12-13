using System;
using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    [Serializable]
    //[CreateAssetMenu(fileName = "item",menuName = "KPU/아이템만들기")]
    public abstract class Item : ScriptableObject
    {
        public string itemName; // 아이템 이름
        public int itemCount; // 아이템 개수
        public Sprite itemIconSPrite; // 아이템 아이콘
    }
}
