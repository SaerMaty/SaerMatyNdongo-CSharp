using project.entity;
using project.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FrmUser : Form
    {
        private ArticleServiceEntity service = new ArticleServiceEntity();
        public FrmUser()
        {
            InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            service.listerUser(dtgvUser);
        }
        private Utilisateur userSelect = new Utilisateur();
        private void dtgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dtgvUser.Rows.Count - 1 && e.ColumnIndex >= 0 && dtgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DataGridViewRow row = dtgvUser.Rows[e.RowIndex];
                row.Selected = true;
                loadForm(row);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string profil = radProfil1.Text;
            if (radProfil2.Checked)
            {
                profil = radProfil2.Text;
            }
            Utilisateur user = new Utilisateur()
            {

                FullName = txtNom.Text,
                Login = txtLogin.Text,
                Pwd = txtPwd.Text,
                Profil = profil
            };

            service.CreerUser(user);
            service.listerUser(dtgvUser);
            //-------------------

        }

        private void loadForm(DataGridViewRow row)
        {
            userSelect.Id = int.Parse(row.Cells[0].Value.ToString());
            txtNom.Text = row.Cells[1].Value.ToString();
            txtLogin.Text = row.Cells[2].Value.ToString();
            txtPwd.Text = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value.ToString().Trim().CompareTo("Admin") == 0)
            {
                radProfil2.Checked = true;
            }
            else
            {
                radProfil1.Checked = true;
            }
        }

    }
}
