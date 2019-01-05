from urllib.parse import parse_qs

my_values = parse_qs('red=5&blue=0&green=', keep_blank_values=True)


def get_first_int(values, key):
    found = values.get(key, [''])
    if found[0]:
        return int(found[0])
    return 0


print(get_first_int(my_values, 'red'))
print(get_first_int(my_values, 'blue'))
print(get_first_int(my_values, 'green'))
