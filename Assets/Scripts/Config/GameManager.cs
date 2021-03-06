﻿using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static SoundData soundData;
    
    public static bool IsLoaded;
    public static bool AccessibilityMode;

    public static SaveManager SaveManager { get; private set; }

    public static GameData GameData { get; private set; }

    public static PlayerData PlayerData { get; set; }

    public void Awake()
    {
        if (IsLoaded) return;
        BetterStreamingAssets.Initialize();
        GameData = new GameData(this);
        SaveManager = new SaveManager();
        if (SaveManager.SaveExists("save")) 
            SaveManager.Load("save");
        IsLoaded = true;
    }

    public static void New()
    {
        PlayerData = new PlayerData();
        var saveData = new SaveData("save", PlayerData);
        SaveManager.Save(saveData);
    }

    public static void Save()
    {
        var saveData = new SaveData("save", PlayerData);
        SaveManager.Save(saveData);
    }

    public void ChangeAvatar(int avatar)
    {
        PlayerData.SelectedAvatar = avatar;
    }

    public static Sprite GetAvatarImage()
    {
        if(PlayerData.SelectedAvatar == 0)
            return Resources.Load<Sprite>("Illustrations/Characters/PLAYER-H_cenario");
        else
            return Resources.Load<Sprite>("Illustrations/Characters/PLAYER-M_cenario");
    }
}