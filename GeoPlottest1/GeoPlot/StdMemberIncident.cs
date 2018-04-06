using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeoPlot
{
    public partial class StdMemberIncident : Form
    {
        
        public StdMemberIncident()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                string noKey = dataGridView2.Rows[e.RowIndex].Cells["From"].Value.ToString();
                string noVal = dataGridView2.Rows[e.RowIndex].Cells["To"].Value.ToString();
                string temp = dataGridView2.Columns[e.ColumnIndex].Name.ToString();
                Default st = (Default)Application.OpenForms["Default"];
                if (st != null)
                {
                    KeyValuePair<string, string> kp = st.getKVP(noKey);
                    if (temp == "From")
                    {
                        int fIndex = st.pointmember.IndexOf(kp);                      
                        st.pointmember.Insert(fIndex, new KeyValuePair<string, string>(noKey, noVal));
                        st.pointmember.Remove(kp);
                    }
                    else if (temp == "To")
                    {
                        int fIndex = st.pointmember.IndexOf(kp);                       
                        st.pointmember.Insert(fIndex, new KeyValuePair<string, string>(noKey, noVal));
                        st.pointmember.Remove(kp);
                    }
                    st.pictureBox1.Invalidate();
                }
            }
        }
        
    }
}
