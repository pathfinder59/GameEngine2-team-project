using System;
using System.ComponentModel;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.KindomRun.Scripts.Item
{
    public class ItemSlotUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI itemCountText;
        [SerializeField] private TextMeshProUGUI itemNameText;
        
        public Sprite IconImage
        {
            set => iconImage.sprite = value;
        }

        public string ItemCountText
        {
            set => itemCountText.text = value;
        }

        public string ItemNameText
        {
            get => itemNameText.text;
            set => itemNameText.text = value;
        }

        public void Use()
        {
            ItemManger.Instance.UseItem(ItemNameText);
        }
        
    }
}
