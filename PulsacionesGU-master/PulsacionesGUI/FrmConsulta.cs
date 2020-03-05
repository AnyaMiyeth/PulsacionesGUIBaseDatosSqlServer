using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
namespace PulsacionesGUI
{
    public partial class FrmConsulta : Form
    {
        PersonaService personaService;
        public FrmConsulta()
        {
            personaService = new PersonaService();
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            DtgPersona.DataSource = null;
            DtgPersona.DataSource = personaService.Consultar();
            TxtTotal.Text = personaService.Totalizar().ToString();
            TxtTotalMujeres.Text = personaService.TotalizarMujeres().ToString();
            TxtTotalHombres.Text = personaService.TotalizarHombres().ToString();

        }
    }
}
