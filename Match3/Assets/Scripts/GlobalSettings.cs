using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class GlobalSettings : ScriptableObject
{
    public Size fieldHeight = Size.SIZE5;
    public Size fieldWidth = Size.SIZE7;

    public int widthSpacing;
    public int heightSpacing;

    public GameObject backgroundSquarePrefab;
    public GameObject tileViewPrefab;

    public int startPositionX { get; private set; }
    public int endPositionX { get; private set; }
    public int startPositionY { get; private set; }
    public int endPositionY { get; private set; }

    public void Initialize()
    {
        int width = (int) fieldWidth;
        int height = (int) fieldHeight;
        var contexts = Contexts.sharedInstance;
        var uiRoot = contexts.game.uiRoot.value;
        var aspectRatioFitter = uiRoot.GetComponent<AspectRatioFitter>();

        aspectRatioFitter.aspectRatio = (float) width / (float) height;

        var rectTransform = uiRoot.GetComponent<RectTransform>();

        widthSpacing = (int) (rectTransform.rect.width / width);

        heightSpacing = (int) (rectTransform.rect.height / height);

        startPositionX = -width / 2;
        endPositionX = width / 2 + 1;
        startPositionY = -height / 2;
        endPositionY = height / 2 + 1;
    }
}

public enum Size
{
    SIZE3 = 3,
    SIZE5 = 5,
    SIZE7 = 7
}