using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Rendering;

public class ApplicationController : Singleton<ApplicationController>
{

    EntityManager eM;
    Entity GiordarnoBruno;
    RenderMesh gbRenderMesh;

    public GameObject StartScreen;

    //public GameObject ButtonPannel;
    public List<Texture> overlayTextures = new List<Texture>();
    //public List<GameObject> buttons = new List<GameObject>();
    public int count = 0;
    bool switchingOverlay;
    // Start is called before the first frame update
    void Start()
    {
        eM = World.Active.EntityManager;
        NativeArray<Entity> entities = eM.GetAllEntities();
        for (int i = 0; i < entities.Length; i++)
        {
            if (eM.Debug.GetEntityInfo(entities[i]).ToLower().Contains("bruno"))
            {
                GiordarnoBruno = entities[i];
            }

        }
        entities.Dispose();

        //// Assaign images to buttons
        //for (int i = 0; i < buttons.Count; i++)
        //{
        //    buttons[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", overlayTextures[i]);
        //}


        //StartCoroutine(DelayButtonPannel());


        StartCoroutine(StartScene());
        SwitchOverlay("Button_Reset");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ApplyViz("wac_dem_slope");
        }

        if (Input.GetAxis("XRI_Left_Trigger") > 0.9f && !switchingOverlay || Input.GetAxis("XRI_Right_Trigger") > 0.9f && !switchingOverlay)
        {

            StartCoroutine(SwitchOverlay2(count));
            switchingOverlay = true;
        }


    }


    public void SwitchOverlay(string overlay)
    {
        RenderMesh gbRenderMesh = eM.GetSharedComponentData<RenderMesh>(GiordarnoBruno);
        Mesh gbMesh = gbRenderMesh.mesh;
        Material _material = gbRenderMesh.material;
        Texture materialTexture;

        switch (overlay)
        {
            case "Button_1":
                //Debug.LogError("Should be switching to:" + overlay);
                materialTexture = gbRenderMesh.material.mainTexture = overlayTextures[0];
                _material.SetTexture("_OverlayMap", materialTexture);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;

            case "Button_2":
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[1]);
                //_material.shaderKeywords.SetValue("_Fill",)
                _material.SetInt("_Lines", 0);
                _material.SetFloat("_Fill", 0.5f);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;

            case "Button_3":
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[2]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;

            case "Button_4":
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[3]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;

            case "Button_5":
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[4]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;
            case "Button_Reset":
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", null);
                _material.SetFloat("_Fill", 0);
                _material.SetInt("_Lines", 0);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                break;
            default:
                Debug.LogError("You Goofed");

                break;
        }
    }

    IEnumerator SwitchOverlay2(int clickCount)
    {
        RenderMesh gbRenderMesh = eM.GetSharedComponentData<RenderMesh>(GiordarnoBruno);
        Mesh gbMesh = gbRenderMesh.mesh;
        Material _material = gbRenderMesh.material;
        Texture materialTexture;

        switch (clickCount)
        {
            case 0:
                //Debug.LogError("Should be switching to:" + overlay);
                materialTexture = gbRenderMesh.material.mainTexture = overlayTextures[0];
                _material.SetTexture("_OverlayMap", materialTexture);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count += 1;

                break;

            case 1:
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[1]);
                //_material.shaderKeywords.SetValue("_Fill",)
                _material.SetInt("_Lines", 0);
                _material.SetFloat("_Fill", 0.5f);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count += 1;

                break;

            case 2:
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[2]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count += 1;

                break;

            case 3:
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[3]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count += 1;

                break;

            case 4:
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", overlayTextures[4]);
                _material.SetFloat("_Fill", 0.5f);
                _material.SetInt("_Lines", 2);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count += 1;
                break;
            case 5:
                //Debug.LogError("Should be switching to:" + overlay);
                _material.SetTexture("_OverlayMap", null);
                _material.SetFloat("_Fill", 0);
                _material.SetInt("_Lines", 0);

                eM.SetSharedComponentData(GiordarnoBruno, new RenderMesh
                {
                    mesh = gbRenderMesh.mesh,
                    material = _material
                });
                count = 0;
                break;
            default:
                Debug.LogError("You Goofed");

                break;

        }
        yield return new WaitForSeconds(0.25f);
        switchingOverlay = false;

    }

    //IEnumerator DelayButtonPannel()
    //{
    //    ButtonPannel.SetActive(false);
    //    yield return new WaitForSeconds(10);
    //    StartScreen.SetActive(false);
    //    ButtonPannel.SetActive(true);
    //}


    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(10);
        StartScreen.SetActive(false);
    }



}
