using System;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SteamKeyGen
{
	// Token: 0x0200000A RID: 10
	public class RandomKeyGenerator
	{
		// Token: 0x17000009 RID: 9
		// (set) Token: 0x06000013 RID: 19 RVA: 0x00002322 File Offset: 0x00000522
		protected internal string KeyLetters
		{
			set
			{
				this.Key_Letters = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (set) Token: 0x06000014 RID: 20 RVA: 0x0000232C File Offset: 0x0000052C
		protected internal string KeyNumbers
		{
			set
			{
				this.Key_Numbers = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00002336 File Offset: 0x00000536
		protected internal int KeyChars
		{
			set
			{
				this.Key_Chars = value;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002340 File Offset: 0x00000540
		public string Generate()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.LettersArray = this.Key_Letters.ToCharArray();
			this.NumbersArray = this.Key_Numbers.ToCharArray();
			int key_Chars = this.Key_Chars;
			checked
			{
				for (int i = 1; i <= key_Chars; i++)
				{
					VBMath.Randomize();
					float num = VBMath.Rnd();
					short num2 = -1;
					bool flag = (int)Math.Round((double)(unchecked(num * 111f))) % 2 == 0;
					if (flag)
					{
						while (num2 < 0)
						{
							num2 = Convert.ToInt16(unchecked((float)this.LettersArray.GetUpperBound(0) * num));
						}
						string text = Conversions.ToString(this.LettersArray[(int)num2]);
						bool flag2 = (int)Math.Round((double)(unchecked((float)num2 * num * 99f))) % 2 != 0;
						if (flag2)
						{
							text = this.LettersArray[(int)num2].ToString();
							text = text.ToUpper();
						}
						stringBuilder.Append(text);
					}
					else
					{
						while (num2 < 0)
						{
							num2 = Convert.ToInt16(unchecked((float)this.NumbersArray.GetUpperBound(0) * num));
						}
						stringBuilder.Append(this.NumbersArray[(int)num2]);
					}
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x04000008 RID: 8
		private string Key_Letters;

		// Token: 0x04000009 RID: 9
		private string Key_Numbers;

		// Token: 0x0400000A RID: 10
		private int Key_Chars;

		// Token: 0x0400000B RID: 11
		private char[] LettersArray;

		// Token: 0x0400000C RID: 12
		private char[] NumbersArray;
	}
}
