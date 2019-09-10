class Account:
    def __init__(self, number, balance):
        self.number = number
        self.balance = balance

    def __repr__(self):
        return f'<Account(number={self.number}), balance={self.balance}>'

    def deposit(self, value):
        self.balance += value


account_1 = Account(10, 1000)
account_2 = Account(11, 500)

accounts = [account_1, account_2]

print(accounts)

account_1.deposit(100)

print(accounts)

account_1 = (10, 1000)
account_2 = (11, 500)

accounts = [account_1, account_2]

print(accounts)

def deposit(account, value):
    number, balance = account
    return number, balance + value

account_1 = deposit(account_1, 100)

accounts = [account_1, account_2]

print(accounts)
