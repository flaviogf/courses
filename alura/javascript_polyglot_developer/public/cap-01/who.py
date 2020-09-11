def bmi(weight, height):
    return weight / (height ** 2)

if __name__ == '__main__':
    print bmi(weight=62, height=1.7)
    print bmi(height=1.7, weight=62)
