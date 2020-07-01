﻿using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class ProdutoDAL : IDAL
    {
        private readonly DataBaseContext dbContext;
        public ProdutoDAL(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
            
            dbContext.Add(entidadeDominio);
            dbContext.SaveChanges();
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            if (!dbContext.Produto.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new NotFoundException("Produto não encontrado");
            }

            try
            {
                dbContext.Update(entidadeDominio);
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbException(e.Message);
            }
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            dbContext.Remove(entidadeDominio);
            dbContext.SaveChanges();
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            var list = dbContext.Produto.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Produto ConsultarId(int id)
        {
           
            var produto = dbContext.Produto
                .Include(obj => obj.Cliente)
                .Include(obj => obj.Cliente.Endereco)
                .Include(obj => obj.Cliente.Endereco.Cidade)
                .Include(obj => obj.Cliente.Endereco.Cidade.Estado)
                .Include(obj => obj.FichaTecnica)
                .Include(obj => obj.FichaTecnica.Componente)
                .Include(obj => obj.FichaTecnica.Categoria)
                .Include(obj => obj.FichaTecnica.Categoria.SubCategoria)
                .Include(obj => obj.Linha)                             
                .FirstOrDefault(x => x.Id == id);

            LinhaDAL dal = new LinhaDAL(dbContext);
            var linha = dal.ConsultarPorId(produto.Linha.Id);
            produto.Linha = linha;   
            
            return produto;
        }
    }
}
