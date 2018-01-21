using UnityEngine;

namespace ZScripts.Map.View
{
    public class MouseClickListener : MonoBehaviour
    {
        public event TileClickHandler TileClicked;
        public event TileClickHandler RightClicked;
        public delegate void ButtonPressHandler();
        public event ButtonPressHandler RightButtonClicked;
        public event ButtonPressHandler LeftButtonClicked;
        public event ButtonPressHandler UpButtonClicked;
        public event ButtonPressHandler DownButtonClicked;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                Vector3 position;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    position = hit.transform.gameObject.transform.parent.gameObject.transform.position;
                    if (TileClicked != null)
                        TileClicked(new IntVector2((int) position.x, (int) position.z));
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                Vector3 position;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    position = hit.transform.gameObject.transform.parent.gameObject.transform.position;
                    if (RightClicked != null)
                        RightClicked(new IntVector2((int) position.x, (int) position.z));
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpButtonClicked();
            }
        
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                DownButtonClicked();
            }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LeftButtonClicked();
            }
        
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RightButtonClicked();
            }
        }
    }
}