using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
namespace GeoPlot
{
    public partial class Form1 : Form
    {

        StdGrid st = new StdGrid(); // Form having the grid, which contains joint coordinates
        StdMemberIncident st1 = new StdMemberIncident(); // Form having the grid, contains member indences
        Default def = new Default();
        private ThreeDObject TheCube = new ThreeDObject();
        public ThreeDObject TheCubeOriginal = new ThreeDObject();
        public Form1()
        {

            InitializeComponent();
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;           
            def.MdiParent = this;
            def.Show();
            st.MdiParent = this;
            st.Show();
            st.Location = new Point(w-18, 0);
            st1.MdiParent = this;
            st1.Show();
            st1.Location = new Point(w-18, h-96);   
        }
        public void openFile() // to open a staad file
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.CheckFileExists = true;
            filedlg.CheckPathExists = true;
            filedlg.DefaultExt = ".std";
            filedlg.Filter = "STAAD files (*.std)|*.std";
            filedlg.Multiselect = false;
            filedlg.Title = "Import";
            DialogResult dr = filedlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fileName = filedlg.FileName;
                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str == "JOINT COORDINATES") // To print joint coordinates
                    {
                        str = sr.ReadLine();
                        do
                        {
                            
                            string[] rowData = str.Split(new Char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string item in rowData)
                            {
                                string[] rowData1 = item.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                st.dataGridView1.Rows.Add(rowData1);
                                string node = null;
                                double x = 0;
                                double y = 0;
                                double z = 0;
                                node = rowData1[0].ToString();
                                double.TryParse(rowData1[1].ToString(),out x);
                                double.TryParse(rowData1[2].ToString(), out y);
                                double.TryParse(rowData1[3].ToString(), out z);
                                ThreeDPoint point = new ThreeDPoint((float)x, (float)y*-1, (float)z, node);
                                point.Scale(15);
                                point.Translate(new float[] { 150, 150, 0 });
                                def.points.Add(point);
                                def.pointsor = new List<ThreeDPoint>(def.points);
                                
                                
                            }
                            str = sr.ReadLine();
                        } while (str != "MEMBER INCIDENCES");

                        if (str == "MEMBER INCIDENCES") // to print member indences
                        {
                            str = sr.ReadLine();
                            do
                            {
                                string[] rowData = str.Split(new Char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string item in rowData)
                                {
                                    string[] rowData2 = item.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                                    
                                    st1.dataGridView2.Rows.Add(rowData2);
                                    string x = null;
                                    string y = null;
                                    x = rowData2[1].ToString();
                                    y = rowData2[2].ToString();
                                    def.pointmember.Add(new KeyValuePair<string,string>(x, y));
                                    def.pointsmemberOr = new List<KeyValuePair<string, string>>(def.pointmember);
                                }
                                str = sr.ReadLine();
                            } while (str != "MEMBER PROPERTY INDIAN");
                        }
                    }
                }
            }

          }
       
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           openFile();
        }
        private void jointAndMemberToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StdGrid std = new StdGrid();
            std.Show();
        }

        private void rotateLeft_Click_1(object sender, EventArgs e)
        {
            def.rotateLeft();
        }

        private void rotateRight_Click_1(object sender, EventArgs e)
        {
            def.rotateRight();
        }


        private void autoRotate_Click(object sender, EventArgs e)
        {
            
        }

        private void rotateUp_Click(object sender, EventArgs e)
        {
            def.rotateUp();
        }

        private void rotateDown_Click(object sender, EventArgs e)
        {
            def.rotateDown();
        }

        private void leftRotate_Click(object sender, EventArgs e)
        {
            def.leftRotate();
        }

        private void rightRotate_Click(object sender, EventArgs e)
        {
            def.rightRotate();
        }

        private void spinLeft_Click(object sender, EventArgs e)
        {
            def.spinLeft();
        }

        private void spinRight_Click(object sender, EventArgs e)
        {
            def.spinRight();
        }

       
   }
}
