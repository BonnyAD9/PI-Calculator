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
        var num = calcArray[0];

        calcArray[0] = num % 10;
        num = num / 10;
        if (num == 0)
        {
            piDigits[j] = 0;
        }
        else
        {
            piDigits[j] = (byte)(num % 10);
            if (num < 100 && num > 9)
            {
                int k = 1;
                piDigits[j - k] += (byte)(num / 10);
                while (piDigits[j - k] > 9)
                {
                    var n = piDigits[j - k];
                    piDigits[j - k] = (byte)(n % 10);
                    k++;
                    byte b = (byte)(n / 10);
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
