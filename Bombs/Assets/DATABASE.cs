using UnityEngine;

public class DATABASE : MonoBehaviour {
    public string[] itemsNames;
    public float[] itemsPrices;
    public Sprite[] inventorySprites;
    public Texture[] ballTextures;
    public Texture[] baseTextures;
    public Color[] ballAlbedoColors;
    public Color[] baseAlbedoColors;
    public Texture[] PlaneTextures;
    public string[] status;

    void Start()
    {
        for (int i = 0; i < status.Length;i++) {
            if(!PlayerPrefs.HasKey(itemsNames[i])) {
                PlayerPrefs.SetString(itemsNames[i], status[i]);
            } else{
                status[i] = PlayerPrefs.GetString(itemsNames[i]);
            }
        }
    }

    public void UpdateStatus (int K ) {
        status[K] = "unlocked";
        for (int i = 0; i < status.Length; i++)
        {
            PlayerPrefs.SetString(itemsNames[i], status[i]);
        }
    }
}
