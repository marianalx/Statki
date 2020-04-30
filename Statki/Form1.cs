using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statki
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int index = 1;
            List<Control> controls = this.Controls.OfType<Button>().Cast<Control>().ToList();
            controls.Reverse();
            foreach (var item in controls)
            {
                Button btn = (Button)item;
                btn.Tag = String.Format("BUTTON{0}", index); // ustawiam Tag przycisku wg schematu: BUTTONx, gdzie x to numer przycisku
                btn.Text = index.ToString();
                btn.Click += Btn_Click;  //podpięcie do klikniecia na przycisk metody 
                index++;
            }

            FindShipButtonByTag(101);
        }

        /// <summary>
        /// Pobiera obiekt przycisku matrycy statków na podstawie jego numeru
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private Button FindShipButtonByTag(int number)
        {
            String pattern = String.Format("BUTTON{0}", number);
            var item = this.Controls.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, pattern));
            return (item==null) ? null : (Button)item;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show(btn.Tag.ToString());
        }
    }
}
