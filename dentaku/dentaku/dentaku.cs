using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dentaku
{
	public partial class dentaku : Form
	{
		public dentaku()
		{
			InitializeComponent();
		}

		string Input_str = "";  //入力数字
		double result = 0;     //計算結果
		string ope = "";       //演算子
		bool signflg = false;  //符号フラグ
		bool opeflg = false;   //演算子判定フラグ
		bool dpflg = false;    //小数点フラグ
		bool eqflg = false;    //イコールフラグ

		///イベント///
		//数字入力
		private void buttonnum(object sender, EventArgs e)
		{
			
		}

		//小数点入力
		private void cmddp_Click(object sender, EventArgs e)
		{

		}

		//演算子入力
		private void cmdplus_Click(object sender, EventArgs e)
		{
			Input_str = ((Button)sender).Text;
			string inputNum = textBox1.Text;
			ope = enzanshi.Text;

			//連続で演算子入力
			if (ope != "")
			{
				//演算処理
				calmethod(inputNum);

				enzanshi.Text = Input_str;
				opeflg = true;
				return;
			}
			else
			{
				enzanshi.Text = Input_str;
				opeflg = true;
				return;
			}
		}

		//イコール入力
		private void cmdeq_Click(object sender, EventArgs e)
		{

		}

		//クリア入力
		private void cmdclear_Click(object sender, EventArgs e)
		{

		}


		///メソッド///
		//演算処理
		private void calmethod(string inputStr)
		{
			double inputNum = double.Parse(inputStr);

			switch (ope)
			{
				case "+":
					result += inputNum;

					break;

				case "-":
					result -= inputNum;

					break;

				case "*":
					result *= inputNum;

					break;

				case "/":
					result /= inputNum;

					break;

			}

			//結果が負数の場合
			if(result < 0)
			{
				signflg = true;
				hugou.Text = "-";
				return ;
			}
			else
			{
				return ;
			}
		}

	//	//桁数チェック
	//	private bool nodcheck(string strNum)
	//	{
	//		double num = double.Parse(strNum);

	//		if (num.) ;
	//	}
	}
}

