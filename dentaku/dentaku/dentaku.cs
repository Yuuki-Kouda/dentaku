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

		//インスタンス生成
		GetSet getSet = new GetSet();

		/// <summary>
		/// 数字クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsClickNumberButton(object sender, EventArgs e)
		{
			//入力数値
			var inputNumber = ((Button)sender).Text;

			//桁チェック
			if (textBox1.Text.Length > 13) return;

			//直前ボタン判定（イコール）
			if (getSet.hasClickedJustBeforeEqualButton)
			{
				textBox1.Text = inputNumber;
				getSet.hasClickedJustBeforeEqualButton = false;
				return;
			}

			//直前ボタン判定（演算子）
			if (getSet.hasClickedJustBeforeOperatorButton)
			{
				//テキストボックス数値を退避
				getSet.resultNumber = double.Parse(textBox1.Text);

				textBox1.Text = inputNumber;
				getSet.hasClickedJustBeforeOperatorButton = false;
				return;
			}

			if (textBox1.Text == "0")
			{
				textBox1.Text = inputNumber;
				return;
			}

			textBox1.Text += inputNumber;
			return;
		}

		/// <summary>
		/// 小数点クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsClickDecimalPointButton(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 13) return;

			//小数点入力済み判定
			if (getSet.hasDecimalPointInputed) return;

			if (getSet.hasClickedJustBeforeOperatorButton)
			{
				textBox1.Text = "0.";
				getSet.hasClickedJustBeforeOperatorButton = false;
				return;
			}

			if (getSet.hasClickedJustBeforeEqualButton)
			{
				textBox1.Text = "0.";
				getSet.hasClickedJustBeforeEqualButton = false;
				return;
			}

			textBox1.Text += ((Button)sender).Text;
			getSet.hasDecimalPointInputed = true;
			return;
		}

		/// <summary>
		/// 演算子クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsClickOperatorButton(object sender, EventArgs e)
		{
			var inputOperatorNumber = ((Button)sender).Text;
			getSet.hasClickedJustBeforeEqualButton = false;

			if (getSet.hasClickedJustBeforeOperatorButton)
			{
				getSet.operatorNumber = inputOperatorNumber;
				return;
			}

			//演算子入力済み判定
			if (getSet.operatorNumber == "")
			{
				getSet.hasClickedJustBeforeOperatorButton = true;
				getSet.operatorNumber = inputOperatorNumber;
				return;
			}

			//演算処理
			Calculation();

			getSet.hasClickedJustBeforeOperatorButton = true;
			textBox1.Text = getSet.resultNumber.ToString();
			getSet.operatorNumber = inputOperatorNumber;
			return;
		}

		/// <summary>
		/// イコールクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsClickEqualButton(object sender, EventArgs e)
		{
			var inputNumber = textBox1.Text;

			if (getSet.hasClickedJustBeforeEqualButton) return;

			if (getSet.operatorNumber == "")
			{
				getSet.hasClickedJustBeforeEqualButton = true;
				return;
			}

			if(getSet.hasClickedJustBeforeOperatorButton)
			{
				getSet.operatorNumber = "";
				getSet.hasClickedJustBeforeOperatorButton = false;
				getSet.hasClickedJustBeforeEqualButton = true;
				return;
			}

			//演算処理へ
			Calculation();

			getSet.hasClickedJustBeforeEqualButton = true;
			getSet.operatorNumber = "";
			textBox1.Text = getSet.resultNumber.ToString();
			getSet.resultNumber = 0;
			return;
		}

		/// <summary>
		/// クリアクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsClickClearButton(object sender, EventArgs e)
		{
			textBox1.Text = "0";
			getSet.resultNumber = 0;
			getSet.operatorNumber = "";
			getSet.hasClickedJustBeforeOperatorButton = false;
			getSet.hasDecimalPointInputed = false;
			getSet.hasClickedJustBeforeEqualButton = false;
			return;
		}

		/// <summary>
		///桁数チェック
		/// </summary>
		/// <param name="strNum">出力数値</param>
		private void NumberOfDigitChecker(string resultNumber)
		{
			if (resultNumber.Length < 13)
			{
				getSet.resultNumber = double.Parse(resultNumber);
				return;
			}

			//桁超え（13桁を超えた後ろの数値は表示しない）
			getSet.resultNumber = double.Parse(resultNumber.Substring(0, 13));
			return;
		}

		/// <summary>
		/// 演算処理
		/// </summary>
		private void Calculation()
		{
			var resultNumber = getSet.resultNumber;

			switch (getSet.operatorNumber)
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

			var resultNumber_Str = resultNumber.ToString();
			//桁数チェック処理
			NumberOfDigitChecker(resultNumber_Str);

			return;
		}
	}
}

