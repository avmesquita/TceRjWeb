using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCE.RJ.Entity
{
	/// <summary>
	/// Tabela de Livros
	/// </summary>
	[Table("TB_LIVRO")]
	public class Book
	{
		/// <summary>
		/// PK
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("COD_LIVRO")]
		[Display(Name = "Código", AutoGenerateField = true, Description = "Código do Livro")]
		public virtual Int64 Id { get; set; } = 0;

		/// <summary>
		/// ISBN
		/// </summary>
		[Index("UK_ISBN", IsUnique = true)]
		[Column("TXT_ISBN")]
		[MaxLength(13)]
		[MinLength(13)]
		[Display(Name = "ISBN", Description = "Código ISBN")]
		[Required]				
		public virtual string ISBN { get; set; } = string.Empty;

		/// <summary>
		/// Autor
		/// </summary>
		[Column("TXT_AUTOR")]
		[MaxLength(256)]
		[Display(Name = "Autor", Description = "Nome do Autor")]
		public virtual string Autor { get; set; } = string.Empty;

		/// <summary>
		/// Nome
		/// </summary>
		[Column("TXT_NOME")]
		[MaxLength(256)]
		[Required]
		[Display(Name = "Título", Description = "Nome do Livro")]
		public virtual string Nome { get; set; } = string.Empty;

		/// <summary>
		/// Preço
		/// </summary>
		[Column("VAL_PRECO")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C}")]
		[Display(Name = "Preço", Description = "Valor de Venda")]
		public virtual decimal Preco { get; set; } = decimal.Zero;

		/// <summary>
		/// Data de Publicação
		/// </summary>
		[Column("DAT_PUBLICACAO")]
		[DataType(DataType.Date)]
		[Display(Name = "Publicação", Description = "Data de Publicação")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public virtual DateTime DataPublicacao { get; set; } = DateTime.Now;

		/// <summary>
		/// Capa do Livro
		/// </summary>
		[Column("BIN_CAPA"), DataType(DataType.Upload)]
		[Display(Name = "Capa do Livro", Description = "Imagem da Capa do Livro")]
		public virtual string Capa { get; set; }
	}
}
