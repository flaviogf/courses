import unittest

from bs4 import BeautifulSoup

from flaskblog import app


class AppTests(unittest.TestCase):
    def setUp(self):
        self._client = app.test_client()

    def test_should_get_home_return_status_code_ok(self):
        response = self._client.get('/home')

        self.assertEqual(200, response.status_code)

    def test_should_get_home_return_posts(self):
        response = self._client.get('/home')

        bs = BeautifulSoup(response.data, 'html.parser')

        result = len(bs.find_all('article', class_='post'))

        expected = 1

        self.assertEqual(expected, result)

    def test_should_get_about_return_status_code_ok(self):
        response = self._client.get('/about')

        self.assertEqual(200, response.status_code)

    def test_should_get_register_return_status_code_ok(self):
        response = self._client.get('/register')

        self.assertEqual(200, response.status_code)

    def test_should_get_login_return_status_code_ok(self):
        response = self._client.get('/login')

        self.assertEqual(200, response.status_code)
