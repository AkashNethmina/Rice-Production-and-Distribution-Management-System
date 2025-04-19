using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    
    public partial class GovernmentAssistance: UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        public GovernmentAssistance()
        {
            InitializeComponent();
        }

        private void GovernmentAssistance_Load(object sender, EventArgs e)
        {

        }
    }
}
