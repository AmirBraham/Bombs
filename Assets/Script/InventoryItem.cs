using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem{
    public string name;
    public float price;
    public Sprite InventorySprite;
    public Texture BallTexture;
    public Texture BaseTexture;
    public Color AtmosphereColor;
    public InventoryItem(string name,float price,Sprite InventorySprite,Texture BallTexture,Texture BaseTexture,Color AtmosphereColor) {
        this.name = name;
        this.price = price;
        this.InventorySprite = InventorySprite;
        this.BallTexture = BallTexture;
        this.BaseTexture = BaseTexture;
        this.AtmosphereColor = AtmosphereColor;
    }
}
