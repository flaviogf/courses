import tkinter as tk


class Todo(tk.Tk):

    def __init__(self):
        super().__init__()

        self.tarefas = []
        self.paleta_cores = [{"bg": "lightgrey", "fg": "black"}, {"bg": "grey", "fg": "white"}]

        self.title("To-Do App V1")
        self.geometry("300x400")

        tarefa1 = tk.Label(self, text="Adicione um tarefa", bg="lightgrey", fg="black", pady=10)

        self.tarefas.append(tarefa1)

        for tarefa in self.tarefas:
            tarefa.pack(side=tk.TOP, fill=tk.X)

        self.criar_tarefa = tk.Text(self, height=3, bg="white", fg="black")
        self.criar_tarefa.pack(side=tk.BOTTOM, fill=tk.X)

        self.bind("<Return>", self.adiciona_tarefa)

    def adiciona_tarefa(self, event=None):
        tarefa = self.criar_tarefa.get(1.0, tk.END).split()

        if len(tarefa) > 0:
            nova_tarefa = tk.Label(self, text=tarefa, pady=10)
            paleta_cor = self.paleta_cores[0] if len(self.tarefas) % 2 == 0 else self.paleta_cores[1]
            nova_tarefa.configure(bg=paleta_cor['bg'], fg=paleta_cor['fg'])
            nova_tarefa.pack(side=tk.TOP, fill=tk.X)
            self.tarefas.append(tarefa)
            self.criar_tarefa.delete(1.0, tk.END)


if __name__ == '__main__':
    root = Todo()
    root.mainloop()
