using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    //                       Variables Publicas (SerializeField)
    [SerializeField]
    Canvas menuPausaPanel;
    [SerializeField]
    Button btnModoTeclado;
    [SerializeField]
    Button btnModoMicro;
    [SerializeField]
    Dropdown dropdownMicrofonos;
    private bool pausedd=false;
    public List<GameObject> objects=new List<GameObject>();

    bool modoMicro = false; //Ya se comprueba automaticamente cual modo usar, pero por si las dudas, por defecto usaremos ModoTeclado
    string microfonoUsado = "";

              //                 Void Start y Update
    void Start()
    {
        menuPausaPanel.enabled = false; //Oculta menu al empezar
        UIModoTecladoMicrofono();       //Configura el modo de pelea segun si hay algun microfono
        DropdownMicrofonos_Start();     //Carga microfonos al desplegable dropdownMicrofonos
    }
    void Update()
    {   // Abre y cierra el menu con Escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            menuPausaPanel.enabled = !menuPausaPanel.enabled;
            if(pausedd){
                for(int i=0;i<2;i++){
                objects[i].SetActive(true);
                }
                pausedd=false;
            }
            else{
                for(int i=0;i<2;i++){
                objects[i].SetActive(false);
                }
                pausedd=true;
            }
        }
    }
    //                       Funciones de Cada Boton del menu
    public void BtnReanudar_Click()
    {
        menuPausaPanel.enabled = false;
    }
    public void BtnModosToggle_Click()
    {
        if (modoMicro)   //Si apreto ModoTeclado, se cambia a modo micro
        {
            modoMicro = !modoMicro;
            btnModoMicro.enabled = btnModoMicro.enabled;
            btnModoTeclado.enabled = btnModoTeclado.enabled;
        }
    }
    
    public void BtnSalir_Click()
    {
        SceneManager.LoadScene(1);
    }
    public void BtnQuit_Click()
    {
        Application.Quit();
    }
    //Funciones para ocultar o cargar interfaz (vienen en Start)
    private void UIModoTecladoMicrofono()
    {
        List<string> microfonos = EnlistarMicrophonos();
        //Debug.Log(microfonos);
        if (microfonos != null) //Si hay microfono
        {
            if (microfonos[0] != "")
            {
                //Debug.Log(microfonos[0]);

                microfonoUsado = microfonos[0];
                modoMicro = true;
                btnModoMicro.enabled = false;
            }
        }
        else                //Si no hay microfono
        {
            microfonoUsado = "";
            modoMicro = false;
            btnModoTeclado.enabled = false;
        }
    }
    public void DropdownMicrofonos_Start()
    {
        // Fill ports array with COM's Name available
        List<string> ports = EnlistarMicrophonos();
        //clear/remove all option item
        dropdownMicrofonos.options.Clear();
        //fill the dropdown menu OptionData with all COM's Name in ports[]
        foreach (string c in ports)
        {
            dropdownMicrofonos.options.Add(new Dropdown.OptionData() { text = c });
        }
        //this swith from 1 to 0 is only to refresh the visual DdMenu
        //dropdownMicrofonos.value = 1;
        //dropdownMicrofonos.value = 0;
    }


    // Funciones privadas
    public List<string> EnlistarMicrophonos()
    {
        List<string> deviceLista = new List<string>();
        string deviceName;
        int minFreq;
        int maxFreq;
        foreach (var device in Microphone.devices)
        {
            //Debug.Log("Name: " + device);
            deviceName = device;
            Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);
            //Debug.Log("MinFreq: " + minFreq + " |MaxFreq: " + maxFreq);

            deviceLista.Add(deviceName);
        }
        return deviceLista;
    }
    public void IniciarGrabacion()
    {
        if (!Microphone.IsRecording(microfonoUsado))
        {
            Microphone.Start(microfonoUsado, true, 12, 4800);
        }
        else { Debug.Log("Se intentó iniciar una grabacion ya empezada (" + microfonoUsado + ")"); }
    }
    public void TerminarGrabacion()
    {
        if (Microphone.IsRecording(microfonoUsado))
        {
            Microphone.End(microfonoUsado);
        }
        else { Debug.Log("Se intentó terminar una grabacion no empezada (" + microfonoUsado + ")"); }
    }

}
