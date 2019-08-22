using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MetroFramework;

namespace SadxAutoSplitFileCreator
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

        }
        string winDir = System.Environment.GetEnvironmentVariable("windir");
        bool s_start;
        bool s_general;
        bool chaos_4;
        bool skychase_1;
        bool skychase_2;
        bool eggh;
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e) // ghetto close
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e) // create file
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "LiveSplit AutoSpliter Script|*.asl";
            saveFileDialog1.Title = "Save AutoSpliter Script";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text + richTextBox2.Text + "\n}");
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e) // writes start code to textbox 1
        {
            
            if (metroCheckBox1.Checked == true)
            {
                s_start = true;
                richTextBox2.Text = "        start\n    {\n     if (current.gamestatus == 0x04 && old.gamestatus == 0x16 && current.level == 0x21 && current.lives == 0x04) //starts timer for big\n    {\n         return true;\n    }\n     else if (current.gamestatus == 0x04 && old.gamestatus == 0x16 && current.level == 0x1A && current.lives == 0x04) //starts timer for sonic tails amy\n    {\n         return true;\n    }\n     else if (current.gamestatus == 0x04 && old.gamestatus == 0x01 && current.level == 0x21 && current.lives == 0x04) //starts time for knux and gamma\n    {\n         return true;\n    }\n    }\n";
            }
            else if (metroCheckBox1.Checked == false)
            {
                s_start = false;
                richTextBox2.Text = richTextBox2.Text.Replace("        start\n    {\n     if (current.gamestatus == 0x04 && old.gamestatus == 0x16 && current.level == 0x21 && current.lives == 0x04) //starts timer for big\n    {\n         return true;\n    }\n     else if (current.gamestatus == 0x04 && old.gamestatus == 0x16 && current.level == 0x1A && current.lives == 0x04) //starts timer for sonic tails amy\n    {\n         return true;\n    }\n     else if (current.gamestatus == 0x04 && old.gamestatus == 0x01 && current.level == 0x21 && current.lives == 0x04) //starts time for knux and gamma\n    {\n         return true;\n    }\n    }\n", "");
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e) //general level finish
        {
            if (metroCheckBox2.Checked == true)
            {
                s_general = true;
                richTextBox2.Text = richTextBox2.Text + "        split\n    {\n     if (current.level != old.level && old.level != 0x14 && old.level != 0x11 && old.level != 0x12 && old.level != 0x24 && old.level != 0x25 && current.character != 0x04 && current.control == 0x00 && current.GameFrames > 0x00) //splits on level finish #exclused chaos 4, chaos 6,egg hornet, sky chase act 1 and sky chase act 2\n    {\n         return true;\n    }\n";
                
            }
            else if (metroCheckBox2.Checked == false)
            {
                s_general = false;
                richTextBox2.Text = richTextBox2.Text.Replace("        split\n    {\n     if (current.level != old.level && old.level != 0x14 && old.level != 0x11 && old.level != 0x12 && old.level != 0x24 && old.level != 0x25 && current.character != 0x04 && current.control == 0x00 && current.GameFrames > 0x00) //splits on level finish #exclused chaos 4, chaos 6,egg hornet, sky chase act 1 and sky chase act 2\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e) // sonic red mountain
        {
            if (metroCheckBox3.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x05 && old.level == 0x05 && current.character == 0x00 && current.control == 0x00 && old.control == 0x01) //splits for sonic's red mountain\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox3.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x05 && old.level == 0x05 && current.character == 0x00 && current.control == 0x00 && old.control == 0x01) //splits for sonic's red mountain\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)//sonic lost world
        {
            if (metroCheckBox4.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x07 && current.character == 0x00 && current.music == 0x4B && old.music == 0xFF) //splits for sonic lost world\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox4.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x07 && current.character == 0x00 && current.music == 0x4B && old.music == 0xFF) //splits for sonic lost world\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e) //sonic chaos 0
        {
            if (metroCheckBox8.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x0F && old.music == 0x4B && current.music == 0xFF) //splits for finshing chaos 0\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox8.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x0F && old.music == 0x4B && current.music == 0xFF) //splits for finshing chaos 0\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox9_CheckedChanged(object sender, EventArgs e) //sonic, knux, tails's chaos 4
        {
            if (metroCheckBox9.Checked == true)
            {
                chaos_4 = true;
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x11 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for tails, sonic and knux's chaos 4 0 health\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox9.Checked == false)
            {
                chaos_4 = false;
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x11 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for tails, sonic and knux's chaos 4 0 health\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox11_CheckedChanged(object sender, EventArgs e) //sonic chaos 6
        {
            if (metroCheckBox11.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x12 && current.bosshealth == 0x00 && old.bosshealth == 0x02 && current.character == 0x00) //splits for sonic's chaos 6 2 health 0 health\n    {\n         return true;\n    }\n";
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x12 && current.bosshealth == 0x00 && old.bosshealth == 0x01 && current.character == 0x00) //splits for sonic's chaos 6 1 health to 0 health\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox11.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x12 && current.bosshealth == 0x00 && old.bosshealth == 0x02 && current.character == 0x00) //splits for sonic's chaos 6 2 health 0 health\n    {\n         return true;\n    }\n", "");
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x12 && current.bosshealth == 0x00 && old.bosshealth == 0x01 && current.character == 0x00) //splits for sonic's chaos 6 1 health to 0 health\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox10_CheckedChanged(object sender, EventArgs e) //sonic egg hornet
        {
            if (metroCheckBox10.Checked == true)
            {
                eggh = true;
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x14 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for tails and sonic's egg hornet 0 health\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox10.Checked == false)
            {
                eggh = false;
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x14 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for tails and sonic's egg hornet 0 health\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox12_CheckedChanged(object sender, EventArgs e) //sonic egg viper
        {
            if (metroCheckBox12.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x16 && current.character == 0x00 && current.control == 0x00 && old.control == 0x01 && current.bosshealth == 0x00) //splits for finishing egg viper\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox12.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x16 && current.character == 0x00 && current.control == 0x00 && old.control == 0x01 && current.bosshealth == 0x00) //splits for finishing egg viper\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox13_CheckedChanged(object sender, EventArgs e) //sonic crystal ring
        {
            if (metroCheckBox13.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x1A && old.crystalring == 0x00 && current.crystalring == 0x01) //splits for getting crystalring\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox13.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x1A && old.crystalring == 0x00 && current.crystalring == 0x01) //splits for getting crystalring\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox14_CheckedChanged(object sender, EventArgs e) //sonic light speed shoes
        {
            if (metroCheckBox14.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x1A && old.lightshoes == 0x00 && current.lightshoes == 0x01) //splits for getting lightshoes\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox14.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x1A && old.lightshoes == 0x00 && current.lightshoes == 0x01) //splits for getting lightshoes\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox15_CheckedChanged(object sender, EventArgs e) // sonic ancient light
        {
            if (metroCheckBox15.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x21 && old.ancientlight == 0x00 && current.ancientlight == 0x01) //splits for ancientlight\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox15.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x21 && old.ancientlight == 0x00 && current.ancientlight == 0x01) //splits for ancientlight\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox16_CheckedChanged(object sender, EventArgs e) //sky chase act 2
        {
            if (metroCheckBox16.Checked == true)
            {
                skychase_2 = true;
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x25 && current.music == 0xFF && current.control == 0x00 && old.level ==0x25 && current.gamestatus == 0x05 && old.gamestatus == 0x0F) //splits for finishing skychaseact2\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox16.Checked == false)
            {
                skychase_2 = false;
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x25 && current.music == 0xFF && current.control == 0x00 && old.level ==0x25 && current.gamestatus == 0x05 && old.gamestatus == 0x0F) //splits for finishing skychaseact2\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e) //sky chase act 1
        {
            if (metroCheckBox7.Checked == true)
            {
                skychase_1 = true;
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x24 && current.music == 0xFF && current.control == 0x00 && old.level ==0x24 && current.gamestatus == 0x05 && old.gamestatus == 0x0F) //splits for finshing skychaseact1\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox7.Checked == false)
            {
                skychase_1 = false;
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x24 && current.music == 0xFF && current.control == 0x00 && old.level ==0x24 && current.gamestatus == 0x05 && old.gamestatus == 0x0F) //splits for finshing skychaseact1\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox17_CheckedChanged(object sender, EventArgs e) //enables super sonic story boss splits
        {
            if (metroCheckBox17.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x13 && current.bosshealth == 0x00 && old.bosshealth == 0x02) // splits for both perfect chaos act 1 and 2\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox17.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x13 && current.bosshealth == 0x00 && old.bosshealth == 0x02) // splits for both perfect chaos act 1 and 2\n    {\n         return true;\n    }\n", "");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s_start == true)
            {
                metroCheckBox1.Checked = true; // sonic
                metroCheckBox5.Checked = true; // tails
                metroCheckBox30.Checked = true; // amy
                metroCheckBox38.Checked = true; // knux
                metroCheckBox20.Checked = true; // big
                metroCheckBox40.Checked = true; // gamma
            }
            if (s_start == false)
            {
                metroCheckBox1.Checked = false; // sonic
                metroCheckBox5.Checked = false; // tails
                metroCheckBox30.Checked = false; // amy
                metroCheckBox38.Checked = false; // knux
                metroCheckBox20.Checked = false; // big
                metroCheckBox40.Checked = false; // gamma
                 
            }
            if (s_general == true)
            {
                metroCheckBox2.Checked = true; // sonic
                metroCheckBox6.Checked = true; // tails
                metroCheckBox31.Checked = true; // amy
                metroCheckBox39.Checked = true; // knux
                metroCheckBox18.Checked = true; // big
                metroCheckBox41.Checked = true; // gamma
               
            }
            if (s_general == false)
            {
                metroCheckBox2.Checked = false; // sonic
                metroCheckBox6.Checked = false; // tails
                metroCheckBox31.Checked = false; // amy
                metroCheckBox39.Checked = false; // knux
                metroCheckBox18.Checked = false; // big
                metroCheckBox41.Checked = false; // gamma
                
            }
            if (chaos_4 == true)
            {
                metroCheckBox9.Checked = true; // sonic
                metroCheckBox24.Checked = true; // tails
                metroCheckBox42.Checked = true; // knux
            }
            if (chaos_4 == false)
            {
                metroCheckBox9.Checked = false; // sonic
                metroCheckBox24.Checked = false; // tails
                metroCheckBox42.Checked = false; // knux
            }
            if (skychase_1 == true)
            {
                metroCheckBox7.Checked = true; // sonic
                metroCheckBox25.Checked = true; // tails
            }
            if (skychase_1 == false)
            {
                metroCheckBox7.Checked = false; // sonic
                metroCheckBox25.Checked = false; // tails
            }
            if (skychase_2 == true)
            {
                metroCheckBox16.Checked = true; // sonic
                metroCheckBox27.Checked = true; // tails
            }
            if (skychase_2 == false)
            {
                metroCheckBox16.Checked = false; // sonic
                metroCheckBox27.Checked = false; // tails
            }
            if (eggh == true)
            {
                metroCheckBox54.Checked = true; 
                metroCheckBox10.Checked = true; // sonic
            }
            if (eggh == false)
            {
                metroCheckBox54.Checked = false; // tails
                metroCheckBox10.Checked = false; // sonic
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)//tails auto start
        {
            if (metroCheckBox5.Checked == true)
            {
                s_start = true;
            }
            else if (metroCheckBox5.Checked == false)
            {
                s_start = false;
            }
        }

        private void metroCheckBox30_CheckedChanged(object sender, EventArgs e)//amy auto start
        {
            if (metroCheckBox30.Checked == true)
            {
                s_start = true;
            }
            else if (metroCheckBox30.Checked == false)
            {
                s_start = false;
            }
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e) // moves textbox2 and metroLabel20 to each page
        {
            metroTabControl1.TabPages[metroTabControl1.SelectedIndex].Controls.Add(richTextBox2);
            metroTabControl1.TabPages[metroTabControl1.SelectedIndex].Controls.Add(metroLabel20);
        }

        private void metroCheckBox24_CheckedChanged(object sender, EventArgs e) // tails chaos 4
        {
            if (metroCheckBox24.Checked == true)
            {
                chaos_4 = true;
            }
            else if (metroCheckBox24.Checked == false)
            {
                chaos_4 = false;
            }
        }

        private void metroCheckBox42_CheckedChanged(object sender, EventArgs e) // knux chaos 4
        {
            if (metroCheckBox42.Checked == true)
            {
                chaos_4 = true;
            }
            else if (metroCheckBox42.Checked == false)
            {
                chaos_4 = false;
            }
        }

        private void metroCheckBox38_CheckedChanged(object sender, EventArgs e) // knux start
        {
            if (metroCheckBox38.Checked == true)
            {
                s_start = true;

            }
            else if (metroCheckBox38.Checked == false)
            {
                s_start = false;
            }
        }

        private void metroCheckBox20_CheckedChanged(object sender, EventArgs e)// big start
        {
            if (metroCheckBox20.Checked == true)
            {
                s_start = true;

            }
            else if (metroCheckBox20.Checked == false)
            {
                s_start = false;
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e) //tails general level finish
        {
            if (metroCheckBox6.Checked == true)
            {
                s_general = true;

            }
            else if (metroCheckBox6.Checked == false)
            {
                s_general = false;
            }
        }

        private void metroCheckBox31_CheckedChanged(object sender, EventArgs e) // amy gen
        {
            if (metroCheckBox31.Checked == true)
            {
                s_general = true;

            }
            else if (metroCheckBox31.Checked == false)
            {
                s_general = false;
            }
        }

        private void metroCheckBox40_CheckedChanged(object sender, EventArgs e)// gamma start
        {
            if (metroCheckBox40.Checked == true)
            {
                s_start = true;

            }
            else if (metroCheckBox40.Checked == false)
            {
                s_start = false;
            }
        }

        private void metroCheckBox48_CheckedChanged(object sender, EventArgs e) //knux chaos 6
        {
            if (metroCheckBox48.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x12 && current.act == 0x01 && current.music == 0x4B && old.music == 0xFF) // splits for knux chaos 6\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox48.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x12 && current.act == 0x01 && current.music == 0x4B && old.music == 0xFF) // splits for knux chaos 6\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox43_CheckedChanged(object sender, EventArgs e) //knux chaos 2
        {
            if (metroCheckBox43.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x10 && current.music == 0x21 && old.music == 0xFF) // splits for knux chaos 2\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox43.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x10 && current.music == 0x21 && old.music == 0xFF) // splits for knux chaos 2\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox47_CheckedChanged(object sender, EventArgs e) // Shovel Claw
        {
            if (metroCheckBox47.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x21 && current.shovelclaw == 0x01 && old.shovelclaw == 0x00) //splits for shovel claw\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox47.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x21 && current.shovelclaw == 0x01 && old.shovelclaw == 0x00) //splits for shovel claw\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox44_CheckedChanged(object sender, EventArgs e) // Fighting Gloves
        {
            if (metroCheckBox44.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x21 && current.fightinggloves == 0x01 && old.fightinggloves == 0x00) //splits for fighting gloves\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox44.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x21 && current.fightinggloves == 0x01 && old.fightinggloves == 0x00) //splits for fighting gloves\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox39_CheckedChanged(object sender, EventArgs e) // knux general
        {
            if (metroCheckBox39.Checked == true)
            {
                s_general = true;

            }
            else if (metroCheckBox39.Checked == false)
            {
                s_general = false;
            }
        }

        private void metroCheckBox19_CheckedChanged(object sender, EventArgs e) // tails sand hill 
        {
            if (metroCheckBox19.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x26 && current.music == 0x5F && old.music == 0xFF)//splits for sand hill\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox19.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x26 && current.music == 0x5F && old.music == 0xFF)//splits for sand hill\n    {\n         return true;\n    }\n", "");
            }
            
        }

        private void metroCheckBox26_CheckedChanged(object sender, EventArgs e) // egg walker
        {
            if (metroCheckBox26.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x15 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for finishing egg walker\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox26.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x15 && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for finishing egg walker\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox23_CheckedChanged(object sender, EventArgs e) // jet anklet
        {
            if (metroCheckBox23.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x1A && current.jetanklet == 0x01 && old.jetanklet == 0x00) //splits for jet anklet\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox23.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x1A && current.jetanklet == 0x01 && old.jetanklet == 0x00) //splits for jet anklet\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox22_CheckedChanged(object sender, EventArgs e) //rythem badge
        {
            if (metroCheckBox22.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x22 && current.rhythmbadge == 0x01 && old.rhythmbadge == 0x00) // splits for rhythm badge\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox22.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x22 && current.rhythmbadge == 0x01 && old.rhythmbadge == 0x00) // splits for rhythm badge\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox25_CheckedChanged(object sender, EventArgs e) //tails sky chase 1
        {
            if (metroCheckBox25.Checked == true)
            {
                skychase_1 = true;
            }
            else if (metroCheckBox25.Checked == false)
            {
                skychase_1 = false;
            }
        }

        private void metroCheckBox27_CheckedChanged(object sender, EventArgs e) //tails sky chase 2
        {
            if (metroCheckBox27.Checked == true)
            {
                skychase_2 = true;
            }
            else if (metroCheckBox27.Checked == false)
            {
                skychase_2 = false;
            }
        }

        private void metroCheckBox33_CheckedChanged(object sender, EventArgs e) // amy zero
        {
            if (metroCheckBox33.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x17 && current.centiseconds == old.centiseconds && current.seconds == old.seconds && current.control == 0x00 && old.control == 0x01 && current.gamestatus == 0x0F && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for finishing zero\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox33.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x17 && current.centiseconds == old.centiseconds && current.seconds == old.seconds && current.control == 0x00 && old.control == 0x01 && current.gamestatus == 0x0F && current.bosshealth == 0x00 && old.bosshealth == 0x01) //splits for finishing zero\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox29_CheckedChanged(object sender, EventArgs e) // Rhythm Badge
        {
            if (metroCheckBox29.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x22 && current.rhythmbadge == 0x01 && old.rhythmbadge == 0x00) // splits for rhythm badge\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox29.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x22 && current.rhythmbadge == 0x01 && old.rhythmbadge == 0x00) // splits for rhythm badge\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox18_CheckedChanged(object sender, EventArgs e)// big general
        {
            if (metroCheckBox18.Checked == true)
            {
                s_general = true;
            }
            else if (metroCheckBox18.Checked == false)
            {
                s_general = false;
            }
        }

        private void metroCheckBox41_CheckedChanged(object sender, EventArgs e)// gamma general 
        {
            if (metroCheckBox41.Checked == true)
            {
                s_general = true;
            }
            else if (metroCheckBox41.Checked == false)
            {
                s_general = false;
            }
        }

        private void metroCheckBox34_CheckedChanged(object sender, EventArgs e) // big twinkle park
        {
            if (metroCheckBox34.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.character == 0x04 && current.music == 0x69 && old.music == 0x2D) //splits for bigs twinkle park\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox34.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("          else if (current.character == 0x04 && current.music == 0x69 && old.music == 0x2D) //splits for bigs twinkle park\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox28_CheckedChanged(object sender, EventArgs e) // big life belt 
        {
            if (metroCheckBox28.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x21 && current.lifebelt == 0x01 && old.lifebelt == 0x00) //splits for getting bigpowerup\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox28.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x21 && current.lifebelt == 0x01 && old.lifebelt == 0x00) //splits for getting bigpowerup\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox32_CheckedChanged(object sender, EventArgs e) // big ice cap
        {
            if (metroCheckBox32.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.character == 0x04 && current.music == 0x35 && old.music == 0x2D) //splits for bigs ice cap\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox32.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.character == 0x04 && current.music == 0x35 && old.music == 0x2D) //splits for bigs ice cap\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox21_CheckedChanged(object sender, EventArgs e) // big emerald coast
        {
            if (metroCheckBox21.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x01 && current.music == 0x1E && old.music == 0x2D) //splits for bigs emerald coast\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox21.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x01 && current.music == 0x1E && old.music == 0x2D) //splits for bigs emerald coast\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox35_CheckedChanged(object sender, EventArgs e) // big hot shelter
        {
            if (metroCheckBox35.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x0C && current.music == 0x4F && old.music == 0x2D) //splits for bigs hot shelter\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox35.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x0C && current.music == 0x4F && old.music == 0x2D) //splits for bigs hot shelter\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox37_CheckedChanged(object sender, EventArgs e) // chaos 6
        {
            if (metroCheckBox37.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x12 && current.character == 0x04 && current.music == 0x4B && old.music == 0xFF) //splits for bigs chaos 6\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox37.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x12 && current.character == 0x04 && current.music == 0x4B && old.music == 0xFF) //splits for bigs chaos 6\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox36_CheckedChanged(object sender, EventArgs e) // bigs touch plane
        {
            if (metroCheckBox36.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x1D && current.control == 0x00 && current.music == 0x5A && old.music == 0xFF) //splits for touch plane\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox36.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x1D && current.control == 0x00 && current.music == 0x5A && old.music == 0xFF) //splits for touch plane\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox52_CheckedChanged(object sender, EventArgs e) // jet booster
        {
            if (metroCheckBox52.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x20 && current.booster == 0x01 && old.booster == 0x00) //splits for jet booster\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox52.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x20 && current.booster == 0x01 && old.booster == 0x00) //splits for jet booster\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox53_CheckedChanged(object sender, EventArgs e) // knux casino
        {
            if (metroCheckBox53.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x09 && current.character == 0x02 && current.music == 0x5F && old.music == 0xFF) //splits for knux casino\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox53.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x09 && current.character == 0x02 && current.music == 0x5F && old.music == 0xFF) //splits for knux casino\n    {\n         return true;\n    }\n", "");
            }
        }

        private void metroCheckBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox54.Checked == true)
            {
                eggh = true;
            }
            else if (metroCheckBox54.Checked == false)
            {
                eggh = false;
            }
        }

        private void metroCheckBox55_CheckedChanged(object sender, EventArgs e) // knux sky deck
        {
            if (metroCheckBox55.Checked == true)
            {
                richTextBox2.Text = richTextBox2.Text + "     else if (current.level == 0x06 && current.act == 0x02 && current.music == 0x5F && old.music == 0xFF) // splits for knux sky deck\n    {\n         return true;\n    }\n";
            }
            else if (metroCheckBox55.Checked == false)
            {
                richTextBox2.Text = richTextBox2.Text.Replace("     else if (current.level == 0x06 && current.act == 0x02 && current.music == 0x5F && old.music == 0xFF) // splits for knux sky deck\n    {\n         return true;\n    }\n", "");
            }
        }
    }
}
