using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSkillController : MonoBehaviour
{
    [Header("Skill Settings")]
    public float UltimateCooldown = 30f;
    public float PrimarySkillCooldown = 5f;
    public bool InstantlyCooldown = false;
    public float ProjectileSpeed = 20;
    public float ProjectileRotationSpeed = 200;
    public int NumberOfProjectiles = 5;
    public Transform FirePoint;
    public CooldownManager CooldownManager;
    public List<Skill> Skills = new List<Skill>();
    private AudioSource _audioSource;

    private HomingMissileController _homeHomingMissileController;
    private Dictionary<string, Skill> skillDictionary = new Dictionary<string, Skill>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _homeHomingMissileController = GetComponent<HomingMissileController>();
        foreach (Skill skill in Skills)
        {
            skillDictionary[skill.SkillName] = skill;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var skill in Skills)
        {
            skill.SkillReadyBorder.fillAmount = 1 - CooldownManager.GetCooldownRemaining(skill.SkillName) / skill.CooldownTime;
            skill.BlackFilter.fillAmount = CooldownManager.GetCooldownRemaining(skill.SkillName) / skill.CooldownTime;
        }

        if (Input.GetKeyDown(KeyCode.G)) UseSkill("Ultimate");
        if (Input.GetKeyDown(KeyCode.F)) UseSkill("Primative");
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseSkill("IceBlast");
    }

    public bool UseSkill(string skillName)
    {
        if ((!CooldownManager.IsCooldown(skillName) || InstantlyCooldown == true) && skillDictionary.ContainsKey(skillName))
        {
            Debug.Log($"🌀 Cast {skillName}!");
            if (skillDictionary[skillName].SkillSound != null)
            {
                
            }
            CastSkill(skillName);
            CooldownManager.StartCooldown(skillName, skillDictionary[skillName].CooldownTime);
            return true;
        }

        return false;
    }


    private void CastSkill(string skillName)
    {
        switch (skillName)
        {
            case "Ultimate":
                _homeHomingMissileController.activeUltimate(ProjectileSpeed, ProjectileRotationSpeed,FirePoint, NumberOfProjectiles);
                break;
            case "Primative":
                _homeHomingMissileController.Skill_1(ProjectileSpeed, ProjectileRotationSpeed, FirePoint);
                break;
            default:
                break;
        }
    }
}
