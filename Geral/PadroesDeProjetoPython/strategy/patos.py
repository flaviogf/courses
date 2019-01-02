class FlyBehavior:
    def fly(self):
        pass


class QuackBehavior:
    def quack(self):
        pass


class FlyWings(FlyBehavior):

    def fly(self):
        print("voando")


class Quack(QuackBehavior):

    def quack(self):
        print("quack")


class Duck:
    def __init__(self):
        self.quack_behavior = None
        self.fly_behavior = None

    def perform_fly(self):
        self.fly_behavior.fly()

    def perform_quack(self):
        self.quack_behavior.quack()


class MallardDuck(Duck):
    def __init__(self):
        super().__init__()
        self.fly_behavior = FlyWings()
        self.quack_behavior = Quack()


if __name__ == '__main__':
    def main():
        pato = MallardDuck()
        pato.perform_fly()
        pato.perform_quack()


    main()
