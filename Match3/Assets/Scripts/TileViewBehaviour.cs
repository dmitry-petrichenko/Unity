using UnityEngine;
using UnityEngine.UI;

public class TileViewBehaviour : MonoBehaviour {
	public Sprite redSprite;
	public Sprite greenSprite;
	public Sprite yellowSprite;
	public Sprite blueSprite;
	public Image selectedImage;

	public Image image;
	public Image selected;

	private Vector2 _scaleValue; 

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
	
	public void SetScale(Vector2 value)
	{
		image.rectTransform.sizeDelta = new Vector2(image.rectTransform.rect.width * value.x,
			image.rectTransform.rect.height * value.y);

		_scaleValue = value;
	}

	public void SetSelected(bool value)
	{
		if (value)
		{
			selected = Instantiate(selectedImage, gameObject.transform);
			selected.rectTransform.sizeDelta = new Vector2(selected.rectTransform.rect.width * 0.4f,
				selected.rectTransform.rect.height * 0.4f);
		}
		else
		{
			if (selected != null)
			{
				Destroy(selected.gameObject);
			}
		}

	}
}
