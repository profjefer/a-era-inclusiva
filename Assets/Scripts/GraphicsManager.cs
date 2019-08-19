using System;
using System.Linq;
using UnityEngine;

public class GraphicsManager
{
    private Resolution _selectedResolution;
    private string _selectedQuality;
    
    public string SelectedQuality
    {
        get { return _selectedQuality; }
        set
        {
            var qualities = QualitySettings.names;
            if (!qualities.Contains(value))
            {
                _selectedQuality = qualities.Last();
                return;
            }
            _selectedQuality = value;
            
            QualitySettings.SetQualityLevel(Array.IndexOf(qualities,_selectedQuality), true);        }
    }

    public Resolution SelectedResolution
    {
        get { return _selectedResolution; }
        set
        {
            _selectedResolution = value;
            Screen.SetResolution(_selectedResolution.width, _selectedResolution.width, Screen.fullScreen);
        }
    }

    public GraphicsManager(SaveData save)
    {
        SelectedResolution = save.Resolution;
        SelectedQuality = save.Quality;
    }


    public GraphicsManager()
    {
        SelectedQuality = QualitySettings.names.Last();
        SelectedResolution = Screen.resolutions.Last();
    }
}