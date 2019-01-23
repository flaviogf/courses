trabalho_terca = True
trabalho_quinta = False

tv_50 = trabalho_terca and trabalho_quinta
tv_32 = trabalho_terca != trabalho_quinta
sorvete = trabalho_terca or trabalho_quinta
mais_saudavel = not sorvete

print(
    f'Tv50={tv_50}, Tv32={tv_32}, Sorvete={sorvete}, Mais Saudavel={mais_saudavel}'
)
