using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_PORTS_CONTROLLER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                //Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
                if(Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", Microsoft.Win32.RegistryValueKind.DWord))==3){
                    lbl_usb_state.BackColor = Color.Green;
                    lbl_usb_state.ForeColor = Color.White;
                    lbl_usb_state.Text = "On";
                    comboBox1.SelectedItem= "On";
                }
                else
                {
                    lbl_usb_state.BackColor = Color.Red;
                    lbl_usb_state.ForeColor = Color.White;
                    lbl_usb_state.Text = "Off";
                    comboBox1.SelectedItem = "Off";
                } 
            }
            catch (Exception ex) {
                MessageBox.Show(""+ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (comboBox1.Text == "On")
                {
                    Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
                    lbl_usb_state.BackColor = Color.Green;
                    lbl_usb_state.ForeColor = Color.White;
                    lbl_usb_state.Text = "On";
                }
                else
                {
                    Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
                    lbl_usb_state.BackColor = Color.Red;
                    lbl_usb_state.ForeColor = Color.White;
                    lbl_usb_state.Text = "Off";
                }
            }catch(Exception ex)
            {
                MessageBox.Show("This app is require Starting as administrator.\nPlease try to open it with administrator permissions");
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
