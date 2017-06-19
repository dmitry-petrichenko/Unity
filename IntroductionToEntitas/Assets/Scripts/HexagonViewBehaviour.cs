using UnityEngine;
using UnityEngine.UI;

public class HexagonViewBehaviour :MonoBehaviour
{
    public Image image;

    public Sprite emitSprite;
    public Sprite ricochetSprite;
    public Sprite splitSprite;
    public Sprite endSprite;

    public void SetType(HexagonType hexagonType)
    {
        image.color = Color.white;
        
        switch (hexagonType)
        {
            case HexagonType.Empty:
            {
                image.sprite = null;
                image.color = Color.clear;
                break;
            }
            case HexagonType.Emit:
            {
                image.sprite = emitSprite;
                break;
            }
            case HexagonType.Ricochet:
            {
                image.sprite = ricochetSprite;
                break;
            }
            case HexagonType.Split:
            {
                image.sprite = splitSprite;
                break;
            }
            case HexagonType.Stop:
            {
                image.sprite = endSprite;
                break;
            }
        }
    }
}
        
  