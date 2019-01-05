package br.com.flaviogf;

class Lista<T> {

    private Object[] lista = new Object[10000];

    private int indice = -1;

    public synchronized void adiciona(T item) {
        lista[++indice] = item;
    }

    @SuppressWarnings("unchecked")
    public T getItem(int i) {
        return (T) lista[i];
    }
}

public class ThreadManipulacaoLista {

    public static void main(String[] args) throws InterruptedException {
        Lista<String> nomes = new Lista<>();

        for (int i = 0; i < 100; i++) {
            new Thread(() -> {
                for (int j = 0; j < 100; j++) {
                    nomes.adiciona(Integer.toString(j) + " - " + Thread.currentThread().getName());
                }
            }).start();
        }

        Thread.sleep(2000);

        for (int i = 0; i < 1000; i++) {
            System.out.println(Integer.toString(i) + " - " + nomes.getItem(i));
        }
    }
}
