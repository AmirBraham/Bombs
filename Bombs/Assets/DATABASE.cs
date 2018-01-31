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

    private void Start()
    {
        for (int i = 0; i < status.Length;i++) {
            PlayerPrefs.SetString(itemsNames[i],status[i]);
        }
    }
}
