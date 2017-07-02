using UnityEngine;

[CreateAssetMenu]
public class GlobalSettings : ScriptableObject
{
     public int height = 5;
     public int width = 5;

     public int widthSpacing;
     public int heightSpacing;

     public GameObject backgroundSquarePrefab;
     public GameObject tileViewPrefab;

     public void Initialize()
     {
          int startWidth = 102;
          int startHeight = 102;
          
          var contexts = Contexts.sharedInstance;
          var uiRoot = contexts.game.uiRoot.value;

          var rectTransform = uiRoot.GetComponent<RectTransform>();
          
          var temp = rectTransform.rect.width / width;
          var scale = temp / startWidth;
          widthSpacing = (int)(scale * startWidth);

          temp = rectTransform.rect.height / height;
          scale = temp / startHeight;
          heightSpacing = (int)(scale * startHeight);
     }
}