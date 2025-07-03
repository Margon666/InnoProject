using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parameters : MonoBehaviour
{
    public float hp = 1000f;
    public Text healthText;
    public Image fillImage;

    private void Update()
    {
        fillImage.fillAmount = hp / 1000f;
        healthText.text = $"{(int)hp} / {(int)1000}";
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            Debug.Log("Dead");
        }

        Debug.Log(hp);
    }

    public void Heal(float hpHeal)
    {
        hp += hpHeal;
        if (hp > 1000f)
        {
            hp = 1000f;
        }
    }

    IEnumerator AnimHealthChg(float fromHealth, float toHealth)
    {
        float dur = 0.5f;
        float elapsed = 0f;
        while (elapsed < dur)
        {
            elapsed += Time.deltaTime;
            float current = Mathf.Lerp(fromHealth, toHealth, elapsed / dur);
            fillImage.fillAmount = current / 1000;
            healthText.text = $"{(int)current} / {(int)1000}";
            yield return null;
        }

        fillImage.fillAmount = toHealth / 1000;
        healthText.text = $"{(int)toHealth} / {(int)1000}";
    }
}