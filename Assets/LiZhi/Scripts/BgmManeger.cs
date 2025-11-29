using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BgmManeger : MonoBehaviour
{
    public ItemManager ItemManager;
    public bool changeBgm;
    public AudioSource BgmSource;//÷˜“Ù¿÷
    public AudioSource EndSource;//Ω· ¯“Ù¿÷
    public GameObject EndBgm;
    //public AudioSource NoiseSource;//∞◊‘Î“Ù
    public float Speed;//“Ù¿÷«–ªªÀŸ∂»
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(EndBgm);
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemManager.LightUpNum >= 6||changeBgm)
        {
            BgmSource.volume = Mathf.MoveTowards(BgmSource.volume, 0f, Time.deltaTime * Speed);
            //NoiseSource.volume = Mathf.MoveTowards(NoiseSource.volume, 0f, Time.deltaTime * Speed);
            EndSource.volume = Mathf.MoveTowards(EndSource.volume, 0.2f, Time.deltaTime * Speed);
            //BgmSource.volume -= Time.deltaTime*Speed;
            //NoiseSource.volume -= Time.deltaTime*Speed;
            //EndSource.volume += Time.deltaTime*Speed;
            //BgmSource.volume =0f;
            //NoiseSource.volume = 0f;
            //EndSource.volume = 1f;

            if (!EndSource.isPlaying)
            {
                EndSource.Play();
            }
            //Debug.Log($"µ±«∞“Ù¡ø: {NoiseSource.volume}, Speed: {Speed}");
        }
    }
}
