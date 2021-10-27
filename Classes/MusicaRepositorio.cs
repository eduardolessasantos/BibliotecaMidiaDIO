using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class MusicaRepositorio : IRepositorio<Musica>
    {
        private List<Musica> listaMusica = new List<Musica>();
        public void Atualiza(int id, Musica objeto)
		{
			listaMusica[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaMusica[id].Excluir();
		}

		public void Insere(Musica objeto)
		{
			listaMusica.Add(objeto);
		}

		public List<Musica> Lista()
		{
			return listaMusica;
		}

		public int ProximoId()
		{
			return listaMusica.Count;
		}

		public Musica RetornaPorId(int id)
		{
			return listaMusica[id];
		}
    }
}