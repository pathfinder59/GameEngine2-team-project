using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KPU;
using UnityEditor;
using System.Xml;
using System.Linq;

namespace Scene.Ui
{
    public class NavigationalCanvasManager : SingletonBehaviour<NavigationalCanvasManager>
    {
        private List<NavigationalCanvas> _navigationalCanvases;
        private void Awake()
        {
            _navigationalCanvases = GetComponentsInChildren<NavigationalCanvas>(includeInactive : true).ToList();
            //                                                                  ㄴ> true로 비활성화된 오브젝트도 가져옴
        }
        public void ShowCanvas(string canvasName)
        {
            var foundedCanvas = _navigationalCanvases.FirstOrDefault(c => c.CanvasName == canvasName);
            if(foundedCanvas != null)
            {
                _navigationalCanvases.Remove(foundedCanvas);
                _navigationalCanvases.Add(foundedCanvas);

                for(var i = 0; i< _navigationalCanvases.Count;++i)
                {
                    var naviagationalCanvas = _navigationalCanvases[i];
                    var canvasComponent = naviagationalCanvas.GetComponent<Canvas>();

                    if(foundedCanvas != naviagationalCanvas)
                        naviagationalCanvas.gameObject.SetActive(true);
                    canvasComponent.overrideSorting = true;
                    canvasComponent.sortingOrder = i;
                    naviagationalCanvas.gameObject.SetActive(false);
                }

                foundedCanvas.gameObject.SetActive(true);
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
