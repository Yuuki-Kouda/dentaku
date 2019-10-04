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

		string Input_str = ""; //入力数字
		string  sign = "";     //符号
		double result = 0;     //計算結果
		string ope = null;     //演算子
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
			string text = textBox1.Text;

			if (opeflg)
			{
				//演算処理

				ope = Input_str;
			}

			else
			{
				enzanshi.Text = Input_str;
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
	}

	///メソッド///
	//演算処理
	private double calmethod(string ope, double inputNum, double result)
	{
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

		return result;

	}

	//桁数チェック
	private bool nodcheck(string strNum)
	{
		double num = double.Parse(strNum);

		if (num.) ;
	}


}

