using UnityEngine;
using UnityEngine.UI;

public class Chair : MonoBehaviour
{
    private Text _botOrHumanText;
    private Button _botOrHuman;
    private GameSettings _setting;
    public bool? amIHuman;

    private void Start()
    {
        _botOrHuman = GameObject.Find("BotOrHuman").GetComponent<Button>();
        _setting = GameObject.Find("Canvas").GetComponent<GameSettings>();
        _botOrHumanText = _botOrHuman.GetComponentInChildren<Text>();
        amIHuman = null;
    }

    public void SelectPlayer()    
    {
        const int numPosition = 5;
        var chairNum = (int)char.GetNumericValue(gameObject.name[numPosition]);
        
        _botOrHumanText.text = (chairNum + 1) + ": ";
        switch (amIHuman)
        {
            case null:
                _botOrHumanText.text += "?";
                break;
            case true:
                _botOrHumanText.text += "Human";
                break;
            default:
                _botOrHumanText.text += "Bot";
                break;
        }

        _setting.currentPlayer = chairNum;
    }
}
