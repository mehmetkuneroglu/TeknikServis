﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmGauge : Form
    {
        public FrmGauge()
        {
            InitializeComponent();
        }

        private void FrmGauge_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            arcScaleComponent1.Value += 5;
            arcScaleComponent2.Value += 5;
            labelComponent1.Text = arcScaleComponent2.Value.ToString();
            digitalGauge1.Text = arcScaleComponent2.Value.ToString();
            arcScaleComponent3.Value += 3;
            if (arcScaleComponent1.Value==180)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            arcScaleComponent1.Value -= 5;
            arcScaleComponent2.Value -= 5;
            labelComponent1.Text = arcScaleComponent2.Value.ToString();
            digitalGauge1.Text = arcScaleComponent2.Value.ToString();
            arcScaleComponent3.Value -= 3;

            if (arcScaleComponent1.Value==0)
            {
                timer2.Stop();
                timer1.Start();
            }
        }
    }
}
