using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ShoeManagement.BLL;
using ShoeManagement.DTO;

namespace ShoeManagement.PL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Shoe> shoes = new ShoeBUS().GetAll();
            dgvShoe.DataSource = shoes;
        }
        private void MainForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
       

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text.Trim());
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = new ShoeBUS().Delete(code);
                if (result)
                {
                    List<Shoe> shoes = new ShoeBUS().GetAll();
                    dgvShoe.DataSource = shoes;
                }
                else
                {
                    MessageBox.Show("SORRY BABEEE !!!");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Shoe> shoes = new ShoeBUS().SearchByName(keyword);
            dgvShoe.DataSource = shoes;
        }

        private void dgvShoe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShoe.SelectedRows.Count > 0)
            {
                int code = int.Parse(dgvShoe.SelectedRows[0].Cells["Code"].Value.ToString());
                Shoe shoe = new ShoeBUS().GetDetails(code);
                if (shoe != null)
                {
                    txtCode.Text = shoe.Code.ToString();
                    txtName.Text = shoe.Name.ToString();
                    txtType.Text = shoe.Type.ToString();
                    txtSize.Text = shoe.Size.ToString();
                    txtPrice.Text = shoe.Price.ToString();
                }    
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text.Trim());
            String name = txtName.Text.Trim();
            String type = txtType.Text.Trim();
            int size = int.Parse(txtSize.Text.Trim());
            int price = int.Parse(txtPrice.Text.Trim());
            Shoe newShoe = new Shoe()
            {
                Code = code,
                Name = name,
                Type = type,
                Size = size,
                Price = price,
            };
            bool result = new ShoeBUS().Update(newShoe);
            if (result)
            {
                List<Shoe> shoes = new ShoeBUS().GetAll();
                dgvShoe.DataSource = shoes;
            }
            else
            {
                MessageBox.Show("SORRY BABEEE !!!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Shoe newShoe = new Shoe()
            {
                Code = 0,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Size = int.Parse(txtSize.Text.Trim()),
                Price = int.Parse(txtPrice.Text.Trim()),
            };
            bool result = new ShoeBUS().AddItem(newShoe);
            if (result)
            {
                List<Shoe> shoes = new ShoeBUS().GetAll();
                dgvShoe.DataSource = shoes;
            }
            else
            {
                MessageBox.Show("SORRY BABEEE !!!");
            }
        }
    }
}
