using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeanguageSetter : MonoBehaviour
{
    public TextMeshProUGUI play;
    public TextMeshProUGUI warning;
    public TextMeshProUGUI warningText;
    
    public TextMeshProUGUI subs1;
    public TextMeshProUGUI subs2;
    public TextMeshProUGUI subs3;
    public TextMeshProUGUI subs4;
    public TextMeshProUGUI subs5;
    public TextMeshProUGUI subs6;
    public TextMeshProUGUI subs7;

    public TextMeshProUGUI die;
    public TextMeshProUGUI restart;
    public TextMeshProUGUI menu;

    public TextMeshProUGUI thanks;
    public TextMeshProUGUI restart2;
    public TextMeshProUGUI menu2;

    public SubtitleData subtitle1;
    public SubtitleData subtitle2;
    public SubtitleData subtitle3;
    public SubtitleData subtitle4;
    public SubtitleData subtitle5;
    public SubtitleData subtitle6;
    public SubtitleData subtitle7;
    public SubtitleData subtitle8;
    public SubtitleData subtitle9;
    public SubtitleData subtitle10;

    public TextMeshProUGUI task;
    public TextMeshProUGUI door;
    public TextMeshProUGUI pickup;
    public TextMeshProUGUI car;

    public void UpdateTextMenu()
    {
        play.text = LanguageManager.instance.GetText("play");
    }


    public void UpdateText()
    {
        warning.text = LanguageManager.instance.GetText("warning");
        warningText.text = LanguageManager.instance.GetText("warningText");
        subs1.text = LanguageManager.instance.GetText("subs1");
        subs2.text = LanguageManager.instance.GetText("subs2");
        subs3.text = LanguageManager.instance.GetText("subs3");
        subs4.text = LanguageManager.instance.GetText("subs4");
        subs5.text = LanguageManager.instance.GetText("subs5");
        subs6.text = LanguageManager.instance.GetText("subs6");
        subs7.text = LanguageManager.instance.GetText("subs7");
        die.text = LanguageManager.instance.GetText("dead");
        restart.text = LanguageManager.instance.GetText("play_again");
        menu.text = LanguageManager.instance.GetText("return_to_menu");

        subtitle1.subtitleText = LanguageManager.instance.GetText("text02");
        subtitle2.subtitleText = LanguageManager.instance.GetText("text03");
        subtitle3.subtitleText = LanguageManager.instance.GetText("text04");
        subtitle4.subtitleText = LanguageManager.instance.GetText("text05");
        subtitle5.subtitleText = LanguageManager.instance.GetText("text06");
        subtitle6.subtitleText = LanguageManager.instance.GetText("text07");
        subtitle7.subtitleText = LanguageManager.instance.GetText("text08");
        subtitle8.subtitleText = LanguageManager.instance.GetText("text09");
        subtitle9.subtitleText = LanguageManager.instance.GetText("text10");
        subtitle10.subtitleText = LanguageManager.instance.GetText("text11");

        task.text = LanguageManager.instance.GetText("look_for_gas_station");
        door.text = LanguageManager.instance.GetText("press_e_to_open");
        pickup.text = LanguageManager.instance.GetText("press_e_to_pickup");


        thanks.text = LanguageManager.instance.GetText("thanks_for_playing");
        restart2.text = LanguageManager.instance.GetText("play_again");
        menu2.text = LanguageManager.instance.GetText("return_to_menu");

    }
}
