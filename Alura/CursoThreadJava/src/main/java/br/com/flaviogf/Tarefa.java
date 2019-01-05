package br.com.flaviogf;

import static java.lang.System.out;
import static java.lang.Thread.sleep;

import java.util.Arrays;

public class Tarefa {

    public void tarefaNumero1() {
        String nome = Thread.currentThread().getName();
        out.println(nome + " tentou iniciar tarefa");
        synchronized (this) {
            out.println(nome + " iniciou tarefa 1");
            try {
                sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            out.println(nome + " fez tarefa numero 1");
            out.println(nome + " finalizou tarefa 1");
        }
    }

    public void tarefaNumero2() {
        String nome = Thread.currentThread().getName();
        out.println(nome + " tentou iniciar tarefa");
        synchronized (this) {
            out.println(nome + " iniciou tarefa 2");
            try {
                sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            out.println(nome + " fez tarefa numero 2");
            out.println(nome + " finalizou tarefa 2");
        }
    }

    public static void main(String[] args) {
        Tarefa tarefa = new Tarefa();

        Arrays.asList(new Thread(() -> {
            tarefa.tarefaNumero1();
        }, "1"), new Thread(() -> {
            tarefa.tarefaNumero2();
        }, "2"), new Thread(() -> {
            tarefa.tarefaNumero1();
        }, "3")).forEach(Thread::start);
    }
}
