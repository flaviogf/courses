data_science_students = {10, 20, 30}

front_end_students = {20, 40, 50}

print(data_science_students)
print(front_end_students)
print(data_science_students & front_end_students) # {20}
print(data_science_students | front_end_students) # {50, 20, 40, 10, 30}
print(data_science_students ^ front_end_students) # {40, 10, 50, 30}
