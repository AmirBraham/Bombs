using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopNavigator : MonoBehaviour {

    public GameObject Base;
    public GameObject Plane;
    public GameObject DatabaseGameObject;
    public Sprite LockedSprite;
	// Use this for initialization
	void Start () {
        int Group1YPos = 50;
        int Group2YPos = 50;

        DATABASE database = DatabaseGameObject.GetComponent<DATABASE>();
        for (int i = 0; i < database.itemsNames.Length ;i++) {
            
            GameObject item = new GameObject(database.itemsNames[i], typeof(RectTransform), typeof(Image),typeof(Button));
            item.transform.parent = transform;
           // GameObject instItem = Instantiate(item,item.transform.position, Quaternion.identity) as GameObject;
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(50,50);
            item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            item.GetComponent<Image>().sprite = database.inventorySprites[i];

            Texture ballT = database.ballTextures[i];
            Texture BaseT = database.baseTextures[i];
            string itemName = database.itemsNames[i];
            Color itemBallAlbedoColor = database.ballAlbedoColors[i];
            Color itemBaseAlbedoColor = database.baseAlbedoColors[i];
            Texture planeT = database.PlaneTextures[i];

            item.GetComponent<Button>().onClick.AddListener(delegate () { ChooseItem(ballT,BaseT,itemName,itemBallAlbedoColor,itemBaseAlbedoColor,planeT); });
            if(i == 0 ) {
                item.GetComponent<RectTransform>().anchoredPosition = new Vector3(-50, 50);
            } else{
                if(i % 2 == 0) {
                    Group1YPos -= 50;
                    item.GetComponent<RectTransform>().anchoredPosition = new Vector3(-50, Group1YPos);

                } else {
                    if(i == 1) {
                        item.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, 50);

                    } else {
                        Group2YPos -= 50;

                        item.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, Group2YPos);

                    }

                }


            if (PlayerPrefs.GetString(itemName) == "locked")
                {
                    GameObject lockedItem = new GameObject(database.itemsNames[i] + "locked", typeof(RectTransform), typeof(Image));
                    lockedItem.transform.parent = item.transform;
                    lockedItem.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                    lockedItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    lockedItem.GetComponent<Image>().sprite = LockedSprite;
                    lockedItem.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

                }

            }



        }



	}

    public void ChooseItem(Texture ballT,Texture baseTexture,string name,Color ballAlbedoColor,Color baseAlbedoColor,Texture planeT) {
        Debug.Log("Changing item");
        PlayerPrefs.SetString("name", name);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.mainTexture = ballT;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.SetColor("_Color", ballAlbedoColor);
        Base.GetComponent<Renderer>().material.mainTexture = baseTexture;
        Base.GetComponent<Renderer>().material.SetColor("_Color", baseAlbedoColor);
        Plane.GetComponent<Renderer>().material.mainTexture = planeT;

    }
  


}
