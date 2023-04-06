using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Ui
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private GameObject _itemPrefab; 
        [SerializeField] public RectTransform _content; 
        public int minItems = 5; 
        public int maxItems = 20;

        void Start()
        {
            int numItems = Random.Range(minItems, maxItems + 1);
            
            for (int i = 0; i < numItems; i++)
            {
                GameObject item = Instantiate(_itemPrefab, _content);

                

                
            }
        }
    }
}