using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public int layerCount = 3;
    public int prefabsPerLayer = 10;
    public int prefabCountRandomRange = 1;

    public List<GameObject> backgroundPrefabs;

    public GameObject cameraObject;


    // Start is called before the first frame update
    void Start()
    {
        int zIndex = -16;
        int zIndexChange = -1;

        float colorMult = 0.7f;
        float colorMultChange = -0.1f;

        for (int i = 0; i < layerCount; i++)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "layer" + i;
            gameObject.transform.SetParent(transform);

            ParallaxLayer layer = gameObject.AddComponent<ParallaxLayer>();
            layer.parallaxCoefficient = 0.09f - 0.01f * i;
            layer.cameraGameObject = cameraObject;

            int numPrefabsPerLayer = Random.Range(0, prefabCountRandomRange) + prefabsPerLayer;

            float generalAreaSize = 30;
            float cellSize = generalAreaSize / numPrefabsPerLayer;
            float startX = 0 - cellSize * (numPrefabsPerLayer * 0.5f) + (cellSize * 0.3f * i);

            for (int j = 0; j < prefabsPerLayer; j++)
            {
                GameObject randomPrefab = backgroundPrefabs[Random.Range(0, backgroundPrefabs.Count)];
                GameObject newBackground = Instantiate(randomPrefab);

                Vector3 cellPosition = new Vector3(startX + j * cellSize, 0, 0);

                newBackground.transform.SetParent(layer.transform);
                newBackground.transform.localPosition = cellPosition + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.1f, 1f) + i * 0.2f);

                SpriteRenderer[] spriteRenderers = newBackground.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    Color color = spriteRenderer.color;
                    spriteRenderer.color = new Color(color.r * colorMult, color.g * colorMult, color.b * colorMult, color.a);
                    spriteRenderer.sortingOrder = zIndex;
                }
            }

            gameObject.transform.position = new Vector3(0, 0.33f * i, 0);
            gameObject.transform.localScale = Vector3.one * (1 - i * 0.04f);

            zIndex += zIndexChange;
            colorMult += colorMultChange;
        }
    }
}
