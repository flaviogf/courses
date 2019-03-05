import json
from random import randint
from time import sleep

import redis

if __name__ == "__main__":
    fila = redis.Redis(host='queue')

    while True:
        email = fila.lpop('emails')

        if email:
            print('worker', email)
            email = json.loads(email)
            print(f'enviando e-mail {email}')
            sleep(randint(10, 50))
            print(f'e-mail enviado {email}')
