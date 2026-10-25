using System.Collections;
using TMPro;
using UnityEngine;
public class MissionUI : MonoBehaviour
{
    [SerializeField] GameObject messagePanel;
    [SerializeField] TMP_Text messageText;
    [SerializeField] float displayTime = 2f;
    Coroutine hideRoutine;
    public void ShowWaveWarning()
    {
        ShowMessage("TOUGH TARGETS INCOMING");
    }
    public void ShowFinalWave()
    {
        ShowMessage("FINAL WAVE");
    }
    void ShowMessage(string message)
    {
        messageText.text = message;
        messagePanel.SetActive(true);
        if (hideRoutine != null)
        {
            StopCoroutine(hideRoutine);
        }
        hideRoutine = StartCoroutine(HideMessageAfterDelay());
    }
    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        messagePanel.SetActive(false);
        hideRoutine = null;
    }
}