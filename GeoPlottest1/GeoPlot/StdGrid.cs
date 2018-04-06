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
    public partial class StdGrid : Form
    {
        
        public StdGrid()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string no = dataGridView1.Rows[e.RowIndex].Cells["NodeNo"].Value.ToString();
                string temp = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
                Default obj = (Default)Application.OpenForms["Default"];
                if (obj != null)
                {
                    ThreeDPoint p1 = obj.getXYZ(no);
                    if (temp == "Xcor")
                    {
                        p1.X = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Xcor"].Value);
                    }
                    if (temp == "Ycor")
                    {
                        p1.X = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Ycor"].Value);
                    }
                    if (temp == "Zcor")
                    {
                        p1.X = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Zcor"].Value);
                    }

                    obj.pictureBox1.Invalidate();
                }
            }
        }
    }
}

