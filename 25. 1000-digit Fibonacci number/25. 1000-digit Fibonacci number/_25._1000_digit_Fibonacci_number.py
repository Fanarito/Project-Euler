def first_fibonacci_by_digits(digits):
    first = 1
    second = 1
    index = 2

    while len(str(second)) < digits:
        fibBuff = second
        second += first
        first = fibBuff
        index += 1
    return index

print(first_fibonacci_by_digits(1000))