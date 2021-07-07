using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroProduto.Dal
{
    public class DAL : IDAL
    {
        protected readonly DataBaseContext dbContext;
        public DAL(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        //MÉTODOS GENÉRICOS
        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
            dbContext.Add(entidadeDominio);
            dbContext.SaveChanges();
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            
            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("acessorio"):
                    if (!dbContext.Acessorio.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                case ("usuario"):
                    if (!dbContext.Usuario.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                case ("cliente"):
                    if (!dbContext.Cliente.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                case ("produto"):
                    if (!dbContext.Produto.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                case ("linha"):
                    if (!dbContext.Linha.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                case ("fichatecnica"):
                    if (!dbContext.FichaTecnica.Any(x => x.Id == entidadeDominio.Id))
                    {
                        throw new ApplicationException("Objeto não encontrado");
                    }
                    try
                    {
                        dbContext.Update(entidadeDominio);
                        dbContext.SaveChanges();
                    }
                    catch (ApplicationException e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                    break;

                default:
                    break;
            }
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            dbContext.Remove(entidadeDominio);
            dbContext.SaveChanges();
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();

            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("acessorio"):                   
                    foreach (EntidadeDominio x in dbContext.Acessorio.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;
                    
                case ("usuario"):                   
                    foreach (EntidadeDominio x in dbContext.Usuario.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;   

                case ("cliente"):                   
                    foreach (EntidadeDominio x in dbContext.Cliente.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;  
                case ("produto"):                   
                    foreach (EntidadeDominio x in dbContext.Produto.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado; 
                case ("linha"):                   
                    foreach (EntidadeDominio x in dbContext.Linha.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;    
                case ("fichatecnica"):                   
                    foreach (EntidadeDominio x in dbContext.FichaTecnica.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;
                default: 
                    return null;
            }           
        }

        public EntidadeDominio ConsultarId(EntidadeDominio entidadeDominio)
        {
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                 return dbContext.Acessorio
                    .Include(x => x.Linha)
                    .FirstOrDefault(x => x.Id == entidadeDominio.Id);                              
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {
                return dbContext.Cliente
               .Include(x => x.Endereco)
               .Include(x => x.Endereco.Cidade)
               .Include(x => x.Endereco.Cidade.Estado)
               .FirstOrDefault(x => x.Id == entidadeDominio.Id);
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                return dbContext.FichaTecnica
                .Include(x => x.Componente)
                .Include(x => x.Categoria)
                .Include(x => x.Categoria.SubCategoria)
                .FirstOrDefault(x => x.Id == entidadeDominio.Id);
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                Linha linha = dbContext.Linha
                .Include(obj => obj.FichaTecnicaLinha)
                .Include(obj => obj.Acessorio)
                .FirstOrDefault(x => x.Id == entidadeDominio.Id);

                if (linha != null)
                {
                    var acessorios = dbContext.Acessorio.Where(x => x.LinhaId == entidadeDominio.Id).ToList();

                    Linha linhaAcessorio = new Linha { Id = linha.Id, Codigo = linha.Codigo, Nome = linha.Nome, FichaTecnicaLinha = linha.FichaTecnicaLinha, Acessorios = acessorios };
                    return linhaAcessorio;
                }
                else return null;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                try
                {
                    Produto produto = dbContext.Produto
                        .Include(obj => obj.Cliente)
                        .Include(obj => obj.Cliente.Endereco)
                        .Include(obj => obj.Cliente.Endereco.Cidade)
                        .Include(obj => obj.Cliente.Endereco.Cidade.Estado)
                        .Include(obj => obj.FichaTecnica)
                        .Include(obj => obj.FichaTecnica.Componente)
                        .Include(obj => obj.FichaTecnica.Categoria)
                        .Include(obj => obj.FichaTecnica.Categoria.SubCategoria)
                        .Include(obj => obj.Linha)
                        .FirstOrDefault(x => x.Id == entidadeDominio.Id);

                    if (produto != null)
                    {
                        Linha linha = (Linha)ConsultarId(new Linha() { Id = entidadeDominio.Id });
                        produto.Linha = linha;
                        return produto;
                    }
                    else return null;                   
                }
                catch (ApplicationException e)
                {
                    throw new ApplicationException(e.Message);
                }
            }

            if (entidadeDominio.GetType().Name.Equals("usuario"))
            {
                return dbContext.Usuario.FirstOrDefault(x => x.Id == entidadeDominio.Id);
            }

            return null;          
        }

        //*********MÉTODOS ESPECIALISTA****************         
        public Linha ConsultarRemoverLinha(int id)
        {
            return dbContext.Linha.FirstOrDefault(x => x.Id == id);
        }

        public Usuario ConsultarEmail(String email)
        {
            return dbContext.Usuario.FirstOrDefault(x => x.Email == email);
        }

        public bool Login(Usuario usuario)
        {            
            Usuario usuarioBanco = dbContext.Usuario.FirstOrDefault(x => x.Email == usuario.Email);
            if (usuarioBanco != null)
            {                
                if (usuario.Senha.Equals(usuarioBanco.Senha)) return true;                
            }
            return false;
        }

        public ICollection<Produto> ConsultarFiltroProdutos(Produto produto)
        {
            HashSet<Produto> consulta = new HashSet<Produto>();

            if (produto.Codigo != null)
            {               
                var resultado = dbContext.Produto.Where(x => x.Codigo == produto.Codigo).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.Nome != null)
            {
                var resultado = dbContext.Produto.Where(x => x.Nome == produto.Nome).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.Valor >= 0.0)
            {
                var resultado = dbContext.Produto.Where(x => x.Valor == produto.Valor).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.DataEntrada != null)
            {
                var resultado = dbContext.Produto.Where(x => x.DataEntrada == produto.DataEntrada).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.Quantidade >= 0)
            {
                var resultado = dbContext.Produto.Where(x => x.Quantidade == produto.Quantidade).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.Status)
            {
                var resultado = dbContext.Produto.Where(x => x.Status == true).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (!produto.Status)
            {
                var resultado = dbContext.Produto.Where(x => x.Status == false).ToList();
                foreach (Produto item in resultado)
                {
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.FichaTecnica.Nome != null)
            {
                var resultado = dbContext.FichaTecnica.Where(x => x.Nome == produto.FichaTecnica.Nome).ToList();
                foreach (FichaTecnica item in resultado)
                {
                    Produto idProdutoFicha = dbContext.Produto.Where(x => x.FichaTecnica.Id == item.Id).FirstOrDefault();
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            if (produto.Cliente.Nome != null)
            {
                var resultado = dbContext.Cliente.Where(x => x.Nome == produto.Cliente.Nome).ToList();
                foreach (Cliente item in resultado)
                {
                    Produto idProdutoCliente = dbContext.Produto.Where(x => x.Cliente.Id == item.Id).FirstOrDefault();
                    Produto retornoProduto = (Produto)ConsultarId(produto);
                    consulta.Add(retornoProduto);
                }
            }

            return consulta;
        }       
    }
}
