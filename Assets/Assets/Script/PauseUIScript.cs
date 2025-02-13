using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIScript : MonoBehaviour
{
    [SerializeField] private GameObject Pause_Panel;

    [SerializeField] private RectTransform Pause_Button_Rect_Transform, Pause_Rect_Transform;
    [SerializeField] private float Top_Pos_Y, Middle_Pos_Y;
    [SerializeField] private float Tween_Duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonClick()
    {
        Pause_Panel.SetActive(true);
        Time.timeScale = 0;
        PausePanelIntro();

    }

    public async void ResumeButtonClick()
    {
        await PausePanelOutro();
        Pause_Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadScene("UIScene");
        Time.timeScale = 1;
    }

    void PausePanelIntro()
    {
        Pause_Rect_Transform.DOAnchorPosY(Middle_Pos_Y, Tween_Duration).SetUpdate(true);
        Pause_Button_Rect_Transform.DOAnchorPosX(100, Tween_Duration).SetUpdate(true);
    }

    async Task PausePanelOutro()
    {
        await  Pause_Rect_Transform.DOAnchorPosY(Top_Pos_Y, Tween_Duration).SetUpdate(true).AsyncWaitForCompletion();
        Pause_Button_Rect_Transform.DOAnchorPosX(-150, Tween_Duration).SetUpdate(true);
    }
}
