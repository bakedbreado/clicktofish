using System.Collections;
using TMPro;
using UnityEngine;

public class JitterText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float jitterIntensity = 0.1f;
    public float jitterSpeed = 1.0f;

    void Start()
    {
        StartCoroutine(JitterTextEffect());
    }

    IEnumerator JitterTextEffect()
    {
        TMP_TextInfo textInfo = textMeshPro.textInfo;
        Vector3[] originalVertices = new Vector3[textInfo.characterCount * 4];

        // Store the original vertices to revert to after jittering
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            originalVertices[i * 4 + 0] = vertices[vertexIndex + 0];
            originalVertices[i * 4 + 1] = vertices[vertexIndex + 1];
            originalVertices[i * 4 + 2] = vertices[vertexIndex + 2];
            originalVertices[i * 4 + 3] = vertices[vertexIndex + 3];
        }

        while (true)
        {
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                float offsetX = Mathf.PerlinNoise(Time.time * jitterSpeed + i, 0) * jitterIntensity;
                float offsetY = Mathf.PerlinNoise(0, Time.time * jitterSpeed + i) * jitterIntensity;

                // Apply jitter to each vertex
                vertices[vertexIndex + 0] = originalVertices[i * 4 + 0] + new Vector3(offsetX, offsetY, 0);
                vertices[vertexIndex + 1] = originalVertices[i * 4 + 1] + new Vector3(offsetX, offsetY, 0);
                vertices[vertexIndex + 2] = originalVertices[i * 4 + 2] + new Vector3(offsetX, offsetY, 0);
                vertices[vertexIndex + 3] = originalVertices[i * 4 + 3] + new Vector3(offsetX, offsetY, 0);
            }

            textMeshPro.UpdateVertexData();

            yield return null;
        }
    }
}