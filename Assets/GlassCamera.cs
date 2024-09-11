using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCamera : MonoBehaviour
{
    public float lupaScale = 2f; // Escala de ampliación
    public float lupaRadius = 0.5f; // Radio de la lupa

    private Camera lupaCamera;
    private RenderTexture lupaTexture;

    private void Start()
    {
        // Crear una cámara dedicada para la lupa
        lupaCamera = gameObject.AddComponent<Camera>();
        lupaCamera.enabled = false;
        lupaCamera.orthographic = true;
        lupaCamera.fieldOfView = 60f;

        // Crear una textura renderizada para la lupa
        lupaTexture = new RenderTexture((int)(Screen.width * lupaRadius), (int)(Screen.height * lupaRadius), 24);
        lupaCamera.targetTexture = lupaTexture;
    }

    private void Update()
    {
        // Posicionar y orientar la cámara de la lupa
        lupaCamera.transform.position = transform.position;
        lupaCamera.transform.rotation = transform.rotation;

        // Establecer el tamaño de la cámara de la lupa
        lupaCamera.orthographicSize = Camera.main.orthographicSize / lupaScale;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Renderizar la textura de la lupa en la imagen final
        Graphics.Blit(lupaTexture, destination);
    }
}