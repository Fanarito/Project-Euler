def self_power(number):
    sum = 0
    for x in range(0, number+1):
        sum += x**x
    return sum

print(str(self_power(1000)-1)[-10:])