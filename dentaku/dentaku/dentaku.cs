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
		double result = 0;      //計算結果
		string ope = "";        //演算子
		bool signflg = false;   //符号フラグ
		bool opeflg = false;    //演算子判定フラグ
		bool dpflg = false;     //小数点フラグ
		bool eqflg = false;     //イコールフラグ
		bool resultflg = false; //結果フラグ
		bool errorflg = false;  //エラーフラグ

		///イベント///
		//数字入力
		private void buttonnum(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			Input_str = ((Button)sender).Text;
			ope = enzanshi.Text;

			if (!errorflg)
			{
				if (text != "")
				{
					//演算子、またはイコールが入力されているとき
					if (opeflg || eqflg)
					{
						if (opeflg)
						{
							//負数の時
							if (signflg)
							{
								result = double.Parse(text) * -1;
								signflg = true;
								dpflg = false;
								opeflg = false;
								resultflg = true;
								hugou.Text = "";
								textBox1.Text = Input_str;
								return;
							}
							else
							{
								result = double.Parse(text);
								signflg = false;
								dpflg = false;
								opeflg = false;
								resultflg = true;
								textBox1.Text = Input_str;
								return;
							}
						}
						else
						{
							eqflg = false;
							dpflg = false;
							textBox1.Text = Input_str;
							return;
						}
					}
					//テキストボックスに0が表示されているとき
					else if (text == "0")
					{
						textBox1.Text = Input_str;
						return;
					}
					else if(text.Length <13)
					{
						text += Input_str;
						textBox1.Text = text;
						return;
					}
					else
					{
						return;
					}
				}
				else
				{
					textBox1.Text = Input_str;
					return;
				}
			}
		}

		//小数点入力
		private void cmddp_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			ope = enzanshi.Text;

			if (!errorflg)
			{
				if (text != "")
				{
					if (opeflg || eqflg)
					{
						if (opeflg)
						{
							//負数の場合
							if (signflg)
							{
								result = double.Parse(text) * -1;
								signflg = false;
								dpflg = true;
								opeflg = false;
								resultflg = true;
								hugou.Text = "";
								textBox1.Text = "0.";
							}
							else
							{
								result = double.Parse(text);
								dpflg = true;
								opeflg = false;
								resultflg = true;
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
					else if (!dpflg && text.Length < 13)
					{
						text += ".";
						textBox1.Text = text;
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
			else
			{
				return;
			}
		}

		//演算子入力
		private void cmdplus_Click(object sender, EventArgs e)
		{
			Input_str = ((Button)sender).Text;
			string text = textBox1.Text;
			ope = enzanshi.Text;
			eqflg = false;

			if (!errorflg)
			{
				if (text != "")
				{
					////連続で演算子入力
					//if (ope != "")
					//{
					//	//演算処理
					//	calmethod(text);

					//	enzanshi.Text = Input_str;
					//	opeflg = true;
					//	textBox1.Text = result.ToString();
					//	return;
					//}
					//else
					//{
					//	enzanshi.Text = Input_str;
					//	eqflg = false;
					//	opeflg = true;
					//	return;
					//}
					if (!resultflg)
					{
						if (!opeflg)
						{
							enzanshi.Text = Input_str;
							eqflg = false;
							opeflg = true;
							return;
						}
						else
						{
							enzanshi.Text = Input_str;
							return;
						}
					}
					else
					{
						return;
					}
				}
				else
				{
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
			ope = enzanshi.Text;

			if (!errorflg)
			{
				if (text != "")
				{
					if (!eqflg)
					{
						if (ope != "")
						{
							//演算処理へ
							calmethod(text);

							//結果入力
							if (!errorflg)
							{
								textBox1.Text = result.ToString();

								enzanshi.Text = "";
								opeflg = false;
								resultflg = false;
								return;
							}
							else
							{
								return;
							}
						}
						else
						{
							eqflg = true;
							return;
						}
					}
					else
					{
						return;
					}
				}
				else
				{
					textBox1.Text = "0";
					eqflg = true;
					return;
				}
			}
			else
			{
				return;
			}
		}

		//クリア入力
		private void cmdclear_Click(object sender, EventArgs e)
		{
			textBox1.Text = "0";
			enzanshi.Text = "";
			hugou.Text = "";
			Input_str = "";  
			result = 0;     
			ope = "";       
			signflg = false;  
			opeflg = false;   
			dpflg = false;    
			eqflg = false;
			resultflg = false;
			errorflg = false;
			return;
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
				result *= -1;
				signflg = true;
				hugou.Text = "-";
				eqflg = true;
				resultflg = false;
			}
			else
			{
				eqflg = true;
				resultflg = false;
			}

			//桁数チェック処理
			string strNum = result.ToString();
			nodcheck(strNum);

			return;
		}

		//桁数チェック
		private void nodcheck(string strNum)
		{
			if(strNum.Length > 13)
			{
				//桁超えエラー
				textBox1.Text = "E";
				enzanshi.Text = "";
				hugou.Text = "";
				errorflg = true;
				return;
			}
			else
			{
				return;
			}
		}
	}
}

