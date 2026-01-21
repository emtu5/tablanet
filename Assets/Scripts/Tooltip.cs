using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private TMP_Text tooltipText;
    [SerializeField] private RectTransform background;

    public void ShowTooltip(string tooltipString) {
        gameObject.SetActive(true);
        tooltipText.text = tooltipString;
        Vector2 backgroundSize = tooltipText.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(8, 8);
        background.sizeDelta = backgroundSize + paddingSize;
    }

    public void HideTooltip() {
        Debug.Log("67");
        gameObject.SetActive(false);
    }

    private void Update() {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }

    private void Start() {
        ShowTooltip("hello!");
    }
}
