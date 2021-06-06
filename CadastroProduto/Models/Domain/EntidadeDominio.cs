namespace CadastroProduto.Models.Domain
{
    public abstract class EntidadeDominio
    {
        public int Id { get; set; }
        public EntidadeDominio(int id) { Id = id;}      

        public EntidadeDominio() { }
    }
}
