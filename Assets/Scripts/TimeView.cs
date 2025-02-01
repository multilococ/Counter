using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clockText;

    private void Update()
    {
        ShowCurrentTime(_clockText);
    }

    private void ShowCurrentTime(TextMeshProUGUI clockText) 
    {
        float currentTime = Time.time;

        clockText.text = string.Format("{0:0.00}", currentTime);   
    }
}