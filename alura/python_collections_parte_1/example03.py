from abc import ABCMeta, abstractclassmethod

class Account(metaclass=ABCMeta):
    def __init__(self, code):
        self._code = code
        self._balance = 0

    def __repr__(self):
        return f'<Account(code={self._code}, balance={self._balance})>'

    def __eq__(self, other):
        return self._code == other._code

    def deposit(self, value):
        self._balance += value

    @abstractclassmethod
    def spend_the_month():
        pass


class SavingsAccount(Account):
    def spend_the_month(self):
        self._balance *= 1.01
        self._balance -= 3


class CheckingAccount(Account):
    def spend_the_month(self):
        self._balance -= 2


if __name__ == '__main__':
    # account_1 = Account(10) TypeError

    account_1 = SavingsAccount(10)
    account_1.deposit(1000)
    account_1.spend_the_month()
    print(account_1)

    account_2 = CheckingAccount(10)
    account_2.deposit(1000)
    account_2.spend_the_month()
    print(account_2)

    print(f'{account_1} == {account_2} -> {account_1 == account_2}')

    accounts = [account_1, account_2]

    for account in accounts:
        account.deposit(500)
        account.spend_the_month()

    for index, account in enumerate(accounts):
        print(f'{index} -> {account}')
