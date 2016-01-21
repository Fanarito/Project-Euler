def palindrome_product(digits):
    largest_number = ""
    smallest_number = "1"
    # Get the largest and smallest numbers with x digits
    for x in range(0, digits):
        largest_number += "9"
        if len(smallest_number) != digits:
            smallest_number += "0"
    largest_number = int(largest_number)
    smallest_number = int(smallest_number)

    list = []
    # Loop down from the largest number to the smallest number
    for x in xrange(largest_number, smallest_number-1, -1):
        # Starts at x to not checking numbers more than ones
        for i in xrange(x, smallest_number-1, -1):
            number = x * i
            if check_if_palindrome(number):
                print number, x, i
                list.append(number)

    return max(list)

def check_if_palindrome(number):
    '''string = str(number)
    even = 0
    if len(string) % 2 == 0:
        even = 1
    for x in range(0, len(string)-even//2):
        if string[x] != string[(len(string)-1)-x]:
            return False
    return True'''
    string = str(number)

    if string == string[::-1]:
        return True
    else:
        return False

import timeit
start = timeit.default_timer()
print(palindrome_product(int(input())))
stop = timeit.default_timer()
print stop - start