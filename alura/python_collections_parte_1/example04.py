from operator import attrgetter

class Account:
    def __init__(self, code, balance):
        self._code = code
        self._balance = balance

    def __repr__(self):
        return f'<Account(code={self._code}, balance={self._balance})>'

    def __lt__(self, other):
        return self._balance < other._balance


if __name__ == '__main__':
    account1 = Account(10, 1000)
    account2 = Account(11, 800)
    account3 = Account(12, 8000)

    print(account1 < account2)
    print(account1 > account2)

    accounts = [account1, account2, account3]

    print(sorted(accounts))
    print(sorted(accounts, reverse=True))
    print(sorted(accounts, key=attrgetter('_code')))
    print(sorted(accounts, key=attrgetter('_code'), reverse=True))
