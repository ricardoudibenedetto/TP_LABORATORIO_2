using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo correo = new Correo();

        /// <summary>
        /// constructor del formulario, instancia el correo.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// cuando se toca el boton agregar instancia un nuevo paquete con los datos ingesados por los inputs del formulario
        /// y lo agrega al correo.
        /// si no los puede agregar porq ya existe lanzara una exception que va a ser manejada por el trycatch.
        /// tambien asocia el metodo paq_informarEstado al evento del paquete.
        /// actualiza el estado de los paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            p.InformarEstado += this.paq_InformaEstado;
            try
            {
                this.correo += p;
            }
            catch (TrackingIdRepetidoException E)
            {
                MessageBox.Show(E.Message);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Metodo que se encarga de limpiar las listas y asignar los paquetes en el estado donde corresponda
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete item in correo.Paquetes)
            {

                if (item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }
                else if (item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }
            }
        }


        /// <summary>
        /// metodo que pide autorizacion al hilo principal y actualiza los estados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// muestra la informacion de de los elementos y guarda en un archivo de texto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectedItem"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (correo != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("entregas");
            }
        }

        /// <summary>
        /// muestra todos los elementos de un correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }


        /// <summary>
        /// cuando el form es cerrado aborta los hilos mediante el metodo finEntrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntrega();
        }
    }
}
