using UnityEngine;
using UnityEngine.UI;

public class TileViewBehaviour : MonoBehaviour {
	public Sprite redSprite;
	public Sprite greenSprite;
	public Sprite yellowSprite;
	public Sprite blueSprite;
	public Sprite selectedSprite;

	public Image image;
	public Image selected;

	public void SetType(TileType tileType)
	{
		image.color = Color.white;
        
		switch (tileType)
		{
			case TileType.Red:
			{
				image.sprite = redSprite;
				break;
			}
			case TileType.Green:
			{
				image.sprite = greenSprite;
				break;
			}
			case TileType.Yellow:
			{
				image.sprite = yellowSprite;
				break;
			}
			case TileType.Blue:
			{
				image.sprite = blueSprite;
				break;
			}
		}
	}

	public void SetSelected(bool value)
	{
		selected.enabled = value;
	}
}
