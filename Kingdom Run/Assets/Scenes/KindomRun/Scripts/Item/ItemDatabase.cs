using System.Collections.Generic;
using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    [CreateAssetMenu(fileName = "item_database", menuName = "KPU/아이템 데이터베이스 만들기")]
    public class ItemDatabase : ScriptableObject
    {
        public List<Item> items;
    }
}
