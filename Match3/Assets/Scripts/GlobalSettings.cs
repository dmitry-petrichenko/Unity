using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
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

    public int startPositionX { get; private set; }
    public int endPositionX { get; private set; }
    public int startPositionY { get; private set; }
    public int endPositionY { get; private set; }

    public void Initialize()
    {
        int startWidth = 102;
        int startHeight = 102;

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

public enum Days
{
    S3 = 3,
    S5 = 5
}