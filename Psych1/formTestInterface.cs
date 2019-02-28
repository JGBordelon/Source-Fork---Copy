using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Psych1
{
    public partial class formTestInterface : Form
    {
        Participant p;
        Form currentForm;
        public formTestInterface()
        {
            InitializeComponent();
            p = new Participant();
        }

        private void buttonGoNoGo_Click(object sender, EventArgs e)
        {
            currentForm = new formGoNoGo(p, 'P', 'R', false, 2);
            currentForm.Show();
            
        }

        private void buttonDRHDRL_Click(object sender, EventArgs e)
        {
            currentForm = new formDRHDRL(p);
            currentForm.Show();
            
        }

        private void buttonEfficacyEvaluation_Click(object sender, EventArgs e) {
            currentForm = new formEfficacyEvaluation(new EfficacyEvaluation());
            currentForm.Show();
            
        }

        private void buttonDerivedLinearTraining_Click(object sender, EventArgs e) {
            currentForm = new formCDT(p);
            currentForm.Show();
            
        }

        private void buttonoutputData_Click(object sender, EventArgs e) {
            currentForm = new formOutputData(p);
            currentForm.Show();
        }

        private void buttonGoNoGoDerived_Click(object sender, EventArgs e) {
            currentForm = new formGoNoGo(p, 'O', 'Q', true, 6);
            currentForm.Show();
        }

        private void buttonClosing_Click(object sender, EventArgs e)
        {
            currentForm = new formClosing();
            currentForm.Show();
        }

        private void buttonSorting_Click(object sender, EventArgs e)
        {
            currentForm = new formSorting(p);
            currentForm.Show();
        }

        private void buttonTestDatabase_Click(object sender, EventArgs e)
        {
            Participant p = new Participant();
            DataWriter dw = new DataWriter(p);
            dw.TestSorting();
        }    
    }
}
