from unittest import TestCase

from desafio_mdc import mdc_v1, mdc_v2


class TestMdc(TestCase):
    def test_caculo_mdc_dos_numeros_21_e_7(self):
        self.assertEqual(7, mdc_v1(21, 7))
        self.assertEqual(7, mdc_v2(21, 7))

    def test_caculo_mdc_dos_numeros_125_e_40(self):
        self.assertEqual(5, mdc_v1(125, 40))
        self.assertEqual(5, mdc_v2(125, 40))

    def test_caculo_mdc_dos_numeros_9_564_66_3(self):
        self.assertEqual(3, mdc_v1(9, 564, 66, 3))
        self.assertEqual(3, mdc_v2(9, 564, 66, 3))
