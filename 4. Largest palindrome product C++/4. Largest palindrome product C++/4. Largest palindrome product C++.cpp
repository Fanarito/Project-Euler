// 4. Largest palindrome product C++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <list>
#include <string>
#include <algorithm>
using namespace std;

bool check_if_palindrome(int number) {
	string palin = to_string(number);
	int even = 0;

	if (palin.length() % 2 == 0)
	{
		even = 1;
	}

	for (size_t i = 0; i < palin.length()-even/2; i++)
	{
		if (palin[i] != palin[(palin.length()-1)-i])
		{
			return false;
		}
	}
	return true;
	// Extremely slow compared to the above code
	/*string palin = to_string(number);
	string reversed = palin;
	reverse(reversed.begin(), reversed.end());
	if (palin == reversed)
	{
		return true;
	}
	else
	{
		return false;
	}*/
}

int max(list<size_t> numbers) {
	size_t answer = 0;

	for each (size_t number in numbers)
	{
		if (number > answer)
		{
			answer = number;
		}
	}
	return answer;
}

int palindrome_product(size_t digits) {
	string largest_number_str = "";
	string smallest_number_str = "1";

	for (size_t i = 0; i < digits; i++)
	{
		largest_number_str += "9";

		if (smallest_number_str.length() != digits)
		{
			smallest_number_str += "0";
		}
	}

	size_t largest_number = stoi(largest_number_str);
	size_t smallest_number = stoi(smallest_number_str);
	
	list<size_t> palindromes;

	for (size_t i = largest_number; i >= smallest_number; i--)
	{
		for (size_t x = i; x >= smallest_number; x--)
		{
			int number = i * x;
			
			if (check_if_palindrome(number))
			{
				palindromes.push_back(number);
				cout << to_string(number) + " " + to_string(i) + " " + to_string(x) << endl;
			}
		}
	}

	return max(palindromes);
}



int main()
{
	int digits;
	cin >> digits;
	cout << palindrome_product(digits);
	char c;
	cin >> c;
    return 0;
}

