using Adobe.Substance;
using Adobe.Substance.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GraphMaterialHandler : MonoBehaviour
{
    public SubstanceGraphSO graphSO;
    protected SubstanceRuntimeGraph runtimeSubstance;

    protected SemaphoreSlim materialLock = new SemaphoreSlim(1);

    private void InstantiateSubstance()
    {
        gameObject.SetActive(false);
        runtimeSubstance = gameObject.AddComponent<SubstanceRuntimeGraph>();
        runtimeSubstance.GraphSO = graphSO;
        gameObject.SetActive(true);
        //Debug.Log("Instantiated");
    }

    private void Awake()
    {
        //InstantiateSubstance();
    }

    private void SetMaterialSettings(Dictionary<string, dynamic> settings)
    {
        foreach (var setting in settings)
        {

            if (setting.Value.GetType() == typeof(float))
                runtimeSubstance.SetInputFloat(setting.Key, setting.Value);
            else if (setting.Value.GetType() == typeof(Color))
                runtimeSubstance.SetInputColor(setting.Key, setting.Value);
            else
                Debug.LogError("Invalid type for setting " + setting.Key);
        }
    }

    public async System.Threading.Tasks.Task<Material> GetMaterial(Dictionary<string, dynamic> inputValues)
    {

        await materialLock.WaitAsync();
        try
        {
            //Debug.Log("we start");
            InstantiateSubstance();
            SetMaterialSettings(inputValues);
            var renderTask = runtimeSubstance.RenderAsync();
            await renderTask;
            return new Material(runtimeSubstance.DefaulMaterial);
        }
        finally
        {
            Destroy(runtimeSubstance);
            runtimeSubstance = null;
            materialLock.Release();
            //Debug.Log("we finish");
        }
    }
}
