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
		/// GetSetクラス
		/// </summary>
		public class GetSet
		{
			string InputNumber = ((Button)sender).Text;
			//

			IsInputNumber(InputNumber);
			return;

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
			//計算結果
			public double resultNumber { get; set; } = 0;
			//演算子
			public string operatorNumber { get; set; } = "";
			//演算子直前押下判定
			public bool hasClickedJustBeforeOperatorButton { get; set; } = false;
			//小数点入力済み判定
			public bool hasDecimalPointInputed { get; set; } = false;
			//イコール直前押下判定
			public bool hasClickedJustBeforeEqualButton { get; set; } = false;
		}

		/// <summary>
		/// 小数点クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmddp_Click(object sender, EventArgs e)
		{
			IsInputDecimalPoint(((Button)sender).Text);
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
		//インスタンス生成
		GetSet getSet = new GetSet();

		/// <summary>
		/// 演算子クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdplus_Click(object sender, EventArgs e)
		{
			string textNumber = textBox1.Text;
			string inputOperatorNumber = ((Button)sender).Text;
			hasEqualInput = false;

			if (!hasClickedJustBeforeOperationButton)
			{
				SetOparator(inputOperatorNumber);
				hasClickedJustBeforeOperationButton = true;
				return;
			}

			if (operateNumber == "")
			{
				SetOparator(inputOperatorNumber);
				SetResultNumber(double.Parse(textNumber));
				return;
			}

			//演算処理
			Calculation();

			textBox1.Text = GetResultNumber().ToString();
			SetOparator(inputOperatorNumber);
			return;
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
			string inputNumber = textBox1.Text;

			if (hasEqualInput) return;

			if (GetOperator() == "")
			{
				hasEqualInput = true;
				return;
			}

			//演算処理へ
			Calculation();

			hasEqualInput = true;
			SetOparator("");
			textBox1.Text = GetResultNumber().ToString();
			return;
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
			SetResultNumber(0);
			SetOparator("");
			hasClickedJustBeforeOperationButton = false;
			hasDecimalPintInput = false;
			hasEqualInput = false;
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
			if (resultNumber.Length < 13)
			{
				SetResultNumber(double.Parse(resultNumber));
				return;
			}

			//桁超え
			SetResultNumber(double.Parse(resultNumber.Substring(0, 13)));
			return;
		}

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

			if (hasEqualInput)
			{
				textBox1.Text = inputNumber;
				hasEqualInput = false;
			}

			if (GetOperator() != "")
			{
				//テキストボックス数値を退避
				SetResultNumber(double.Parse(textBox1.Text));
				hasClickedJustBeforeOperationButton = false;
				return;
			}

			if(textBox1.Text == "0")
			{
				textBox1.Text = inputNumber;
				return;
			}

			textBox1.Text += inputNumber;
			return;
		}

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

		/// <summary>
		/// 小数点処理
		/// </summary>
		/// <param name="inputDesimalPoint"></param>
		private void IsInputDecimalPoint(string inputDesimalPoint)
		{
			if (hasDecimalPintInput) return;

			//数字入力処理へ
			IsInputNumber(inputDesimalPoint);
			hasDecimalPintInput = true;
			return;
		}

		/// <summary>
		/// 演算子set
		/// </summary>
		/// <param name="InputOperator"></param>
		private void SetOparator(string InputOperator)
		{
			operateNumber = InputOperator;
			return;
		}

		/// <summary>
		/// 演算子get
		/// </summary>
		/// <returns></returns>
		private string GetOperator()
		{
			return operateNumber;
		}

		/// <summary>
		/// 計算結果set
		/// </summary>
		/// <param name="outputResultNumber"></param>
		private void SetResultNumber(double outputResultNumber)
		{
			result = outputResultNumber;
			return;
		}

		/// <summary>
		/// 計算結果get
		/// </summary>
		/// <returns></returns>
		private double GetResultNumber()
		{
			return result;
		}
		/// <summary>
		/// 演算処理
		/// </summary>
		private void Calculation()
		{
			double resultNumber = GetResultNumber();

			switch (GetOperator())
			{
				case "+":
					resultNumber += double.Parse(textBox1.Text);

					break;

				case "-":
					resultNumber -= double.Parse(textBox1.Text);

					break;

				case "*":
					resultNumber *= double.Parse(textBox1.Text);

					break;

				case "/":
					if (resultNumber == 0 || double.Parse(textBox1.Text) == 0)
					{
						resultNumber = 0;
					}
					else
					{
						resultNumber /= double.Parse(textBox1.Text);

					}

					break;

			}

			string resultNumber_Str = resultNumber.ToString();
			//桁数チェック処理
			NumberOgDigitChecker(resultNumber_Str);

			return;

		}
	}
}

