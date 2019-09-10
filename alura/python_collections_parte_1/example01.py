ages = [10, 20, 30]

print(ages)

ages.remove(20)

print(ages)

ages.append(20)

print(ages)

ages.remove(20)
ages.insert(1, 20)

print(ages)

for age in ages:
    print(age)


ages_next_year = [age + 1 for age in ages]

print(ages_next_year)
