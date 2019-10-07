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

		/// <summary>
		/// 変数宣言
		/// </summary>
		string Input_str = "";  //入力数字
		double hdn_Num = 0;     //隠れ数字
		double result = 0;      //計算結果
		string ope = "";        //演算子
		bool signflg = false;   //符号フラグ
		bool opeflg = false;    //演算子判定フラグ
		bool dpflg = false;     //小数点フラグ
		bool eqflg = false;     //イコールフラグ
		bool resultflg = false; //結果フラグ
		bool errorflg = false;  //エラーフラグ

		/// <summary>
		/// 数字クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonnum(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			Input_str = ((Button)sender).Text;
			ope = enzanshi.Text;

			//エラーチェック
			if (!errorflg)
			{
				//演算子、またはイコールが入力されているとき
				if (opeflg || eqflg)
					{
						//演算子フラグチェック
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
					//桁数チェック
					else if (text.Length < 13)
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
		}

		/// <summary>
		/// 小数点クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmddp_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			ope = enzanshi.Text;

			if (!errorflg)
			{
				if (opeflg || eqflg)
					{
						if (opeflg)
						{
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
					//小数点フラグチェックと桁数チェック
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
				return;
			}
		}

		/// <summary>
		/// 演算子クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdplus_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			//result = double.Parse(text);
			eqflg = false;

			if (!errorflg)
			{
				if (opeflg)
					{
						result = hdn_Num;

						//演算処理
						calmethod(text);

						ope = ((Button)sender).Text;
						result = double.Parse(text);
						eqflg = false;
						opeflg = true;
					}
					else
					{
						ope = ((Button)sender).Text;
						hdn_Num = double.Parse(text);
						eqflg = false;
						opeflg = true;
						return;
					}
					////結果数値フラグチェック
					//if (!resultflg)
					//{
					//	if (!opeflg)
					//	{
					//		enzanshi.Text = Input_str;
					//		eqflg = false;
					//		opeflg = true;
					//		return;
					//	}
					//	else
					//	{
					//		enzanshi.Text = Input_str;
					//		return;
					//	}
					//}
					//else
					//{
					//	return;
					//}
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// イコールクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdeq_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;

			if (!errorflg)
			{
				if (!eqflg)
					{
						if (opeflg)
						{
							//演算処理へ
							calmethod(text);

							//結果入力
							if (!errorflg)
							{
								textBox1.Text = result.ToString();

								opeflg = false;
								resultflg = false;
								eqflg = true;
								return;
							}
							else
							{
								textBox1.Text = result.ToString();
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
				return;
			}
		}

		/// <summary>
		/// クリアクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdclear_Click(object sender, EventArgs e)
		{
			textBox1.Text = "0";
			Input_str = "";
			result = 0;
			hdn_Num = 0;
			ope = "";
			signflg = false;
			opeflg = false;
			dpflg = false;
			eqflg = false;
			resultflg = false;
			errorflg = false;
			return;
		}

		/// <summary>
		/// 演算処理
		/// </summary>
		/// <param name="inputStr">入力数字</param>
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
					if (result == 0 || inputNum == 0)
					{
						result = 0;
					}
					else
					{
						result /= inputNum;

					}

					break;

			}

			eqflg = true;
			resultflg = false;

			//桁数チェック処理
			string strNum = result.ToString();
			nodcheck(strNum);

			return;
		}

		/// <summary>
		///桁数チェック
		/// </summary>
		/// <param name="strNum">出力数値</param>
		private void nodcheck(string strNum)
		{
			if (strNum.Length > 13)
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

