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
			Input_str = textBox1.Text;
			string text = ((Button)sender).Text;

			if (Input_str != "")
			{
				//演算子、またはイコールが入力されているとき
				if (opeflg || eqflg)
				{
					if (opeflg)
					{
						//負数の時
						if (signflg)
						{
							result = double.Parse(Input_str) * -1;
							signflg = true;
							dpflg = false;
							hugou.Text = "";
							enzanshi.Text = "";
							textBox1.Text = text;
						}
						else
						{
							result = double.Parse(Input_str);
							signflg = false;
							dpflg = false;
							enzanshi.Text = "";
							textBox1.Text = text;
						}
					}
					else
					{
						eqflg = false;
						dpflg = false;
						textBox1.Text = text;
					}
				}
				//テキストボックスに0が表示されているとき
				else if(Input_str == "0")
				{
					textBox1.Text = text;
				}
				else
				{
					Input_str += text;
					textBox1.Text = Input_str;
				}
			}
			else
			{
				textBox1.Text = text;
			}
			return;
		}

		//小数点入力
		private void cmddp_Click(object sender, EventArgs e)
		{
			Input_str = ((Button)sender).Text;
			string text = textBox1.Text;

			if(text != "")
			{
				if(opeflg || eqflg)
				{
					if(opeflg)
					{
						//負数の場合
						if(signflg)
						{
							result = double.Parse(Input_str) * -1;
							signflg = false;
							dpflg = true;
							hugou.Text = "";
							enzanshi.Text = "";
							textBox1.Text = "0.";
						}
						else
						{
							result = double.Parse(Input_str);
							dpflg = true;
							enzanshi.Text = "";
							textBox1.Text = "0.";
						}
					}
					else
					{
						eqflg = false;
						dpflg = true;
						textBox1.Text = "0.";
					}
				}
				else if(!dpflg)
				{
					text += ".";
					dpflg = true;
				}
				else
				{
					return;
				}
			}
			else
			{
				textBox1.Text = "0.";
				dpflg = true;
			}
		}

		//演算子入力
		private void cmdplus_Click(object sender, EventArgs e)
		{
			Input_str = ((Button)sender).Text;
			string text = textBox1.Text;
			ope = enzanshi.Text;
			eqflg = false;

			if(text != "")
			{
				//連続で演算子入力
				if (ope != "")
				{
					//演算処理
					calmethod(text);

					enzanshi.Text = Input_str;
					opeflg = true;
					textBox1.Text = result.ToString();
					return;
				}
				else
				{
					enzanshi.Text = Input_str;
					opeflg = true;
					return;
				}
			}
			else
			{
				return;
			}
		}

		//イコール入力
		private void cmdeq_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;

			if(text != "")
			{
				if(opeflg)
				{
					
				}
			}

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
				eqflg = true;
			}
			else
			{
				eqflg = true;
			}
			//桁数チェック処理

			return;
		}

	//	//桁数チェック
	//	private bool nodcheck(string strNum)
	//	{
	//		double num = double.Parse(strNum);

	//		if (num.) ;
	//	}
	}
}

