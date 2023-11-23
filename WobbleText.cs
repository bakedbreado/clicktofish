using System.Collections;
using TMPro;
using UnityEngine;

public class WobbleText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float wobbleIntensity = 0.1f;
    public float wobbleSpeed = 1.0f;

    void Start()
    {
        StartCoroutine(WobbleTextEffect());
    }

    IEnumerator WobbleTextEffect()
    {
        TMP_TextInfo textInfo = textMeshPro.textInfo;

        while (true)
        {
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                float displacement = Mathf.Sin(Time.time * wobbleSpeed + i) * wobbleIntensity;

                // Apply the displacement to the bottom vertices of the character
                vertices[vertexIndex + 1] += new Vector3(0f, displacement, 0f);
                vertices[vertexIndex + 2] += new Vector3(0f, displacement, 0f);
                vertices[vertexIndex + 3] += new Vector3(0f, displacement, 0f);
                vertices[vertexIndex + 0] += new Vector3(0f, displacement, 0f);
            }

            textMeshPro.UpdateVertexData();

            yield return null;
        }
    }
}