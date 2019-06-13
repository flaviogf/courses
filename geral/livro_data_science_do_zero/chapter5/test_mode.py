from example01 import mode, num_friends


def test_should_mode_return_100_and_49():
    assert [100, 49] == mode(num_friends)
