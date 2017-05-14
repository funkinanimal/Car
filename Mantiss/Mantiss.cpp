#include <iostream>
#include <string>
using namespace std;

string fourToHex(string f)
{
	if (f == "0000")
		return "0";
	if (f == "0001")
		return "1";
	if (f == "0010")
		return "2";
	if (f == "0011")
		return "3";
	if (f == "0100")
		return "4";
	if (f == "0101")
		return "5";
	if (f == "0110")
		return "6";
	if (f == "0111")
		return "7";
	if (f == "1000")
		return "8";
	if (f == "1001")
		return "9";
	if (f == "1010")
		return "A";
	if (f == "1011")
		return "B";
	if (f == "1100")
		return "C";
	if (f == "1101")
		return "D";
	if (f == "1110")
		return "E";
	if (f == "1111")
		return "F";

	return "?";
}


string binToDec(string s)
{
	string exit = "(";
	int d = 0;
	for (int n = 0; n < s.length(); n++)
	{
		d += ((int)(s[n]) - 48) * pow(2, s.length() - 1 - n);
	}

	exit += to_string(d) + "d, ";
	string h = "";
	string in = s;
	while (in.length() % 4 != 0)
		in = "0" + in;
	for (int i = 0; i < in.length(); i += 4)
		h += fourToHex(in.substr(i, 4));
	exit += h + ")";
	return exit;
}


string pointBinToDec(string s)
{
	string exit = "(";
	float d = 0;
	for (int n = 0; n < s.length(); n++)
	{
		d += ((int)(s[n]) - 48) * pow(2, (-1 - n));
	}

	exit += to_string(d) + "d, ";
	string h = "0.";
	string in = s;
	while (in.length() % 4 != 0)
		in += "0";
	for (int i = 0; i < in.length(); i += 4)
		h += fourToHex(in.substr(i, 4));
	exit += h + ")";
	return exit;
}


string toBin(unsigned int num)
{
	if (num == 0)
		return "0";

	string ex = "";
	while (num > 0)
	{
		ex = to_string(num % 2) + ex;
		num /= 2;
	}
	return ex;
}


string createOrder(unsigned int num, int size)
{
	string ex = "";

	if (num == 0)
		return "0";

	while (num > 0)
	{
		ex = to_string(num % 2) + ex;
		num /= 2;
	}

	if (ex.length() < size)
	{
		for (int i = 0; i < size - ex.length(); i++)
			ex = "0" + ex;
	}

	return ex;
}


string createMantissa(long double d, int size)
{
	string mant = "";

	d--;
	for (int i = 0; i < size; i++)
	{
		d = abs(d * 2);

		if (d >= 1)
		{
			mant += "1";
			d--;
		}
		else
			mant += "0";
	}

	return mant;
}

void floatToProcess(float f)
{
	int or = 8, mant = 23, size = 127;

	string sign;
	if (f >= 0)
		sign = "0";
	else
		sign = "1";

	int e = 0;
	float norm = abs(f);
	if (f < 1)
	{
		while (norm < 1)
		{
			norm *= 2;
			e--;
		}
	}
	else
	{
		while (norm >= 2)
		{
			norm /= 2;
			e++;
		}
	}
	e += size;

	string order = createOrder(e, or );
	string mantissa = createMantissa(norm, mant);

	cout << endl << "Our program: " << endl;
	cout << "Sign: " << sign << endl;
	cout << "Exponent: " << order << binToDec(order) << endl;
	cout << "Mantissa: " << mantissa << pointBinToDec(mantissa) << endl;

	typedef struct {
		unsigned int mantissa : 23;
		unsigned int exponent : 8;
		unsigned int sign : 1;
	} tFloatStruct;

	tFloatStruct* comp = reinterpret_cast<tFloatStruct*>(&f);

	cout << endl << "In processor:" << endl;
	cout << "Sign: " << toBin(comp->sign) << endl;
	cout << "Exponent: " << toBin(comp->exponent) << endl;
	cout << "Mantissa: " << toBin(comp->mantissa) << endl;
}


void doubleToProcess(double d)
{
	int or = 11, mant = 52, size = 1023;

	string sign;
	if (d >= 0)
		sign = "0";
	else
		sign = "1";

	int e = 0;
	double norm = abs(d);
	if (d < 1)
	{
		while (norm < 1)
		{
			norm *= 2;
			e--;
		}
	}
	else
	{
		while (norm >= 2)
		{
			norm /= 2;
			e++;
		}
	}
	e += size;

	string order = createOrder(e, or );
	string mantissa = createMantissa(norm, mant);

	cout << endl << "Our program: " << endl;
	cout << "Sign: " << sign << endl;
	cout << "Exponent: " << order << binToDec(order) << endl;
	cout << "Mantissa: " << mantissa << pointBinToDec(mantissa) << endl;

	typedef struct {
		unsigned int mantissa_low : 32;
		unsigned int mantissa_high : 20;
		unsigned int exponent : 11;
		unsigned int sign : 1;
	} tDoubleStruct;

	tDoubleStruct* comp = reinterpret_cast<tDoubleStruct*>(&d);

	cout << endl << "In processor:" << endl;
	cout << "Sign: " << toBin(comp->sign) << endl;
	cout << "Exponent: " << toBin(comp->exponent) << endl;
	cout << "Mantissa: " << toBin(comp->mantissa_high) << toBin(comp->mantissa_low) << endl;
}


void longDoubleToProcess(long double ld)
{
	int or = 15, mant = 64, size = 16383;

	string sign;
	if (ld >= 0)
		sign = "0";
	else
		sign = "1";

	long int e = 0;
	long double norm = abs(ld);
	if (ld < 1)
	{
		while (norm < 1)
		{
			norm *= 2;
			e--;
		}
	}
	else
	{
		while (norm >= 2)
		{
			norm /= 2;
			e++;
		}
	}
	e += size;

	string order = createOrder(e, or );
	string mantissa = createMantissa(norm, mant);

	cout << endl << "Our program: " << endl;
	cout << "Sign: " << sign << endl;
	cout << "Exponent: " << order << binToDec(order) << endl;
	cout << "Mantissa: " << mantissa << pointBinToDec(mantissa) << endl;

	typedef struct {
		unsigned int mantissa_low : 32;
		unsigned int mantissa_high : 32;
		unsigned int exponent : 15;
		unsigned int sign : 1;
	} tLongDoubleStruct;

	tLongDoubleStruct* comp = reinterpret_cast<tLongDoubleStruct*>(&ld);

	cout << endl << "In processor:" << endl;
	cout << "Sign: " << toBin(comp->sign) << endl;
	cout << "Exponent: " << toBin(comp->exponent) << endl;
	cout << "Mantissa: " << toBin(comp->mantissa_high) << toBin(comp->mantissa_low) << endl;
}


int ordToDec(string s)
{
	int ans = 0;
	int step = s.length() - 1;
	string now;
	for (int i = 0; i < s.length(); i++)
	{
		now = s[i];
		int q = atoi(now.c_str());
		ans += q * pow(2, step);
		step--;
	}
	return ans;
}


long double mantToDec(string s)
{
	long double ans = 0;
	int step = -1;
	string now;
	for (int i = 0; i < s.length(); i++)
	{
		now = s[i];
		int q = atoi(now.c_str());
		ans += q * pow(2, step);
		step--;
	}
	return ans;
}


void procToFloat()
{
	int or = 8, m = 23, s = 1, size = 127;

	float exit = 0;
	string sign = "";
	while (sign.length() != s)
	{
		cout << "(1 char) Sign: ";
		cin >> sign;
	}
	string ord = "";
	while (ord.length() != or )
	{
		cout << "(8 char) Order: ";
		cin >> ord;
	}
	string mant = "";
	while (mant.length() != m)
	{
		cout << "(23 char) Mantissa: ";
		cin >> mant;
	}

	int e = ordToDec(ord);
	e = e - size;
	float q = mantToDec(mant) + 1;
	float ans = q * pow(2, e);
	if (sign == "1")
		ans = ans - 2 * ans;

	cout << ans << endl;
}


void procToDouble()
{
	int or = 11, m = 52, s = 1, size = 1023;

	double exit = 0;
	string sign = "";
	while (sign.length() != s)
	{
		cout << "(1 char) Sign: ";
		cin >> sign;
	}
	string ord = "";
	while (ord.length() != or )
	{
		cout << "(11 char) Order: ";
		cin >> ord;
	}
	string mant = "";
	while (mant.length() != m)
	{
		cout << "(52 char) Mantissa: ";
		cin >> mant;
	}

	int e = ordToDec(ord);
	e = e - size;
	double q = mantToDec(mant) + 1;
	double ans = q * pow(2, e);
	if (sign == "1")
		ans = ans - 2 * ans;

	cout << ans << endl;
}


void procToLongDouble()
{
	int or = 15, m = 64, s = 1, size = 16383;

	long double exit = 0;
	string sign = "";
	while (sign.length() != s)
	{
		cout << "(1 char) Sign: ";
		cin >> sign;
	}
	string ord = "";
	while (ord.length() != or )
	{
		cout << "(15 char) Order: ";
		cin >> ord;
	}
	string mant = "";
	while (mant.length() != m)
	{
		cout << "(64 char) Mantissa: ";
		cin >> mant;
	}

	int e = ordToDec(ord);
	e = e - size;
	long double q = mantToDec(mant) + 1;
	long double ans = q * pow(2, e);
	if (sign == "1")
		ans = ans - 2 * ans;

	cout << ans << endl;
}


int main()
{
	while (true)
	{
		int q;
		cout << endl << "1 dec to processor 2 processor to dec" << endl;
		cin >> q;
		if (q == 1)
		{
			int n;
			cout << endl << "1-float 2-double 3-long double" << endl;
			cin >> n;
			switch (n)
			{
			case 1:
				float f;
				cin >> f;
				floatToProcess(f);
				break;

			case 2:
				double d;
				cin >> d;
				doubleToProcess(d);
				break;

			case 3:
				long double ld;
				cin >> ld;
				longDoubleToProcess(ld);
				break;
			}
		}
		else if (q == 2)
		{
			int n;
			cout << endl << "1-float 2-double 3-long double" << endl;
			cin >> n;
			switch (n)
			{
			case 1:
				procToFloat();
				break;

			case 2:
				procToDouble();
				break;

			case 3:
				procToLongDouble();
				break;
			}
		}
	}
	system("pause");
	return 0;
}