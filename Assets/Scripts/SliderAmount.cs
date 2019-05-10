using System.Globalization;
using TMPro;
using UnityEngine;

public class SliderAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;

    public void ChangeValue(float value)
    {
        amountText.text = value.ToString(CultureInfo.InvariantCulture);
    }
}