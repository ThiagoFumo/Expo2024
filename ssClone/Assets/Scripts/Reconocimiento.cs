using UnityEngine;
using System.Diagnostics;

public class Reconocimiento : MonoBehaviour
{
    public void RunPythonScript()
    {
        string ironPythonPath = "/home/barrio/Descargas/ironpython_2.7.12.deb"; // Reemplaza con la ruta al ejecutable de IronPython
        string pythonScriptPath = "/home/barrio/Descargas/ssClone 1/ssClone/Assets/juego.py"; // Reemplaza con la ruta al script de Python

        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = ironPythonPath;
        start.Arguments = pythonScriptPath;
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;

        try
        {
            using (Process process = Process.Start(start))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    UnityEngine.Debug.Log(result);
                }
            }
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError("Error al ejecutar IronPython: " + ex.Message);
        }
    }
}
