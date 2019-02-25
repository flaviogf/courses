from unittest import TestCase

from evolucao import HomoSapien


class TestHomoSapiens(TestCase):
    def test_init(self):
        homo_sapiens = HomoSapien('fernando')

        self.assertEqual('fernando', homo_sapiens.nome)
        self.assertEqual(0, homo_sapiens.idade)

    def test_idade(self):
        homo_sapiens = HomoSapien('fernando')

        homo_sapiens.idade = 25

        self.assertEqual('fernando', homo_sapiens.nome)
        self.assertEqual(25, homo_sapiens.idade)

    def test_especies(self):
        especies = ('Australopiteco', 'HomoHabilis', 'HomoErectus',
                    'HomoNeanderthalensis', 'HomoSapiens')

        self.assertTupleEqual(especies, HomoSapien.especies())

    def test_especie(self):
        self.assertEqual('HomoSapiens', HomoSapien.especie)

    def test_evoluido(self):
        self.assertTrue(HomoSapien.evoluido())

    def test_inteligente(self):
        self.assertTrue(HomoSapien.inteligente())
