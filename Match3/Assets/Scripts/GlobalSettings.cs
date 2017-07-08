using System.CodeDom.Compiler;
using UnityEngine;
using UnityEngine.UI;

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
          var aspectRatioFitter = uiRoot.GetComponent<AspectRatioFitter>();

          aspectRatioFitter.aspectRatio = (float)width / (float)height;
               
          var rectTransform = uiRoot.GetComponent<RectTransform>();

          widthSpacing = (int)(rectTransform.rect.width / width);

          heightSpacing = (int) (rectTransform.rect.height / height);

          //Debug.Log(widthSpacing);
          //Debug.Log(aspectRatioFitter.aspectRatio + " " + rectTransform.rect.width + " " + widthSpacing);
     }
}