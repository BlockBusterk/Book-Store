﻿using BookShopManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Forms
{
    public partial class Form_Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;

        public Form_Dashboard()
        {
            InitializeComponent();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Handle the "Yes" button click
                // Do something here
                this.Dispose();
            }
            else
            {
                // Handle the "No" button click
                // Do something else here
            }
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 20;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 20;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        //private void btnSaleBooks_Click(object sender, EventArgs e)
        //{
        //    moveSidePanel(btnSaleBooks);
        //    UC_Sales us = new UC_Sales();
        //    AddControlsToPanel(us);
        //}

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPurchase);
            UC_PurchaseDetails up = new UC_PurchaseDetails();
            AddControlsToPanel(up);
        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnViewSales);
            UC_ViewSales vs = new UC_ViewSales();
            AddControlsToPanel(vs);
        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    moveSidePanel(btnSettings);
        //}

        private void btnUser_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCustomer);
            UC_Customer cus = new UC_Customer();
            AddControlsToPanel(cus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnChat);
            UC_Chat_Admin cus = new UC_Chat_Admin();
            AddControlsToPanel(cus);
        }

        private void panelSide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
