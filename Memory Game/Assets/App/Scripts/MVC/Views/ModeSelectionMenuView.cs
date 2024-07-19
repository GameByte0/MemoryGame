using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeSelectionMenuView : MonoBehaviour
{
    [SerializeField] private ModeSelectionMenuController _controller;

    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private TMP_Dropdown _gameModeDropdown;

    public TMP_Dropdown GameModeDropdown { get => _gameModeDropdown; }
    public TMP_Dropdown DifficultyDropdown { get => _difficultyDropdown; }
}
