using System;
using System.Linq;

namespace PiCalc;

class PI
{
    private const float multiplier = 3.322f;
    private byte[] piDigits;
    private int[] calcArray;

    public PI(int nOfDigits)
    {
        piDigits = new byte[nOfDigits];
        calcArray = new int[(int)Math.Ceiling(nOfDigits * multiplier)];
        Array.Fill(calcArray, 2);
    }

    private int A(int i)
    {
        return i;
    }

    private int B(int i)
    {
        return (i * 2) + 1;
    }

    private void GetDigit(int j)
    {
        MulTen();
        for (int i = calcArray.Length - 1; i > 0; i--)
        {
            calcArray[i - 1] += (calcArray[i] / B(i)) * A(i);
            calcArray[i] %= B(i);
        }
        string num = calcArray[0].ToString();

        calcArray[0] = int.Parse(num.Last().ToString());
        num = num.Remove(num.Length - 1);
        if (num == "")
        {
            piDigits[j] = 0;
        }
        else
        {
            piDigits[j] = byte.Parse(num.Last().ToString());
            if (num.Length == 2)
            {
                int k = 1;
                piDigits[j - k] += byte.Parse(num.Remove(num.Length - 1));
                while (piDigits[j - k] > 9)
                {
                    string n = piDigits[j - k].ToString();
                    piDigits[j - k] = byte.Parse(n.Last().ToString());
                    k++;
                    byte b = 0;
                    byte.TryParse(n.Remove(n.Length - 1), out b);
                    piDigits[j - k] += b;
                }
            }
        }
    }

    private void MulTen()
    {
        for (int i = 0; i < calcArray.Length; i++)
        {
            calcArray[i] *= 10;
        }
    }

    public byte[] GetPi()
    {
        for (int i = 0; i < piDigits.Length; i++)
        {
            GetDigit(i);
        }
        return piDigits;
    }

}
