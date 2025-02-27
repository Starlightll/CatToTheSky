using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public string SkillName;
    public float CooldownTime;
    public Image SkillImage;
    public Image BlackFilter;
    public Image SkillNotReadyBorder;
    public Image SkillReadyBorder;
    public AudioClip SkillSound;
}
