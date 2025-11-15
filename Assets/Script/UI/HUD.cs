using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    Text myText;
    Slider mySlider;
    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = NewMonoBehaviourScript.instance.exp;
                float maxExp = NewMonoBehaviourScript.instance.nextExp[NewMonoBehaviourScript.instance.level];

                mySlider.value = curExp / maxExp;
                break;

            case InfoType.Level:
                myText.text = string.Format("Lv. {0:F0}", NewMonoBehaviourScript.instance.level);

                break;

            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", NewMonoBehaviourScript.instance.kill);

                break;

            case InfoType.Time:
                break;
            case InfoType.Health:
                break;
        }
    }
}
