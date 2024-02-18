using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExtendableDesktopSearch
{
    public partial class SettingsUserControl : UserControl
    {
        
        public SettingsUserControl()
        {
            InitializeComponent();
            
        
        
        }

        private void gbGeneralSettings_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ExtendableDesktopSearch.Properties.Resources.GeneralSettings, new Point(10, 20));
            
        }
    }
}
