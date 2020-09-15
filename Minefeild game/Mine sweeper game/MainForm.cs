/*
 * Created by SharpDevelop.
 * User: Salman-pc
 * Date: 14/09/2020
 * Time: 14:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * // TODO : Create game interface
 *
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mine_sweeper_game
{
	/// <summary>
	/// Simple mine sweeper game created using windows form
	/// </summary>
	public partial class MainForm : Form
	{
		List<string> MineSweep =  new List<string>(){
			"a","a","b","b","c","c",
			"d","d","e","e","f","f",
			"g","g","h","h","i","i",
			"j","j","k","k","l","l",
			"m","m","r","r","r","r",
			"3","3","4","4","5","5"
		};
		int Count = 0;
		public MainForm()
		{
			InitializeComponent();
			ShowRandom();
			
		}
		private void ShowRandom()
		{
			Label label;
			int RanNum;
			Random random = new Random();
			for(int i = 0;i < tableLayoutPanel1.Controls.Count;i++)
			{
				if(tableLayoutPanel1.Controls[i] is Label)
					label =  (Label)tableLayoutPanel1.Controls[i];
				else
					continue;
				
				RanNum = random.Next(0,MineSweep.Count);
				label.Text =  MineSweep[RanNum];

				
				MineSweep.RemoveAt(RanNum);
			}
		}
		
		private void ShowRight()
		{
			Label label;
			for(int i = 0;i< tableLayoutPanel1.Controls.Count;i++){
				if(tableLayoutPanel1.Controls[i] is Label)
					label = (Label)tableLayoutPanel1.Controls[i];
				else
					continue;
				
				if(label.Text == "r"){
					label.ForeColor = Color.Black;
					label.BackColor = Color.Red;
				}
				else{
					label.ForeColor = Color.Green;
					label.BackColor = Color.Green;
				}
				
				
			}
			
		}
		void LabelClick(object sender, EventArgs e)
		{
			
			Label label =  sender as Label;
			label.ForeColor =  Color.Black;
			if(label.Text == "r"){
				label.BackColor = Color.Red;
				label.ForeColor = Color.Black;
				MessageBox.Show("You just killed by mine explosion","You Death",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
				MessageBox.Show("if you want to restart just reopen this game");
				ShowRight();
			}else{
				label.BackColor = Color.Green;
				label.ForeColor = Color.Green;
				Count++;
				if(Count ==  32){
					MessageBox.Show("you just pass the minefeild safely","Congratulation");
					MessageBox.Show("if you want to restart just reopen this game");
					ShowRight();
				}
			}
				
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			MessageBox.Show(Count.ToString());
		}
	}
}
