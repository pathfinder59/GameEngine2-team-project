using System;
using System.Collections.Generic;
using System.Linq;
using KPU;
using KPU.Manager;
using UnityEngine;

namespace Scenes.KindomRun.Scripts.Item
{
    public class ItemManger : SingletonBehaviour<ItemManger>
    {
        [SerializeField] private ItemDatabase itemDatabase;
        [SerializeField] private Canvas itemCanvas;
        [SerializeField] private GameObject itemSlotPrefab;
        [SerializeField] private RectTransform targetRectTransform;
        private Dictionary<string, List<Item>> _items;

        private void Awake()
        {
            _items = new Dictionary<string, List<Item>>();
        }
        private void Start()
        {
            EventManager.On("game_ended", ResetList);
        }
        private void ResetList(object obj)
        {
            _items.Clear();
        }
        public void AddItem(string itemName)
        {
            var founded = itemDatabase.items.FirstOrDefault(Item => Item.itemName == itemName);
            
            if (founded == null) throw new Exception("해당 아이템은 데이터베이스에 존재하지 않습니다.");

            if (!_items.ContainsKey(itemName))
            {
                _items.Add(itemName, new List<Item>());
            }
            _items[itemName].Add(founded);
            
            var slotUi = targetRectTransform.GetComponentsInChildren<ItemSlotUI>(true);
            var existedSlot = slotUi.FirstOrDefault(slot => slot.ItemNameText == itemName);

            ItemSlotUI itemSlotUi;
            
            if (existedSlot == null)
            {
                var go = Instantiate(itemSlotPrefab, targetRectTransform);

                itemSlotUi = go.GetComponent<ItemSlotUI>();
            }
            else
            {
                existedSlot.gameObject.SetActive(true);
                itemSlotUi = existedSlot.GetComponent<ItemSlotUI>();
            }
            
            itemSlotUi.IconImage = founded.itemIconSPrite;
            itemSlotUi.ItemCountText = _items[itemName].Count.ToString();
            itemSlotUi.ItemNameText = founded.itemName;
        }

        public void UseItem(string itemName)
        {
            if (!_items.ContainsKey(itemName)) throw new Exception("해당 아이템은 존재하지 않습니다.");

            var founded = _items[itemName][0] as UsableItem;
            
            EventManager.Emit(founded.eventName);

            _items[itemName].Remove(founded);

            var slotUi = targetRectTransform.GetComponentsInChildren<ItemSlotUI>();
            var existedSlot = slotUi.FirstOrDefault(slot => slot.ItemNameText == itemName);
            
            if (_items[itemName].Count > 0)
            {
                var itemSlotUi = existedSlot.GetComponent<ItemSlotUI>();
                itemSlotUi.ItemCountText = _items[itemName].Count.ToString();
            }
            else
            {
                existedSlot.gameObject.SetActive(false);
            }
        }
        
    }
}
