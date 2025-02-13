using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickAttack : MonoBehaviour
{
    [SerializeField] private GameObject Joy_Stick;
    [SerializeField] private GameObject Joy_Stick_BG;

    public Vector2 Joy_stick_Vec; 
    private Vector2 Joy_Stick_Touch_Position;
    private Vector2 Joy_Stick_Original_Position; 
    private float Joy_stick_radius;
    // Start is called before the first frame update
    void Start()
    {
        Joy_Stick_Original_Position = Joy_Stick_BG.transform.position;
        Joy_stick_radius = Joy_Stick_BG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    // Update is called once per frame
    public void PointerDown()
    {
        Joy_Stick.transform.position = Input.mousePosition;
        Joy_Stick_BG.transform.position = Input.mousePosition;
        Joy_Stick_Touch_Position = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        Joy_stick_Vec = (dragPos - Joy_Stick_Touch_Position).normalized;

        float Joy_distance = Vector2.Distance(dragPos, Joy_Stick_Touch_Position);

        if (Joy_distance < Joy_stick_radius)
        {
            Joy_Stick.transform.position = dragPos;
        }
        else
        {
            Joy_Stick.transform.position = Joy_Stick_Touch_Position + Joy_stick_Vec * Joy_stick_radius;
        }
    }

    public void PointerUp()
    {
        Joy_stick_Vec = new Vector2(0,0);
        Joy_Stick.transform.position = Joy_Stick_Original_Position;
        Joy_Stick_BG.transform.position = Joy_Stick_Original_Position;
    }
}
