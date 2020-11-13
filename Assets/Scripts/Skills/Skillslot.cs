using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillslot : MonoBehaviour
{
    public Image icon;
    public Image cooldown;
    // distribute from an input manager instead
    public Skill skill;
    public KeyCode hotkey;
    TMPro.TextMeshProUGUI text;

    #region Setup & Callbacks
    [HideInInspector] public int skillID;
    private void Awake()
    {
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        text.enabled = skill;
    }
    private void Start()
    {
        UpdateText(hotkey);
        if (skill)
        {
            UpdateSkill(skill);
        }

        CallbackHandler.instance.upgradeSkill += UpgradeSkill;
    }
    private void OnDestroy()
    {
        CallbackHandler.instance.upgradeSkill -= UpgradeSkill;
    }
    #endregion Setup & Callbacks

    // Update is called once per frame
    void Update()
    {
        if (skill)
        {
            if (Input.GetKeyDown(hotkey))
            {
                if (skill.cooldown <= 0)
                {
                    if (PlayerStats.instance.SpendMana(skill.manaCost))
                       skill.Use();
                }
            }
            skill.UpdateCooldown(Time.deltaTime);
            cooldown.fillAmount = skill.cooldown / skill.maxCooldown;
        }
    }

    void UpdateSkill(Skill _skill)
    {
        icon.sprite = _skill.image;
        text.enabled = skill;
        _skill.cooldown = 0;
    }

    void UpdateText(KeyCode _hotkey)
    {
        switch (_hotkey)
        {
            case KeyCode.Alpha1:
                {
                    text.SetText("1");
                    break;
                }
            case KeyCode.Alpha2:
                {
                    text.SetText("2");
                    break;
                }
            case KeyCode.Alpha3:
                {
                    text.SetText("3");
                    break;
                }
            case KeyCode.Mouse1:
                {
                    text.SetText("R");
                    break;
                }
        }
    }

    public void UpgradeSkill(int _id, UpgradeType _upgrade)
    {
        if (_id == skillID)
        {
            skill.UpgradeSkill(_upgrade);
        }
    }
}
