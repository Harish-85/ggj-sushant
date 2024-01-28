using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;

    float fadeTime = 1f;
    [SerializeField] CanvasGroup levelSelectionCanvasGroup;
    [SerializeField] RectTransform levelSelectionPanelTransform;

    [SerializeField] CanvasGroup audioSettingsCanvasGroup;
    [SerializeField] RectTransform audioSettingsPanelTransform;

    [SerializeField] CanvasGroup TutorialCanvasGroup;
    [SerializeField] RectTransform TutorialPanelTransform;

    [SerializeField] CanvasGroup LevelScreenCanvasGroup;
    [SerializeField] RectTransform LevelScreenPanelTransform;

    public void OnLevelButtonPressed()
    {
        PanelFadeIn(LevelScreenCanvasGroup, LevelScreenPanelTransform);
    }

    public void OnLevelExitButtonPressed()
    {
        PanelFadeOut(LevelScreenCanvasGroup, LevelScreenPanelTransform);
    }
    public void OnTutorialButtonPressed()
    {
        PanelFadeIn(TutorialCanvasGroup, TutorialPanelTransform);
    }

    public void TutorialExitButtonPressed()
    {
        PanelFadeOut(TutorialCanvasGroup, TutorialPanelTransform);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnAudioSettingsButtonPressed()
    {
        PanelFadeIn(audioSettingsCanvasGroup, audioSettingsPanelTransform);
    }
    public void OnAudioSettingsExitButtonPressed()
    {
        PanelFadeOut(audioSettingsCanvasGroup, audioSettingsPanelTransform);
    }

    void PanelFadeIn(CanvasGroup canvasGroup , RectTransform panelTransform)
    {
        canvasGroup.alpha = 0;
        panelTransform.transform.localPosition = new Vector3 (0, -1000, 0);
        panelTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);

        canvasGroup.DOFade(1,fadeTime);
    }

     void PanelFadeOut(CanvasGroup canvasGroup, RectTransform panelTransform)
    {
        canvasGroup.alpha = 1;
        panelTransform.transform.localPosition = new Vector3(0, 0, 0);
        panelTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InFlash);

        canvasGroup.DOFade(0, fadeTime);
    }

    //UI-Audio Manager communication

    public void ToggleMusic()
    {
        AudioManager._instance.ToggleMusic();
    }

    public void MusicVolume()
    {
        Debug.Log(musicSlider.value);
        AudioManager._instance.MusicVolume(musicSlider.value);
    }


}
