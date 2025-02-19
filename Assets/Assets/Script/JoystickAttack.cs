using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickAttack : MonoBehaviour
{
    [SerializeField] private GameObject Joy_Stick;
    [SerializeField] private GameObject Joy_Stick_BG;

    public Vector2 Joy_stick_Vec; // 
    private Vector2 Joy_Stick_Touch_Position;
    private Vector2 Joy_Stick_Original_Position; 
    private float Joy_stick_radius;
    // Start is called before the first frame update
    void Start()
    {
        Joy_Stick_Original_Position = Joy_Stick_BG.transform.position;
        Joy_stick_radius = Joy_Stick_BG.GetComponent<RectTransform>().sizeDelta.y / 4;
        Debug.Log(Joy_stick_radius);
    }



    // Update is called once per frame
    public void PointerDown()
    {
        Vector2 inputPosition = Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : Input.mousePosition;
        Joy_Stick.transform.position = inputPosition;
        Joy_Stick_BG.transform.position = inputPosition;
        Joy_Stick_Touch_Position = inputPosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        Joy_stick_Vec = (dragPos - Joy_Stick_Touch_Position).normalized;

        float Joy_distance = Vector2.Distance(dragPos, Joy_Stick_Touch_Position);

        if (Joy_distance < Joy_stick_radius)
        {
            Joy_Stick.transform.position = dragPos; // khi mà khoảng cách bé hơn bán kính thì hand sẽ bằng vị trí kéo 
        }
        else
        {
            Joy_Stick.transform.position = Joy_Stick_Touch_Position + Joy_stick_Vec * Joy_stick_radius; 
            /* 
                khi khoảng cách lớn hơn bán kính tức ngón tay đã ở ngoài joyBG thì để cho hand không bị rơi ra ngoài JoyBG
            thì hand sẽ bằng hướng nhân với bán kính là ra một vector có cùng hướng với joyVec và có cùng độ dài của bán kính, 
            tiếp tục cộng với vector JoyTouch kết quả của phép cộng này là vị trí mới của hand giới hạn trong bán kính tối ra từ vị trí chạm ban đầu 
            */
        }
    }

    public void PointerUp()
    {
        Joy_stick_Vec = new Vector2(0,0);
        Joy_Stick.transform.position = Joy_Stick_Original_Position;
        Joy_Stick_BG.transform.position = Joy_Stick_Original_Position;
    }
}
