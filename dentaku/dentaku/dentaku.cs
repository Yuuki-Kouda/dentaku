using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentaku
{
	public partial class Dentaku : Form
	{
		public Dentaku()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 変数宣言
		/// </summary>
		string Input_str = "";  //入力数字
		double result = 0;      //計算結果
		string ope = "";        //演算子
		bool opeflg = false;    //演算子判定フラグ
		bool dpflg = false;     //小数点フラグ
		bool eqflg = false;     //イコールフラグ
		bool errorflg = false;  //エラーフラグ
		//enum IsClickButton
		//{
		//	None,
		//	DecimalPoint,
		//	Plus,
		//	Minus,
		//	Prouduct,
		//	Division,
		//	Equal,
		//}

		/// <summary>
		/// 数字クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonnum(object sender, EventArgs e)
		{

			//	string text = textBox1.Text;
			//Input_str = ((Button)sender).Text;

			////演算子、またはイコールが入力されているとき
			//if (opeflg || eqflg)
			//{
			//	//演算子フラグチェック
			//	if (opeflg)
			//	{
			//		HasDecimalPintInput = false;
			//		opeflg = false;
			//		textBox1.Text = Input_str;
			//		return;
			//	}
			//	else
			//	{
			//		eqflg = false;
			//		HasDecimalPintInput = false;
			//		textBox1.Text = Input_str;
			//		return;
			//	}
			//}
			////テキストボックスに0が表示されているとき
			//else if (text == "0")
			//{
			//	textBox1.Text = Input_str;
			//	return;
			//}
			////桁数チェック
			//else if (text.Length < 13)
			//{
			//	text += Input_str;
			//	textBox1.Text = text;
			//	return;
			//}
			//else
			//{
			//	return;
			//}
		}

		/// <summary>
		/// 小数点クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmddp_Click(object sender, EventArgs e)
		{
			//string text = textBox1.Text;

			//if (opeflg || eqflg)
			//{
			//	if (opeflg)
			//	{
			//		result = double.Parse(text);
			//		HasDecimalPintInput = true;
			//		opeflg = false;
			//		textBox1.Text = "0.";
			//	}
			//	else
			//	{
			//		eqflg = false;
			//		HasDecimalPintInput = true;
			//		textBox1.Text = "0.";
			//	}
			//}
			////小数点フラグチェックと桁数チェック
			//else if (!HasDecimalPintInput && text.Length < 13)
			//{
			//	text += ".";
			//	textBox1.Text = text;
			//	HasDecimalPintInput = true;
			//}
			//else
			//{
			//	return;
			//}
		}

		/// <summary>
		/// 演算子クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdplus_Click(object sender, EventArgs e)
		{

			{
			}
			{
				return;
			}
			//string text = textBox1.Text;
			//eqflg = false;

			//if (!opeflg)
			//{
			//	if (operateNumber != "")
			//	{

			//		//演算処理
			//		calmethod(text);

			//		if (!errorflg)
			//		{
			//			operateNumber = ((Button)sender).Text;
			//			eqflg = false;
			//			opeflg = true;
			//			textBox1.Text = result.ToString();
			//			return;
			//		}
			//		else
			//		{
			//			return;
			//		}
			//	}
			//	else
			//	{
			//		operateNumber = ((Button)sender).Text;
			//		result = double.Parse(text);
			//		eqflg = false;
			//		opeflg = true;
			//		return;
			//	}
			//}
			//else
			//{
			//	operateNumber = ((Button)sender).Text;
			//	eqflg = false;
			//	return;
			//}
		}

		/// <summary>
		/// イコールクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdeq_Click(object sender, EventArgs e)
		{


			{
				return;
			}
			//string text = textBox1.Text;

			//if (!hasEqualInput)
			//{
			//	if (operateNumber != "")
			//	{

			//		//演算処理へ
			//		calmethod(text);

			//		//結果入力
			//		if (!errorflg)
			//		{
			//			textBox1.Text = result.ToString();

			//			hasClickedJustBeforeOperationButton = false;
			//			hasEqualInput = true;
			//			operateNumber = "";
			//			return;
			//		}
			//		else
			//		{
			//			return;
			//		}
			//	}
			//	else
			//	{
			//		hasEqualInput = true;
			//		return;
			//	}
			//}
			//else
			//{
			//	return;
			//}
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
			ope = "";
			opeflg = false;
			dpflg = false;
			eqflg = false;
			errorflg = false;
			return;
		}

		/// <summary>
		/// 演算処理
		/// </summary>
		/// <param name="inputStr">入力数字</param>
		//private void calmethod(string inputStr)
		//{
		//	double inputNum = double.Parse(inputStr);

		//	switch (operateNumber)
		//	{
		//		case "+":
		//			result += inputNum;

		//			break;

		//		case "-":
		//			result -= inputNum;

		//			break;

		//		case "*":
		//			result *= inputNum;

		//			break;

		//		case "/":
		//			if (result == 0 || inputNum == 0)
		//			{
		//				result = 0;
		//			}
		//			else
		//			{
		//				result /= inputNum;

		//			}

		//			break;

		//	}

		//	hasEqualInput = true;

		//	//桁数チェック処理
		//	NumberOgDigitChecker();

		//	return;
		//}

		/// <summary>
		///桁数チェック
		/// </summary>
		/// <param name="strNum">出力数値</param>
		private void NumberOgDigitChecker(string resultNumber)
		{
			double inputNum = double.Parse(inputStr);
		/// <summary>
		/// クリックボタン管理
		/// </summary>
		/// <param name="clickButtonText"></param>
		/// <returns>クリックボタン内容</returns>
		//private IsClickButton IsClickedButton(string clickButtonText)
		//{
		//	switch (clickedOperationButton)
		//	{
		//		case "+":
		//			return IsClickButton.Plus;

		//		case "-":
		//			return IsClickButton.Minus;

		//		case "*":
		//			return IsClickButton.Prouduct;

		//		case "/":
		//			return IsClickButton.Division;

		//		default:
		//			return IsClickButton.None;
		//	}
		//}

		/// <summary>
		/// 直前クリックボタン管理
		/// </summary>
		/// <returns></returns>
		//private IsClickButton IsClickedJustBeforeButton()
		//{
		//	switch (clickedOperationButton)
		//	{

		//		case "+":
		//			return IsClickButton.Plus;

		//		case "-":
		//			return IsClickButton.Minus;

		//		case "*":
		//			return IsClickButton.Prouduct;

		//		case "/":
		//			return IsClickButton.Division;

		//		case "=":
		//			return IsClickButton.Equal;

		//		default:
		//			return IsClickButton.None;
		//	}
		//}

		/// <summary>
		/// 数値入力処理
		/// </summary>
		/// <param name="inputNumber"></param>
		private void IsInputNumber(string inputNumber)
		{
			if (textBox1.Text.Length > 13) return;

			switch (ope)
		/// <summary>
		/// 0処理
		/// </summary>
		//private void IsInputZero(string inputZero)
		//{
		//	if (textBox1.Text == "0") return;

		//	//数字入力処理へ
		//	IsInputNumber(inputZero);
		//	return;
		//}
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

			//桁数チェック処理
			nodcheck();

			return;
		}

		/// <summary>
		///桁数チェック
		/// </summary>
		/// <param name="strNum">出力数値</param>
		private void nodcheck()
		{
			if (result.ToString().Length > 13)
			{
				//桁超えエラー
				textBox1.Text = result.ToString().Substring(0, 13);
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

