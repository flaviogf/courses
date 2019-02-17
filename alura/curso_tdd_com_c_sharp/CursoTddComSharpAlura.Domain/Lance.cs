namespace CursoTddComCSharpAlura.Domain
{
    public class Lance
    {
        public Usuario Usuario { get; }

        public decimal Valor { get; }

        public Lance(Usuario usuario, decimal valor)
        {
            Usuario = usuario;
            Valor = valor;
        }
    }
}
